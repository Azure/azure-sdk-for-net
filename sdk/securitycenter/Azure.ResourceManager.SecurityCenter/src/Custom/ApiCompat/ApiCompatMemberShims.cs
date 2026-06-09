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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SecureScoreControlDefinitionItem", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(string), typeof(string), typeof(int?), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.AzureResourceLink>), typeof(Azure.ResourceManager.SecurityCenter.Models.SecurityControlType?))]
    public static partial class ArmSecurityCenterModelFactory
    {
        public static Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem SecureScoreControlDefinitionItem(Azure.Core.ResourceIdentifier id = default, string name = default, Azure.Core.ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = default, string displayName = default, string description = default, int? maxScore = default, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> assessmentDefinitions = default, Azure.ResourceManager.SecurityCenter.Models.SecurityControlType? sourceType = default)
        {
            System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.AzureResourceLink> assessmentDefinitionLinks = assessmentDefinitions is null
                ? new System.Collections.Generic.List<Azure.ResourceManager.SecurityCenter.Models.AzureResourceLink>()
                : System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(assessmentDefinitions, item => new Azure.ResourceManager.SecurityCenter.Models.AzureResourceLink(item?.Id, new System.Collections.Generic.Dictionary<string, System.BinaryData>())));
            return new Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem(
                id,
                name,
                resourceType,
                systemData,
                new Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItemProperties(displayName, description, maxScore, new Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionSource(sourceType, new System.Collections.Generic.Dictionary<string, System.BinaryData>()), assessmentDefinitionLinks, new System.Collections.Generic.Dictionary<string, System.BinaryData>()),
                new System.Collections.Generic.Dictionary<string, System.BinaryData>());
        }
    }

    public partial class SecurityAssessmentPartner : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner>
    {
        public SecurityAssessmentPartner(string partnerName, string secret)
        {
            PartnerName = partnerName;
            Secret = secret;
        }

        public string PartnerName { get; set; }
        public string Secret { get; set; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentPartner>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public readonly partial struct AutoProvisionState
    {
        public AutoProvisionState(string value)
        {
            _value = value ?? throw new System.ArgumentNullException(nameof(value));
        }

        public static Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState Off => new Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState("Off");
        public static Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState On => new Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState("On");
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState(string value) => new Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState(value);
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState other) => string.Equals(_value, other._value, System.StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState other && Equals(other);
        public override int GetHashCode() => _value is null ? 0 : System.StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState left, Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState right) => left.Equals(right);
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState left, Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState right) => !left.Equals(right);
        public override string ToString() => _value;
    }

    [System.Obsolete("This API is no longer supported by the service.", false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderCspmAwsOfferingVmScannersConfiguration
    {
        public DefenderCspmAwsOfferingVmScannersConfiguration() { }
        public string CloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IDictionary<string, string> ExclusionTags { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode? ScanningMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    [System.Obsolete("This API is no longer supported by the service.", false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForServersAwsOfferingVmScannersConfiguration
    {
        public DefenderForServersAwsOfferingVmScannersConfiguration() { }
        public string CloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IDictionary<string, string> ExclusionTags { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode? ScanningMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    [System.Obsolete("This API is no longer supported by the service.", false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning
    {
        public DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning() { }
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType? VulnerabilityAssessmentAutoProvisioningType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    [System.Obsolete("This API is no longer supported by the service.", false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent
    {
        public SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent() { }
        public bool? LatestScan { get; set; }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> Results { get; } = new System.Collections.Generic.List<System.Collections.Generic.IList<string>>();
    }

    [System.Obsolete("This API is no longer supported by the service.", false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityContactPropertiesAlertNotifications
    {
        public SecurityContactPropertiesAlertNotifications() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity? MinimalSeverity { get; set; }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState? State { get; set; }
    }

    [System.Obsolete("This API is no longer supported by the service.", false)]
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

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SecurityAutomationAction")]
    public abstract partial class SecurityAutomationAction
    {
        protected SecurityAutomationAction() { }
    }

}

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterResourceGroupResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> GetResourceGroupSecurityAlert(Azure.Core.AzureLocation ascLocation, string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetResourceGroupSecurityAlert(ascLocation.ToString(), alertName, cancellationToken);

        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>> GetResourceGroupSecurityAlertAsync(Azure.Core.AzureLocation ascLocation, string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetResourceGroupSecurityAlertAsync(ascLocation.ToString(), alertName, cancellationToken);

        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> GetResourceGroupSecurityTask(Azure.Core.AzureLocation ascLocation, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetResourceGroupSecurityTask(ascLocation.ToString(), taskName, cancellationToken);

        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>> GetResourceGroupSecurityTaskAsync(Azure.Core.AzureLocation ascLocation, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetResourceGroupSecurityTaskAsync(ascLocation.ToString(), taskName, cancellationToken);
    }
}

namespace Azure.ResourceManager.SecurityCenter
{
    public static partial class SecurityCenterExtensions
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardingsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution> GetSecuritySolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolution> GetExternalSecuritySolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboardings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolution> GetSecuritySolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityAlertData> GetAlertsByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyCollection GetJitNetworkAccessPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertCollection GetResourceGroupSecurityAlerts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskCollection GetResourceGroupSecurityTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource> GetResourceGroupSecurityAlert(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityAlert(ascLocation, alertName, cancellationToken);
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityAlertResource>> GetResourceGroupSecurityAlertAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityAlertAsync(ascLocation, alertName, cancellationToken);
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource> GetResourceGroupSecurityTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityTask(ascLocation, taskName, cancellationToken);
        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ResourceGroupSecurityTaskResource>> GetResourceGroupSecurityTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetMockableSecurityCenterResourceGroupResource(resourceGroupResource).GetResourceGroupSecurityTaskAsync(ascLocation, taskName, cancellationToken);
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControlsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDetails> GetSecureScoreControls(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityScoreODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SecurityCenterPricingCollection GetSecurityCenterPricings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationCollection GetSubscriptionSecurityApplications(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SubscriptionSecurityApplicationResource GetSubscriptionSecurityApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource> GetSecurityAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityAssessmentResource>> GetSecurityAssessmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assessmentName, Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand? expand = default(Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentODataExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding> GetMdeOnboarding(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> GetSecurityCenterLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> GetSecuritySetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>> GetMdeOnboardingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation ascLocation, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType connectionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetSecurityCenterLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetSecuritySettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SecurityCenterLocationResource
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SqlVulnerabilityAssessmentScanResource
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResultsAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult> GetSqlVulnerabilityAssessmentScanResults(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> Get(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource>> GetAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SqlVulnerabilityAssessmentBaselineRuleCollection
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> AddRulesAsync(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This method is obsolete and will be removed in a future release. Please use AddRulesAsync().", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAllAsync(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAllAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> AddRules(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This method is obsolete and will be removed in a future release. Please use AddRules().", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAll(System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> GetAll(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SqlVulnerabilityAssessmentScanCollection
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetAllAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentScanResource> GetAll(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Data")]
    public partial class SecurityConnectorGovernanceRuleResource
    {
#pragma warning disable CS0618 // Type is retained for API compatibility.
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceRuleData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
#pragma warning restore CS0618

        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation ExecuteRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SqlVulnerabilityAssessmentBaselineRuleResource
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Update(Azure.WaitUntil waitUntil, System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource> Get(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Guid workspaceId, Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SqlVulnerabilityAssessmentBaselineRuleResource>> GetAsync(System.Guid workspaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Data")]
    public partial class SecurityConnectorApplicationResource
    {
#pragma warning disable CS0618 // Type is retained for API compatibility.
        public virtual Azure.ResourceManager.SecurityCenter.SecurityApplicationData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
#pragma warning restore CS0618

        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SecuritySettingCollection
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, Azure.ResourceManager.SecurityCenter.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource> Get(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, Azure.ResourceManager.SecurityCenter.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecuritySettingResource>> GetAsync(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class ServerVulnerabilityAssessmentResource
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class DefenderCspmAwsOfferingVmScanners
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public new Azure.ResourceManager.SecurityCenter.Models.DefenderCspmAwsOfferingVmScannersConfiguration Configuration { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersAwsOfferingVmScanners
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public new Azure.ResourceManager.SecurityCenter.Models.DefenderForServersAwsOfferingVmScannersConfiguration Configuration { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersGcpOffering
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning VulnerabilityAssessmentAutoProvisioning { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType? AvailableSubPlanType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsArcAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityContactData
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.SecurityContactPropertiesAlertNotifications AlertNotifications { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public readonly partial struct SecurityFamily
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamily VulnerabilityAssessment { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class SecuritySolutionsReferenceData
    {
        public SecuritySolutionsReferenceData(Azure.ResourceManager.SecurityCenter.Models.SecurityFamily securityFamily, string alertVendorName, System.Uri packageInfoUri, string productName, string publisher, string publisherDisplayName, string template) : this(new Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceDataProperties(securityFamily, alertVendorName, packageInfoUri?.AbsoluteUri, productName, publisher, publisherDisplayName, template))
        {
        }

        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.SecurityFamily SecurityFamily { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string AlertVendorName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ProductName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string Publisher { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string PublisherDisplayName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string Template { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Uri PackageInfoUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityConnectorResource
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleCollection GetSecurityConnectorGovernanceRules() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SecurityCenterLocationCollection
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource> Get(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCenterLocationResource>> GetAsync(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation ascLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SqlVulnerabilityAssessmentBaselineRuleData
    {
        public SqlVulnerabilityAssessmentBaselineRuleData() { }

        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> RuleResults { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class JitNetworkAccessPolicyInitiatePort
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset EndOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class JitNetworkAccessRequestInfo
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset StartOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class JitNetworkAccessRequestPort
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset EndOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class AdditionalWorkspacesProperties
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.AdditionalWorkspaceType? WorkspaceType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersAwsOffering
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType? AvailableSubPlanType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class GovernanceRuleOwnerSource
    {
    }

    public partial class DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentAutoProvisioningType? VulnerabilityAssessmentAutoProvisioningType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class ContainerRegistryVulnerabilityProperties
    {
        public ContainerRegistryVulnerabilityProperties() { }

        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsPatchable { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ContainerRegistryVulnerabilityPropertiesType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DataExportSettings
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForContainersAwsOffering
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsContainerVulnerabilityAssessmentEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ContainerVulnerabilityAssessmentCloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ContainerVulnerabilityAssessmentTaskCloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string KubernetesScubaReaderCloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ScubaExternalId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForContainersGcpOffering
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsAuditLogsAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsDefenderAgentAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsPolicyAgentAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersAwsOfferingArcAutoProvisioning
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersAwsOfferingMdeAutoProvisioning
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class DefenderForServersGcpOfferingMdeAutoProvisioning
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class GovernanceEmailNotification
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsManagerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsOwnerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class GovernanceRuleEmailNotification
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsManagerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsOwnerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class ServerVulnerabilityProperties
    {
        public ServerVulnerabilityProperties() { }

        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsPatchable { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ServerVulnerabilityType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityCenterPricingData
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsDeprecated { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class SecurityTaskProperties
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public readonly partial struct ExternalSecuritySolutionKind
    {
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind Aad => AAD;
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind Ata => ATA;
        public static Azure.ResourceManager.SecurityCenter.Models.ExternalSecuritySolutionKind Cef => CEF;
    }

    public readonly partial struct IotSecurityRecommendationType
    {
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotAcrAuthentication => IoTACRAuthentication;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotAgentSendsUnutilizedMessages => IoTAgentSendsUnutilizedMessages;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotBaseline => IoTBaseline;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotEdgeHubMemOptimize => IoTEdgeHubMemOptimize;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotEdgeLoggingOptions => IoTEdgeLoggingOptions;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotInconsistentModuleSettings => IoTInconsistentModuleSettings;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotInstallAgent => IoTInstallAgent;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotIPFilterDenyAll => IoTIPFilterDenyAll;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotIPFilterPermissiveRule => IoTIPFilterPermissiveRule;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotOpenPorts => IoTOpenPorts;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPermissiveFirewallPolicy => IoTPermissiveFirewallPolicy;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPermissiveInputFirewallRules => IoTPermissiveInputFirewallRules;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPermissiveOutputFirewallRules => IoTPermissiveOutputFirewallRules;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotPrivilegedDockerOptions => IoTPrivilegedDockerOptions;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotSharedCredentials => IoTSharedCredentials;
        public static Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType IotVulnerableTlsCipherSuite => IoTVulnerableTLSCipherSuite;
    }

    public readonly partial struct JitNetworkAccessPortProtocol
    {
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol Tcp => TCP;
        public static Azure.ResourceManager.SecurityCenter.Models.JitNetworkAccessPortProtocol Udp => UDP;
    }

    public readonly partial struct SecurityValueType
    {
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityValueType IPCidr => IpCidr;
    }

    public partial class SqlServerVulnerabilityProperties
    {
        public SqlServerVulnerabilityProperties() { }

        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string SqlServerVulnerabilityType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    public partial class SecurityAssessmentCreateOrUpdateContent
    {
        [System.Obsolete("This API is no longer supported by the service.", false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public new System.Uri LinksAzurePortalUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }

        public new Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentStatus Status
        {
            get => base.Status;
            set => Properties = new Azure.ResourceManager.SecurityCenter.Models.SecurityAssessmentProperties(ResourceDetails, value);
        }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Baseline")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Status")]
    public partial class BaselineAdjustedResult
    {
        public BaselineAdjustedResult()
        {
            ResultsNotInBaseline = new ChangeTrackingList<System.Collections.Generic.IList<string>>();
            ResultsOnlyInBaseline = new ChangeTrackingList<System.Collections.Generic.IList<string>>();
        }

        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentBaseline Baseline { get; set; }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus? Status { get; set; }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Benchmark")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Reference")]
    public partial class BenchmarkReference
    {
        public BenchmarkReference() { }
        public string Benchmark { get; set; }
        public string Reference { get; set; }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("IotSecurityAlertedDevice")]
    public partial class IotSecurityAlertedDevice
    {
        public IotSecurityAlertedDevice() { }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("IotSecurityDeviceAlert")]
    public partial class IotSecurityDeviceAlert
    {
        public IotSecurityDeviceAlert() { }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("IotSecurityDeviceRecommendation")]
    public partial class IotSecurityDeviceRecommendation
    {
        public IotSecurityDeviceRecommendation() { }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("AssessmentDefinitions")]
    public partial class SecureScoreControlDefinitionItem
    {
        public SecureScoreControlDefinitionItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> AssessmentDefinitions { get; } = new System.Collections.Generic.List<Azure.ResourceManager.Resources.Models.SubResource>();
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Definition")]
    public partial class SecureScoreControlDetails
    {
        public SecureScoreControlDetails() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecureScoreControlDefinitionItem Definition { get; set; }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("UpdatedOn")]
    public partial class SqlVulnerabilityAssessmentBaseline
    {
        public SqlVulnerabilityAssessmentBaseline() { }
        public System.DateTimeOffset? UpdatedOn { get; set; }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("TriggerType")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("State")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Server")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Database")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SqlVersion")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("StartOn")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("EndOn")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("HighSeverityFailedRulesCount")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("MediumSeverityFailedRulesCount")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("LowSeverityFailedRulesCount")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("TotalPassedRulesCount")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("TotalFailedRulesCount")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("TotalRulesCount")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("IsBaselineApplied")]
    public partial class SqlVulnerabilityAssessmentScanProperties
    {
        public SqlVulnerabilityAssessmentScanProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanTriggerType? TriggerType { get; set; }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanState? State { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string SqlVersion { get; set; }
        public System.DateTimeOffset? StartOn { get; set; }
        public System.DateTimeOffset? EndOn { get; set; }
        public int? HighSeverityFailedRulesCount { get; set; }
        public int? MediumSeverityFailedRulesCount { get; set; }
        public int? LowSeverityFailedRulesCount { get; set; }
        public int? TotalPassedRulesCount { get; set; }
        public int? TotalFailedRulesCount { get; set; }
        public int? TotalRulesCount { get; set; }
        public bool? IsBaselineApplied { get; set; }
    }

    public partial class SubAssessmentStatus
    {
        public SubAssessmentStatus() { }
    }

    [System.Obsolete("This API is no longer supported by the service.", false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AwsAssumeRoleAuthenticationDetailsProperties : AuthenticationDetailsProperties
    {
        public AwsAssumeRoleAuthenticationDetailsProperties(string awsAssumeRoleArn, System.Guid awsExternalId) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        public string AwsAssumeRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Guid AwsExternalId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string AccountId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string RoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

    [System.Obsolete("This API is no longer supported by the service.", false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityAlertSimulatorBundlesRequestProperties : SecurityAlertSimulatorRequestProperties
    {
        public SecurityAlertSimulatorBundlesRequestProperties() : base(default(SecurityCenterKind)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType> Bundles { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }

}

namespace Azure.ResourceManager.SecurityCenter
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Properties")]
    public partial class SecurityCenterLocationData
    {
        public SecurityCenterLocationData() { }
        public System.BinaryData Properties { get; set; }
    }

    public partial class ServerVulnerabilityAssessmentData
    {
        public ServerVulnerabilityAssessmentData() { }
    }

    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Properties")]
    public partial class SqlVulnerabilityAssessmentScanData
    {
        public SqlVulnerabilityAssessmentScanData() { }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanProperties Properties { get; set; }
    }

}
