// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmCognitiveServicesModelFactory
    {
        /// <summary> (Deprecated) Initializes a new instance of <see cref="Models.CognitiveServicesAccountProperties"/>. </summary>
        public static CognitiveServicesAccountProperties CognitiveServicesAccountProperties(ServiceAccountProvisioningState? provisioningState = null, string endpoint = null, IEnumerable<CognitiveServicesSkuCapability> capabilities = null, bool? isMigrated = null, string migrationToken = null, CognitiveServicesSkuChangeInfo skuChangeInfo = null, string customSubDomainName = null, CognitiveServicesNetworkRuleSet networkAcls = null, ServiceAccountEncryptionProperties encryption = null, IEnumerable<ServiceAccountUserOwnedStorage> userOwnedStorage = null, UserOwnedAmlWorkspace amlWorkspace = null, IEnumerable<CognitiveServicesPrivateEndpointConnectionData> privateEndpointConnections = null, ServiceAccountPublicNetworkAccess? publicNetworkAccess = null, ServiceAccountApiProperties apiProperties = null, DateTimeOffset? createdOn = null, ServiceAccountCallRateLimit callRateLimit = null, bool? enableDynamicThrottling = null, ServiceAccountQuotaLimit quotaLimit = null, bool? restrictOutboundNetworkAccess = null, IEnumerable<string> allowedFqdnList = null, bool? disableLocalAuth = null, IReadOnlyDictionary<string, string> endpoints = null, bool? restore = null, DateTimeOffset? deletedOn = null, string scheduledPurgeDate = null, CognitiveServicesMultiRegionSettings locations = null, IEnumerable<CommitmentPlanAssociation> commitmentPlanAssociations = null, AbusePenalty abusePenalty = null, RaiMonitorConfig raiMonitorConfig = null, AIFoundryNetworkInjection aiFoundryNetworkInjection = null, bool? allowProjectManagement = null, string defaultProject = null, IEnumerable<string> associatedProjects = null)
        {
            capabilities ??= new List<CognitiveServicesSkuCapability>();
            userOwnedStorage ??= new List<ServiceAccountUserOwnedStorage>();
            privateEndpointConnections ??= new List<CognitiveServicesPrivateEndpointConnectionData>();
            allowedFqdnList ??= new List<string>();
            endpoints ??= new Dictionary<string, string>();
            commitmentPlanAssociations ??= new List<CommitmentPlanAssociation>();
            associatedProjects ??= new List<string>();

            List<AIFoundryNetworkInjection> aiFoundryNetworkInjections = new List<AIFoundryNetworkInjection>();
            if (aiFoundryNetworkInjection != null)
            {
                aiFoundryNetworkInjections.Add(aiFoundryNetworkInjection);
            }

            return new CognitiveServicesAccountProperties(
                provisioningState,
                endpoint,
                capabilities?.ToList(),
                isMigrated,
                migrationToken,
                skuChangeInfo,
                customSubDomainName,
                networkAcls,
                encryption,
                userOwnedStorage?.ToList(),
                amlWorkspace,
                privateEndpointConnections?.ToList(),
                publicNetworkAccess,
                apiProperties,
                createdOn,
                callRateLimit,
                enableDynamicThrottling,
                quotaLimit,
                restrictOutboundNetworkAccess,
                allowedFqdnList?.ToList(),
                disableLocalAuth,
                endpoints,
                restore,
                deletedOn,
                scheduledPurgeDate,
                locations,
                commitmentPlanAssociations?.ToList(),
                abusePenalty,
                raiMonitorConfig,
                aiFoundryNetworkInjections?.ToList(),
                allowProjectManagement,
                defaultProject,
                associatedProjects?.ToList(),
                serializedAdditionalRawData: null);
        }
    }
}
