// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    public static partial class ArmOperationalInsightsModelFactory
    {
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
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new OperationalInsightsWorkspacePatch(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                eTag,
                provisioningState is null && customerId is null && sku is null && retentionInDays is null && workspaceCapping is null && createdOn is null && modifiedOn is null && publicNetworkAccessForIngestion is null && publicNetworkAccessForQuery is null && forceCmkForQuery is null && privateLinkScopedResources is null && features is null && defaultDataCollectionRuleResourceId is null && replication is null && failover is null ? default : new WorkspaceProperties(
                    provisioningState,
                    customerId,
                    sku,
                    retentionInDays,
                    workspaceCapping,
                    createdOn,
                    modifiedOn,
                    publicNetworkAccessForIngestion,
                    publicNetworkAccessForQuery,
                    forceCmkForQuery,
                    (privateLinkScopedResources ?? new ChangeTrackingList<OperationalInsightsPrivateLinkScopedResourceInfo>()).ToList(),
                    features,
                    defaultDataCollectionRuleResourceId,
                    replication,
                    failover,
                    null),
                identity,
                tags);
        }
    }
}