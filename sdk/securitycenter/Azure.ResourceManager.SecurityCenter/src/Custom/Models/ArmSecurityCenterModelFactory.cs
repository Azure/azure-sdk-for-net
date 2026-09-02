// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The regenerated model factory follows the latest TypeSpec model graph, but the GA package exposed overloads using older flattened parameters and enum types; keep those overloads here so callers can recompile without ApiCompat breaks.
    // Suppress the corresponding generated overloads only where the generated all-optional signatures would be source-ambiguous with the preserved GA overloads that differ by nested collection interface types.
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
    [CodeGenSuppress("RuleResultsProperties", typeof(IEnumerable<IList<string>>), typeof(bool?))]
    [CodeGenSuppress("RuleResultsInput", typeof(bool?), typeof(IEnumerable<IList<string>>))]
    [CodeGenSuppress("SqlVulnerabilityAssessmentScanResultProperties", typeof(string), typeof(SqlVulnerabilityAssessmentScanResultRuleStatus?), typeof(bool?), typeof(IEnumerable<IList<string>>), typeof(SqlVulnerabilityAssessmentRemediation), typeof(BaselineAdjustedResult), typeof(VulnerabilityAssessmentRule))]
    [CodeGenSuppress("BaselineAdjustedResult", typeof(SqlVulnerabilityAssessmentBaseline), typeof(SqlVulnerabilityAssessmentScanResultRuleStatus?), typeof(IEnumerable<IList<string>>), typeof(IEnumerable<IList<string>>))]
    [CodeGenSuppress("SqlVulnerabilityAssessmentBaseline", typeof(IEnumerable<IList<string>>))]
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

        /// <summary> Initializes a new instance of <see cref="SecurityCenter.IngestionSettingData"/>. </summary>
        public static IngestionSettingData IngestionSettingData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, BinaryData properties = default)
        {
            return new IngestionSettingData(id, name, resourceType, systemData, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.IngestionConnectionString"/>. </summary>
        public static IngestionConnectionString IngestionConnectionString(AzureLocation? location = default, string value = default)
        {
            return new IngestionConnectionString(location, value);
        }

        /// <summary> Initializes a new instance of <see cref="Models.IngestionSettingToken"/>. </summary>
        public static IngestionSettingToken IngestionSettingToken(string token = default)
        {
            return new IngestionSettingToken(token);
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

        /// <summary> Initializes a new instance of <see cref="Models.RuleResultsProperties"/>. </summary>
        /// <param name="results"> Expected results in the baseline. </param>
        /// <param name="isLatestScan"> Take results from latest scan. </param>
        /// <returns> A new <see cref="Models.RuleResultsProperties"/> instance for mocking. </returns>
        public static RuleResultsProperties RuleResultsProperties(IEnumerable<IEnumerable<string>> results = default, bool? isLatestScan = default)
        {
            return new RuleResultsProperties(ToStringListRows(results), isLatestScan, new ChangeTrackingDictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.RuleResultsInput"/>. </summary>
        /// <param name="isLatestScan"> Take results from latest scan. </param>
        /// <param name="results">
        /// Expected results to be inserted into the baseline.
        /// Leave this field empty if latestScan == true.
        /// </param>
        /// <returns> A new <see cref="Models.RuleResultsInput"/> instance for mocking. </returns>
        public static RuleResultsInput RuleResultsInput(bool? isLatestScan = default, IEnumerable<IEnumerable<string>> results = default)
        {
            return new RuleResultsInput(isLatestScan, ToStringListRows(results), new ChangeTrackingDictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.SqlVulnerabilityAssessmentScanResultProperties"/>. </summary>
        /// <param name="ruleId"> The rule Id. </param>
        /// <param name="status"> The rule result status. </param>
        /// <param name="isTrimmed"> Indicates whether the results specified here are trimmed. </param>
        /// <param name="queryResults"> The results of the query that was run. </param>
        /// <param name="remediation"> Remediation details. </param>
        /// <param name="baselineAdjustedResult"> The rule result adjusted with baseline. </param>
        /// <param name="ruleMetadata"> vulnerability assessment rule metadata details. </param>
        /// <returns> A new <see cref="Models.SqlVulnerabilityAssessmentScanResultProperties"/> instance for mocking. </returns>
        public static SqlVulnerabilityAssessmentScanResultProperties SqlVulnerabilityAssessmentScanResultProperties(string ruleId = default, SqlVulnerabilityAssessmentScanResultRuleStatus? status = default, bool? isTrimmed = default, IEnumerable<IEnumerable<string>> queryResults = default, SqlVulnerabilityAssessmentRemediation remediation = default, BaselineAdjustedResult baselineAdjustedResult = default, VulnerabilityAssessmentRule ruleMetadata = default)
        {
            return new SqlVulnerabilityAssessmentScanResultProperties(
                ruleId,
                status,
                isTrimmed,
                ToStringListRows(queryResults),
                remediation,
                baselineAdjustedResult,
                ruleMetadata,
                new ChangeTrackingDictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.BaselineAdjustedResult"/>. </summary>
        /// <param name="baseline"> Baseline details. </param>
        /// <param name="status"> The rule result status. </param>
        /// <param name="resultsNotInBaseline"> Results that are not in the baseline. </param>
        /// <param name="resultsOnlyInBaseline"> Results that are in the baseline. </param>
        /// <returns> A new <see cref="Models.BaselineAdjustedResult"/> instance for mocking. </returns>
        public static BaselineAdjustedResult BaselineAdjustedResult(SqlVulnerabilityAssessmentBaseline baseline = default, SqlVulnerabilityAssessmentScanResultRuleStatus? status = default, IEnumerable<IEnumerable<string>> resultsNotInBaseline = default, IEnumerable<IEnumerable<string>> resultsOnlyInBaseline = default)
        {
            return new BaselineAdjustedResult(
                baseline,
                status,
                ToStringListRows(resultsNotInBaseline),
                ToStringListRows(resultsOnlyInBaseline),
                new ChangeTrackingDictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.SqlVulnerabilityAssessmentBaseline"/>. </summary>
        /// <param name="expectedResults"> Expected results. </param>
        /// <returns> A new <see cref="Models.SqlVulnerabilityAssessmentBaseline"/> instance for mocking. </returns>
        public static SqlVulnerabilityAssessmentBaseline SqlVulnerabilityAssessmentBaseline(IEnumerable<IEnumerable<string>> expectedResults = default)
        {
            return new SqlVulnerabilityAssessmentBaseline(ToStringListRows(expectedResults), new ChangeTrackingDictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.VulnerabilityAssessmentRuleQueryCheck"/>. </summary>
        /// <param name="query"> The rule query. </param>
        /// <param name="expectedResult"> Expected result. </param>
        /// <param name="columnNames"> Column names of expected result. </param>
        /// <returns> A new <see cref="Models.VulnerabilityAssessmentRuleQueryCheck"/> instance for mocking. </returns>
        public static VulnerabilityAssessmentRuleQueryCheck VulnerabilityAssessmentRuleQueryCheck(string query = default, IEnumerable<IEnumerable<string>> expectedResult = default, IEnumerable<string> columnNames = default)
        {
            return new VulnerabilityAssessmentRuleQueryCheck(
                query,
                ToStringListRows(expectedResult),
                columnNames is null ? new ChangeTrackingList<string>() : columnNames.ToList(),
                new ChangeTrackingDictionary<string, BinaryData>());
        }

        private static IList<IList<string>> ToStringListRows(IEnumerable<IEnumerable<string>> rows)
        {
            return rows is null
                ? new ChangeTrackingList<IList<string>>()
                : rows.Select(row => (IList<string>)(row is null ? null : row.ToList())).ToList();
        }

        private static IDictionary<string, IList<IList<string>>> ToStringListRowDictionary(IDictionary<string, IEnumerable<IEnumerable<string>>> rows)
        {
            return rows is null
                ? new ChangeTrackingDictionary<string, IList<IList<string>>>()
                : rows.ToDictionary(row => row.Key, row => ToStringListRows(row.Value));
        }
    }
}
