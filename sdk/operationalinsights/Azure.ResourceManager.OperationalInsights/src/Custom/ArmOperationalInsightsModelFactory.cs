// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.OperationalInsights;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    public static partial class ArmOperationalInsightsModelFactory
    {
        // Backward-compatibility shim for the factory signature shipped in version 1.3.2.
        /// <summary> Initializes a new instance of <see cref="OperationalInsights.OperationalInsightsSummaryLogsData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata. </param>
        /// <param name="ruleType"> SummaryRules rule type. </param>
        /// <param name="displayName"> The display name of the Summary rule. </param>
        /// <param name="description"> The description of the Summary rule. </param>
        /// <param name="isActive"> Indicates whether the Summary rule is active. </param>
        /// <param name="statusCode"> Indicates the reason for rule deactivation. </param>
        /// <param name="provisioningState"> The provisioning state of the Summary rule. </param>
        /// <param name="ruleDefinition"> Rule definition parameters. </param>
        /// <returns> A new <see cref="OperationalInsights.OperationalInsightsSummaryLogsData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete and will be removed in a future release.", false)]
        public static OperationalInsightsSummaryLogsData OperationalInsightsSummaryLogsData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            OperationalInsightsNetworkSecurityPerimeterRuleType? ruleType,
            string displayName,
            string description,
            bool? isActive,
            OperationalInsightsNetworkSecurityPerimeterStatusCode? statusCode,
            OperationalInsightsNetworkSecurityPerimeterProvisioningState? provisioningState,
            OperationalInsightsSummaryRule ruleDefinition)
        {
            return new OperationalInsightsSummaryLogsData(
                id,
                name,
                resourceType,
                systemData,
                ruleType is null && displayName is null && description is null && isActive is null && statusCode is null && provisioningState is null && ruleDefinition is null
                    ? default
                    : new SummaryLogsProperties(
                        ruleType.HasValue ? ruleType.Value : default(OperationalInsightsSummaryLogsRuleType?),
                        displayName,
                        description,
                        isActive,
                        statusCode.HasValue ? statusCode.Value : default(OperationalInsightsSummaryLogsStatusCode?),
                        provisioningState.HasValue ? provisioningState.Value : default(OperationalInsightsSummaryLogsProvisioningState?),
                        ruleDefinition,
                        default),
                default);
        }

        /// <summary> The top level Workspace resource container. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="eTag"> Resource Etag. </param>
        /// <param name="provisioningState"> The provisioning state of the workspace. </param>
        /// <param name="customerId"> This is a read-only property. Represents the ID associated with the workspace. </param>
        /// <param name="sku"> The SKU of the workspace. </param>
        /// <param name="retentionInDays"> The workspace data retention in days. Allowed values are per pricing plan. See pricing tiers documentation for details. </param>
        /// <param name="workspaceCapping"> The daily volume cap for ingestion. </param>
        /// <param name="createdOn"> Workspace creation date. </param>
        /// <param name="modifiedOn"> Workspace modification date. </param>
        /// <param name="publicNetworkAccessForIngestion"> The network access type for accessing Log Analytics ingestion. </param>
        /// <param name="publicNetworkAccessForQuery"> The network access type for accessing Log Analytics query. </param>
        /// <param name="forceCmkForQuery"> Indicates whether customer managed storage is mandatory for query management. </param>
        /// <param name="privateLinkScopedResources"> List of linked private link scope resources. </param>
        /// <param name="features"> Workspace features. </param>
        /// <param name="defaultDataCollectionRuleResourceId"> The resource ID of the default Data Collection Rule to use for this workspace. Expected format is - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionRules/{dcrName}. </param>
        /// <param name="replication"> workspace replication properties. </param>
        /// <param name="failover"> workspace failover properties. </param>
        /// <param name="identity"> The identity of the resource. </param>
        /// <param name="tags"> Resource tags. Optional. </param>
        /// <returns> A new <see cref="Models.OperationalInsightsWorkspacePatch"/> instance for mocking. </returns>
        public static OperationalInsightsWorkspacePatch OperationalInsightsWorkspacePatch(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string eTag = default, OperationalInsightsWorkspaceEntityStatus? provisioningState = default, Guid? customerId = default, OperationalInsightsWorkspaceSku sku = default, int? retentionInDays = default, OperationalInsightsWorkspaceCapping workspaceCapping = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForIngestion = default, OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForQuery = default, bool? forceCmkForQuery = default, IEnumerable<OperationalInsightsPrivateLinkScopedResourceInfo> privateLinkScopedResources = default, OperationalInsightsWorkspaceFeatures features = default, ResourceIdentifier defaultDataCollectionRuleResourceId = default, OperationalInsightsWorkspaceReplicationProperties replication = default, OperationalInsightsWorkspaceFailoverProperties failover = default, ManagedServiceIdentity identity = default, IDictionary<string, string> tags = default)
        {
            return OperationalInsightsWorkspacePatch(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                provisioningState: provisioningState,
                customerId: customerId,
                sku: sku,
                retentionInDays: retentionInDays,
                workspaceCapping: workspaceCapping,
                createdOn: createdOn,
                modifiedOn: modifiedOn,
                publicNetworkAccessForIngestion: publicNetworkAccessForIngestion,
                publicNetworkAccessForQuery: publicNetworkAccessForQuery,
                forceCmkForQuery: forceCmkForQuery,
                privateLinkScopedResources: privateLinkScopedResources,
                features: features,
                defaultDataCollectionRuleResourceId: defaultDataCollectionRuleResourceId,
                replication: replication,
                failover: failover,
                identity: identity,
                tags: tags,
                eTag: eTag is null ? default(ETag?) : new ETag(eTag));
        }
    }
}
