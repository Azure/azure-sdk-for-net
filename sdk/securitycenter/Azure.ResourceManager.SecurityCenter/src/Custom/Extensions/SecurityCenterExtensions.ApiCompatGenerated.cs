// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CA1822 // Compatibility instance members intentionally preserve previous signatures.
#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Models;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
public static partial class SecurityCenterExtensions
    {
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DiscoveredSecuritySolution> GetDiscoveredSecuritySolution(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string discoveredSecuritySolutionName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<DiscoveredSecuritySolution>> GetDiscoveredSecuritySolutionAsync(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string discoveredSecuritySolutionName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<ExternalSecuritySolution> GetExternalSecuritySolution(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string externalSecuritySolutionsName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<ExternalSecuritySolution>> GetExternalSecuritySolutionAsync(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string externalSecuritySolutionsName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicy(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string jitNetworkAccessPolicyName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<JitNetworkAccessPolicyResource>> GetJitNetworkAccessPolicyAsync(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string jitNetworkAccessPolicyName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecurityCenterPricingResource> GetSecurityCenterPricing(this SubscriptionResource subscriptionResource, string pricingName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecurityCenterPricingResource>> GetSecurityCenterPricingAsync(this SubscriptionResource subscriptionResource, string pricingName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecurityContactResource> GetSecurityContact(this SubscriptionResource subscriptionResource, string securityContactName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecurityContactResource>> GetSecurityContactAsync(this SubscriptionResource subscriptionResource, string securityContactName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecuritySolution> GetSecuritySolution(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string securitySolutionName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecuritySolution>> GetSecuritySolutionAsync(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string securitySolutionName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(this ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(this ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(this ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SqlVulnerabilityAssessmentBaselineRuleResource> GetSqlVulnerabilityAssessmentBaselineRule(this ArmClient client, ResourceIdentifier scope, string ruleId, Guid workspaceId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SqlVulnerabilityAssessmentBaselineRuleResource>> GetSqlVulnerabilityAssessmentBaselineRuleAsync(this ArmClient client, ResourceIdentifier scope, string ruleId, Guid workspaceId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SqlVulnerabilityAssessmentScanResource> GetSqlVulnerabilityAssessmentScan(this ArmClient client, ResourceIdentifier scope, string scanId, Guid workspaceId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SqlVulnerabilityAssessmentScanResource>> GetSqlVulnerabilityAssessmentScanAsync(this ArmClient client, ResourceIdentifier scope, string scanId, Guid workspaceId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(this SubscriptionResource subscriptionResource, string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(this SubscriptionResource subscriptionResource, string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SubscriptionSecurityApplicationResource> GetSubscriptionSecurityApplication(this SubscriptionResource subscriptionResource, string applicationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SubscriptionSecurityApplicationResource>> GetSubscriptionSecurityApplicationAsync(this SubscriptionResource subscriptionResource, string applicationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SecurityTopologyResource> GetTopology(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string topologyResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SecurityTopologyResource>> GetTopologyAsync(this ResourceGroupResource resourceGroupResource, AzureLocation ascLocation, string topologyResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
