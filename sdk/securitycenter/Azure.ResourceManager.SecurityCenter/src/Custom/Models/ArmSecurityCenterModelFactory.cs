// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The regenerated model factory follows the latest TypeSpec model graph, but the GA package exposed overloads using older flattened parameters and enum types; keep those overloads here so callers can recompile without ApiCompat breaks.
    [CodeGenSuppress(
        "SecurityAlertsSuppressionRuleData",
        typeof(ResourceIdentifier),
        typeof(string),
        typeof(ResourceType),
        typeof(SystemData),
        typeof(string),
        typeof(DateTimeOffset?),
        typeof(DateTimeOffset?),
        typeof(string),
        typeof(SecurityAlertsSuppressionRuleState?),
        typeof(string),
        typeof(IEnumerable<SuppressionAlertsScopeElement>))]
    public static partial class ArmSecurityCenterModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DefenderCspmGcpOffering"/>. </summary>
        public static DefenderCspmGcpOffering DefenderCspmGcpOffering(string description = default)
        {
            return new DefenderCspmGcpOffering(
                OfferingType.DefenderCspmGcp,
                description,
                new ChangeTrackingDictionary<string, BinaryData>(),
                default,
                default,
                default,
                default,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DefenderForContainersAwsOffering"/>. </summary>
        public static DefenderForContainersAwsOffering DefenderForContainersAwsOffering(string description = default, string kubernetesServiceCloudRoleArn = default, string kubernetesDataCollectionCloudRoleArn = default, string cloudRoleArn = default, string kinesisToS3CloudRoleArn = default, string containerVulnerabilityAssessmentCloudRoleArn = default, string containerVulnerabilityAssessmentTaskCloudRoleArn = default, bool? enableAuditLogsAutoProvisioning = default, bool? enableDefenderAgentAutoProvisioning = default, long? kubeAuditRetentionTime = default, string dataCollectionExternalId = default)
        {
            return new DefenderForContainersAwsOffering(
                OfferingType.DefenderForContainersAws,
                description,
                new ChangeTrackingDictionary<string, BinaryData>(),
                kubernetesServiceCloudRoleArn is null ? default : new DefenderForContainersAwsOfferingKubernetesService { CloudRoleArn = kubernetesServiceCloudRoleArn },
                kubernetesDataCollectionCloudRoleArn is null ? default : new DefenderForContainersAwsOfferingKubernetesDataCollection { CloudRoleArn = kubernetesDataCollectionCloudRoleArn },
                cloudRoleArn is null ? default : new DefenderForContainersAwsOfferingCloudWatchToKinesis { CloudRoleArn = cloudRoleArn },
                kinesisToS3CloudRoleArn is null ? default : new DefenderForContainersAwsOfferingKinesisToS3 { CloudRoleArn = kinesisToS3CloudRoleArn },
                enableAuditLogsAutoProvisioning,
                enableDefenderAgentAutoProvisioning,
                default,
                kubeAuditRetentionTime,
                dataCollectionExternalId,
                default,
                default,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.GcpProjectDetails"/>. </summary>
        public static GcpProjectDetails GcpProjectDetails(string projectNumber = default, string projectId = default, string workloadIdentityPoolId = default)
        {
            return new GcpProjectDetails(projectNumber, projectId, workloadIdentityPoolId, default, new ChangeTrackingDictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="SecurityCenter.SecurityAlertsSuppressionRuleData"/>. </summary>
        public static SecurityAlertsSuppressionRuleData SecurityAlertsSuppressionRuleData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string alertType = default, DateTimeOffset? lastModifiedOn = default, DateTimeOffset? expireOn = default, string reason = default, SecurityAlertsSuppressionRuleState? state = default, string comment = default, IEnumerable<SuppressionAlertsScopeElement> suppressionAlertsScopeAllOf = default)
        {
            return new SecurityAlertsSuppressionRuleData(
                id,
                name,
                resourceType,
                systemData,
                alertType is null && lastModifiedOn is null && expireOn is null && reason is null && state is null && comment is null && suppressionAlertsScopeAllOf is null ? default : new AlertsSuppressionRuleProperties(
                    alertType,
                    lastModifiedOn,
                    expireOn,
                    reason,
                    state.GetValueOrDefault(),
                    comment,
                    suppressionAlertsScopeAllOf is null ? default : new SuppressionAlertsScope(suppressionAlertsScopeAllOf),
                    new ChangeTrackingDictionary<string, BinaryData>()),
                new ChangeTrackingDictionary<string, BinaryData>());
        }
    }
}
