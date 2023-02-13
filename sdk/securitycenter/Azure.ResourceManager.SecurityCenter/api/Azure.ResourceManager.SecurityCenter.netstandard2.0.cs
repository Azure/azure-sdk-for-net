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
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary> Issues { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation> PathRecommendations { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode ProtectionMode { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus? RecommendationStatus { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem? SourceSystem { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation> VmRecommendations { get { throw null; } }
    }
    public partial class AdaptiveApplicationControlGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdaptiveApplicationControlGroupResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation ascLocation, string groupName) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule> Rules { get { throw null; } }
        public System.DateTimeOffset? RulesCalculatedOn { get { throw null; } set { } }
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
        public Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState? AutoProvision { get { throw null; } set { } }
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
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus? ResourceStatus { get { throw null; } }
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
        public Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud? SupportedCloud { get { throw null; } set { } }
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
        public Azure.ResourceManager.SecurityCenter.Models.GovernanceAssignmentAdditionalInfo AdditionalData { get { throw null; } set { } }
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
        public System.DateTimeOffset? AggregatedOn { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.IotSecurityAggregatedAlertTopDevice> TopDevicesList { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionAnalyticsModelDevicesMetrics> DevicesMetrics { get { throw null; } }
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
    public partial class IotSecuritySolutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>, System.Collections.IEnumerable
    {
        protected IotSecuritySolutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionName, Azure.ResourceManager.SecurityCenter.IotSecuritySolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionName, Azure.ResourceManager.SecurityCenter.IotSecuritySolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> Get(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>> GetAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotSecuritySolutionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IotSecuritySolutionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspacesProperties> AdditionalWorkspaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AutoDiscoveredResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource> DisabledDataSources { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption> Export { get { throw null; } }
        public System.Collections.Generic.IList<string> IotHubs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigurationProperties> RecommendationsConfiguration { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.UnmaskedIPLoggingStatus? UnmaskedIPLoggingStatus { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.UserDefinedResourcesProperties UserDefinedResources { get { throw null; } set { } }
        public string Workspace { get { throw null; } set { } }
    }
    public partial class IotSecuritySolutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotSecuritySolutionResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.IotSecuritySolutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.IotSecuritySolutionAnalyticsModelResource GetIotSecuritySolutionAnalyticsModel() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> Update(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>> UpdateAsync(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestInfo> Requests { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyVirtualMachine> VirtualMachines { get { throw null; } }
    }
    public partial class JitNetworkAccessPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JitNetworkAccessPolicyResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation ascLocation, string jitNetworkAccessPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestInfo> Initiate(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestInfo>> InitiateAsync(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState? State { get { throw null; } set { } }
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
        public Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState? State { get { throw null; } set { } }
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
        public Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState? State { get { throw null; } set { } }
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
    public partial class ResourceGroupSecurityAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>, System.Collections.IEnumerable
    {
        protected ResourceGroupSecurityAlertCollection() { }
        public virtual Azure.Response<bool> Exists(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> Get(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>> GetAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupSecurityAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupSecurityAlertResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Activate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation ascLocation, string alertName) { throw null; }
        public virtual Azure.Response Dismiss(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DismissAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resolve(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResolveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSatateToInProgress(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSatateToInProgressAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupSecurityTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>, System.Collections.IEnumerable
    {
        protected ResourceGroupSecurityTaskCollection() { }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupSecurityTaskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupSecurityTaskResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation ascLocation, string taskName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecureScoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecureScoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecureScoreResource>, System.Collections.IEnumerable
    {
        protected SecureScoreCollection() { }
        public virtual Azure.Response<bool> Exists(string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreResource> Get(string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecureScoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecureScoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreResource>> GetAsync(string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecureScoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecureScoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecureScoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecureScoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecureScoreData : Azure.ResourceManager.Models.ResourceData
    {
        public SecureScoreData() { }
        public double? Current { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public int? Max { get { throw null; } }
        public double? Percentage { get { throw null; } }
        public long? Weight { get { throw null; } }
    }
    public partial class SecureScoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecureScoreResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecureScoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string secureScoreName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControlsAsync(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityAlertData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityAlertData() { }
        public string AlertDisplayName { get { throw null; } }
        public string AlertType { get { throw null; } }
        public System.Uri AlertUri { get { throw null; } }
        public string CompromisedEntity { get { throw null; } }
        public string CorrelationKey { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, string>> ExtendedLinks { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get { throw null; } }
        public System.DateTimeOffset? GeneratedOn { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.KillChainIntent? Intent { get { throw null; } }
        public bool? IsIncident { get { throw null; } }
        public System.DateTimeOffset? ProcessingEndOn { get { throw null; } }
        public string ProductComponentName { get { throw null; } }
        public string ProductName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RemediationSteps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertResourceIdentifier> ResourceIdentifiers { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity? Severity { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubTechniques { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSupportingEvidence SupportingEvidence { get { throw null; } set { } }
        public string SystemAlertId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Techniques { get { throw null; } }
        public string VendorName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class SecurityAlertsSuppressionRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource>, System.Collections.IEnumerable
    {
        protected SecurityAlertsSuppressionRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertsSuppressionRuleName, Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertsSuppressionRuleName, Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource> Get(string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource> GetAll(string alertType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource> GetAllAsync(string alertType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource>> GetAsync(string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityAlertsSuppressionRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityAlertsSuppressionRuleData() { }
        public string AlertType { get { throw null; } set { } }
        public string Comment { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Reason { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertsSuppressionRuleState? State { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SuppressionAlertsScopeElement> SuppressionAlertsScopeAllOf { get { throw null; } set { } }
    }
    public partial class SecurityAlertsSuppressionRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityAlertsSuppressionRuleResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string alertsSuppressionRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityApplicationData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityApplicationData() { }
        public System.Collections.Generic.IList<System.BinaryData> ConditionSets { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType? SourceResourceType { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentCollection : Azure.ResourceManager.ArmCollection
    {
        protected SecurityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> Get(string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetAsync(string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityAssessmentData() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalData { get { throw null; } }
        public System.Uri AzurePortalUri { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataProperties Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner PartnersData { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusResult Status { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentMetadataData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityAssessmentMetadataData() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType? AssessmentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory> Categories { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort? ImplementationEffort { get { throw null; } set { } }
        public bool? IsPreview { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataPartner PartnerData { get { throw null; } set { } }
        public string PlannedDeprecationDate { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPublishDates PublishDates { get { throw null; } set { } }
        public string RemediationDescription { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity? Severity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique> Techniques { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityThreat> Threats { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact? UserImpact { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityAssessmentResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> Get(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetAsync(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource> GetGovernanceAssignment(string assignmentKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource>> GetGovernanceAssignmentAsync(string assignmentKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceAssignmentCollection GetGovernanceAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource> GetSecuritySubAssessment(string subAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource>> GetSecuritySubAssessmentAsync(string subAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentCollection GetSecuritySubAssessments() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityAutomationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>, System.Collections.IEnumerable
    {
        protected SecurityAutomationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string automationName, Azure.ResourceManager.SecurityCenter.SecurityAutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string automationName, Azure.ResourceManager.SecurityCenter.SecurityAutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> Get(string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>> GetAsync(string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityAutomationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SecurityAutomationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationAction> Actions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationScope> Scopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationSource> Sources { get { throw null; } }
    }
    public partial class SecurityAutomationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityAutomationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAutomationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityAutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityAutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationValidationStatus> Validate(Azure.ResourceManager.SecurityCenter.SecurityAutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationValidationStatus>> ValidateAsync(Azure.ResourceManager.SecurityCenter.SecurityAutomationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataCollection GetAllSubscriptionAssessmentMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataCollection GetAllTenantAssessmentMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource> GetAutoProvisioningSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource>> GetAutoProvisioningSettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingResource GetAutoProvisioningSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.AutoProvisioningSettingCollection GetAutoProvisioningSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResultResource> GetComplianceResult(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string complianceResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ComplianceResultResource>> GetComplianceResultAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string complianceResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ComplianceResultResource GetComplianceResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ComplianceResultCollection GetComplianceResults(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution>> GetDiscoveredSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string discoveredSecuritySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution>> GetExternalSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string externalSecuritySolutionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.GovernanceAssignmentResource GetGovernanceAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.IngestionSettingResource> GetIngestionSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IngestionSettingResource>> GetIngestionSettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IngestionSettingResource GetIngestionSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IngestionSettingCollection GetIngestionSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedAlertResource GetIotSecurityAggregatedAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecurityAggregatedRecommendationResource GetIotSecurityAggregatedRecommendationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> GetIotSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecuritySolutionAnalyticsModelResource GetIotSecuritySolutionAnalyticsModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource>> GetIotSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource GetIotSecuritySolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.IotSecuritySolutionCollection GetIotSecuritySolutions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> GetIotSecuritySolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.IotSecuritySolutionResource> GetIotSecuritySolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyCollection GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string jitNetworkAccessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource>> GetJitNetworkAccessPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string jitNetworkAccessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource GetJitNetworkAccessPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboarding(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>> GetMdeOnboardingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardingsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RegulatoryComplianceAssessmentResource GetRegulatoryComplianceAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RegulatoryComplianceControlResource GetRegulatoryComplianceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource> GetRegulatoryComplianceStandard(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string regulatoryComplianceStandardName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource>> GetRegulatoryComplianceStandardAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string regulatoryComplianceStandardName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardResource GetRegulatoryComplianceStandardResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.RegulatoryComplianceStandardCollection GetRegulatoryComplianceStandards(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> GetResourceGroupSecurityAlert(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>> GetResourceGroupSecurityAlertAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource GetResourceGroupSecurityAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertCollection GetResourceGroupSecurityAlerts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> GetResourceGroupSecurityTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>> GetResourceGroupSecurityTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource GetResourceGroupSecurityTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskCollection GetResourceGroupSecurityTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreResource> GetSecureScore(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecureScoreResource>> GetSecureScoreAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string secureScoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem> GetSecureScoreControlDefinitions(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem> GetSecureScoreControlDefinitionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem> GetSecureScoreControlDefinitionsBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem> GetSecureScoreControlDefinitionsBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControlsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecureScoreResource GetSecureScoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecureScoreCollection GetSecureScores(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource> GetSecurityAlertsSuppressionRule(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource>> GetSecurityAlertsSuppressionRuleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string alertsSuppressionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleResource GetSecurityAlertsSuppressionRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityAlertsSuppressionRuleCollection GetSecurityAlertsSuppressionRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> GetSecurityAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetSecurityAssessmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource GetSecurityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityAssessmentCollection GetSecurityAssessments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> GetSecurityAutomation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource>> GetSecurityAutomationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string automationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityAutomationResource GetSecurityAutomationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityAutomationCollection GetSecurityAutomations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> GetSecurityAutomations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAutomationResource> GetSecurityAutomationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> GetSecurityCenterLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetSecurityCenterLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource GetSecurityCenterLocationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterLocationCollection GetSecurityCenterLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> GetSecurityCenterPricing(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>> GetSecurityCenterPricingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource GetSecurityCenterPricingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterPricingCollection GetSecurityCenterPricings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetSecurityCloudConnector(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetSecurityCloudConnectorAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource GetSecurityCloudConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorCollection GetSecurityCloudConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource> GetSecurityCompliance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource>> GetSecurityComplianceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityComplianceResource GetSecurityComplianceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityComplianceCollection GetSecurityCompliances(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> GetSecuritySetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetSecuritySettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecuritySettingResource GetSecuritySettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecuritySettingCollection GetSecuritySettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution> GetSecuritySolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution>> GetSecuritySolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string securitySolutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution> GetSecuritySolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution> GetSecuritySolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecuritySubAssessmentResource GetSecuritySubAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource> GetSecurityWorkspaceSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource>> GetSecurityWorkspaceSettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource GetSecurityWorkspaceSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingCollection GetSecurityWorkspaceSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource GetServerVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryCollection GetSoftwareInventories(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventoriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventory(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetSoftwareInventoryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource GetSoftwareInventoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetSqlVulnerabilityAssessmentBaselineRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetSqlVulnerabilityAssessmentBaselineRuleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource GetSqlVulnerabilityAssessmentBaselineRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleCollection GetSqlVulnerabilityAssessmentBaselineRules(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetSqlVulnerabilityAssessmentScan(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetSqlVulnerabilityAssessmentScanAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource GetSqlVulnerabilityAssessmentScanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanCollection GetSqlVulnerabilityAssessmentScans(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> GetSubscriptionAssessmentMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> GetSubscriptionAssessmentMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource GetSubscriptionAssessmentMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource GetSubscriptionSecurityAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> GetSubscriptionSecurityApplication(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>> GetSubscriptionSecurityApplicationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource GetSubscriptionSecurityApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationCollection GetSubscriptionSecurityApplications(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource GetSubscriptionSecurityTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityTaskData> GetTasks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityTaskData> GetTasksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> GetTenantAssessmentMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource, string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>> GetTenantAssessmentMetadataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource GetTenantAssessmentMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopology(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource>> GetTopologyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string topologyResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityCenterLocationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>, System.Collections.IEnumerable
    {
        protected SecurityCenterLocationCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> Get(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetAsync(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityCenterLocationData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityCenterLocationData() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class SecurityCenterLocationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityCenterLocationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityCenterLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation ascLocation) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAdaptiveApplicationControlGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupCollection GetAdaptiveApplicationControlGroups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolutionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource> GetSubscriptionSecurityAlert(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource>> GetSubscriptionSecurityAlertAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertCollection GetSubscriptionSecurityAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource> GetSubscriptionSecurityTask(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource>> GetSubscriptionSecurityTaskAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskCollection GetSubscriptionSecurityTasks() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityCenterPricingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>, System.Collections.IEnumerable
    {
        protected SecurityCenterPricingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string pricingName, Azure.ResourceManager.SecurityCenter.SecurityCenterPricingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string pricingName, Azure.ResourceManager.SecurityCenter.SecurityCenterPricingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> Get(string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>> GetAsync(string pricingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityCenterPricingData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityCenterPricingData() { }
        public System.TimeSpan? FreeTrialRemainingTime { get { throw null; } }
        public bool? IsDeprecated { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier? PricingTier { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> ReplacedBy { get { throw null; } }
        public string SubPlan { get { throw null; } set { } }
    }
    public partial class SecurityCenterPricingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityCenterPricingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityCenterPricingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string pricingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityCenterPricingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCenterPricingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityCenterPricingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityCloudConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>, System.Collections.IEnumerable
    {
        protected SecurityCloudConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityCloudConnectorData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityCloudConnectorData() { }
        public Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties AuthenticationDetails { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties HybridComputeSettings { get { throw null; } set { } }
    }
    public partial class SecurityCloudConnectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityCloudConnectorResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityComplianceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource>, System.Collections.IEnumerable
    {
        protected SecurityComplianceCollection() { }
        public virtual Azure.Response<bool> Exists(string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource> Get(string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource>> GetAsync(string complianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityComplianceData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityComplianceData() { }
        public System.DateTimeOffset? AssessedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.ComplianceSegment> AssessmentResult { get { throw null; } }
        public int? ResourceCount { get { throw null; } }
    }
    public partial class SecurityComplianceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityComplianceResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityComplianceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string complianceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityComplianceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityConnectorApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>, System.Collections.IEnumerable
    {
        protected SecurityConnectorApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.SecurityCenter.SecurityApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string securityConnectorName, string applicationId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment EnvironmentData { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName? EnvironmentName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string HierarchyIdentifier { get { throw null; } set { } }
        public System.DateTimeOffset? HierarchyIdentifierTrialEndOn { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering> Offerings { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation ExecuteRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus> GetRuleExecutionStatus(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>> GetRuleExecutionStatusAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.SecurityCenter.Models.SecurityContactPropertiesAlertNotifications AlertNotifications { get { throw null; } set { } }
        public string Emails { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityContactPropertiesNotificationsByRole NotificationsByRole { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityContactResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecuritySettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>, System.Collections.IEnumerable
    {
        protected SecuritySettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, Azure.ResourceManager.SecurityCenter.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, Azure.ResourceManager.SecurityCenter.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> Get(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetAsync(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecuritySettingData : Azure.ResourceManager.Models.ResourceData
    {
        public SecuritySettingData() { }
    }
    public partial class SecuritySettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecuritySettingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecuritySettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.SecurityCenter.Models.SecuritySubAssessmentAdditionalInfo AdditionalData { get { throw null; } set { } }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? GeneratedOn { get { throw null; } }
        public string Impact { get { throw null; } }
        public string Remediation { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatus Status { get { throw null; } set { } }
        public string VulnerabilityId { get { throw null; } }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastStateChangedOn { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityTaskProperties SecurityTaskParameters { get { throw null; } set { } }
        public string State { get { throw null; } }
        public string SubState { get { throw null; } }
    }
    public partial class SecurityWorkspaceSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource>, System.Collections.IEnumerable
    {
        protected SecurityWorkspaceSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceSettingName, Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceSettingName, Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource> Get(string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource>> GetAsync(string workspaceSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityWorkspaceSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityWorkspaceSettingData() { }
        public string Scope { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } set { } }
    }
    public partial class SecurityWorkspaceSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityWorkspaceSettingResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string workspaceSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource> Update(Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingResource>> UpdateAsync(Azure.ResourceManager.SecurityCenter.SecurityWorkspaceSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SoftwareInventoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>, System.Collections.IEnumerable
    {
        protected SoftwareInventoryCollection() { }
        public virtual Azure.Response<bool> Exists(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> Get(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetAsync(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SoftwareInventoryData : Azure.ResourceManager.Models.ResourceData
    {
        public SoftwareInventoryData() { }
        public string DeviceId { get { throw null; } set { } }
        public string EndOfSupportDate { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus? EndOfSupportStatus { get { throw null; } set { } }
        public System.DateTimeOffset? FirstSeenOn { get { throw null; } set { } }
        public int? NumberOfKnownVulnerabilities { get { throw null; } set { } }
        public string OSPlatform { get { throw null; } set { } }
        public string SoftwareName { get { throw null; } set { } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class SoftwareInventoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SoftwareInventoryResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SoftwareInventoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceNamespace, string resourceType, string resourceName, string softwareName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlVulnerabilityAssessmentBaselineRuleCollection : Azure.ResourceManager.ArmCollection
    {
        protected SqlVulnerabilityAssessmentBaselineRuleCollection() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> AddRules(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> AddRulesAsync(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Get(string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use AddRules().", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAll(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAll(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use AddRulesAsync().", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAllAsync(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAllAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetAsync(string ruleId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlVulnerabilityAssessmentBaselineRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlVulnerabilityAssessmentBaselineRuleData() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> RuleResults { get { throw null; } }
    }
    public partial class SqlVulnerabilityAssessmentBaselineRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlVulnerabilityAssessmentBaselineRuleResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string ruleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Get(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Update(Azure.WaitUntil waitUntil, System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlVulnerabilityAssessmentScanCollection : Azure.ResourceManager.ArmCollection
    {
        protected SqlVulnerabilityAssessmentScanCollection() { }
        public virtual Azure.Response<bool> Exists(string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> Get(string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetAll(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetAllAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetAsync(string scanId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlVulnerabilityAssessmentScanData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlVulnerabilityAssessmentScanData() { }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanProperties Properties { get { throw null; } set { } }
    }
    public partial class SqlVulnerabilityAssessmentScanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlVulnerabilityAssessmentScanResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string scanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> Get(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResult(string scanResultId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult>> GetSqlVulnerabilityAssessmentScanResultAsync(string scanResultId, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResults(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResultsAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionAssessmentMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>, System.Collections.IEnumerable
    {
        protected SubscriptionAssessmentMetadataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentMetadataName, Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentMetadataName, Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string assessmentMetadataName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionAssessmentMetadataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation ExecuteRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus> GetRuleExecutionStatus(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>> GetRuleExecutionStatusAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionSecurityAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource>, System.Collections.IEnumerable
    {
        protected SubscriptionSecurityAlertCollection() { }
        public virtual Azure.Response<bool> Exists(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource> Get(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource>> GetAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Simulate(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SimulateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionSecurityAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionSecurityAlertResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Activate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation ascLocation, string alertName) { throw null; }
        public virtual Azure.Response Dismiss(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DismissAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resolve(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResolveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSatateToInProgress(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSatateToInProgressAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionSecurityApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>, System.Collections.IEnumerable
    {
        protected SubscriptionSecurityApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> Get(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>> GetAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionSecurityApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionSecurityApplicationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string applicationId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionSecurityTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource>, System.Collections.IEnumerable
    {
        protected SubscriptionSecurityTaskCollection() { }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionSecurityTaskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionSecurityTaskResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation ascLocation, string taskName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionSecurityTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.SecurityCenter.SecurityAssessmentMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string assessmentMetadataName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.TenantAssessmentMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SecurityCenter.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AadConnectivityStateType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AadConnectivityStateType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType Connected { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType Discovered { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType NotLicensed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType left, Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType left, Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AadExternalSecuritySolution : Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution
    {
        public AadExternalSecuritySolution() { }
        public Azure.ResourceManager.SecurityCenter.Models.AadSolutionProperties Properties { get { throw null; } set { } }
    }
    public partial class AadSolutionProperties : Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionProperties
    {
        public AadSolutionProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.AadConnectivityStateType? ConnectivityState { get { throw null; } set { } }
    }
    public partial class ActiveConnectionsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public ActiveConnectionsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdaptiveApplicationControlEnforcementMode : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdaptiveApplicationControlEnforcementMode(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode Audit { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode Enforce { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdaptiveApplicationControlGroupSourceSystem : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdaptiveApplicationControlGroupSourceSystem(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem AzureAppLocker { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem AzureAuditD { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem NonAzureAppLocker { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem NonAzureAuditD { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem right) { throw null; }
        public override string ToString() { throw null; }
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
        public AdaptiveNetworkHardeningEnforceContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule> rules, System.Collections.Generic.IEnumerable<string> networkSecurityGroups) { }
        public System.Collections.Generic.IList<string> NetworkSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule> Rules { get { throw null; } }
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
    public partial class AtaExternalSecuritySolution : Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution
    {
        public AtaExternalSecuritySolution() { }
        public Azure.ResourceManager.SecurityCenter.Models.AtaSolutionProperties Properties { get { throw null; } set { } }
    }
    public partial class AtaSolutionProperties : Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionProperties
    {
        public AtaSolutionProperties() { }
        public string LastEventReceived { get { throw null; } set { } }
    }
    public abstract partial class AuthenticationDetailsProperties
    {
        protected AuthenticationDetailsProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState? AuthenticationProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission> GrantedPermissions { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationTriggeringRuleOperator : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationTriggeringRuleOperator(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator GreaterThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator LesserThan { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator LesserThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator NotEquals { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator StartsWith { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator left, Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator left, Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationTriggeringRulePropertyType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationTriggeringRulePropertyType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType Boolean { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType Integer { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType Number { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType left, Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType left, Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoProvisionState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoProvisionState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState Off { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState left, Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState left, Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState right) { throw null; }
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
    public partial class AwsAssumeRoleAuthenticationDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties
    {
        public AwsAssumeRoleAuthenticationDetailsProperties(string awsAssumeRoleArn, System.Guid awsExternalId) { }
        public string AccountId { get { throw null; } }
        public string AwsAssumeRoleArn { get { throw null; } set { } }
        public System.Guid AwsExternalId { get { throw null; } set { } }
    }
    public partial class AwsCredsAuthenticationDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties
    {
        public AwsCredsAuthenticationDetailsProperties(string awsAccessKeyId, string awsSecretAccessKey) { }
        public string AccountId { get { throw null; } }
        public string AwsAccessKeyId { get { throw null; } set { } }
        public string AwsSecretAccessKey { get { throw null; } set { } }
    }
    public partial class AwsEnvironment : Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment
    {
        public AwsEnvironment() { }
        public Azure.ResourceManager.SecurityCenter.Models.AwsOrganizationalInfo OrganizationalData { get { throw null; } set { } }
    }
    public partial class AwsOrganizationalDataMaster : Azure.ResourceManager.SecurityCenter.Models.AwsOrganizationalInfo
    {
        public AwsOrganizationalDataMaster() { }
        public System.Collections.Generic.IList<string> ExcludedAccountIds { get { throw null; } }
        public string StacksetName { get { throw null; } set { } }
    }
    public partial class AwsOrganizationalDataMember : Azure.ResourceManager.SecurityCenter.Models.AwsOrganizationalInfo
    {
        public AwsOrganizationalDataMember() { }
        public string ParentHierarchyId { get { throw null; } set { } }
    }
    public abstract partial class AwsOrganizationalInfo
    {
        protected AwsOrganizationalInfo() { }
    }
    public partial class AzureDevOpsScopeEnvironment : Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment
    {
        public AzureDevOpsScopeEnvironment() { }
    }
    public partial class AzureResourceDetails : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterResourceDetails
    {
        public AzureResourceDetails() { }
        public string Id { get { throw null; } }
    }
    public partial class AzureResourceIdentifier : Azure.ResourceManager.SecurityCenter.Models.SecurityAlertResourceIdentifier
    {
        internal AzureResourceIdentifier() { }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } }
    }
    public partial class BaselineAdjustedResult
    {
        public BaselineAdjustedResult() { }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaseline Baseline { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> ResultsNotInBaseline { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> ResultsOnlyInBaseline { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus? Status { get { throw null; } set { } }
    }
    public partial class BenchmarkReference
    {
        public BenchmarkReference() { }
        public string Benchmark { get { throw null; } set { } }
        public string Reference { get { throw null; } set { } }
    }
    public partial class CefExternalSecuritySolution : Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution
    {
        public CefExternalSecuritySolution() { }
        public Azure.ResourceManager.SecurityCenter.Models.CefSolutionProperties Properties { get { throw null; } set { } }
    }
    public partial class CefSolutionProperties : Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionProperties
    {
        public CefSolutionProperties() { }
        public string Agent { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string LastEventReceived { get { throw null; } set { } }
    }
    public partial class ComplianceSegment
    {
        internal ComplianceSegment() { }
        public double? Percentage { get { throw null; } }
        public string SegmentType { get { throw null; } }
    }
    public partial class ConnectableResourceInfo
    {
        internal ConnectableResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.ConnectedResourceInfo> InboundConnectedResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.ConnectedResourceInfo> OutboundConnectedResources { get { throw null; } }
    }
    public partial class ConnectedResourceInfo
    {
        internal ConnectedResourceInfo() { }
        public Azure.Core.ResourceIdentifier ConnectedResourceId { get { throw null; } }
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
    public partial class ContainerRegistryVulnerabilityProperties : Azure.ResourceManager.SecurityCenter.Models.SecuritySubAssessmentAdditionalInfo
    {
        public ContainerRegistryVulnerabilityProperties() { }
        public string ContainerRegistryVulnerabilityPropertiesType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.SecurityCve> Cve { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.SecurityCenter.Models.SecurityCvss> Cvss { get { throw null; } }
        public string ImageDigest { get { throw null; } }
        public bool? IsPatchable { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public string RepositoryName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.VendorReference> VendorReferences { get { throw null; } }
    }
    public partial class CspmMonitorAwsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public CspmMonitorAwsOffering() { }
        public string CloudRoleArn { get { throw null; } set { } }
    }
    public partial class CspmMonitorAzureDevOpsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public CspmMonitorAzureDevOpsOffering() { }
    }
    public partial class CspmMonitorGcpOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
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
    public partial class CspmMonitorGithubOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
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
        public Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud? SupportedCloud { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomAssessmentAutomationSupportedCloud : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomAssessmentAutomationSupportedCloud(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud Aws { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud Gcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud left, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud left, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomAssessmentSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomAssessmentSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity left, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity left, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomEntityStoreAssignmentCreateOrUpdateContent
    {
        public CustomEntityStoreAssignmentCreateOrUpdateContent() { }
        public string Principal { get { throw null; } set { } }
    }
    public partial class DataExportSettings : Azure.ResourceManager.SecurityCenter.SecuritySettingData
    {
        public DataExportSettings() { }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class DefenderCspmAwsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderCspmAwsOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderCspmAwsOfferingVmScanners VmScanners { get { throw null; } set { } }
    }
    public partial class DefenderCspmAwsOfferingVmScanners
    {
        public DefenderCspmAwsOfferingVmScanners() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderCspmAwsOfferingVmScannersConfiguration Configuration { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class DefenderCspmAwsOfferingVmScannersConfiguration
    {
        public DefenderCspmAwsOfferingVmScannersConfiguration() { }
        public string CloudRoleArn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExclusionTags { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode? ScanningMode { get { throw null; } set { } }
    }
    public partial class DefenderCspmGcpOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderCspmGcpOffering() { }
    }
    public partial class DefenderForContainersAwsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderForContainersAwsOffering() { }
        public string CloudRoleArn { get { throw null; } set { } }
        public string ContainerVulnerabilityAssessmentCloudRoleArn { get { throw null; } set { } }
        public string ContainerVulnerabilityAssessmentTaskCloudRoleArn { get { throw null; } set { } }
        public bool? IsAutoProvisioningEnabled { get { throw null; } set { } }
        public bool? IsContainerVulnerabilityAssessmentEnabled { get { throw null; } set { } }
        public string KinesisToS3CloudRoleArn { get { throw null; } set { } }
        public long? KubeAuditRetentionTime { get { throw null; } set { } }
        public string KubernetesScubaReaderCloudRoleArn { get { throw null; } set { } }
        public string KubernetesServiceCloudRoleArn { get { throw null; } set { } }
        public string ScubaExternalId { get { throw null; } set { } }
    }
    public partial class DefenderForContainersGcpOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderForContainersGcpOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForContainersGcpOfferingDataPipelineNativeCloudConnection DataPipelineNativeCloudConnection { get { throw null; } set { } }
        public bool? IsAuditLogsAutoProvisioningEnabled { get { throw null; } set { } }
        public bool? IsDefenderAgentAutoProvisioningEnabled { get { throw null; } set { } }
        public bool? IsPolicyAgentAutoProvisioningEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForContainersGcpOfferingNativeCloudConnection NativeCloudConnection { get { throw null; } set { } }
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
    public partial class DefenderForDatabasesAwsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderForDatabasesAwsOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds Rds { get { throw null; } set { } }
    }
    public partial class DefenderForDatabasesAwsOfferingArcAutoProvisioning
    {
        public DefenderForDatabasesAwsOfferingArcAutoProvisioning() { }
        public string CloudRoleArn { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class DefenderForDatabasesAwsOfferingRds
    {
        public DefenderForDatabasesAwsOfferingRds() { }
        public string CloudRoleArn { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class DefenderForDatabasesGcpOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderForDatabasesGcpOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.GcpDefenderForDatabasesArcAutoProvisioning DefenderForDatabasesArcAutoProvisioning { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class DefenderForDevOpsAzureDevOpsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderForDevOpsAzureDevOpsOffering() { }
    }
    public partial class DefenderForDevOpsGithubOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderForDevOpsGithubOffering() { }
    }
    public partial class DefenderForServersAwsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderForServersAwsOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType? AvailableSubPlanType { get { throw null; } set { } }
        public string DefenderForServersCloudRoleArn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingMdeAutoProvisioning MdeAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning VaAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingVmScanners VmScanners { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingArcAutoProvisioning
    {
        public DefenderForServersAwsOfferingArcAutoProvisioning() { }
        public string CloudRoleArn { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingMdeAutoProvisioning
    {
        public DefenderForServersAwsOfferingMdeAutoProvisioning() { }
        public System.BinaryData Configuration { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingVmScanners
    {
        public DefenderForServersAwsOfferingVmScanners() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingVmScannersConfiguration Configuration { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingVmScannersConfiguration
    {
        public DefenderForServersAwsOfferingVmScannersConfiguration() { }
        public string CloudRoleArn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExclusionTags { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode? ScanningMode { get { throw null; } set { } }
    }
    public partial class DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning
    {
        public DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType? VulnerabilityAssessmentAutoProvisioningType { get { throw null; } set { } }
    }
    public partial class DefenderForServersGcpOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
    {
        public DefenderForServersGcpOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType? AvailableSubPlanType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.GcpDefenderForServersInfo DefenderForServers { get { throw null; } set { } }
        public bool? IsArcAutoProvisioningEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingMdeAutoProvisioning MdeAutoProvisioning { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning VulnerabilityAssessmentAutoProvisioning { get { throw null; } set { } }
    }
    public partial class DefenderForServersGcpOfferingMdeAutoProvisioning
    {
        public DefenderForServersGcpOfferingMdeAutoProvisioning() { }
        public System.BinaryData Configuration { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning
    {
        public DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType? VulnerabilityAssessmentAutoProvisioningType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefenderForServersScanningMode : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefenderForServersScanningMode(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode left, Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode left, Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DenylistCustomAlertRule : Azure.ResourceManager.SecurityCenter.Models.ListCustomAlertRule
    {
        public DenylistCustomAlertRule(bool isEnabled, System.Collections.Generic.IEnumerable<string> denylistValues) : base (default(bool)) { }
        public System.Collections.Generic.IList<string> DenylistValues { get { throw null; } }
    }
    public partial class DirectMethodInvokesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public DirectMethodInvokesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class DiscoveredSecuritySolution : Azure.ResourceManager.Models.ResourceData
    {
        public DiscoveredSecuritySolution(Azure.ResourceManager.SecurityCenter.Models.SecurityFamily securityFamily, string offer, string publisher, string sku) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityFamily SecurityFamily { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
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
    public partial class ExternalSecuritySolution : Azure.ResourceManager.Models.ResourceData
    {
        public ExternalSecuritySolution() { }
        public Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind? Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExternalSecuritySolutionKind : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExternalSecuritySolutionKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind Aad { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind Ata { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind Cef { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind left, Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind left, Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExternalSecuritySolutionProperties
    {
        public ExternalSecuritySolutionProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string DeviceType { get { throw null; } set { } }
        public string DeviceVendor { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } set { } }
    }
    public partial class FailedLocalLoginsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public FailedLocalLoginsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class FileUploadsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule
    {
        public FileUploadsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base (default(bool), default(int), default(int), default(System.TimeSpan)) { }
    }
    public partial class GcpCredentialsDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties
    {
        public GcpCredentialsDetailsProperties(string organizationId, string gcpCredentialType, string projectId, string privateKeyId, string privateKey, string clientEmail, string clientId, System.Uri authUri, System.Uri tokenUri, System.Uri authProviderX509CertUri, System.Uri clientX509CertUri) { }
        public System.Uri AuthProviderX509CertUri { get { throw null; } set { } }
        public System.Uri AuthUri { get { throw null; } set { } }
        public string ClientEmail { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public System.Uri ClientX509CertUri { get { throw null; } set { } }
        public string GcpCredentialType { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string PrivateKey { get { throw null; } set { } }
        public string PrivateKeyId { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public System.Uri TokenUri { get { throw null; } set { } }
    }
    public partial class GcpDefenderForDatabasesArcAutoProvisioning
    {
        public GcpDefenderForDatabasesArcAutoProvisioning() { }
        public string ServiceAccountEmailAddress { get { throw null; } set { } }
        public string WorkloadIdentityProviderId { get { throw null; } set { } }
    }
    public partial class GcpDefenderForServersInfo
    {
        public GcpDefenderForServersInfo() { }
        public string ServiceAccountEmailAddress { get { throw null; } set { } }
        public string WorkloadIdentityProviderId { get { throw null; } set { } }
    }
    public partial class GcpMemberOrganizationalInfo : Azure.ResourceManager.SecurityCenter.Models.GcpOrganizationalInfo
    {
        public GcpMemberOrganizationalInfo() { }
        public string ManagementProjectNumber { get { throw null; } set { } }
        public string ParentHierarchyId { get { throw null; } set { } }
    }
    public abstract partial class GcpOrganizationalInfo
    {
        protected GcpOrganizationalInfo() { }
    }
    public partial class GcpParentOrganizationalInfo : Azure.ResourceManager.SecurityCenter.Models.GcpOrganizationalInfo
    {
        public GcpParentOrganizationalInfo() { }
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
    public partial class GcpProjectEnvironment : Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment
    {
        public GcpProjectEnvironment() { }
        public Azure.ResourceManager.SecurityCenter.Models.GcpOrganizationalInfo OrganizationalData { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.GcpProjectDetails ProjectDetails { get { throw null; } set { } }
    }
    public partial class GithubScopeEnvironment : Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment
    {
        public GithubScopeEnvironment() { }
    }
    public partial class GovernanceAssignmentAdditionalInfo
    {
        public GovernanceAssignmentAdditionalInfo() { }
        public string TicketLink { get { throw null; } set { } }
        public int? TicketNumber { get { throw null; } set { } }
        public string TicketStatus { get { throw null; } set { } }
    }
    public partial class GovernanceEmailNotification
    {
        public GovernanceEmailNotification() { }
        public bool? IsManagerEmailNotificationDisabled { get { throw null; } set { } }
        public bool? IsOwnerEmailNotificationDisabled { get { throw null; } set { } }
    }
    public partial class GovernanceRuleEmailNotification
    {
        public GovernanceRuleEmailNotification() { }
        public bool? IsManagerEmailNotificationDisabled { get { throw null; } set { } }
        public bool? IsOwnerEmailNotificationDisabled { get { throw null; } set { } }
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
        public HybridComputeSettingsProperties(Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState autoProvision) { }
        public Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState AutoProvision { get { throw null; } set { } }
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
    public partial class InformationProtectionAwsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering
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
    public partial class IotSecurityAggregatedAlertTopDevice
    {
        internal IotSecurityAggregatedAlertTopDevice() { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotSecurityRecommendationType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotSecurityRecommendationType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotAcrAuthentication { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotAgentSendsUnutilizedMessages { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotBaseline { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotEdgeHubMemOptimize { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotEdgeLoggingOptions { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotInconsistentModuleSettings { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotInstallAgent { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotIPFilterDenyAll { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotIPFilterPermissiveRule { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotOpenPorts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPermissiveFirewallPolicy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPermissiveInputFirewallRules { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPermissiveOutputFirewallRules { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPrivilegedDockerOptions { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotSharedCredentials { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotVulnerableTlsCipherSuite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType left, Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType left, Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotSecuritySolutionAnalyticsModelDevicesMetrics
    {
        internal IotSecuritySolutionAnalyticsModelDevicesMetrics() { }
        public System.DateTimeOffset? Date { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.IotSeverityMetrics DevicesMetrics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotSecuritySolutionDataSource : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotSecuritySolutionDataSource(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource TwinData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource left, Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource left, Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionDataSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotSecuritySolutionExportOption : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotSecuritySolutionExportOption(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption RawEvents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption left, Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption left, Azure.ResourceManager.SecurityCenter.Models.IotSecuritySolutionExportOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotSecuritySolutionPatch : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterTagsResourceInfo
    {
        public IotSecuritySolutionPatch() { }
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
        public JitNetworkAccessPolicyInitiatePort(int number, System.DateTimeOffset endOn) { }
        public string AllowedSourceAddressPrefix { get { throw null; } set { } }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public int Number { get { throw null; } }
    }
    public partial class JitNetworkAccessPolicyInitiateVirtualMachine
    {
        public JitNetworkAccessPolicyInitiateVirtualMachine(Azure.Core.ResourceIdentifier id, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiatePort> ports) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPolicyInitiatePort> Ports { get { throw null; } }
    }
    public partial class JitNetworkAccessPolicyVirtualMachine
    {
        public JitNetworkAccessPolicyVirtualMachine(Azure.Core.ResourceIdentifier id, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortRule> ports) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortRule> Ports { get { throw null; } }
        public string PublicIPAddress { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitNetworkAccessPortProtocol : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitNetworkAccessPortProtocol(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol All { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol left, Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol left, Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JitNetworkAccessPortRule
    {
        public JitNetworkAccessPortRule(int number, Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol protocol, System.TimeSpan maxRequestAccessDuration) { }
        public string AllowedSourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AllowedSourceAddressPrefixes { get { throw null; } }
        public System.TimeSpan MaxRequestAccessDuration { get { throw null; } set { } }
        public int Number { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol Protocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitNetworkAccessPortStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitNetworkAccessPortStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus Initiated { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus Revoked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus left, Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus left, Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitNetworkAccessPortStatusReason : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitNetworkAccessPortStatusReason(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason Expired { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason NewerRequestInitiated { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason UserRequested { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason left, Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason left, Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JitNetworkAccessRequestInfo
    {
        public JitNetworkAccessRequestInfo(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestVirtualMachine> virtualMachines, System.DateTimeOffset startOn, string requestor) { }
        public string Justification { get { throw null; } set { } }
        public string Requestor { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestVirtualMachine> VirtualMachines { get { throw null; } }
    }
    public partial class JitNetworkAccessRequestPort
    {
        public JitNetworkAccessRequestPort(int number, System.DateTimeOffset endOn, Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus status, Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason statusReason) { }
        public string AllowedSourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AllowedSourceAddressPrefixes { get { throw null; } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public int? MappedPort { get { throw null; } set { } }
        public int Number { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatus Status { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortStatusReason StatusReason { get { throw null; } set { } }
    }
    public partial class JitNetworkAccessRequestVirtualMachine
    {
        public JitNetworkAccessRequestVirtualMachine(Azure.Core.ResourceIdentifier id, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestPort> ports) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessRequestPort> Ports { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KillChainIntent : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.KillChainIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KillChainIntent(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent Collection { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent CommandAndControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent CredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent DefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent Discovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent Execution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent Exfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent Exploitation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent Impact { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent InitialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent LateralMovement { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent Persistence { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent PreAttack { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent PrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent Probing { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.KillChainIntent Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.KillChainIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.KillChainIntent left, Azure.ResourceManager.SecurityCenter.Models.KillChainIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.KillChainIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.KillChainIntent left, Azure.ResourceManager.SecurityCenter.Models.KillChainIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ListCustomAlertRule : Azure.ResourceManager.SecurityCenter.Models.CustomAlertRule
    {
        public ListCustomAlertRule(bool isEnabled) : base (default(bool)) { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityValueType? ValueType { get { throw null; } }
    }
    public partial class LocalUserNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule
    {
        public LocalUserNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base (default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
    }
    public partial class LogAnalyticsIdentifier : Azure.ResourceManager.SecurityCenter.Models.SecurityAlertResourceIdentifier
    {
        internal LogAnalyticsIdentifier() { }
        public System.Guid? AgentId { get { throw null; } }
        public System.Guid? WorkspaceId { get { throw null; } }
        public string WorkspaceResourceGroup { get { throw null; } }
        public string WorkspaceSubscriptionId { get { throw null; } }
    }
    public partial class MdeOnboarding : Azure.ResourceManager.Models.ResourceData
    {
        public MdeOnboarding() { }
        public byte[] OnboardingPackageLinux { get { throw null; } set { } }
        public byte[] OnboardingPackageWindows { get { throw null; } set { } }
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
    public partial class OnPremiseResourceDetails : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterResourceDetails
    {
        public OnPremiseResourceDetails(Azure.Core.ResourceIdentifier workspaceId, System.Guid vmUuid, string sourceComputerId, string machineName) { }
        public string MachineName { get { throw null; } set { } }
        public string SourceComputerId { get { throw null; } set { } }
        public System.Guid VmUuid { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } set { } }
    }
    public partial class OnPremiseSqlResourceDetails : Azure.ResourceManager.SecurityCenter.Models.OnPremiseResourceDetails
    {
        public OnPremiseSqlResourceDetails(Azure.Core.ResourceIdentifier workspaceId, System.Guid vmUuid, string sourceComputerId, string machineName, string serverName, string databaseName) : base (default(Azure.Core.ResourceIdentifier), default(System.Guid), default(string), default(string)) { }
        public string DatabaseName { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
    }
    public partial class PathRecommendation
    {
        public PathRecommendation() { }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? Action { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType? FileType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType? IotSecurityRecommendationType { get { throw null; } set { } }
        public bool? IsCommon { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo PublisherInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation> Usernames { get { throw null; } }
        public System.Collections.Generic.IList<string> UserSids { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PathRecommendationFileType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PathRecommendationFileType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Dll { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Exe { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Executable { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Msi { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Script { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType left, Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType left, Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProcessNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule
    {
        public ProcessNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base (default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
    }
    public partial class ProxyServerProperties
    {
        public ProxyServerProperties() { }
        public string IP { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
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
        public RecommendationConfigurationProperties(Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType recommendationType, Azure.ResourceManager.SecurityCenter.Models.RecommendationConfigStatus status) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType RecommendationType { get { throw null; } set { } }
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
    public partial class RecommendedSecurityRule
    {
        public RecommendedSecurityRule() { }
        public int? DestinationPort { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection? Direction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPAddresses { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol> Protocols { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegulatoryComplianceState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegulatoryComplianceState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState Passed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState Skipped { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState Unsupported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState left, Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState left, Azure.ResourceManager.SecurityCenter.Models.RegulatoryComplianceState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class SecureScoreControlDefinitionItem : Azure.ResourceManager.Models.ResourceData
    {
        public SecureScoreControlDefinitionItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> AssessmentDefinitions { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public int? MaxScore { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityControlType? SourceType { get { throw null; } }
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
    public partial class SecurityAlertEntity
    {
        internal SecurityAlertEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string AlertEntityType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertMinimalSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertMinimalSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertNotificationByRoleState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertNotificationByRoleState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState Off { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertNotificationState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertNotificationState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState Off { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertReceivingRole : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertReceivingRole(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole AccountAdmin { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole Contributor { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole Owner { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole ServiceAdmin { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SecurityAlertResourceIdentifier
    {
        protected SecurityAlertResourceIdentifier() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityAlertSimulatorBundlesRequestProperties : Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorRequestProperties
    {
        public SecurityAlertSimulatorBundlesRequestProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType> Bundles { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertSimulatorBundleType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertSimulatorBundleType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType AppServices { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType CosmosDbs { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType Dns { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType KeyVaults { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType KubernetesService { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType ResourceManager { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType SqlServers { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType StorageAccounts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType VirtualMachines { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityAlertSimulatorContent
    {
        public SecurityAlertSimulatorContent() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class SecurityAlertSimulatorRequestProperties
    {
        public SecurityAlertSimulatorRequestProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public enum SecurityAlertsSuppressionRuleState
    {
        Enabled = 0,
        Disabled = 1,
        Expired = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus Active { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus Dismissed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityAlertSupportingEvidence
    {
        public SecurityAlertSupportingEvidence() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string SecurityAlertSupportingEvidenceType { get { throw null; } }
    }
    public partial class SecurityAlertSyncSettings : Azure.ResourceManager.SecurityCenter.SecuritySettingData
    {
        public SecurityAlertSyncSettings() { }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityAssessmentCreateOrUpdateContent() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalData { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri LinksAzurePortalUri { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataProperties Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner PartnersData { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatus Status { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentMetadataPartner
    {
        public SecurityAssessmentMetadataPartner(string partnerName, string secret) { }
        public string PartnerName { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentMetadataProperties
    {
        public SecurityAssessmentMetadataProperties(string displayName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity severity, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType assessmentType) { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType AssessmentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory> Categories { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.ImplementationEffort? ImplementationEffort { get { throw null; } set { } }
        public bool? IsPreview { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentMetadataPartner PartnerData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public string RemediationDescription { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity Severity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityThreat> Threats { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact? UserImpact { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAssessmentODataExpand : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAssessmentODataExpand(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand Links { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand Metadata { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityAssessmentPartner
    {
        public SecurityAssessmentPartner(string partnerName, string secret) { }
        public string PartnerName { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
    }
    public partial class SecurityAssessmentPublishDates
    {
        public SecurityAssessmentPublishDates(string @public) { }
        public string GA { get { throw null; } set { } }
        public string Public { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAssessmentResourceCategory : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAssessmentResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory Compute { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory Data { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory IdentityAndAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory IoT { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory Networking { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAssessmentResourceStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAssessmentResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus NotHealthy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus OffByPolicy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAssessmentSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAssessmentSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityAssessmentStatus
    {
        public SecurityAssessmentStatus(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode code) { }
        public string Cause { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode Code { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAssessmentStatusCode : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAssessmentStatusCode(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode Healthy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityAssessmentStatusResult : Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatus
    {
        public SecurityAssessmentStatusResult(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode code) : base (default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatusCode)) { }
        public System.DateTimeOffset? FirstEvaluatedOn { get { throw null; } }
        public System.DateTimeOffset? StatusChangeOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAssessmentTactic : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAssessmentTactic(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic Collection { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic CommandAndControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic CredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic DefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic Discovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic Execution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic Exfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic Impact { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic InitialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic LateralMovement { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic Persistence { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic PrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic Reconnaissance { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic ResourceDevelopment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTactic right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAssessmentTechnique : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAssessmentTechnique(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique AbuseElevationControlMechanism { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique AccessTokenManipulation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique AccountDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique AccountManipulation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ActiveScanning { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ApplicationLayerProtocol { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique AudioCapture { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique BootOrLogonAutostartExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique BootOrLogonInitializationScripts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique BruteForce { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique CloudInfrastructureDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique CloudServiceDashboard { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique CloudServiceDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique CommandAndScriptingInterpreter { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique CompromiseClientSoftwareBinary { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique CompromiseInfrastructure { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ContainerAndResourceDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique CreateAccount { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique CreateOrModifySystemProcess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique CredentialsFromPasswordStores { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DataDestruction { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DataEncryptedForImpact { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DataFromCloudStorageObject { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DataFromConfigurationRepository { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DataFromInformationRepositories { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DataFromLocalSystem { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DataManipulation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DataStaged { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique Defacement { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DeobfuscateDecodeFilesOrInformation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DiskWipe { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DomainTrustDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DriveByCompromise { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique DynamicResolution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique EndpointDenialOfService { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique EventTriggeredExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ExfiltrationOverAlternativeProtocol { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ExploitationForClientExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ExploitationForCredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ExploitationForDefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ExploitationForPrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ExploitationOfRemoteServices { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ExploitPublicFacingApplication { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ExternalRemoteServices { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique FallbackChannels { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique FileAndDirectoryDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique FileAndDirectoryPermissionsModification { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique GatherVictimNetworkInformation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique HideArtifacts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique HijackExecutionFlow { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ImpairDefenses { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ImplantContainerImage { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique IndicatorRemovalOnHost { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique IndirectCommandExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique IngressToolTransfer { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique InputCapture { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique InterProcessCommunication { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique LateralToolTransfer { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ManInTheMiddle { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique Masquerading { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ModifyAuthenticationProcess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ModifyRegistry { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique NetworkDenialOfService { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique NetworkServiceScanning { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique NetworkSniffing { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique NonApplicationLayerProtocol { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique NonStandardPort { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ObfuscatedFilesOrInformation { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ObtainCapabilities { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique OfficeApplicationStartup { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique OSCredentialDumping { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique PermissionGroupsDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique Phishing { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique PreOSBoot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ProcessDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ProcessInjection { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ProtocolTunneling { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique Proxy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique QueryRegistry { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique RemoteAccessSoftware { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique RemoteServices { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique RemoteServiceSessionHijacking { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique RemoteSystemDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ResourceHijacking { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ScheduledTaskJob { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ScreenCapture { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique SearchVictimOwnedWebsites { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ServerSoftwareComponent { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ServiceStop { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique SignedBinaryProxyExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique SoftwareDeploymentTools { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique SQLStoredProcedures { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique StealOrForgeKerberosTickets { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique SubvertTrustControls { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique SupplyChainCompromise { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique SystemInformationDiscovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique TaintSharedContent { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique TrafficSignaling { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique TransferDataToCloudAccount { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique TrustedRelationship { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique UnsecuredCredentials { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique UserExecution { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique ValidAccounts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique WindowsManagementInstrumentation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentTechnique right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAssessmentType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAssessmentType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType CustomerManaged { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType CustomPolicy { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType VerifiedPartner { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAssessmentUserImpact : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAssessmentUserImpact(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact High { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact Moderate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact left, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentUserImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SecurityAutomationAction
    {
        protected SecurityAutomationAction() { }
    }
    public partial class SecurityAutomationActionEventHub : Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationAction
    {
        public SecurityAutomationActionEventHub() { }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EventHubResourceId { get { throw null; } set { } }
        public string SasPolicyName { get { throw null; } }
    }
    public partial class SecurityAutomationActionLogicApp : Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationAction
    {
        public SecurityAutomationActionLogicApp() { }
        public Azure.Core.ResourceIdentifier LogicAppResourceId { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class SecurityAutomationActionWorkspace : Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationAction
    {
        public SecurityAutomationActionWorkspace() { }
        public Azure.Core.ResourceIdentifier WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class SecurityAutomationRuleSet
    {
        public SecurityAutomationRuleSet() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationTriggeringRule> Rules { get { throw null; } }
    }
    public partial class SecurityAutomationScope
    {
        public SecurityAutomationScope() { }
        public string Description { get { throw null; } set { } }
        public string ScopePath { get { throw null; } set { } }
    }
    public partial class SecurityAutomationSource
    {
        public SecurityAutomationSource() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource? EventSource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAutomationRuleSet> RuleSets { get { throw null; } }
    }
    public partial class SecurityAutomationTriggeringRule
    {
        public SecurityAutomationTriggeringRule() { }
        public string ExpectedValue { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRuleOperator? Operator { get { throw null; } set { } }
        public string PropertyJPath { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AutomationTriggeringRulePropertyType? PropertyType { get { throw null; } set { } }
    }
    public partial class SecurityAutomationValidationStatus
    {
        internal SecurityAutomationValidationStatus() { }
        public bool? IsValid { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class SecurityCenterAllowedConnection : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityCenterAllowedConnection() { }
        public System.DateTimeOffset? CalculatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.ConnectableResourceInfo> ConnectableResources { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityCenterCloudName : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterCloudName(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName Aws { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName Azure { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName AzureDevOps { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName Gcp { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName Github { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SecurityCenterCloudOffering
    {
        protected SecurityCenterCloudOffering() { }
        public string Description { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityCenterCloudPermission : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterCloudPermission(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission AwsAmazonSsmAutomationRole { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission AwsAwsSecurityHubReadOnlyAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission AwsSecurityAudit { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission GcpSecurityCenterAdminViewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityCenterConfigurationStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterConfigurationStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus Configured { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus NoStatus { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus NotConfigured { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityCenterConnectionType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType External { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityCenterFileProtectionMode
    {
        public SecurityCenterFileProtectionMode() { }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Exe { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Executable { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Msi { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Script { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityCenterPricingTier : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterPricingTier(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier Free { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityCenterPublisherInfo
    {
        public SecurityCenterPublisherInfo() { }
        public string BinaryName { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        public string PublisherName { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public abstract partial class SecurityCenterResourceDetails
    {
        protected SecurityCenterResourceDetails() { }
    }
    public partial class SecurityCenterTagsResourceInfo
    {
        public SecurityCenterTagsResourceInfo() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityCenterVmEnforcementSupportState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterVmEnforcementSupportState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState NotSupported { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState Supported { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SecurityConnectorEnvironment
    {
        protected SecurityConnectorEnvironment() { }
    }
    public partial class SecurityContactPropertiesAlertNotifications
    {
        public SecurityContactPropertiesAlertNotifications() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity? MinimalSeverity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState? State { get { throw null; } set { } }
    }
    public partial class SecurityContactPropertiesNotificationsByRole
    {
        public SecurityContactPropertiesNotificationsByRole() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertReceivingRole> Roles { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationByRoleState? State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityControlType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityControlType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityControlType BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityControlType Custom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityControlType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityControlType left, Azure.ResourceManager.SecurityCenter.Models.SecurityControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityControlType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityControlType left, Azure.ResourceManager.SecurityCenter.Models.SecurityControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityCve
    {
        internal SecurityCve() { }
        public string Link { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class SecurityCvss
    {
        internal SecurityCvss() { }
        public float? Base { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEventSource : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEventSource(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource Alerts { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource Assessments { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource AssessmentsSnapshot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource RegulatoryComplianceAssessment { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource RegulatoryComplianceAssessmentSnapshot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource SecureScoreControls { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource SecureScoreControlsSnapshot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource SecureScores { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource SecureScoresSnapshot { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource SubAssessments { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource SubAssessmentsSnapshot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource left, Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource left, Azure.ResourceManager.SecurityCenter.Models.SecurityEventSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityFamily : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityFamily(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily Ngfw { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily SaasWaf { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily VulnerabilityAssessment { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityFamilyProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityFamilyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityScoreODataExpand : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityScoreODataExpand(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand Definition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand left, Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand left, Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecuritySettingName : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecuritySettingName(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName Mcas { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName Sentinel { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName Wdatp { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName WdatpExcludeLinuxPublicPreview { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName WdatpUnifiedSolution { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName left, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName left, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecuritySolution : Azure.ResourceManager.Models.ResourceData
    {
        public SecuritySolution() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProtectionStatus { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityFamily? SecurityFamily { get { throw null; } set { } }
        public string Template { get { throw null; } set { } }
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
    public abstract partial class SecuritySubAssessmentAdditionalInfo
    {
        protected SecuritySubAssessmentAdditionalInfo() { }
    }
    public partial class SecurityTaskProperties
    {
        public SecurityTaskProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityThreat : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityThreat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityThreat(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityThreat AccountBreach { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityThreat DataExfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityThreat DataSpillage { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityThreat DenialOfService { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityThreat ElevationOfPrivilege { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityThreat MaliciousInsider { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityThreat MissingCoverage { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityThreat ThreatResistance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityThreat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityThreat left, Azure.ResourceManager.SecurityCenter.Models.SecurityThreat right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityThreat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityThreat left, Azure.ResourceManager.SecurityCenter.Models.SecurityThreat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityTopologyResource : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityTopologyResource() { }
        public System.DateTimeOffset? CalculatedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.TopologySingleResource> TopologyResources { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityTrafficDirection : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityTrafficDirection(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection left, Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection left, Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityTransportProtocol : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol left, Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol left, Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityValueType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityValueType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityValueType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityValueType IPCidr { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityValueType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityValueType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityValueType left, Azure.ResourceManager.SecurityCenter.Models.SecurityValueType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityValueType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityValueType left, Azure.ResourceManager.SecurityCenter.Models.SecurityValueType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ServerVulnerabilityProperties : Azure.ResourceManager.SecurityCenter.Models.SecuritySubAssessmentAdditionalInfo
    {
        public ServerVulnerabilityProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.SecurityCve> Cve { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.SecurityCenter.Models.SecurityCvss> Cvss { get { throw null; } }
        public bool? IsPatchable { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public string ServerVulnerabilityType { get { throw null; } }
        public string Threat { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.VendorReference> VendorReferences { get { throw null; } }
    }
    public partial class ServicePrincipalProperties
    {
        public ServicePrincipalProperties() { }
        public System.Guid? ApplicationId { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
    }
    public partial class SqlServerVulnerabilityProperties : Azure.ResourceManager.SecurityCenter.Models.SecuritySubAssessmentAdditionalInfo
    {
        public SqlServerVulnerabilityProperties() { }
        public string Query { get { throw null; } }
        public string SqlServerVulnerabilityType { get { throw null; } }
    }
    public partial class SqlVulnerabilityAssessmentBaseline
    {
        public SqlVulnerabilityAssessmentBaseline() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> ExpectedResults { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    public partial class SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent
    {
        public SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent() { }
        public bool? LatestScan { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> Results { get { throw null; } }
    }
    public partial class SqlVulnerabilityAssessmentRemediation
    {
        public SqlVulnerabilityAssessmentRemediation() { }
        public string Description { get { throw null; } set { } }
        public bool? IsAutomated { get { throw null; } set { } }
        public string PortalLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scripts { get { throw null; } }
    }
    public partial class SqlVulnerabilityAssessmentScanProperties
    {
        public SqlVulnerabilityAssessmentScanProperties() { }
        public string Database { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public int? HighSeverityFailedRulesCount { get { throw null; } set { } }
        public bool? IsBaselineApplied { get { throw null; } set { } }
        public int? LowSeverityFailedRulesCount { get { throw null; } set { } }
        public int? MediumSeverityFailedRulesCount { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string SqlVersion { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState? State { get { throw null; } set { } }
        public int? TotalFailedRulesCount { get { throw null; } set { } }
        public int? TotalPassedRulesCount { get { throw null; } set { } }
        public int? TotalRulesCount { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType? TriggerType { get { throw null; } set { } }
    }
    public partial class SqlVulnerabilityAssessmentScanResult : Azure.ResourceManager.Models.ResourceData
    {
        public SqlVulnerabilityAssessmentScanResult() { }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties Properties { get { throw null; } set { } }
    }
    public partial class SqlVulnerabilityAssessmentScanResultProperties
    {
        public SqlVulnerabilityAssessmentScanResultProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.BaselineAdjustedResult BaselineAdjustedResult { get { throw null; } set { } }
        public bool? IsTrimmed { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> QueryResults { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation Remediation { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule RuleMetadata { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVulnerabilityAssessmentScanResultRuleStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVulnerabilityAssessmentScanResultRuleStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus Finding { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus InternalError { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus NonFinding { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus left, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus left, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVulnerabilityAssessmentScanState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVulnerabilityAssessmentScanState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState FailedToRun { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState Passed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState left, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState left, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVulnerabilityAssessmentScanTriggerType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVulnerabilityAssessmentScanTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType OnDemand { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType Recurring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType left, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType left, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubAssessmentStatus
    {
        public SubAssessmentStatus() { }
        public string Cause { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SubAssessmentStatusCode? Code { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentSeverity? Severity { get { throw null; } }
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
    public partial class SuppressionAlertsScopeElement
    {
        public SuppressionAlertsScopeElement() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Field { get { throw null; } set { } }
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
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string Severity { get { throw null; } }
        public int? TopologyScore { get { throw null; } }
    }
    public partial class TopologySingleResourceChild
    {
        internal TopologySingleResourceChild() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
    }
    public partial class TopologySingleResourceParent
    {
        internal TopologySingleResourceParent() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
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
    public partial class UserRecommendation
    {
        public UserRecommendation() { }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? RecommendationAction { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
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
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState? EnforcementSupport { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? RecommendationAction { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VulnerabilityAssessmentAutoProvisioningType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentAutoProvisioningType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType Qualys { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType TVM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType left, Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType left, Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VulnerabilityAssessmentRule
    {
        public VulnerabilityAssessmentRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.BenchmarkReference> BenchmarkReferences { get { throw null; } }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck QueryCheck { get { throw null; } set { } }
        public string Rationale { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType? RuleType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityCenter.Models.RuleSeverity? Severity { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class VulnerabilityAssessmentRuleQueryCheck
    {
        public VulnerabilityAssessmentRuleQueryCheck() { }
        public System.Collections.Generic.IList<string> ColumnNames { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> ExpectedResult { get { throw null; } }
        public string Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VulnerabilityAssessmentRuleType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentRuleType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType BaselineExpected { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType Binary { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType NegativeList { get { throw null; } }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType PositiveList { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType left, Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType left, Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
