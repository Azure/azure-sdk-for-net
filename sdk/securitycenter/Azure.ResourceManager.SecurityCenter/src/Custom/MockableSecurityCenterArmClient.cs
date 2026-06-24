// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the MockableSecurityCenterArmClient class.
    /// </summary>
    public partial class MockableSecurityCenterArmClient
    {
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveApplicationControlGroupResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead.")]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveNetworkHardeningResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead.")]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomAssessmentAutomationResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomationResource(ResourceIdentifier id) instead.")]
        public virtual Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomationResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomEntityStoreAssignmentResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignmentResource(ResourceIdentifier id) instead.")]
        public virtual Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignmentResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCloudConnectorResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public virtual Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource GetSecurityCloudConnectorResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSoftwareInventoryResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public virtual Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource GetSoftwareInventoryResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }

        /// <summary> Gets an object representing a security connector governance rule resource. </summary>
        public virtual SecurityConnectorGovernanceRuleResource GetSecurityConnectorGovernanceRuleResource(ResourceIdentifier id)
        {
            return new SecurityConnectorGovernanceRuleResource(Client, GetGovernanceRuleResource(id));
        }

        /// <summary> Gets an object representing a subscription governance rule resource. </summary>
        public virtual SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(ResourceIdentifier id)
        {
            return new SubscriptionGovernanceRuleResource(Client, GetGovernanceRuleResource(id));
        }

        /// <summary> Gets a SQL vulnerability assessment baseline rule. </summary>
        public virtual Response<SqlVulnerabilityAssessmentBaselineRuleResource> GetSqlVulnerabilityAssessmentBaselineRule(ResourceIdentifier scope, string ruleId, System.Guid workspaceId, CancellationToken cancellationToken = default)
        {
            return GetSqlVulnerabilityAssessmentBaselineRule(scope, ruleId, cancellationToken: cancellationToken);
        }

        /// <summary> Gets a SQL vulnerability assessment baseline rule. </summary>
        public virtual Task<Response<SqlVulnerabilityAssessmentBaselineRuleResource>> GetSqlVulnerabilityAssessmentBaselineRuleAsync(ResourceIdentifier scope, string ruleId, System.Guid workspaceId, CancellationToken cancellationToken = default)
        {
            return GetSqlVulnerabilityAssessmentBaselineRuleAsync(scope, ruleId, cancellationToken: cancellationToken);
        }

        /// <summary> Gets a SQL vulnerability assessment scan. </summary>
        public virtual Response<SqlVulnerabilityAssessmentScanResource> GetSqlVulnerabilityAssessmentScan(ResourceIdentifier scope, string scanId, System.Guid workspaceId, CancellationToken cancellationToken = default)
        {
            return GetSqlVulnerabilityAssessmentScan(scope, scanId, cancellationToken: cancellationToken);
        }

        /// <summary> Gets a SQL vulnerability assessment scan. </summary>
        public virtual Task<Response<SqlVulnerabilityAssessmentScanResource>> GetSqlVulnerabilityAssessmentScanAsync(ResourceIdentifier scope, string scanId, System.Guid workspaceId, CancellationToken cancellationToken = default)
        {
            return GetSqlVulnerabilityAssessmentScanAsync(scope, scanId, cancellationToken: cancellationToken);
        }
    }
}
