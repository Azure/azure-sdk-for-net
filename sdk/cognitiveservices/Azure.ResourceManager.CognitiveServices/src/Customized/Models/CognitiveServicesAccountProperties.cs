// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    /// <summary> Properties of Cognitive Services account. </summary>
    public partial class CognitiveServicesAccountProperties
    {
        /// <summary> (Deprecated) The network injections for the Cognitive Services account. </summary>
        [WirePath("networkInjections")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Please use `AIFoundryNetworkInjections` instead.")]
        public AIFoundryNetworkInjection NetworkInjections { get { throw new InvalidOperationException("Deprecated.  Use AIFoundryNetworkInjections array instead"); } set { throw new InvalidOperationException("Deprecated. Use AIFoundryNetworkInjections array instead"); } }

        internal CognitiveServicesAccountProperties(ServiceAccountProvisioningState? provisioningState, string endpoint, IReadOnlyList<CognitiveServicesSkuCapability> capabilities, bool? isMigrated, string migrationToken, CognitiveServicesSkuChangeInfo skuChangeInfo, string customSubDomainName, CognitiveServicesNetworkRuleSet networkAcls, ServiceAccountEncryptionProperties encryption, IList<ServiceAccountUserOwnedStorage> userOwnedStorage, UserOwnedAmlWorkspace amlWorkspace, IReadOnlyList<CognitiveServicesPrivateEndpointConnectionData> privateEndpointConnections, ServiceAccountPublicNetworkAccess? publicNetworkAccess, ServiceAccountApiProperties apiProperties, DateTimeOffset? createdOn, ServiceAccountCallRateLimit callRateLimit, bool? enableDynamicThrottling, ServiceAccountQuotaLimit quotaLimit, bool? restrictOutboundNetworkAccess, IList<string> allowedFqdnList, bool? disableLocalAuth, IReadOnlyDictionary<string, string> endpoints, bool? restore, DateTimeOffset? deletedOn, string scheduledPurgeDate, CognitiveServicesMultiRegionSettings locations, IReadOnlyList<CommitmentPlanAssociation> commitmentPlanAssociations, AbusePenalty abusePenalty, RaiMonitorConfig raiMonitorConfig, AIFoundryNetworkInjection aiFoundryNetworkInjection, bool? allowProjectManagement, string defaultProject, IList<string> associatedProjects, IDictionary<string, BinaryData> serializedAdditionalRawData):this(provisioningState, endpoint, capabilities, isMigrated, migrationToken, skuChangeInfo, customSubDomainName, networkAcls, encryption, userOwnedStorage, amlWorkspace, privateEndpointConnections, publicNetworkAccess, apiProperties, createdOn, callRateLimit, enableDynamicThrottling, quotaLimit, restrictOutboundNetworkAccess, allowedFqdnList, disableLocalAuth, endpoints, restore, deletedOn, scheduledPurgeDate, locations, commitmentPlanAssociations, abusePenalty, raiMonitorConfig, new List<AIFoundryNetworkInjection> { aiFoundryNetworkInjection }, allowProjectManagement, defaultProject, associatedProjects, serializedAdditionalRawData)
        {
        }
    }
}
