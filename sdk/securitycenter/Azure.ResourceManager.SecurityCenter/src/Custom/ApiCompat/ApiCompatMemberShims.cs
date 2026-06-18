// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.
#pragma warning disable CS0169 // Compatibility extensible enums preserve generated backing fields.
#pragma warning disable SA1402 // Compatibility shims are grouped by purpose in one file.
#pragma warning disable SA1508 // Generated-style shim formatting is intentionally preserved.
#pragma warning disable CA1822 // Compatibility instance members intentionally preserve previous signatures.

// Compatibility shims for public SecurityCenter members that existed in the previous GA SDK but are not generated from the latest service specification.
namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: the generated factory overload exposes an internal AzureResourceLink type after the
    // assessmentDefinitions property is hidden behind the public SubResource compatibility property below.
    // Suppress the invalid generated overload and preserve the previous public ModelFactory signature.
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderCspmAwsOfferingVmScannersConfiguration
    {
        public DefenderCspmAwsOfferingVmScannersConfiguration() { }
        public string CloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IDictionary<string, string> ExclusionTags { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode? ScanningMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForServersAwsOfferingVmScannersConfiguration
    {
        public DefenderForServersAwsOfferingVmScannersConfiguration() { }
        public string CloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IDictionary<string, string> ExclusionTags { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode? ScanningMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning
    {
        public DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning() { }
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType? VulnerabilityAssessmentAutoProvisioningType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent
    {
        public SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent() { }
        public bool? LatestScan { get; set; }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> Results { get; } = new System.Collections.Generic.List<System.Collections.Generic.IList<string>>();
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityContactPropertiesAlertNotifications
    {
        public SecurityContactPropertiesAlertNotifications() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity? MinimalSeverity { get; set; }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState? State { get; set; }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct VulnerabilityAssessmentAutoProvisioningType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentAutoProvisioningType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType Qualys { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType TVM { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType left, Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType left, Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}

namespace Azure.ResourceManager.SecurityCenter
{
    public static partial class SecurityCenterExtensions
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardingsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterPricingCollection GetSecurityCenterPricings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> GetSecurityAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetSecurityAssessmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboarding(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> GetSecurityCenterLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> GetSecuritySetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>> GetMdeOnboardingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetSecurityCenterLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetSecuritySettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SecurityCenterLocationResource
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SqlVulnerabilityAssessmentScanResource
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResultsAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResults(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> Get(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SqlVulnerabilityAssessmentBaselineRuleCollection
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> AddRulesAsync(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use AddRulesAsync().", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAllAsync(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAllAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> AddRules(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use AddRules().", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAll(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAll(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SqlVulnerabilityAssessmentScanCollection
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetAllAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetAll(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Data")]
    public partial class SecurityConnectorGovernanceRuleResource
    {
#pragma warning disable CS0618 // Type is retained for API compatibility.
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceRuleData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
#pragma warning restore CS0618

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation ExecuteRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SqlVulnerabilityAssessmentBaselineRuleResource
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Update(Azure.WaitUntil waitUntil, System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Get(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
public partial class SecuritySettingCollection
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, Azure.ResourceManager.SecurityCenter.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> Get(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, Azure.ResourceManager.SecurityCenter.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetAsync(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class ServerVulnerabilityAssessmentResource
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class DefenderCspmAwsOfferingVmScanners
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public new Azure.ResourceManager.SecurityCenter.Models.DefenderCspmAwsOfferingVmScannersConfiguration Configuration { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersAwsOfferingVmScanners
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public new Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingVmScannersConfiguration Configuration { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersGcpOffering
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning VulnerabilityAssessmentAutoProvisioning { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType? AvailableSubPlanType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsArcAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityContactData
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.SecurityContactPropertiesAlertNotifications AlertNotifications { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public readonly partial struct SecurityFamily
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily VulnerabilityAssessment { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityConnectorResource
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleCollection GetSecurityConnectorGovernanceRules() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SecurityCenterLocationCollection
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> Get(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetAsync(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class JitNetworkAccessPolicyInitiatePort
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset EndOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class JitNetworkAccessRequestInfo
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset StartOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class JitNetworkAccessRequestPort
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset EndOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class AdditionalWorkspacesProperties
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType? WorkspaceType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersAwsOffering
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType? AvailableSubPlanType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class GovernanceRuleOwnerSource
    {
    }

    public partial class DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType? VulnerabilityAssessmentAutoProvisioningType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
public partial class DataExportSettings
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForContainersAwsOffering
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsContainerVulnerabilityAssessmentEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ContainerVulnerabilityAssessmentCloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ContainerVulnerabilityAssessmentTaskCloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string KubernetesScubaReaderCloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ScubaExternalId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForContainersGcpOffering
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsAuditLogsAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsDefenderAgentAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsPolicyAgentAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersAwsOfferingArcAutoProvisioning
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersAwsOfferingMdeAutoProvisioning
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersGcpOfferingMdeAutoProvisioning
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class GovernanceEmailNotification
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsManagerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsOwnerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class GovernanceRuleEmailNotification
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsManagerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsOwnerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}

namespace Azure.ResourceManager.SecurityCenter
{
}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class SecurityTaskProperties
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AwsAssumeRoleAuthenticationDetailsProperties : AuthenticationDetailsProperties
    {
        public AwsAssumeRoleAuthenticationDetailsProperties(string awsAssumeRoleArn, System.Guid awsExternalId) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        public string AwsAssumeRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Guid AwsExternalId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string AccountId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string RoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityAlertSimulatorBundlesRequestProperties : SecurityAlertSimulatorRequestProperties
    {
        public SecurityAlertSimulatorBundlesRequestProperties() : base(default(SecurityCenterKind)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType> Bundles { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter
{
}
