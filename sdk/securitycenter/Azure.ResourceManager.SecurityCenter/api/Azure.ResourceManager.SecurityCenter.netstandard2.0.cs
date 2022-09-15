namespace Azure.ResourceManager.SecurityCenter
{
    public partial class AdaptiveApplicationControlGroupCollection : Azure.ResourceManager.ArmCollection
    {
        protected AdaptiveApplicationControlGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AdaptiveApplicationControlGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public AdaptiveApplicationControlGroupData() { }
        public Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus? ConfigurationStatus { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.EnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary> Issues { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation> PathRecommendations { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.ProtectionMode ProtectionMode { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus? RecommendationStatus { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SourceSystem? SourceSystem { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation> VmRecommendations { get { throw null; } }
    }
    public partial class AdaptiveApplicationControlGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdaptiveApplicationControlGroupResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ascLocation, string groupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AdaptiveNetworkHardeningCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>, System.Collections.IEnumerable
    {
        protected AdaptiveNetworkHardeningCollection() { }
        public virtual Azure.Response<bool> Exists(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> Get(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdaptiveNetworkHardeningData : Azure.ResourceManager.Models.ResourceData
    {
        public AdaptiveNetworkHardeningData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups> EffectiveNetworkSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.Rule> Rules { get { throw null; } }
        public System.DateTimeOffset? RulesCalculationOn { get { throw null; } set { } }
    }
    public partial class AdaptiveNetworkHardeningResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdaptiveNetworkHardeningResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Enforce(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnforceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AdvancedThreatProtectionSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public AdvancedThreatProtectionSettingData() { }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class AdvancedThreatProtectionSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvancedThreatProtectionSettingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AdvancedThreatProtectionSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdvancedThreatProtectionSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AdvancedThreatProtectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdvancedThreatProtectionSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AdvancedThreatProtectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdvancedThreatProtectionSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdvancedThreatProtectionSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertData : Azure.ResourceManager.Models.ResourceData
    {
        public AlertData() { }
        public string AlertDisplayName { get { throw null; } }
        public string AlertType { get { throw null; } }
        public System.Uri AlertUri { get { throw null; } }
        public string CompromisedEntity { get { throw null; } }
        public string CorrelationKey { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.AlertEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, string>> ExtendedLinks { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.Intent? Intent { get { throw null; } }
        public bool? IsIncident { get { throw null; } }
        public System.DateTimeOffset? ProcessingEndTimeUtc { get { throw null; } }
        public string ProductComponentName { get { throw null; } }
        public string ProductName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RemediationSteps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.AlertResourceIdentifier> ResourceIdentifiers { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.AlertSeverity? Severity { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.AlertStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubTechniques { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.AlertPropertiesSupportingEvidence SupportingEvidence { get { throw null; } set { } }
        public string SystemAlertId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Techniques { get { throw null; } }
        public System.DateTimeOffset? TimeGeneratedUtc { get { throw null; } }
        public string VendorName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class AlertsSuppressionRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource>, System.Collections.IEnumerable
    {
        protected AlertsSuppressionRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertsSuppressionRuleName, Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertsSuppressionRuleName, Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource> Get(string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource> GetAll(string alertType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource> GetAllAsync(string alertType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource>> GetAsync(string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertsSuppressionRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public AlertsSuppressionRuleData() { }
        public string AlertType { get { throw null; } set { } }
        public string Comment { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationDateUtc { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public string Reason { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RuleState? State { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.ScopeElement> SuppressionAlertsScopeAllOf { get { throw null; } set { } }
    }
    public partial class AlertsSuppressionRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertsSuppressionRuleResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string alertsSuppressionRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AllowedConnectionsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AllowedConnectionsResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AllowedConnectionsResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ascLocation, Azure.ResourceManager.SecurityCenter.Models.ConnectionType connectionType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AllowedConnectionsResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected AllowedConnectionsResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string ascLocation, Azure.ResourceManager.SecurityCenter.Models.ConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ascLocation, Azure.ResourceManager.SecurityCenter.Models.ConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource> Get(string ascLocation, Azure.ResourceManager.SecurityCenter.Models.ConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource>> GetAsync(string ascLocation, Azure.ResourceManager.SecurityCenter.Models.ConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AllowedConnectionsResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AllowedConnectionsResourceData() { }
        public System.DateTimeOffset? CalculatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.ConnectableResource> ConnectableResources { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    public partial class ApplicationData : Azure.ResourceManager.Models.ResourceData
    {
        public ApplicationData() { }
        public System.Collections.Generic.IList<System.BinaryData> ConditionSets { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType? SourceResourceType { get { throw null; } set { } }
    }
    public partial class AscLocationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationResource>, System.Collections.IEnumerable
    {
        protected AscLocationCollection() { }
        public virtual Azure.Response<bool> Exists(string ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationResource> Get(string ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AscLocationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AscLocationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationResource>> GetAsync(string ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AscLocationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AscLocationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AscLocationData : Azure.ResourceManager.Models.ResourceData
    {
        public AscLocationData() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class AscLocationLocationAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource>, System.Collections.IEnumerable
    {
        protected AscLocationLocationAlertCollection() { }
        public virtual Azure.Response<bool> Exists(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource> Get(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource>> GetAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AscLocationLocationAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AscLocationLocationAlertResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ascLocation, string alertName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSubscriptionLevelStateToActivate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSubscriptionLevelStateToActivateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSubscriptionLevelStateToDismiss(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSubscriptionLevelStateToDismissAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSubscriptionLevelStateToInProgress(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSubscriptionLevelStateToInProgressAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSubscriptionLevelStateToResolve(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSubscriptionLevelStateToResolveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AscLocationLocationTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource>, System.Collections.IEnumerable
    {
        protected AscLocationLocationTaskCollection() { }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AscLocationLocationTaskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AscLocationLocationTaskResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ascLocation, string taskName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AscLocationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AscLocationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AscLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ascLocation) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAdaptiveApplicationControlGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupCollection GetAdaptiveApplicationControlGroups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource> GetAllowedConnectionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource> GetAllowedConnectionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource> GetAscLocationLocationAlert(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource>> GetAscLocationLocationAlertAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertCollection GetAscLocationLocationAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource> GetAscLocationLocationTask(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource>> GetAscLocationLocationTaskAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskCollection GetAscLocationLocationTasks() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource> GetDiscoveredSecuritySolutionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource> GetDiscoveredSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource> GetExternalSecuritySolutionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource> GetExternalSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.TopologyResource> GetTopologiesByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.TopologyResource> GetTopologiesByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SimulateAlert(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.AlertSimulatorRequestBody alertSimulatorRequestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SimulateAlertAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.AlertSimulatorRequestBody alertSimulatorRequestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AutomationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AutomationResource>, System.Collections.IEnumerable
    {
        protected AutomationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AutomationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string automationName, Azure.ResourceManager.SecurityCenter.AutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AutomationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string automationName, Azure.ResourceManager.SecurityCenter.AutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource> Get(string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AutomationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AutomationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource>> GetAsync(string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AutomationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AutomationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AutomationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AutomationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AutomationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.AutomationAction> Actions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.AutomationScope> Scopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.AutomationSource> Sources { get { throw null; } }
    }
    public partial class AutomationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AutomationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AutomationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AutomationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.Models.AutomationValidationStatus> Validate(Azure.ResourceManager.SecurityCenter.AutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.AutomationValidationStatus>> ValidateAsync(Azure.ResourceManager.SecurityCenter.AutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutoProvisioningSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>, System.Collections.IEnumerable
    {
        protected AutoProvisioningSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string settingName, Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string settingName, Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> Get(string settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>> GetAsync(string settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutoProvisioningSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public AutoProvisioningSettingData() { }
        public Azure.ResourceManager.SecurityCenter.Models.AutoProvision? AutoProvision { get { throw null; } set { } }
    }
    public partial class AutoProvisioningSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutoProvisioningSettingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string settingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComplianceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ComplianceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ComplianceResource>, System.Collections.IEnumerable
    {
        protected ComplianceCollection() { }
        public virtual Azure.Response<bool> Exists(string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResource> Get(string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ComplianceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ComplianceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResource>> GetAsync(string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.ComplianceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ComplianceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.ComplianceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ComplianceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComplianceData : Azure.ResourceManager.Models.ResourceData
    {
        public ComplianceData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.ComplianceSegment> AssessmentResult { get { throw null; } }
        public System.DateTimeOffset? AssessmentTimestampUtcOn { get { throw null; } }
        public int? ResourceCount { get { throw null; } }
    }
    public partial class ComplianceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComplianceResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.ComplianceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string complianceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComplianceResultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ComplianceResultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ComplianceResultResource>, System.Collections.IEnumerable
    {
        protected ComplianceResultCollection() { }
        public virtual Azure.Response<bool> Exists(string complianceResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string complianceResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResultResource> Get(string complianceResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ComplianceResultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ComplianceResultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResultResource>> GetAsync(string complianceResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.ComplianceResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ComplianceResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.ComplianceResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ComplianceResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComplianceResultData : Azure.ResourceManager.Models.ResourceData
    {
        public ComplianceResultData() { }
        public Azure.ResourceManager.SecurityCenter.Models.ResourceStatus? ResourceStatus { get { throw null; } }
    }
    public partial class ComplianceResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComplianceResultResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.ComplianceResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string complianceResultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConnectorSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource>, System.Collections.IEnumerable
    {
        protected ConnectorSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.ConnectorSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.ConnectorSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectorSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public ConnectorSettingData() { }
        public Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties AuthenticationDetails { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties HybridComputeSettings { get { throw null; } set { } }
    }
    public partial class ConnectorSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectorSettingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.ConnectorSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.ConnectorSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.ConnectorSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CustomAssessmentAutomationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>, System.Collections.IEnumerable
    {
        protected CustomAssessmentAutomationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customAssessmentAutomationName, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customAssessmentAutomationName, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> Get(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetAsync(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomAssessmentAutomationData : Azure.ResourceManager.Models.ResourceData
    {
        public CustomAssessmentAutomationData() { }
        public string AssessmentKey { get { throw null; } set { } }
        public string CompressedQuery { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string RemediationDescription { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SeverityEnum? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum? SupportedCloud { get { throw null; } set { } }
    }
    public partial class CustomAssessmentAutomationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomAssessmentAutomationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string customAssessmentAutomationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CustomEntityStoreAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>, System.Collections.IEnumerable
    {
        protected CustomEntityStoreAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customEntityStoreAssignmentName, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customEntityStoreAssignmentName, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> Get(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetAsync(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomEntityStoreAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public CustomEntityStoreAssignmentData() { }
        public string EntityStoreDatabaseLink { get { throw null; } set { } }
        public string Principal { get { throw null; } set { } }
    }
    public partial class CustomEntityStoreAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomEntityStoreAssignmentResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string customEntityStoreAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceSecurityGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource>, System.Collections.IEnumerable
    {
        protected DeviceSecurityGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deviceSecurityGroupName, Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deviceSecurityGroupName, Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deviceSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deviceSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource> Get(string deviceSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource>> GetAsync(string deviceSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceSecurityGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public DeviceSecurityGroupData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule> AllowlistRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.DenylistCustomAlertRule> DenylistRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.ThresholdCustomAlertRule> ThresholdRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule> TimeWindowRules { get { throw null; } }
    }
    public partial class DeviceSecurityGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceSecurityGroupResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string deviceSecurityGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveredSecuritySolutionCollection : Azure.ResourceManager.ArmCollection
    {
        protected DiscoveredSecuritySolutionCollection() { }
        public virtual Azure.Response<bool> Exists(string ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource> Get(string ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource>> GetAsync(string ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveredSecuritySolutionData : Azure.ResourceManager.Models.ResourceData
    {
        public DiscoveredSecuritySolutionData(Azure.ResourceManager.SecurityCenter.Models.SecurityFamily securityFamily, string offer, string publisher, string sku) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityFamily SecurityFamily { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
    }
    public partial class DiscoveredSecuritySolutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveredSecuritySolutionResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ascLocation, string discoveredSecuritySolutionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExternalSecuritySolutionCollection : Azure.ResourceManager.ArmCollection
    {
        protected ExternalSecuritySolutionCollection() { }
        public virtual Azure.Response<bool> Exists(string ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource> Get(string ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource>> GetAsync(string ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExternalSecuritySolutionData : Azure.ResourceManager.Models.ResourceData
    {
        public ExternalSecuritySolutionData() { }
        public Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType? Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    public partial class ExternalSecuritySolutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExternalSecuritySolutionResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ascLocation, string externalSecuritySolutionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GovernanceAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>, System.Collections.IEnumerable
    {
        protected GovernanceAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assignmentKey, Azure.ResourceManager.SecurityCenter.GovernanceAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assignmentKey, Azure.ResourceManager.SecurityCenter.GovernanceAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assignmentKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assignmentKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> Get(string assignmentKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>> GetAsync(string assignmentKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GovernanceAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public GovernanceAssignmentData() { }
        public Azure.ResourceManager.SecurityCenter.Models.GovernanceAssignmentAdditionalData AdditionalData { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.GovernanceEmailNotification GovernanceEmailNotification { get { throw null; } set { } }
        public bool? IsGracePeriod { get { throw null; } set { } }
        public string Owner { get { throw null; } set { } }
        public System.DateTimeOffset? RemediationDueOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RemediationEta RemediationEta { get { throw null; } set { } }
    }
    public partial class GovernanceAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GovernanceAssignmentResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string assessmentName, string assignmentKey) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GovernanceRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public GovernanceRuleData() { }
        public System.Collections.Generic.IList<System.BinaryData> ConditionSets { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleEmailNotification GovernanceEmailNotification { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } set { } }
        public bool? IsGracePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSource OwnerSource { get { throw null; } set { } }
        public string RemediationTimeframe { get { throw null; } set { } }
        public int? RulePriority { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType? RuleType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleSourceResourceType? SourceResourceType { get { throw null; } set { } }
    }
    public partial class IngestionSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>, System.Collections.IEnumerable
    {
        protected IngestionSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ingestionSettingName, Azure.ResourceManager.SecurityCenter.IngestionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ingestionSettingName, Azure.ResourceManager.SecurityCenter.IngestionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> Get(string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>> GetAsync(string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IngestionSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public IngestionSettingData() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class IngestionSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IngestionSettingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.IngestionSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ingestionSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.IngestionConnectionString> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.IngestionConnectionString> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.Models.IngestionSettingToken> GetTokens(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.IngestionSettingToken>> GetTokensAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.IngestionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.IngestionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotSecurityAggregatedAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource>, System.Collections.IEnumerable
    {
        protected IotSecurityAggregatedAlertCollection() { }
        public virtual Azure.Response<bool> Exists(string aggregatedAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aggregatedAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource> Get(string aggregatedAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource>> GetAsync(string aggregatedAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotSecurityAggregatedAlertData : Azure.ResourceManager.Models.ResourceData
    {
        public IotSecurityAggregatedAlertData() { }
        public string ActionTaken { get { throw null; } }
        public System.DateTimeOffset? AggregatedDateUtc { get { throw null; } }
        public string AlertDisplayName { get { throw null; } }
        public string AlertType { get { throw null; } }
        public long? Count { get { throw null; } }
        public string Description { get { throw null; } }
        public string EffectedResourceType { get { throw null; } }
        public string LogAnalyticsQuery { get { throw null; } }
        public string RemediationSteps { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity? ReportedSeverity { get { throw null; } }
        public string SystemSource { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.IotSecurityAggregatedAlertPropertiesTopDevicesListItem> TopDevicesList { get { throw null; } }
        public string VendorName { get { throw null; } }
    }
    public partial class IotSecurityAggregatedAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotSecurityAggregatedAlertResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionName, string aggregatedAlertName) { throw null; }
        public virtual Azure.Response Dismiss(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DismissAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotSecurityAggregatedRecommendationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource>, System.Collections.IEnumerable
    {
        protected IotSecurityAggregatedRecommendationCollection() { }
        public virtual Azure.Response<bool> Exists(string aggregatedRecommendationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aggregatedRecommendationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource> Get(string aggregatedRecommendationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource>> GetAsync(string aggregatedRecommendationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotSecurityAggregatedRecommendationData : Azure.ResourceManager.Models.ResourceData
    {
        public IotSecurityAggregatedRecommendationData() { }
        public string Description { get { throw null; } }
        public string DetectedBy { get { throw null; } }
        public long? HealthyDevices { get { throw null; } }
        public string LogAnalyticsQuery { get { throw null; } }
        public string RecommendationDisplayName { get { throw null; } }
        public string RecommendationName { get { throw null; } set { } }
        public string RecommendationTypeId { get { throw null; } }
        public string RemediationSteps { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity? ReportedSeverity { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public long? UnhealthyDeviceCount { get { throw null; } }
    }
    public partial class IotSecurityAggregatedRecommendationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotSecurityAggregatedRecommendationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionName, string aggregatedRecommendationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotSecuritySolutionAnalyticsModelData : Azure.ResourceManager.Models.ResourceData
    {
        public IotSecuritySolutionAnalyticsModelData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionAnalyticsModelPropertiesDevicesMetricsItem> DevicesMetrics { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.IotSeverityMetrics Metrics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.IotSecurityDeviceAlert> MostPrevalentDeviceAlerts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.IotSecurityDeviceRecommendation> MostPrevalentDeviceRecommendations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.IotSecurityAlertedDevice> TopAlertedDevices { get { throw null; } }
        public long? UnhealthyDeviceCount { get { throw null; } }
    }
    public partial class IotSecuritySolutionAnalyticsModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotSecuritySolutionAnalyticsModelResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.IotSecuritySolutionAnalyticsModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionAnalyticsModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionAnalyticsModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource> GetIotSecurityAggregatedAlert(string aggregatedAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource>> GetIotSecurityAggregatedAlertAsync(string aggregatedAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertCollection GetIotSecurityAggregatedAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource> GetIotSecurityAggregatedRecommendation(string aggregatedRecommendationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource>> GetIotSecurityAggregatedRecommendationAsync(string aggregatedRecommendationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationCollection GetIotSecurityAggregatedRecommendations() { throw null; }
    }
    public partial class IotSecuritySolutionModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>, System.Collections.IEnumerable
    {
        protected IotSecuritySolutionModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionName, Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionName, Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> Get(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>> GetAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotSecuritySolutionModelData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IotSecuritySolutionModelData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspacesProperties> AdditionalWorkspaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AutoDiscoveredResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.DataSource> DisabledDataSources { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.ExportData> Export { get { throw null; } }
        public System.Collections.Generic.IList<string> IotHubs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigurationProperties> RecommendationsConfiguration { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus? UnmaskedIPLoggingStatus { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.UserDefinedResourcesProperties UserDefinedResources { get { throw null; } set { } }
        public string Workspace { get { throw null; } set { } }
    }
    public partial class IotSecuritySolutionModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotSecuritySolutionModelResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.IotSecuritySolutionAnalyticsModelResource GetIotSecuritySolutionAnalyticsModel() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> Update(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>> UpdateAsync(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JitNetworkAccessPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>, System.Collections.IEnumerable
    {
        protected JitNetworkAccessPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jitNetworkAccessPolicyName, Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jitNetworkAccessPolicyName, Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jitNetworkAccessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jitNetworkAccessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> Get(string jitNetworkAccessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>> GetAsync(string jitNetworkAccessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JitNetworkAccessPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public JitNetworkAccessPolicyData(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyVirtualMachine> virtualMachines) { }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequest> Requests { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyVirtualMachine> VirtualMachines { get { throw null; } }
    }
    public partial class JitNetworkAccessPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JitNetworkAccessPolicyResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ascLocation, string jitNetworkAccessPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequest> Initiate(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequest>> InitiateAsync(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MdeOnboardingDataData : Azure.ResourceManager.Models.ResourceData
    {
        public MdeOnboardingDataData() { }
        public byte[] OnboardingPackageLinux { get { throw null; } set { } }
        public byte[] OnboardingPackageWindows { get { throw null; } set { } }
    }
    public partial class MdeOnboardingDataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MdeOnboardingDataResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.MdeOnboardingDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.MdeOnboardingDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.MdeOnboardingDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PricingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.PricingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.PricingResource>, System.Collections.IEnumerable
    {
        protected PricingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.PricingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string pricingName, Azure.ResourceManager.SecurityCenter.PricingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.PricingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string pricingName, Azure.ResourceManager.SecurityCenter.PricingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.PricingResource> Get(string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.PricingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.PricingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.PricingResource>> GetAsync(string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.PricingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.PricingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.PricingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.PricingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PricingData : Azure.ResourceManager.Models.ResourceData
    {
        public PricingData() { }
        public bool? Deprecated { get { throw null; } }
        public System.TimeSpan? FreeTrialRemainingTime { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.PricingTier? PricingTier { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> ReplacedBy { get { throw null; } }
        public string SubPlan { get { throw null; } set { } }
    }
    public partial class PricingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PricingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.PricingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string pricingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.PricingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.PricingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.PricingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.PricingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.PricingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.PricingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RegulatoryComplianceAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource>, System.Collections.IEnumerable
    {
        protected RegulatoryComplianceAssessmentCollection() { }
        public virtual Azure.Response<bool> Exists(string regulatoryComplianceAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string regulatoryComplianceAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource> Get(string regulatoryComplianceAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource>> GetAsync(string regulatoryComplianceAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RegulatoryComplianceAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public RegulatoryComplianceAssessmentData() { }
        public string AssessmentDetailsLink { get { throw null; } }
        public string AssessmentType { get { throw null; } }
        public string Description { get { throw null; } }
        public int? FailedResources { get { throw null; } }
        public int? PassedResources { get { throw null; } }
        public int? SkippedResources { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.State? State { get { throw null; } set { } }
        public int? UnsupportedResources { get { throw null; } }
    }
    public partial class RegulatoryComplianceAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RegulatoryComplianceAssessmentResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string regulatoryComplianceStandardName, string regulatoryComplianceControlName, string regulatoryComplianceAssessmentName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RegulatoryComplianceControlCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource>, System.Collections.IEnumerable
    {
        protected RegulatoryComplianceControlCollection() { }
        public virtual Azure.Response<bool> Exists(string regulatoryComplianceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string regulatoryComplianceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource> Get(string regulatoryComplianceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource>> GetAsync(string regulatoryComplianceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RegulatoryComplianceControlData : Azure.ResourceManager.Models.ResourceData
    {
        public RegulatoryComplianceControlData() { }
        public string Description { get { throw null; } }
        public int? FailedAssessments { get { throw null; } }
        public int? PassedAssessments { get { throw null; } }
        public int? SkippedAssessments { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.State? State { get { throw null; } set { } }
    }
    public partial class RegulatoryComplianceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RegulatoryComplianceControlResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string regulatoryComplianceStandardName, string regulatoryComplianceControlName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource> GetRegulatoryComplianceAssessment(string regulatoryComplianceAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource>> GetRegulatoryComplianceAssessmentAsync(string regulatoryComplianceAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentCollection GetRegulatoryComplianceAssessments() { throw null; }
    }
    public partial class RegulatoryComplianceStandardCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource>, System.Collections.IEnumerable
    {
        protected RegulatoryComplianceStandardCollection() { }
        public virtual Azure.Response<bool> Exists(string regulatoryComplianceStandardName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string regulatoryComplianceStandardName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource> Get(string regulatoryComplianceStandardName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource>> GetAsync(string regulatoryComplianceStandardName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RegulatoryComplianceStandardData : Azure.ResourceManager.Models.ResourceData
    {
        public RegulatoryComplianceStandardData() { }
        public int? FailedControls { get { throw null; } }
        public int? PassedControls { get { throw null; } }
        public int? SkippedControls { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.State? State { get { throw null; } set { } }
        public int? UnsupportedControls { get { throw null; } }
    }
    public partial class RegulatoryComplianceStandardResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RegulatoryComplianceStandardResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string regulatoryComplianceStandardName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource> GetRegulatoryComplianceControl(string regulatoryComplianceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource>> GetRegulatoryComplianceControlAsync(string regulatoryComplianceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlCollection GetRegulatoryComplianceControls() { throw null; }
    }
    public partial class ResourceGroupLocationAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource>, System.Collections.IEnumerable
    {
        protected ResourceGroupLocationAlertCollection() { }
        public virtual Azure.Response<bool> Exists(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource> Get(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource>> GetAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupLocationAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupLocationAlertResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ascLocation, string alertName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateResourceGroupLevelStateToActivate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateResourceGroupLevelStateToActivateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateResourceGroupLevelStateToDismiss(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateResourceGroupLevelStateToDismissAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateResourceGroupLevelStateToInProgress(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateResourceGroupLevelStateToInProgressAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateResourceGroupLevelStateToResolve(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateResourceGroupLevelStateToResolveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupLocationTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource>, System.Collections.IEnumerable
    {
        protected ResourceGroupLocationTaskCollection() { }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupLocationTaskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupLocationTaskResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ascLocation, string taskName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RuleResultCollection : Azure.ResourceManager.ArmCollection
    {
        protected RuleResultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.RuleResultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, string workspaceId, Azure.ResourceManager.SecurityCenter.Models.RuleResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.RuleResultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, string workspaceId, Azure.ResourceManager.SecurityCenter.Models.RuleResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RuleResultResource> Get(string ruleId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.RuleResultResource> GetAll(string workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.RuleResultResource> GetAll(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.RuleResultResource> GetAllAsync(string workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.RuleResultResource> GetAllAsync(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RuleResultResource>> GetAsync(string ruleId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RuleResultData : Azure.ResourceManager.Models.ResourceData
    {
        public RuleResultData() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> RuleResults { get { throw null; } }
    }
    public partial class RuleResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RuleResultResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.RuleResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string ruleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.RuleResultResource> Get(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RuleResultResource>> GetAsync(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.RuleResultResource> Update(Azure.WaitUntil waitUntil, string workspaceId, Azure.ResourceManager.SecurityCenter.Models.RuleResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.RuleResultResource>> UpdateAsync(Azure.WaitUntil waitUntil, string workspaceId, Azure.ResourceManager.SecurityCenter.Models.RuleResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScanCollection : Azure.ResourceManager.ArmCollection
    {
        protected ScanCollection() { }
        public virtual Azure.Response<bool> Exists(string scanId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scanId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResource> Get(string scanId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ScanResource> GetAll(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ScanResource> GetAllAsync(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResource>> GetAsync(string scanId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScanData : Azure.ResourceManager.Models.ResourceData
    {
        public ScanData() { }
        public Azure.ResourceManager.SecurityCenter.Models.ScanProperties Properties { get { throw null; } set { } }
    }
    public partial class ScanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScanResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.ScanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string scanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResource> Get(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResource>> GetAsync(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResultResource> GetScanResult(string scanResultId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResultResource>> GetScanResultAsync(string scanResultId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.ScanResultCollection GetScanResults() { throw null; }
    }
    public partial class ScanResultCollection : Azure.ResourceManager.ArmCollection
    {
        protected ScanResultCollection() { }
        public virtual Azure.Response<bool> Exists(string scanResultId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scanResultId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResultResource> Get(string scanResultId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ScanResultResource> GetAll(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ScanResultResource> GetAllAsync(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResultResource>> GetAsync(string scanResultId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScanResultData : Azure.ResourceManager.Models.ResourceData
    {
        public ScanResultData() { }
        public Azure.ResourceManager.SecurityCenter.Models.ScanResultProperties Properties { get { throw null; } set { } }
    }
    public partial class ScanResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScanResultResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.ScanResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string scanId, string scanResultId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResultResource> Get(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResultResource>> GetAsync(string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecureScoreItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource>, System.Collections.IEnumerable
    {
        protected SecureScoreItemCollection() { }
        public virtual Azure.Response<bool> Exists(string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource> Get(string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource>> GetAsync(string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecureScoreItemData : Azure.ResourceManager.Models.ResourceData
    {
        public SecureScoreItemData() { }
        public double? Current { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public int? Max { get { throw null; } }
        public double? Percentage { get { throw null; } }
        public long? Weight { get { throw null; } }
    }
    public partial class SecureScoreItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecureScoreItemResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecureScoreItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string secureScoreName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControlsAsync(Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityAssessmentMetadataResponseData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityAssessmentMetadataResponseData() { }
        public Azure.ResourceManager.SecurityCenter.Models.AssessmentType? AssessmentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.Category> Categories { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort? ImplementationEffort { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataPartnerData PartnerData { get { throw null; } set { } }
        public string PlannedDeprecationDate { get { throw null; } set { } }
        public string PolicyDefinitionId { get { throw null; } }
        public bool? Preview { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataPropertiesResponsePublishDates PublishDates { get { throw null; } set { } }
        public string RemediationDescription { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.Severity? Severity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.Tactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.Technique> Techniques { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.Threat> Threats { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.UserImpact? UserImpact { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentResponseCollection : Azure.ResourceManager.ArmCollection
    {
        protected SecurityAssessmentResponseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, Azure.ResourceManager.SecurityCenter.Models.ExpandEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, Azure.ResourceManager.SecurityCenter.Models.ExpandEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource> Get(string assessmentName, Azure.ResourceManager.SecurityCenter.Models.ExpandEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource>> GetAsync(string assessmentName, Azure.ResourceManager.SecurityCenter.Models.ExpandEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityAssessmentResponseData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityAssessmentResponseData() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalData { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri LinksAzurePortalUri { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataProperties Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartnerData PartnersData { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusResponse Status { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityAssessmentResponseResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource> Get(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource>> GetAsync(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> GetGovernanceAssignment(string assignmentKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>> GetGovernanceAssignmentAsync(string assignmentKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceAssignmentCollection GetGovernanceAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource> GetSecuritySubAssessment(string subAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource>> GetSecuritySubAssessmentAsync(string subAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentCollection GetSecuritySubAssessments() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SecurityCenterExtensions
    {
        public static Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAdaptiveNetworkHardening(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAdaptiveNetworkHardeningAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningCollection GetAdaptiveNetworkHardenings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AdvancedThreatProtectionSettingResource GetAdvancedThreatProtectionSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AdvancedThreatProtectionSettingResource GetAdvancedThreatProtectionSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.AlertData> GetAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AlertData> GetAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.AlertData> GetAlertsByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AlertData> GetAlertsByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource> GetAlertsSuppressionRule(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource>> GetAlertsSuppressionRuleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleResource GetAlertsSuppressionRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AlertsSuppressionRuleCollection GetAlertsSuppressionRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource GetAllowedConnectionsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource> GetAllowedConnectionsResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, Azure.ResourceManager.SecurityCenter.Models.ConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource>> GetAllowedConnectionsResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, Azure.ResourceManager.SecurityCenter.Models.ConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AllowedConnectionsResourceCollection GetAllowedConnectionsResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource> GetAllowedConnectionsResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AllowedConnectionsResource> GetAllowedConnectionsResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataCollection GetAllSubscriptionAssessmentMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataCollection GetAllTenantAssessmentMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationResource> GetAscLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AscLocationResource>> GetAscLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AscLocationLocationAlertResource GetAscLocationLocationAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AscLocationLocationTaskResource GetAscLocationLocationTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AscLocationResource GetAscLocationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AscLocationCollection GetAscLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource> GetAutomation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutomationResource>> GetAutomationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AutomationResource GetAutomationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AutomationCollection GetAutomations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.AutomationResource> GetAutomations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AutomationResource> GetAutomationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> GetAutoProvisioningSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>> GetAutoProvisioningSettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource GetAutoProvisioningSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingCollection GetAutoProvisioningSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResource> GetCompliance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResource>> GetComplianceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ComplianceResource GetComplianceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResultResource> GetComplianceResult(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string complianceResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResultResource>> GetComplianceResultAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string complianceResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ComplianceResultResource GetComplianceResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ComplianceResultCollection GetComplianceResults(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ComplianceCollection GetCompliances(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource> GetConnectorSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ConnectorSettingResource>> GetConnectorSettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ConnectorSettingResource GetConnectorSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ConnectorSettingCollection GetConnectorSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetCustomAssessmentAutomationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationCollection GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetCustomEntityStoreAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentCollection GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource> GetDeviceSecurityGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deviceSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource>> GetDeviceSecurityGroupAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deviceSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupResource GetDeviceSecurityGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.DeviceSecurityGroupCollection GetDeviceSecurityGroups(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource> GetDiscoveredSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource>> GetDiscoveredSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource GetDiscoveredSecuritySolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionCollection GetDiscoveredSecuritySolutions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource> GetDiscoveredSecuritySolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.DiscoveredSecuritySolutionResource> GetDiscoveredSecuritySolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource> GetExternalSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource>> GetExternalSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource GetExternalSecuritySolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionCollection GetExternalSecuritySolutions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource> GetExternalSecuritySolutionsByExternalSecuritySolution(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ExternalSecuritySolutionResource> GetExternalSecuritySolutionsByExternalSecuritySolutionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource GetGovernanceAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> GetIngestionSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>> GetIngestionSettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IngestionSettingResource GetIngestionSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IngestionSettingCollection GetIngestionSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource GetIotSecurityAggregatedAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource GetIotSecurityAggregatedRecommendationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecuritySolutionAnalyticsModelResource GetIotSecuritySolutionAnalyticsModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> GetIotSecuritySolutionModel(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource>> GetIotSecuritySolutionModelAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource GetIotSecuritySolutionModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelCollection GetIotSecuritySolutionModels(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> GetIotSecuritySolutionModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionModelResource> GetIotSecuritySolutionModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyCollection GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string jitNetworkAccessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>> GetJitNetworkAccessPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string jitNetworkAccessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource GetJitNetworkAccessPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.MdeOnboardingDataResource GetMdeOnboardingData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.MdeOnboardingDataResource GetMdeOnboardingDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.PricingResource> GetPricing(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.PricingResource>> GetPricingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.PricingResource GetPricingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.PricingCollection GetPricings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource GetRegulatoryComplianceAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource GetRegulatoryComplianceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource> GetRegulatoryComplianceStandard(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string regulatoryComplianceStandardName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource>> GetRegulatoryComplianceStandardAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string regulatoryComplianceStandardName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource GetRegulatoryComplianceStandardResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardCollection GetRegulatoryComplianceStandards(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource> GetResourceGroupLocationAlert(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource>> GetResourceGroupLocationAlertAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertResource GetResourceGroupLocationAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupLocationAlertCollection GetResourceGroupLocationAlerts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource> GetResourceGroupLocationTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource>> GetResourceGroupLocationTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskResource GetResourceGroupLocationTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupLocationTaskCollection GetResourceGroupLocationTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.RuleResultResource> GetRuleResult(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RuleResultResource>> GetRuleResultAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RuleResultResource GetRuleResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RuleResultCollection GetRuleResults(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResource> GetScan(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ScanResource>> GetScanAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, string workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ScanResource GetScanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ScanResultResource GetScanResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ScanCollection GetScans(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem> GetSecureScoreControlDefinitions(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem> GetSecureScoreControlDefinitionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem> GetSecureScoreControlDefinitionsBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem> GetSecureScoreControlDefinitionsBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControlsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource> GetSecureScoreItem(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreItemResource>> GetSecureScoreItemAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecureScoreItemResource GetSecureScoreItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecureScoreItemCollection GetSecureScoreItems(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource> GetSecurityAssessmentResponse(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.ExpandEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource>> GetSecurityAssessmentResponseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.ExpandEnum? expand = default(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseResource GetSecurityAssessmentResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityAssessmentResponseCollection GetSecurityAssessmentResponses(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> GetSecurityConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string securityConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource GetSecurityConnectorApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>> GetSecurityConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string securityConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource GetSecurityConnectorGovernanceRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityConnectorResource GetSecurityConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityConnectorCollection GetSecurityConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> GetSecurityConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> GetSecurityConnectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> GetSecurityContact(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> GetSecurityContactAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityContactResource GetSecurityContactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityContactCollection GetSecurityContacts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySolutionResource> GetSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySolutionResource>> GetSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecuritySolutionResource GetSecuritySolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecuritySolutionCollection GetSecuritySolutions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecuritySolutionResource> GetSecuritySolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecuritySolutionResource> GetSecuritySolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource GetSecuritySubAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource GetServerVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SettingResource> GetSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SettingResource>> GetSettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SettingResource GetSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SettingCollection GetSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareResource> GetSoftware(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareResource>> GetSoftwareAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SoftwareResource GetSoftwareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SoftwareCollection GetSoftwares(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SoftwareResource> GetSoftwares(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SoftwareResource> GetSoftwaresAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource> GetSubscriptionApplication(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource>> GetSubscriptionApplicationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource GetSubscriptionApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionApplicationCollection GetSubscriptionApplications(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> GetSubscriptionAssessmentMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> GetSubscriptionAssessmentMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource GetSubscriptionAssessmentMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityTaskData> GetTasks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityTaskData> GetTasksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> GetTenantAssessmentMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource, string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>> GetTenantAssessmentMetadataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource GetTenantAssessmentMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.TopologyResource GetTopologyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.TopologyResource> GetTopologyResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.TopologyResource>> GetTopologyResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.TopologyResourceCollection GetTopologyResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.TopologyResource> GetTopologyResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.TopologyResource> GetTopologyResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource> GetWorkspaceSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource>> GetWorkspaceSettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource GetWorkspaceSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.WorkspaceSettingCollection GetWorkspaceSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class SecurityConnectorApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>, System.Collections.IEnumerable
    {
        protected SecurityConnectorApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.SecurityCenter.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.SecurityCenter.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> Get(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> GetAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityConnectorApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityConnectorApplicationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.ApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string securityConnectorName, string applicationId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>, System.Collections.IEnumerable
    {
        protected SecurityConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securityConnectorName, Azure.ResourceManager.SecurityCenter.SecurityConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securityConnectorName, Azure.ResourceManager.SecurityCenter.SecurityConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string securityConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securityConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> Get(string securityConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>> GetAsync(string securityConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityConnectorData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SecurityConnectorData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.SecurityCenter.Models.EnvironmentData EnvironmentData { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.CloudName? EnvironmentName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string HierarchyIdentifier { get { throw null; } set { } }
        public System.DateTimeOffset? HierarchyIdentifierTrialEndOn { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.CloudOffering> Offerings { get { throw null; } }
    }
    public partial class SecurityConnectorGovernanceRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>, System.Collections.IEnumerable
    {
        protected SecurityConnectorGovernanceRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> Get(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> GetAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityConnectorGovernanceRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityConnectorGovernanceRuleResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string securityConnectorName, string ruleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus> GetSecurityConnectorGovernanceRulesExecuteStatu(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>> GetSecurityConnectorGovernanceRulesExecuteStatuAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RuleIdExecuteSingleSecurityConnectorGovernanceRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RuleIdExecuteSingleSecurityConnectorGovernanceRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityConnectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityConnectorResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string securityConnectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> GetSecurityConnectorApplication(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> GetSecurityConnectorApplicationAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationCollection GetSecurityConnectorApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> GetSecurityConnectorGovernanceRule(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> GetSecurityConnectorGovernanceRuleAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleCollection GetSecurityConnectorGovernanceRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource> Update(Azure.ResourceManager.SecurityCenter.SecurityConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorResource>> UpdateAsync(Azure.ResourceManager.SecurityCenter.SecurityConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityContactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityContactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityContactResource>, System.Collections.IEnumerable
    {
        protected SecurityContactCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityContactResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securityContactName, Azure.ResourceManager.SecurityCenter.SecurityContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securityContactName, Azure.ResourceManager.SecurityCenter.SecurityContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> Get(string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityContactResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityContactResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> GetAsync(string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityContactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityContactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityContactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityContactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityContactData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityContactData() { }
        public Azure.ResourceManager.SecurityCenter.Models.AlertNotification? AlertNotifications { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin? AlertsToAdmins { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
    }
    public partial class SecurityContactResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityContactResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityContactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string securityContactName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> Update(Azure.ResourceManager.SecurityCenter.SecurityContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> UpdateAsync(Azure.ResourceManager.SecurityCenter.SecurityContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecuritySolutionCollection : Azure.ResourceManager.ArmCollection
    {
        protected SecuritySolutionCollection() { }
        public virtual Azure.Response<bool> Exists(string ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySolutionResource> Get(string ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySolutionResource>> GetAsync(string ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecuritySolutionData : Azure.ResourceManager.Models.ResourceData
    {
        public SecuritySolutionData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProtectionStatus { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityFamily? SecurityFamily { get { throw null; } set { } }
        public string Template { get { throw null; } set { } }
    }
    public partial class SecuritySolutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecuritySolutionResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecuritySolutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ascLocation, string securitySolutionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecuritySubAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource>, System.Collections.IEnumerable
    {
        protected SecuritySubAssessmentCollection() { }
        public virtual Azure.Response<bool> Exists(string subAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource> Get(string subAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource>> GetAsync(string subAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecuritySubAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public SecuritySubAssessmentData() { }
        public Azure.ResourceManager.SecurityCenter.Models.AdditionalData AdditionalData { get { throw null; } set { } }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string IdPropertiesId { get { throw null; } }
        public string Impact { get { throw null; } }
        public string Remediation { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.ResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatus Status { get { throw null; } set { } }
        public System.DateTimeOffset? TimeGenerated { get { throw null; } }
    }
    public partial class SecuritySubAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecuritySubAssessmentResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string assessmentName, string subAssessmentName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityTaskData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityTaskData() { }
        public System.DateTimeOffset? CreationTimeUtc { get { throw null; } }
        public System.DateTimeOffset? LastStateChangeTimeUtc { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityTaskParameters SecurityTaskParameters { get { throw null; } set { } }
        public string State { get { throw null; } }
        public string SubState { get { throw null; } }
    }
    public partial class ServerVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected ServerVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerVulnerabilityAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerVulnerabilityAssessmentData() { }
        public Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ServerVulnerabilityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerVulnerabilityAssessmentResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceNamespace, string resourceType, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SettingResource>, System.Collections.IEnumerable
    {
        protected SettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SettingName settingName, Azure.ResourceManager.SecurityCenter.SettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SettingName settingName, Azure.ResourceManager.SecurityCenter.SettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.SecurityCenter.Models.SettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.SecurityCenter.Models.SettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SettingResource> Get(Azure.ResourceManager.SecurityCenter.Models.SettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SettingResource>> GetAsync(Azure.ResourceManager.SecurityCenter.Models.SettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SettingData : Azure.ResourceManager.Models.ResourceData
    {
        public SettingData() { }
    }
    public partial class SettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SettingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.ResourceManager.SecurityCenter.Models.SettingName settingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SoftwareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareResource>, System.Collections.IEnumerable
    {
        protected SoftwareCollection() { }
        public virtual Azure.Response<bool> Exists(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareResource> Get(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SoftwareResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SoftwareResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareResource>> GetAsync(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SoftwareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SoftwareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SoftwareData : Azure.ResourceManager.Models.ResourceData
    {
        public SoftwareData() { }
        public string DeviceId { get { throw null; } set { } }
        public string EndOfSupportDate { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus? EndOfSupportStatus { get { throw null; } set { } }
        public string FirstSeenAt { get { throw null; } set { } }
        public int? NumberOfKnownVulnerabilities { get { throw null; } set { } }
        public string OSPlatform { get { throw null; } set { } }
        public string SoftwareName { get { throw null; } set { } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class SoftwareResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SoftwareResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SoftwareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceNamespace, string resourceType, string resourceName, string softwareName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource>, System.Collections.IEnumerable
    {
        protected SubscriptionApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.SecurityCenter.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.SecurityCenter.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource> Get(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource>> GetAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionApplicationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.ApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string applicationId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionAssessmentMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>, System.Collections.IEnumerable
    {
        protected SubscriptionAssessmentMetadataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentMetadataName, Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataResponseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentMetadataName, Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataResponseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> Get(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> GetAsync(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionAssessmentMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionAssessmentMetadataResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string assessmentMetadataName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataResponseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataResponseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionGovernanceRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>, System.Collections.IEnumerable
    {
        protected SubscriptionGovernanceRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Get(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionGovernanceRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionGovernanceRuleResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ruleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus> GetSubscriptionGovernanceRulesExecuteStatu(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>> GetSubscriptionGovernanceRulesExecuteStatuAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RuleIdExecuteSingleSubscription(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RuleIdExecuteSingleSubscriptionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantAssessmentMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>, System.Collections.IEnumerable
    {
        protected TenantAssessmentMetadataCollection() { }
        public virtual Azure.Response<bool> Exists(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> Get(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>> GetAsync(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantAssessmentMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantAssessmentMetadataResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string assessmentMetadataName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopologyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopologyResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.TopologyResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ascLocation, string topologyResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.TopologyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.TopologyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopologyResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected TopologyResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.TopologyResource> Get(string ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.TopologyResource>> GetAsync(string ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopologyResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public TopologyResourceData() { }
        public System.DateTimeOffset? CalculatedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.TopologySingleResource> TopologyResources { get { throw null; } }
    }
    public partial class WorkspaceSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource>, System.Collections.IEnumerable
    {
        protected WorkspaceSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceSettingName, Azure.ResourceManager.SecurityCenter.WorkspaceSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceSettingName, Azure.ResourceManager.SecurityCenter.WorkspaceSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource> Get(string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource>> GetAsync(string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkspaceSettingData() { }
        public string Scope { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class WorkspaceSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceSettingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.WorkspaceSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string workspaceSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource> Update(Azure.ResourceManager.SecurityCenter.WorkspaceSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.WorkspaceSettingResource>> UpdateAsync(Azure.ResourceManager.SecurityCenter.WorkspaceSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class ActiveConnectionsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public ActiveConnectionsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdaptiveApplicationControlIssue : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdaptiveApplicationControlIssue(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue ExecutableViolationsAudited { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue MsiAndScriptViolationsAudited { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue MsiAndScriptViolationsBlocked { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue RulesViolatedManually { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue ViolationsAudited { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue ViolationsBlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdaptiveApplicationControlIssueSummary
    {
        internal AdaptiveApplicationControlIssueSummary() { }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue? Issue { get { throw null; } }
        public float? NumberOfVms { get { throw null; } }
    }
    public partial class AdaptiveNetworkHardeningEnforceContent
    {
        public AdaptiveNetworkHardeningEnforceContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.Rule> rules, System.Collections.Generic.IEnumerable<string> networkSecurityGroups) { }
        public System.Collections.Generic.IList<string> NetworkSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.Rule> Rules { get { throw null; } }
    }
    public abstract partial class AdditionalData
    {
        protected AdditionalData() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalWorkspaceDataType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalWorkspaceDataType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType Alerts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType RawEvents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType left, Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType left, Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdditionalWorkspacesProperties
    {
        public AdditionalWorkspacesProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceDataType> DataTypes { get { throw null; } }
        public string Workspace { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType? WorkspaceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalWorkspaceType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalWorkspaceType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType Sentinel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType left, Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType left, Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertEntity
    {
        internal AlertEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string AlertEntityType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertNotification : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AlertNotification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertNotification(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertNotification Off { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertNotification On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AlertNotification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AlertNotification left, Azure.ResourceManager.SecurityCenter.Models.AlertNotification right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AlertNotification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AlertNotification left, Azure.ResourceManager.SecurityCenter.Models.AlertNotification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertPropertiesSupportingEvidence
    {
        public AlertPropertiesSupportingEvidence() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string AlertPropertiesSupportingEvidenceType { get { throw null; } }
    }
    public abstract partial class AlertResourceIdentifier
    {
        protected AlertResourceIdentifier() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AlertSeverity left, Azure.ResourceManager.SecurityCenter.Models.AlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AlertSeverity left, Azure.ResourceManager.SecurityCenter.Models.AlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertSimulatorBundlesRequestProperties : Azure.ResourceManager.SecurityCenter.Models.AlertSimulatorRequestProperties
    {
        public AlertSimulatorBundlesRequestProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.BundleType> Bundles { get { throw null; } }
    }
    public partial class AlertSimulatorRequestBody
    {
        public AlertSimulatorRequestBody() { }
        public Azure.ResourceManager.SecurityCenter.Models.AlertSimulatorRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class AlertSimulatorRequestProperties
    {
        public AlertSimulatorRequestProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AlertStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertStatus Active { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertStatus Dismissed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertStatus Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AlertStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AlertStatus left, Azure.ResourceManager.SecurityCenter.Models.AlertStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AlertStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AlertStatus left, Azure.ResourceManager.SecurityCenter.Models.AlertStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertsToAdmin : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertsToAdmin(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin Off { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin left, Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin left, Azure.ResourceManager.SecurityCenter.Models.AlertsToAdmin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertSyncSettings : Azure.ResourceManager.SecurityCenter.SettingData
    {
        public AlertSyncSettings() { }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class AllowlistCustomAlertRule : Azure.ResourceManager.SecurityCenter.Models.ListCustomAlertRule
    {
        public AllowlistCustomAlertRule(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base (default(bool)) { }
        public System.Collections.Generic.IList<string> AllowlistValues { get { throw null; } }
    }
    public partial class AmqpC2DMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public AmqpC2DMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class AmqpC2DRejectedMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public AmqpC2DRejectedMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class AmqpD2CMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public AmqpD2CMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationSourceResourceType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationSourceResourceType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType Assessments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType left, Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType left, Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentStatus
    {
        public AssessmentStatus(Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode code) { }
        public string Cause { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode Code { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentStatusCode : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentStatusCode(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode Healthy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode left, Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode left, Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentStatusResponse : Azure.ResourceManager.SecurityCenter.Models.AssessmentStatus
    {
        public AssessmentStatusResponse(Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode code) : base (default(Azure.ResourceManager.SecurityCenter.Models.AssessmentStatusCode)) { }
        public System.DateTimeOffset? FirstEvaluationOn { get { throw null; } }
        public System.DateTimeOffset? StatusChangeOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AssessmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AssessmentType BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AssessmentType CustomerManaged { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AssessmentType CustomPolicy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AssessmentType VerifiedPartner { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AssessmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AssessmentType left, Azure.ResourceManager.SecurityCenter.Models.AssessmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AssessmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AssessmentType left, Azure.ResourceManager.SecurityCenter.Models.AssessmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AuthenticationDetailsProperties
    {
        protected AuthenticationDetailsProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState? AuthenticationProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.PermissionProperty> GrantedPermissions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState Expired { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState IncorrectPolicy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState Invalid { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AutomationAction
    {
        protected AutomationAction() { }
    }
    public partial class AutomationActionEventHub : Azure.ResourceManager.SecurityCenter.Models.AutomationAction
    {
        public AutomationActionEventHub() { }
        public string ConnectionString { get { throw null; } set { } }
        public string EventHubResourceId { get { throw null; } set { } }
        public string SasPolicyName { get { throw null; } }
    }
    public partial class AutomationActionLogicApp : Azure.ResourceManager.SecurityCenter.Models.AutomationAction
    {
        public AutomationActionLogicApp() { }
        public string LogicAppResourceId { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class AutomationActionWorkspace : Azure.ResourceManager.SecurityCenter.Models.AutomationAction
    {
        public AutomationActionWorkspace() { }
        public string WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AutomationRuleSet
    {
        public AutomationRuleSet() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRule> Rules { get { throw null; } }
    }
    public partial class AutomationScope
    {
        public AutomationScope() { }
        public string Description { get { throw null; } set { } }
        public string ScopePath { get { throw null; } set { } }
    }
    public partial class AutomationSource
    {
        public AutomationSource() { }
        public Azure.ResourceManager.SecurityCenter.Models.EventSource? EventSource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.AutomationRuleSet> RuleSets { get { throw null; } }
    }
    public partial class AutomationTriggeringRule
    {
        public AutomationTriggeringRule() { }
        public string ExpectedValue { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.Operator? Operator { get { throw null; } set { } }
        public string PropertyJPath { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.PropertyType? PropertyType { get { throw null; } set { } }
    }
    public partial class AutomationValidationStatus
    {
        internal AutomationValidationStatus() { }
        public bool? IsValid { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoProvision : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AutoProvision>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoProvision(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AutoProvision Off { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutoProvision On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AutoProvision other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AutoProvision left, Azure.ResourceManager.SecurityCenter.Models.AutoProvision right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AutoProvision (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AutoProvision left, Azure.ResourceManager.SecurityCenter.Models.AutoProvision right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailableSubPlanType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailableSubPlanType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType P1 { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType P2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType left, Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType left, Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AwAssumeRoleAuthenticationDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties
    {
        public AwAssumeRoleAuthenticationDetailsProperties(string awsAssumeRoleArn, string awsExternalId) { }
        public string AccountId { get { throw null; } }
        public string AwsAssumeRoleArn { get { throw null; } set { } }
        public string AwsExternalId { get { throw null; } set { } }
    }
    public partial class AwsCredsAuthenticationDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties
    {
        public AwsCredsAuthenticationDetailsProperties(string awsAccessKeyId, string awsSecretAccessKey) { }
        public string AccountId { get { throw null; } }
        public string AwsAccessKeyId { get { throw null; } set { } }
        public string AwsSecretAccessKey { get { throw null; } set { } }
    }
    public partial class AWSEnvironmentData : Azure.ResourceManager.SecurityCenter.Models.EnvironmentData
    {
        public AWSEnvironmentData() { }
        public Azure.ResourceManager.SecurityCenter.Models.AwsOrganizationalData OrganizationalData { get { throw null; } set { } }
    }
    public abstract partial class AwsOrganizationalData
    {
        protected AwsOrganizationalData() { }
    }
    public partial class AwsOrganizationalDataMaster : Azure.ResourceManager.SecurityCenter.Models.AwsOrganizationalData
    {
        public AwsOrganizationalDataMaster() { }
        public System.Collections.Generic.IList<string> ExcludedAccountIds { get { throw null; } }
        public string StacksetName { get { throw null; } set { } }
    }
    public partial class AwsOrganizationalDataMember : Azure.ResourceManager.SecurityCenter.Models.AwsOrganizationalData
    {
        public AwsOrganizationalDataMember() { }
        public string ParentHierarchyId { get { throw null; } set { } }
    }
    public partial class AzureDevOpsScopeEnvironmentData : Azure.ResourceManager.SecurityCenter.Models.EnvironmentData
    {
        public AzureDevOpsScopeEnvironmentData() { }
    }
    public partial class AzureResourceDetails : Azure.ResourceManager.SecurityCenter.Models.ResourceDetails
    {
        public AzureResourceDetails() { }
        public string Id { get { throw null; } }
    }
    public partial class AzureResourceIdentifier : Azure.ResourceManager.SecurityCenter.Models.AlertResourceIdentifier
    {
        internal AzureResourceIdentifier() { }
        public string AzureResourceId { get { throw null; } }
    }
    public partial class Baseline
    {
        public Baseline() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> ExpectedResults { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    public partial class BaselineAdjustedResult
    {
        public BaselineAdjustedResult() { }
        public Azure.ResourceManager.SecurityCenter.Models.Baseline Baseline { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> ResultsNotInBaseline { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> ResultsOnlyInBaseline { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.RuleStatus? Status { get { throw null; } set { } }
    }
    public partial class BenchmarkReference
    {
        public BenchmarkReference() { }
        public string Benchmark { get { throw null; } set { } }
        public string Reference { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BundleType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.BundleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BundleType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.BundleType AppServices { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.BundleType CosmosDbs { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.BundleType Dns { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.BundleType KeyVaults { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.BundleType KubernetesService { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.BundleType ResourceManager { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.BundleType SqlServers { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.BundleType StorageAccounts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.BundleType VirtualMachines { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.BundleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.BundleType left, Azure.ResourceManager.SecurityCenter.Models.BundleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.BundleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.BundleType left, Azure.ResourceManager.SecurityCenter.Models.BundleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Category : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Category>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Category(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Category Compute { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Category Data { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Category IdentityAndAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Category Iot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Category Networking { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Category other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Category left, Azure.ResourceManager.SecurityCenter.Models.Category right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Category (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Category left, Azure.ResourceManager.SecurityCenter.Models.Category right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudName : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.CloudName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudName(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.CloudName AWS { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.CloudName Azure { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.CloudName AzureDevOps { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.CloudName GCP { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.CloudName Github { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.CloudName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.CloudName left, Azure.ResourceManager.SecurityCenter.Models.CloudName right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.CloudName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.CloudName left, Azure.ResourceManager.SecurityCenter.Models.CloudName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class CloudOffering
    {
        protected CloudOffering() { }
        public string Description { get { throw null; } }
    }
    public partial class ComplianceSegment
    {
        internal ComplianceSegment() { }
        public double? Percentage { get { throw null; } }
        public string SegmentType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus Configured { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus NoStatus { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus NotConfigured { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus left, Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus left, Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectableResource
    {
        internal ConnectableResource() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.ConnectedResource> InboundConnectedResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.ConnectedResource> OutboundConnectedResources { get { throw null; } }
    }
    public partial class ConnectedResource
    {
        internal ConnectedResource() { }
        public string ConnectedResourceId { get { throw null; } }
        public string TcpPorts { get { throw null; } }
        public string UdpPorts { get { throw null; } }
    }
    public partial class ConnectionFromIPNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule
    {
        public ConnectionFromIPNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base (default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
    }
    public partial class ConnectionToIPNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule
    {
        public ConnectionToIPNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base (default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ConnectionType External { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ConnectionType Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ConnectionType left, Azure.ResourceManager.SecurityCenter.Models.ConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ConnectionType left, Azure.ResourceManager.SecurityCenter.Models.ConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryVulnerabilityProperties : Azure.ResourceManager.SecurityCenter.Models.AdditionalData
    {
        public ContainerRegistryVulnerabilityProperties() { }
        public string ContainerRegistryVulnerabilityPropertiesType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.CVE> Cve { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.SecurityCenter.Models.Cvss> Cvss { get { throw null; } }
        public string ImageDigest { get { throw null; } }
        public bool? Patchable { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public string RepositoryName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.VendorReference> VendorReferences { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ControlType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ControlType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ControlType BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ControlType Custom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ControlType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ControlType left, Azure.ResourceManager.SecurityCenter.Models.ControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ControlType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ControlType left, Azure.ResourceManager.SecurityCenter.Models.ControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CspmMonitorAwsOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public CspmMonitorAwsOffering() { }
        public string CloudRoleArn { get { throw null; } set { } }
    }
    public partial class CspmMonitorAzureDevOpsOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public CspmMonitorAzureDevOpsOffering() { }
    }
    public partial class CspmMonitorGcpOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public CspmMonitorGcpOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.CspmMonitorGcpOfferingNativeCloudConnection NativeCloudConnection { get { throw null; } set { } }
    }
    public partial class CspmMonitorGcpOfferingNativeCloudConnection
    {
        public CspmMonitorGcpOfferingNativeCloudConnection() { }
        public string ServiceAccountEmailAddress { get { throw null; } set { } }
        public string WorkloadIdentityProviderId { get { throw null; } set { } }
    }
    public partial class CspmMonitorGithubOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public CspmMonitorGithubOffering() { }
    }
    public abstract partial class CustomAlertRule
    {
        protected CustomAlertRule(bool isEnabled) { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
    }
    public partial class CustomAssessmentAutomationCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public CustomAssessmentAutomationCreateOrUpdateContent() { }
        public string CompressedQuery { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string RemediationDescription { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SeverityEnum? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum? SupportedCloud { get { throw null; } set { } }
    }
    public partial class CustomEntityStoreAssignmentCreateOrUpdateContent
    {
        public CustomEntityStoreAssignmentCreateOrUpdateContent() { }
        public string Principal { get { throw null; } set { } }
    }
    public partial class CVE
    {
        internal CVE() { }
        public string Link { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class Cvss
    {
        internal Cvss() { }
        public float? Base { get { throw null; } }
    }
    public partial class DataExportSettings : Azure.ResourceManager.SecurityCenter.SettingData
    {
        public DataExportSettings() { }
        public bool? Enabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSource : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.DataSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSource(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.DataSource TwinData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.DataSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.DataSource left, Azure.ResourceManager.SecurityCenter.Models.DataSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.DataSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.DataSource left, Azure.ResourceManager.SecurityCenter.Models.DataSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DefenderFoDatabasesAwsOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public DefenderFoDatabasesAwsOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
    }
    public partial class DefenderFoDatabasesAwsOfferingArcAutoProvisioning
    {
        public DefenderFoDatabasesAwsOfferingArcAutoProvisioning() { }
        public string CloudRoleArn { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningServicePrincipalSecretMetadata ServicePrincipalSecretMetadata { get { throw null; } set { } }
    }
    public partial class DefenderFoDatabasesAwsOfferingArcAutoProvisioningServicePrincipalSecretMetadata
    {
        public DefenderFoDatabasesAwsOfferingArcAutoProvisioningServicePrincipalSecretMetadata() { }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public string ParameterNameInStore { get { throw null; } set { } }
        public string ParameterStoreRegion { get { throw null; } set { } }
    }
    public partial class DefenderForContainersAwsOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public DefenderForContainersAwsOffering() { }
        public bool? AutoProvisioning { get { throw null; } set { } }
        public string CloudRoleArn { get { throw null; } set { } }
        public string ContainerVulnerabilityAssessmentCloudRoleArn { get { throw null; } set { } }
        public string ContainerVulnerabilityAssessmentTaskCloudRoleArn { get { throw null; } set { } }
        public bool? EnableContainerVulnerabilityAssessment { get { throw null; } set { } }
        public string KinesisToS3CloudRoleArn { get { throw null; } set { } }
        public long? KubeAuditRetentionTime { get { throw null; } set { } }
        public string KubernetesScubaReaderCloudRoleArn { get { throw null; } set { } }
        public string KubernetesServiceCloudRoleArn { get { throw null; } set { } }
        public string ScubaExternalId { get { throw null; } set { } }
    }
    public partial class DefenderForContainersGcpOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public DefenderForContainersGcpOffering() { }
        public bool? AuditLogsAutoProvisioningFlag { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForContainersGcpOfferingDataPipelineNativeCloudConnection DataPipelineNativeCloudConnection { get { throw null; } set { } }
        public bool? DefenderAgentAutoProvisioningFlag { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForContainersGcpOfferingNativeCloudConnection NativeCloudConnection { get { throw null; } set { } }
        public bool? PolicyAgentAutoProvisioningFlag { get { throw null; } set { } }
    }
    public partial class DefenderForContainersGcpOfferingDataPipelineNativeCloudConnection
    {
        public DefenderForContainersGcpOfferingDataPipelineNativeCloudConnection() { }
        public string ServiceAccountEmailAddress { get { throw null; } set { } }
        public string WorkloadIdentityProviderId { get { throw null; } set { } }
    }
    public partial class DefenderForContainersGcpOfferingNativeCloudConnection
    {
        public DefenderForContainersGcpOfferingNativeCloudConnection() { }
        public string ServiceAccountEmailAddress { get { throw null; } set { } }
        public string WorkloadIdentityProviderId { get { throw null; } set { } }
    }
    public partial class DefenderForDatabasesGcpOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public DefenderForDatabasesGcpOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesGcpOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesGcpOfferingDefenderForDatabasesArcAutoProvisioning DefenderForDatabasesArcAutoProvisioning { get { throw null; } set { } }
    }
    public partial class DefenderForDatabasesGcpOfferingArcAutoProvisioning
    {
        public DefenderForDatabasesGcpOfferingArcAutoProvisioning() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration Configuration { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration
    {
        public DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration() { }
        public string AgentOnboardingServiceAccountNumericId { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
    }
    public partial class DefenderForDatabasesGcpOfferingDefenderForDatabasesArcAutoProvisioning
    {
        public DefenderForDatabasesGcpOfferingDefenderForDatabasesArcAutoProvisioning() { }
        public string ServiceAccountEmailAddress { get { throw null; } set { } }
        public string WorkloadIdentityProviderId { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public DefenderForServersAwsOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType? AvailableSubPlanType { get { throw null; } set { } }
        public string DefenderForServersCloudRoleArn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingMdeAutoProvisioning MdeAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingVaAutoProvisioning VaAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingVmScanners VmScanners { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingArcAutoProvisioning
    {
        public DefenderForServersAwsOfferingArcAutoProvisioning() { }
        public string CloudRoleArn { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingArcAutoProvisioningServicePrincipalSecretMetadata ServicePrincipalSecretMetadata { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingArcAutoProvisioningServicePrincipalSecretMetadata
    {
        public DefenderForServersAwsOfferingArcAutoProvisioningServicePrincipalSecretMetadata() { }
        public string ExpiryDate { get { throw null; } set { } }
        public string ParameterNameInStore { get { throw null; } set { } }
        public string ParameterStoreRegion { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingMdeAutoProvisioning
    {
        public DefenderForServersAwsOfferingMdeAutoProvisioning() { }
        public System.BinaryData Configuration { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingVaAutoProvisioning
    {
        public DefenderForServersAwsOfferingVaAutoProvisioning() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType? VAAutoProvisioningType { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingVmScanners
    {
        public DefenderForServersAwsOfferingVmScanners() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingVmScannersConfiguration Configuration { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingVmScannersConfiguration
    {
        public DefenderForServersAwsOfferingVmScannersConfiguration() { }
        public string CloudRoleArn { get { throw null; } set { } }
        public System.BinaryData ExclusionTags { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ScanningMode? ScanningMode { get { throw null; } set { } }
    }
    public partial class DefenderForServersGcpOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public DefenderForServersGcpOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType? AvailableSubPlanType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingDefenderForServers DefenderForServers { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingMdeAutoProvisioning MdeAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingVaAutoProvisioning VaAutoProvisioning { get { throw null; } set { } }
    }
    public partial class DefenderForServersGcpOfferingArcAutoProvisioning
    {
        public DefenderForServersGcpOfferingArcAutoProvisioning() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingArcAutoProvisioningConfiguration Configuration { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class DefenderForServersGcpOfferingArcAutoProvisioningConfiguration
    {
        public DefenderForServersGcpOfferingArcAutoProvisioningConfiguration() { }
        public string AgentOnboardingServiceAccountNumericId { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
    }
    public partial class DefenderForServersGcpOfferingDefenderForServers
    {
        public DefenderForServersGcpOfferingDefenderForServers() { }
        public string ServiceAccountEmailAddress { get { throw null; } set { } }
        public string WorkloadIdentityProviderId { get { throw null; } set { } }
    }
    public partial class DefenderForServersGcpOfferingMdeAutoProvisioning
    {
        public DefenderForServersGcpOfferingMdeAutoProvisioning() { }
        public System.BinaryData Configuration { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class DefenderForServersGcpOfferingVaAutoProvisioning
    {
        public DefenderForServersGcpOfferingVaAutoProvisioning() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType? VAAutoProvisioningType { get { throw null; } set { } }
    }
    public partial class DenylistCustomAlertRule : Azure.ResourceManager.SecurityCenter.Models.ListCustomAlertRule
    {
        public DenylistCustomAlertRule(bool isEnabled, System.Collections.Generic.IEnumerable<string> denylistValues) : base (default(bool)) { }
        public System.Collections.Generic.IList<string> DenylistValues { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Direction : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Direction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Direction(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Direction Inbound { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Direction Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Direction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Direction left, Azure.ResourceManager.SecurityCenter.Models.Direction right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Direction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Direction left, Azure.ResourceManager.SecurityCenter.Models.Direction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DirectMethodInvokesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public DirectMethodInvokesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class EffectiveNetworkSecurityGroups
    {
        public EffectiveNetworkSecurityGroups() { }
        public string NetworkInterface { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NetworkSecurityGroups { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndOfSupportStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndOfSupportStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus NoLongerSupported { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus None { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus UpcomingNoLongerSupported { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus UpcomingVersionNoLongerSupported { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus VersionNoLongerSupported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus left, Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus left, Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnforcementMode : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.EnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnforcementMode(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.EnforcementMode Audit { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EnforcementMode Enforce { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EnforcementMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.EnforcementMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.EnforcementMode left, Azure.ResourceManager.SecurityCenter.Models.EnforcementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.EnforcementMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.EnforcementMode left, Azure.ResourceManager.SecurityCenter.Models.EnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnforcementSupport : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnforcementSupport(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport NotSupported { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport Supported { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport left, Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport left, Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EnvironmentData
    {
        protected EnvironmentData() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSource : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.EventSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSource(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource Alerts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource Assessments { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource AssessmentsSnapshot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource RegulatoryComplianceAssessment { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource RegulatoryComplianceAssessmentSnapshot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource SecureScoreControls { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource SecureScoreControlsSnapshot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource SecureScores { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource SecureScoresSnapshot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource SubAssessments { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.EventSource SubAssessmentsSnapshot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.EventSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.EventSource left, Azure.ResourceManager.SecurityCenter.Models.EventSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.EventSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.EventSource left, Azure.ResourceManager.SecurityCenter.Models.EventSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExecuteGovernanceRuleParams
    {
        public ExecuteGovernanceRuleParams() { }
        public bool? Override { get { throw null; } set { } }
    }
    public partial class ExecuteRuleStatus
    {
        internal ExecuteRuleStatus() { }
        public string OperationId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpandControlsEnum : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpandControlsEnum(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum Definition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum left, Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum left, Azure.ResourceManager.SecurityCenter.Models.ExpandControlsEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpandEnum : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ExpandEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpandEnum(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ExpandEnum Links { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ExpandEnum Metadata { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum left, Azure.ResourceManager.SecurityCenter.Models.ExpandEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ExpandEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ExpandEnum left, Azure.ResourceManager.SecurityCenter.Models.ExpandEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportData : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ExportData>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportData(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ExportData RawEvents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ExportData other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ExportData left, Azure.ResourceManager.SecurityCenter.Models.ExportData right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ExportData (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ExportData left, Azure.ResourceManager.SecurityCenter.Models.ExportData right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExternalSecuritySolutionKindType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExternalSecuritySolutionKindType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType AAD { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType ATA { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType CEF { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType left, Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType left, Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKindType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FailedLocalLoginsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public FailedLocalLoginsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.FileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.FileType Dll { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.FileType Exe { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.FileType Executable { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.FileType Msi { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.FileType Script { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.FileType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.FileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.FileType left, Azure.ResourceManager.SecurityCenter.Models.FileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.FileType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.FileType left, Azure.ResourceManager.SecurityCenter.Models.FileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileUploadsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public FileUploadsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class GcpCredentialsDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties
    {
        public GcpCredentialsDetailsProperties(string organizationId, string gcpCredentialsDetailsPropertiesType, string projectId, string privateKeyId, string privateKey, string clientEmail, string clientId, System.Uri authUri, System.Uri tokenUri, System.Uri authProviderX509CertUri, System.Uri clientX509CertUri) { }
        public System.Uri AuthProviderX509CertUri { get { throw null; } set { } }
        public System.Uri AuthUri { get { throw null; } set { } }
        public string ClientEmail { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public System.Uri ClientX509CertUri { get { throw null; } set { } }
        public string GcpCredentialsDetailsPropertiesType { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string PrivateKey { get { throw null; } set { } }
        public string PrivateKeyId { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public System.Uri TokenUri { get { throw null; } set { } }
    }
    public abstract partial class GcpOrganizationalData
    {
        protected GcpOrganizationalData() { }
    }
    public partial class GcpOrganizationalDataMember : Azure.ResourceManager.SecurityCenter.Models.GcpOrganizationalData
    {
        public GcpOrganizationalDataMember() { }
        public string ManagementProjectNumber { get { throw null; } set { } }
        public string ParentHierarchyId { get { throw null; } set { } }
    }
    public partial class GcpOrganizationalDataOrganization : Azure.ResourceManager.SecurityCenter.Models.GcpOrganizationalData
    {
        public GcpOrganizationalDataOrganization() { }
        public System.Collections.Generic.IList<string> ExcludedProjectNumbers { get { throw null; } }
        public string ServiceAccountEmailAddress { get { throw null; } set { } }
        public string WorkloadIdentityProviderId { get { throw null; } set { } }
    }
    public partial class GcpProjectDetails
    {
        public GcpProjectDetails() { }
        public string ProjectId { get { throw null; } set { } }
        public string ProjectNumber { get { throw null; } set { } }
        public string WorkloadIdentityPoolId { get { throw null; } }
    }
    public partial class GcpProjectEnvironmentData : Azure.ResourceManager.SecurityCenter.Models.EnvironmentData
    {
        public GcpProjectEnvironmentData() { }
        public Azure.ResourceManager.SecurityCenter.Models.GcpOrganizationalData OrganizationalData { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.GcpProjectDetails ProjectDetails { get { throw null; } set { } }
    }
    public partial class GithubScopeEnvironmentData : Azure.ResourceManager.SecurityCenter.Models.EnvironmentData
    {
        public GithubScopeEnvironmentData() { }
    }
    public partial class GovernanceAssignmentAdditionalData
    {
        public GovernanceAssignmentAdditionalData() { }
        public string TicketLink { get { throw null; } set { } }
        public int? TicketNumber { get { throw null; } set { } }
        public string TicketStatus { get { throw null; } set { } }
    }
    public partial class GovernanceEmailNotification
    {
        public GovernanceEmailNotification() { }
        public bool? DisableManagerEmailNotification { get { throw null; } set { } }
        public bool? DisableOwnerEmailNotification { get { throw null; } set { } }
    }
    public partial class GovernanceRuleEmailNotification
    {
        public GovernanceRuleEmailNotification() { }
        public bool? DisableManagerEmailNotification { get { throw null; } set { } }
        public bool? DisableOwnerEmailNotification { get { throw null; } set { } }
    }
    public partial class GovernanceRuleOwnerSource
    {
        public GovernanceRuleOwnerSource() { }
        public Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType? SourceType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GovernanceRuleOwnerSourceType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GovernanceRuleOwnerSourceType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType ByTag { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType Manually { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType left, Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType left, Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleOwnerSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GovernanceRuleSourceResourceType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleSourceResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GovernanceRuleSourceResourceType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleSourceResourceType Assessments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleSourceResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleSourceResourceType left, Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleSourceResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleSourceResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleSourceResourceType left, Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleSourceResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GovernanceRuleType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GovernanceRuleType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType Integrated { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType ServiceNow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType left, Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType left, Azure.ResourceManager.SecurityCenter.Models.GovernanceRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpC2DMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public HttpC2DMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class HttpC2DRejectedMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public HttpC2DRejectedMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class HttpD2CMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public HttpD2CMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState Expired { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState Invalid { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridComputeSettingsProperties
    {
        public HybridComputeSettingsProperties(Azure.ResourceManager.SecurityCenter.Models.AutoProvision autoProvision) { }
        public Azure.ResourceManager.SecurityCenter.Models.AutoProvision AutoProvision { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState? HybridComputeProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties ProxyServer { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties ServicePrincipal { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImplementationEffort : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImplementationEffort(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort Moderate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort left, Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort left, Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InformationProtectionAwsOffering : Azure.ResourceManager.SecurityCenter.Models.CloudOffering
    {
        public InformationProtectionAwsOffering() { }
        public string InformationProtectionCloudRoleArn { get { throw null; } set { } }
    }
    public partial class IngestionConnectionString
    {
        internal IngestionConnectionString() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class IngestionSettingToken
    {
        internal IngestionSettingToken() { }
        public string Token { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Intent : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Intent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Intent(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent Collection { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent CommandAndControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent CredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent DefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent Discovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent Execution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent Exfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent Exploitation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent Impact { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent InitialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent LateralMovement { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent Persistence { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent PreAttack { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent PrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent Probing { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Intent Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Intent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Intent left, Azure.ResourceManager.SecurityCenter.Models.Intent right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Intent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Intent left, Azure.ResourceManager.SecurityCenter.Models.Intent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotSecurityAggregatedAlertPropertiesTopDevicesListItem
    {
        internal IotSecurityAggregatedAlertPropertiesTopDevicesListItem() { }
        public long? AlertsCount { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string LastOccurrence { get { throw null; } }
    }
    public partial class IotSecurityAlertedDevice
    {
        public IotSecurityAlertedDevice() { }
        public long? AlertsCount { get { throw null; } }
        public string DeviceId { get { throw null; } }
    }
    public partial class IotSecurityDeviceAlert
    {
        public IotSecurityDeviceAlert() { }
        public string AlertDisplayName { get { throw null; } }
        public long? AlertsCount { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity? ReportedSeverity { get { throw null; } }
    }
    public partial class IotSecurityDeviceRecommendation
    {
        public IotSecurityDeviceRecommendation() { }
        public long? DevicesCount { get { throw null; } }
        public string RecommendationDisplayName { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity? ReportedSeverity { get { throw null; } }
    }
    public partial class IotSecuritySolutionAnalyticsModelPropertiesDevicesMetricsItem
    {
        internal IotSecuritySolutionAnalyticsModelPropertiesDevicesMetricsItem() { }
        public Azure.ResourceManager.SecurityCenter.Models.IotSeverityMetrics DevicesMetrics { get { throw null; } }
        public System.DateTimeOffset? On { get { throw null; } }
    }
    public partial class IotSecuritySolutionModelPatch : Azure.ResourceManager.SecurityCenter.Models.TagsResource
    {
        public IotSecuritySolutionModelPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigurationProperties> RecommendationsConfiguration { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.UserDefinedResourcesProperties UserDefinedResources { get { throw null; } set { } }
    }
    public partial class IotSeverityMetrics
    {
        internal IotSeverityMetrics() { }
        public long? High { get { throw null; } }
        public long? Low { get { throw null; } }
        public long? Medium { get { throw null; } }
    }
    public partial class JitNetworkAccessPolicyInitiateContent
    {
        public JitNetworkAccessPolicyInitiateContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiateVirtualMachine> virtualMachines) { }
        public string Justification { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiateVirtualMachine> VirtualMachines { get { throw null; } }
    }
    public partial class JitNetworkAccessPolicyInitiatePort
    {
        public JitNetworkAccessPolicyInitiatePort(int number, System.DateTimeOffset endTimeUtc) { }
        public string AllowedSourceAddressPrefix { get { throw null; } set { } }
        public System.DateTimeOffset EndTimeUtc { get { throw null; } }
        public int Number { get { throw null; } }
    }
    public partial class JitNetworkAccessPolicyInitiateVirtualMachine
    {
        public JitNetworkAccessPolicyInitiateVirtualMachine(string id, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiatePort> ports) { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiatePort> Ports { get { throw null; } }
    }
    public partial class JitNetworkAccessPolicyVirtualMachine
    {
        public JitNetworkAccessPolicyVirtualMachine(string id, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortRule> ports) { }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortRule> Ports { get { throw null; } }
        public string PublicIPAddress { get { throw null; } set { } }
    }
    public partial class JitNetworkAccessPortRule
    {
        public JitNetworkAccessPortRule(int number, Azure.ResourceManager.SecurityCenter.Models.Protocol protocol, System.TimeSpan maxRequestAccessDuration) { }
        public string AllowedSourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AllowedSourceAddressPrefixes { get { throw null; } }
        public System.TimeSpan MaxRequestAccessDuration { get { throw null; } set { } }
        public int Number { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.Protocol Protocol { get { throw null; } set { } }
    }
    public partial class JitNetworkAccessRequest
    {
        public JitNetworkAccessRequest(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestVirtualMachine> virtualMachines, System.DateTimeOffset startTimeUtc, string requestor) { }
        public string Justification { get { throw null; } set { } }
        public string Requestor { get { throw null; } set { } }
        public System.DateTimeOffset StartTimeUtc { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestVirtualMachine> VirtualMachines { get { throw null; } }
    }
    public partial class JitNetworkAccessRequestPort
    {
        public JitNetworkAccessRequestPort(int number, System.DateTimeOffset endTimeUtc, Azure.ResourceManager.SecurityCenter.Models.Status status, Azure.ResourceManager.SecurityCenter.Models.StatusReason statusReason) { }
        public string AllowedSourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AllowedSourceAddressPrefixes { get { throw null; } }
        public System.DateTimeOffset EndTimeUtc { get { throw null; } set { } }
        public int? MappedPort { get { throw null; } set { } }
        public int Number { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.Status Status { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.StatusReason StatusReason { get { throw null; } set { } }
    }
    public partial class JitNetworkAccessRequestVirtualMachine
    {
        public JitNetworkAccessRequestVirtualMachine(string id, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestPort> ports) { }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestPort> Ports { get { throw null; } }
    }
    public partial class ListCustomAlertRule : Azure.ResourceManager.SecurityCenter.Models.CustomAlertRule
    {
        public ListCustomAlertRule(bool isEnabled) : base (default(bool)) { }
        public Azure.ResourceManager.SecurityCenter.Models.ValueType? ValueType { get { throw null; } }
    }
    public partial class LocalUserNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule
    {
        public LocalUserNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base (default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
    }
    public partial class LogAnalyticsIdentifier : Azure.ResourceManager.SecurityCenter.Models.AlertResourceIdentifier
    {
        internal LogAnalyticsIdentifier() { }
        public string AgentId { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        public string WorkspaceResourceGroup { get { throw null; } }
        public string WorkspaceSubscriptionId { get { throw null; } }
    }
    public partial class MqttC2DMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public MqttC2DMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class MqttC2DRejectedMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public MqttC2DRejectedMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class MqttD2CMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public MqttD2CMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class OnPremiseResourceDetails : Azure.ResourceManager.SecurityCenter.Models.ResourceDetails
    {
        public OnPremiseResourceDetails(string workspaceId, System.Guid vmUuid, string sourceComputerId, string machineName) { }
        public string MachineName { get { throw null; } set { } }
        public string SourceComputerId { get { throw null; } set { } }
        public System.Guid VmUuid { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class OnPremiseSqlResourceDetails : Azure.ResourceManager.SecurityCenter.Models.OnPremiseResourceDetails
    {
        public OnPremiseSqlResourceDetails(string workspaceId, System.Guid vmUuid, string sourceComputerId, string machineName, string serverName, string databaseName) : base (default(string), default(System.Guid), default(string), default(string)) { }
        public string DatabaseName { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Operator : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Operator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Operator(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Operator Contains { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Operator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Operator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Operator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Operator GreaterThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Operator LesserThan { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Operator LesserThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Operator NotEquals { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Operator StartsWith { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Operator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Operator left, Azure.ResourceManager.SecurityCenter.Models.Operator right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Operator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Operator left, Azure.ResourceManager.SecurityCenter.Models.Operator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PathRecommendation
    {
        public PathRecommendation() { }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? Action { get { throw null; } set { } }
        public bool? Common { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus? ConfigurationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.FileType? FileType { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.PublisherInfo PublisherInfo { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationType? RecommendationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation> Usernames { get { throw null; } }
        public System.Collections.Generic.IList<string> UserSids { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PermissionProperty : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.PermissionProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PermissionProperty(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.PermissionProperty AWSAmazonSSMAutomationRole { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PermissionProperty AWSAWSSecurityHubReadOnlyAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PermissionProperty AWSSecurityAudit { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PermissionProperty GCPSecurityCenterAdminViewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.PermissionProperty other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.PermissionProperty left, Azure.ResourceManager.SecurityCenter.Models.PermissionProperty right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.PermissionProperty (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.PermissionProperty left, Azure.ResourceManager.SecurityCenter.Models.PermissionProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PricingTier : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.PricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PricingTier(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.PricingTier Free { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.PricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.PricingTier left, Azure.ResourceManager.SecurityCenter.Models.PricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.PricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.PricingTier left, Azure.ResourceManager.SecurityCenter.Models.PricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProcessNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule
    {
        public ProcessNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base (default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PropertyType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.PropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PropertyType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.PropertyType Boolean { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PropertyType Integer { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PropertyType Number { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PropertyType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.PropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.PropertyType left, Azure.ResourceManager.SecurityCenter.Models.PropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.PropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.PropertyType left, Azure.ResourceManager.SecurityCenter.Models.PropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProtectionMode
    {
        public ProtectionMode() { }
        public Azure.ResourceManager.SecurityCenter.Models.EnforcementMode? Exe { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.EnforcementMode? Executable { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.EnforcementMode? Msi { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.EnforcementMode? Script { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Protocol : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Protocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Protocol(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Protocol All { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Protocol TCP { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Protocol UDP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Protocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Protocol left, Azure.ResourceManager.SecurityCenter.Models.Protocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Protocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Protocol left, Azure.ResourceManager.SecurityCenter.Models.Protocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyServerProperties
    {
        public ProxyServerProperties() { }
        public string IP { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
    }
    public partial class PublisherInfo
    {
        public PublisherInfo() { }
        public string BinaryName { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        public string PublisherName { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class QueryCheck
    {
        public QueryCheck() { }
        public System.Collections.Generic.IList<string> ColumnNames { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> ExpectedResult { get { throw null; } }
        public string Query { get { throw null; } set { } }
    }
    public partial class QueuePurgesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public QueuePurgesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationAction : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RecommendationAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationAction(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationAction Add { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationAction Recommended { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationAction Remove { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RecommendationAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RecommendationAction left, Azure.ResourceManager.SecurityCenter.Models.RecommendationAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RecommendationAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RecommendationAction left, Azure.ResourceManager.SecurityCenter.Models.RecommendationAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationConfigStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationConfigStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus left, Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus left, Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendationConfigurationProperties
    {
        public RecommendationConfigurationProperties(Azure.ResourceManager.SecurityCenter.Models.RecommendationType recommendationType, Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus status) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationType RecommendationType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus NoStatus { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus NotAvailable { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus NotRecommended { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus Recommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus left, Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus left, Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RecommendationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotAcrAuthentication { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotAgentSendsUnutilizedMessages { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotBaseline { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotEdgeHubMemOptimize { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotEdgeLoggingOptions { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotInconsistentModuleSettings { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotInstallAgent { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotIPFilterDenyAll { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotIPFilterPermissiveRule { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotOpenPorts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotPermissiveFirewallPolicy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotPermissiveInputFirewallRules { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotPermissiveOutputFirewallRules { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotPrivilegedDockerOptions { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotSharedCredentials { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationType IotVulnerableTlsCipherSuite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RecommendationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RecommendationType left, Azure.ResourceManager.SecurityCenter.Models.RecommendationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RecommendationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RecommendationType left, Azure.ResourceManager.SecurityCenter.Models.RecommendationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Remediation
    {
        public Remediation() { }
        public bool? Automated { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string PortalLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scripts { get { throw null; } }
    }
    public partial class RemediationEta
    {
        public RemediationEta(System.DateTimeOffset eta, string justification) { }
        public System.DateTimeOffset Eta { get { throw null; } set { } }
        public string Justification { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportedSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportedSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity left, Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity left, Azure.ResourceManager.SecurityCenter.Models.ReportedSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ResourceDetails
    {
        protected ResourceDetails() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ResourceStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ResourceStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ResourceStatus NotHealthy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ResourceStatus OffByPolicy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ResourceStatus left, Azure.ResourceManager.SecurityCenter.Models.ResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ResourceStatus left, Azure.ResourceManager.SecurityCenter.Models.ResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Rule
    {
        public Rule() { }
        public int? DestinationPort { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.Direction? Direction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPAddresses { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.TransportProtocol> Protocols { get { throw null; } }
    }
    public partial class RuleResultCreateOrUpdateContent
    {
        public RuleResultCreateOrUpdateContent() { }
        public bool? LatestScan { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> Results { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RuleSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleSeverity Medium { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleSeverity Obsolete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RuleSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RuleSeverity left, Azure.ResourceManager.SecurityCenter.Models.RuleSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RuleSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RuleSeverity left, Azure.ResourceManager.SecurityCenter.Models.RuleSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RulesResultsContent
    {
        public RulesResultsContent() { }
        public bool? LatestScan { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<System.Collections.Generic.IList<string>>> Results { get { throw null; } }
    }
    public enum RuleState
    {
        Enabled = 0,
        Disabled = 1,
        Expired = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RuleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleStatus Finding { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleStatus InternalError { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleStatus NonFinding { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RuleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RuleStatus left, Azure.ResourceManager.SecurityCenter.Models.RuleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RuleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RuleStatus left, Azure.ResourceManager.SecurityCenter.Models.RuleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleType BaselineExpected { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleType Binary { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleType NegativeList { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RuleType PositiveList { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RuleType left, Azure.ResourceManager.SecurityCenter.Models.RuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RuleType left, Azure.ResourceManager.SecurityCenter.Models.RuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScanningMode : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ScanningMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScanningMode(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ScanningMode Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ScanningMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ScanningMode left, Azure.ResourceManager.SecurityCenter.Models.ScanningMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ScanningMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ScanningMode left, Azure.ResourceManager.SecurityCenter.Models.ScanningMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScanProperties
    {
        public ScanProperties() { }
        public string Database { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public int? HighSeverityFailedRulesCount { get { throw null; } set { } }
        public bool? IsBaselineApplied { get { throw null; } set { } }
        public int? LowSeverityFailedRulesCount { get { throw null; } set { } }
        public int? MediumSeverityFailedRulesCount { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string SqlVersion { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ScanState? State { get { throw null; } set { } }
        public int? TotalFailedRulesCount { get { throw null; } set { } }
        public int? TotalPassedRulesCount { get { throw null; } set { } }
        public int? TotalRulesCount { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType? TriggerType { get { throw null; } set { } }
    }
    public partial class ScanResultProperties
    {
        public ScanResultProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.BaselineAdjustedResult BaselineAdjustedResult { get { throw null; } set { } }
        public bool? IsTrimmed { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> QueryResults { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.Remediation Remediation { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.VaRule RuleMetadata { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RuleStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScanState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ScanState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScanState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ScanState Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ScanState FailedToRun { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ScanState InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ScanState Passed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ScanState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ScanState left, Azure.ResourceManager.SecurityCenter.Models.ScanState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ScanState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ScanState left, Azure.ResourceManager.SecurityCenter.Models.ScanState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScanTriggerType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScanTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType OnDemand { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType Recurring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType left, Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType left, Azure.ResourceManager.SecurityCenter.Models.ScanTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScopeElement
    {
        public ScopeElement() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Field { get { throw null; } set { } }
    }
    public partial class SecureScoreControlDefinitionItem : Azure.ResourceManager.Models.ResourceData
    {
        public SecureScoreControlDefinitionItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> AssessmentDefinitions { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public int? MaxScore { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.ControlType? SourceType { get { throw null; } }
    }
    public partial class SecureScoreControlDetails : Azure.ResourceManager.Models.ResourceData
    {
        public SecureScoreControlDetails() { }
        public double? Current { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem Definition { get { throw null; } set { } }
        public string DisplayName { get { throw null; } }
        public int? HealthyResourceCount { get { throw null; } }
        public int? Max { get { throw null; } }
        public int? NotApplicableResourceCount { get { throw null; } }
        public double? Percentage { get { throw null; } }
        public int? UnhealthyResourceCount { get { throw null; } }
        public long? Weight { get { throw null; } }
    }
    public partial class SecurityAssessmentMetadataPartnerData
    {
        public SecurityAssessmentMetadataPartnerData(string partnerName, string secret) { }
        public string PartnerName { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentMetadataProperties
    {
        public SecurityAssessmentMetadataProperties(string displayName, Azure.ResourceManager.SecurityCenter.Models.Severity severity, Azure.ResourceManager.SecurityCenter.Models.AssessmentType assessmentType) { }
        public Azure.ResourceManager.SecurityCenter.Models.AssessmentType AssessmentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.Category> Categories { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort? ImplementationEffort { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataPartnerData PartnerData { get { throw null; } set { } }
        public string PolicyDefinitionId { get { throw null; } }
        public bool? Preview { get { throw null; } set { } }
        public string RemediationDescription { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.Severity Severity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.Threat> Threats { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.UserImpact? UserImpact { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentMetadataPropertiesResponsePublishDates
    {
        public SecurityAssessmentMetadataPropertiesResponsePublishDates(string @public) { }
        public string GA { get { throw null; } set { } }
        public string Public { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentPartnerData
    {
        public SecurityAssessmentPartnerData(string partnerName, string secret) { }
        public string PartnerName { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentResponseCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityAssessmentResponseCreateOrUpdateContent() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalData { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri LinksAzurePortalUri { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataProperties Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartnerData PartnersData { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AssessmentStatus Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityFamily : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityFamily(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily Ngfw { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily SaasWaf { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily Va { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily Waf { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityFamily left, Azure.ResourceManager.SecurityCenter.Models.SecurityFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityFamily left, Azure.ResourceManager.SecurityCenter.Models.SecurityFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecuritySolutionsReferenceData : Azure.ResourceManager.Models.ResourceData
    {
        public SecuritySolutionsReferenceData(Azure.ResourceManager.SecurityCenter.Models.SecurityFamily securityFamily, string alertVendorName, System.Uri packageInfoUri, string productName, string publisher, string publisherDisplayName, string template) { }
        public string AlertVendorName { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Uri PackageInfoUri { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string PublisherDisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityFamily SecurityFamily { get { throw null; } set { } }
        public string Template { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecuritySolutionStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecuritySolutionStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus left, Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus left, Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityTaskParameters
    {
        public SecurityTaskParameters() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerVulnerabilityAssessmentPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerVulnerabilityAssessmentPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.ServerVulnerabilityAssessmentPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerVulnerabilityProperties : Azure.ResourceManager.SecurityCenter.Models.AdditionalData
    {
        public ServerVulnerabilityProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.CVE> Cve { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.SecurityCenter.Models.Cvss> Cvss { get { throw null; } }
        public bool? Patchable { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public string ServerVulnerabilityPropertiesType { get { throw null; } }
        public string Threat { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.VendorReference> VendorReferences { get { throw null; } }
    }
    public partial class ServicePrincipalProperties
    {
        public ServicePrincipalProperties() { }
        public string ApplicationId { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SettingName : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SettingName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SettingName(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SettingName Mcas { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SettingName Sentinel { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SettingName Wdatp { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SettingName WdatpExcludeLinuxPublicPreview { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SettingName WdatpUnifiedSolution { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SettingName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SettingName left, Azure.ResourceManager.SecurityCenter.Models.SettingName right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SettingName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SettingName left, Azure.ResourceManager.SecurityCenter.Models.SettingName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Severity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Severity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Severity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Severity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Severity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Severity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Severity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Severity left, Azure.ResourceManager.SecurityCenter.Models.Severity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Severity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Severity left, Azure.ResourceManager.SecurityCenter.Models.Severity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SeverityEnum : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SeverityEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeverityEnum(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SeverityEnum High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SeverityEnum Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SeverityEnum Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SeverityEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SeverityEnum left, Azure.ResourceManager.SecurityCenter.Models.SeverityEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SeverityEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SeverityEnum left, Azure.ResourceManager.SecurityCenter.Models.SeverityEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceSystem : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SourceSystem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceSystem(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SourceSystem AzureAppLocker { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SourceSystem AzureAuditD { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SourceSystem NonAzureAppLocker { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SourceSystem NonAzureAuditD { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SourceSystem None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SourceSystem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SourceSystem left, Azure.ResourceManager.SecurityCenter.Models.SourceSystem right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SourceSystem (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SourceSystem left, Azure.ResourceManager.SecurityCenter.Models.SourceSystem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerVulnerabilityProperties : Azure.ResourceManager.SecurityCenter.Models.AdditionalData
    {
        public SqlServerVulnerabilityProperties() { }
        public string Query { get { throw null; } }
        public string SqlServerVulnerabilityPropertiesType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.State Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.State Passed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.State Skipped { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.State Unsupported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.State left, Azure.ResourceManager.SecurityCenter.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.State left, Azure.ResourceManager.SecurityCenter.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Status Initiated { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Status Revoked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Status left, Azure.ResourceManager.SecurityCenter.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Status left, Azure.ResourceManager.SecurityCenter.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusReason : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.StatusReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusReason(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.StatusReason Expired { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.StatusReason NewerRequestInitiated { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.StatusReason UserRequested { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.StatusReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.StatusReason left, Azure.ResourceManager.SecurityCenter.Models.StatusReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.StatusReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.StatusReason left, Azure.ResourceManager.SecurityCenter.Models.StatusReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubAssessmentStatus
    {
        public SubAssessmentStatus() { }
        public string Cause { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode? Code { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.Severity? Severity { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubAssessmentStatusCode : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubAssessmentStatusCode(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode Healthy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode left, Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode left, Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportedCloudEnum : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportedCloudEnum(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum AWS { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum GCP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum left, Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum left, Azure.ResourceManager.SecurityCenter.Models.SupportedCloudEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Tactic : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Tactic>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Tactic(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic Collection { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic CommandAndControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic CredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic DefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic Discovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic Execution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic Exfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic Impact { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic InitialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic LateralMovement { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic Persistence { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic PrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic Reconnaissance { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Tactic ResourceDevelopment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Tactic other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Tactic left, Azure.ResourceManager.SecurityCenter.Models.Tactic right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Tactic (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Tactic left, Azure.ResourceManager.SecurityCenter.Models.Tactic right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagsResource
    {
        public TagsResource() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Technique : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Technique>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Technique(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique AbuseElevationControlMechanism { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique AccessTokenManipulation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique AccountDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique AccountManipulation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ActiveScanning { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ApplicationLayerProtocol { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique AudioCapture { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique BootOrLogonAutostartExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique BootOrLogonInitializationScripts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique BruteForce { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique CloudInfrastructureDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique CloudServiceDashboard { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique CloudServiceDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique CommandAndScriptingInterpreter { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique CompromiseClientSoftwareBinary { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique CompromiseInfrastructure { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ContainerAndResourceDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique CreateAccount { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique CreateOrModifySystemProcess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique CredentialsFromPasswordStores { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DataDestruction { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DataEncryptedForImpact { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DataFromCloudStorageObject { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DataFromConfigurationRepository { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DataFromInformationRepositories { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DataFromLocalSystem { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DataManipulation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DataStaged { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique Defacement { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DeobfuscateDecodeFilesOrInformation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DiskWipe { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DomainTrustDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DriveByCompromise { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique DynamicResolution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique EndpointDenialOfService { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique EventTriggeredExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ExfiltrationOverAlternativeProtocol { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ExploitationForClientExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ExploitationForCredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ExploitationForDefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ExploitationForPrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ExploitationOfRemoteServices { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ExploitPublicFacingApplication { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ExternalRemoteServices { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique FallbackChannels { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique FileAndDirectoryDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique FileAndDirectoryPermissionsModification { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique GatherVictimNetworkInformation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique HideArtifacts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique HijackExecutionFlow { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ImpairDefenses { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ImplantContainerImage { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique IndicatorRemovalOnHost { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique IndirectCommandExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique IngressToolTransfer { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique InputCapture { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique InterProcessCommunication { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique LateralToolTransfer { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ManInTheMiddle { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique Masquerading { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ModifyAuthenticationProcess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ModifyRegistry { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique NetworkDenialOfService { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique NetworkServiceScanning { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique NetworkSniffing { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique NonApplicationLayerProtocol { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique NonStandardPort { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ObfuscatedFilesOrInformation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ObtainCapabilities { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique OfficeApplicationStartup { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique OSCredentialDumping { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique PermissionGroupsDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique Phishing { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique PreOSBoot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ProcessDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ProcessInjection { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ProtocolTunneling { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique Proxy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique QueryRegistry { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique RemoteAccessSoftware { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique RemoteServices { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique RemoteServiceSessionHijacking { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique RemoteSystemDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ResourceHijacking { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ScheduledTaskJob { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ScreenCapture { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique SearchVictimOwnedWebsites { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ServerSoftwareComponent { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ServiceStop { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique SignedBinaryProxyExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique SoftwareDeploymentTools { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique SQLStoredProcedures { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique StealOrForgeKerberosTickets { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique SubvertTrustControls { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique SupplyChainCompromise { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique SystemInformationDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique TaintSharedContent { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique TrafficSignaling { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique TransferDataToCloudAccount { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique TrustedRelationship { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique UnsecuredCredentials { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique UserExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique ValidAccounts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Technique WindowsManagementInstrumentation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Technique other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Technique left, Azure.ResourceManager.SecurityCenter.Models.Technique right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Technique (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Technique left, Azure.ResourceManager.SecurityCenter.Models.Technique right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Threat : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.Threat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Threat(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.Threat AccountBreach { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Threat DataExfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Threat DataSpillage { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Threat DenialOfService { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Threat ElevationOfPrivilege { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Threat MaliciousInsider { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Threat MissingCoverage { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.Threat ThreatResistance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.Threat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.Threat left, Azure.ResourceManager.SecurityCenter.Models.Threat right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.Threat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.Threat left, Azure.ResourceManager.SecurityCenter.Models.Threat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThresholdCustomAlertRule : Azure.ResourceManager.SecurityCenter.Models.CustomAlertRule
    {
        public ThresholdCustomAlertRule(bool isEnabled, int minThreshold, int maxThreshold) : base (default(bool)) { }
        public int MaxThreshold { get { throw null; } set { } }
        public int MinThreshold { get { throw null; } set { } }
    }
    public partial class TimeWindowCustomAlertRule : Azure.ResourceManager.SecurityCenter.Models.ThresholdCustomAlertRule
    {
        public TimeWindowCustomAlertRule(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int)) { }
        public System.TimeSpan TimeWindowSize { get { throw null; } set { } }
    }
    public partial class TopologySingleResource
    {
        internal TopologySingleResource() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.TopologySingleResourceChild> Children { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string NetworkZones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.TopologySingleResourceParent> Parents { get { throw null; } }
        public bool? RecommendationsExist { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string Severity { get { throw null; } }
        public int? TopologyScore { get { throw null; } }
    }
    public partial class TopologySingleResourceChild
    {
        internal TopologySingleResourceChild() { }
        public string ResourceId { get { throw null; } }
    }
    public partial class TopologySingleResourceParent
    {
        internal TopologySingleResourceParent() { }
        public string ResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransportProtocol : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.TransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.TransportProtocol TCP { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.TransportProtocol UDP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.TransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.TransportProtocol left, Azure.ResourceManager.SecurityCenter.Models.TransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.TransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.TransportProtocol left, Azure.ResourceManager.SecurityCenter.Models.TransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TwinUpdatesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public TwinUpdatesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class UnauthorizedOperationsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public UnauthorizedOperationsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmaskedIPLoggingStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmaskedIPLoggingStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus left, Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus left, Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDefinedResourcesProperties
    {
        public UserDefinedResourcesProperties(string query, System.Collections.Generic.IEnumerable<string> querySubscriptions) { }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> QuerySubscriptions { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserImpact : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.UserImpact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserImpact(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.UserImpact High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.UserImpact Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.UserImpact Moderate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.UserImpact other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.UserImpact left, Azure.ResourceManager.SecurityCenter.Models.UserImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.UserImpact (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.UserImpact left, Azure.ResourceManager.SecurityCenter.Models.UserImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserRecommendation
    {
        public UserRecommendation() { }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? RecommendationAction { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VAAutoProvisioningType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VAAutoProvisioningType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType Qualys { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType TVM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType left, Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType left, Azure.ResourceManager.SecurityCenter.Models.VAAutoProvisioningType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValueType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ValueType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValueType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ValueType IPCidr { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ValueType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ValueType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ValueType left, Azure.ResourceManager.SecurityCenter.Models.ValueType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ValueType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ValueType left, Azure.ResourceManager.SecurityCenter.Models.ValueType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaRule
    {
        public VaRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.BenchmarkReference> BenchmarkReferences { get { throw null; } }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.QueryCheck QueryCheck { get { throw null; } set { } }
        public string Rationale { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RuleType? RuleType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RuleSeverity? Severity { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class VendorReference
    {
        internal VendorReference() { }
        public string Link { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class VmRecommendation
    {
        public VmRecommendation() { }
        public Azure.ResourceManager.SecurityCenter.Models.ConfigurationStatus? ConfigurationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.EnforcementSupport? EnforcementSupport { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? RecommendationAction { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
}
