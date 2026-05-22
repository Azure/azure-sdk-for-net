// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter
{
    // Suppress duplicate generated extension factories for resource types that appear through multiple Security APIs.
    [CodeGenSuppress("GetAlertResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetAssessmentsMetadatumResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetTaskResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetSqlVulnerabilityAssessmentScanResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    // Suppress generated methods whose return types changed so ApiCompat shims can preserve the previous GA signatures.
    [CodeGenSuppress("GetAllowedConnectionsAsync", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetAllowedConnections", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetDiscoveredSecuritySolutionsAsync", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetDiscoveredSecuritySolutions", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetExternalSecuritySolutionsAsync", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetExternalSecuritySolutions", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetMdeOnboardingsAsync", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetMdeOnboardings", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetSecuritySolutionsAsync", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetSecuritySolutions", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetTopologiesAsync", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    [CodeGenSuppress("GetTopologies", typeof(Azure.ResourceManager.Resources.SubscriptionResource), typeof(System.Threading.CancellationToken))]
    public static partial class SecurityCenterExtensions
    {
    }
}
