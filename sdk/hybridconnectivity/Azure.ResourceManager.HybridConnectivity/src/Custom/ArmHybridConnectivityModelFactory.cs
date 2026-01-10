// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmHybridConnectivityModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.HybridConnectivityOperationStatus"/>. </summary>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        /// <param name="resourceId"> Fully qualified ID of the resource against which the original async operation was started. </param>
        /// <returns> A new <see cref="Models.HybridConnectivityOperationStatus"/> instance for mocking. </returns>
        public static HybridConnectivityOperationStatus HybridConnectivityOperationStatus(ResourceIdentifier id = default, string name = default, string status = default, double? percentComplete = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, IEnumerable<HybridConnectivityOperationStatus> operations = default, ResponseError error = default, ResourceIdentifier resourceId = default)
        {
            operations ??= new List<HybridConnectivityOperationStatus>();

            return new HybridConnectivityOperationStatus(
                id,
                name,
                status,
                percentComplete,
                startOn,
                endOn,
                operations?.ToList(),
                error,
                resourceId,
                serializedAdditionalRawData: null);
        }

        /// <param name="hostname"> The ingress hostname. </param>
        /// <param name="serverId"> The arc ingress gateway server app id. </param>
        /// <param name="tenantId"> The target resource home tenant id. </param>
        /// <param name="namespaceName"> The namespace name. </param>
        /// <param name="namespaceNameSuffix"> The suffix domain name of relay namespace. </param>
        /// <param name="hybridConnectionName"> Azure Relay hybrid connection name for the resource. </param>
        /// <param name="accessKey"> Access key for hybrid connection. </param>
        /// <param name="expiresOn"> The expiration of access key in unix time. </param>
        /// <param name="serviceConfigurationToken"> The token to access the enabled service. </param>
        /// <returns> A new <see cref="Models.IngressGatewayAsset"/> instance for mocking. </returns>
        public static IngressGatewayAsset IngressGatewayAsset(string hostname = default, Guid? serverId = default, Guid? tenantId = default, string namespaceName = default, string namespaceNameSuffix = default, string hybridConnectionName = default, string accessKey = default, long? expiresOn = default, string serviceConfigurationToken = default)
        {
            return new IngressGatewayAsset(
                namespaceName is null && namespaceNameSuffix is null && hybridConnectionName is null && accessKey is null && expiresOn is null && serviceConfigurationToken is null ? default : new RelayNamespaceAccessProperties(
                    namespaceName,
                    namespaceNameSuffix,
                    hybridConnectionName,
                    accessKey,
                    expiresOn,
                    serviceConfigurationToken,
                    null),
                hostname is null && serverId is null && tenantId is null ? default : new IngressProfileProperties(hostname, new AADProfileProperties(serverId.GetValueOrDefault(), tenantId.GetValueOrDefault(), null), null),
                additionalBinaryDataProperties: null);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="awsCloudExcludedAccounts"> List of AWS accounts which need to be excluded. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <returns> A new <see cref="Models.PublicCloudConnectorPatch"/> instance for mocking. </returns>
        public static PublicCloudConnectorPatch PublicCloudConnectorPatch(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IEnumerable<string> awsCloudExcludedAccounts = default, IDictionary<string, string> tags = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            PublicCloudConnectorPropertiesUpdate properties = null;
            if (awsCloudExcludedAccounts != null)
            {
                var awsCloudProfile = new AwsCloudProfileUpdate(awsCloudExcludedAccounts?.ToList(), null);
                properties = new PublicCloudConnectorPropertiesUpdate(awsCloudProfile, null);
            }

            return new PublicCloudConnectorPatch(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                properties);
        }

        /// <param name="provisioningState"> The resource provisioning state. </param>
        /// <param name="solutionType"> The type of the solution. </param>
        /// <param name="solutionSettings"> Solution settings. </param>
        /// <param name="status"> The status of solution configurations. </param>
        /// <param name="statusDetails"> The detailed message of status details. </param>
        /// <param name="lastSyncedOn"> The last time resources were inventoried. </param>
        /// <returns> A new <see cref="Models.PublicCloudConnectorSolutionConfigurationProperties"/> instance for mocking. </returns>
        public static PublicCloudConnectorSolutionConfigurationProperties PublicCloudConnectorSolutionConfigurationProperties(PublicCloudResourceProvisioningState? provisioningState = default, string solutionType = default, PublicCloudConnectorSolutionSettings solutionSettings = default, PublicCloudConnectorSolutionConfigurationStatus? status = default, string statusDetails = default, DateTimeOffset? lastSyncedOn = default)
        {
            return new PublicCloudConnectorSolutionConfigurationProperties(
                provisioningState,
                solutionType,
                solutionSettings,
                status,
                statusDetails,
                lastSyncedOn,
                additionalBinaryDataProperties: null);
        }

        /// <param name="solutionType"> The type of the solution. </param>
        /// <param name="solutionSettings"> Solution settings. </param>
        /// <returns> A new <see cref="Models.PublicCloudConnectorSolutionTypeSettings"/> instance for mocking. </returns>
        public static PublicCloudConnectorSolutionTypeSettings PublicCloudConnectorSolutionTypeSettings(string solutionType = default, PublicCloudConnectorSolutionSettings solutionSettings = default)
        {
            return new PublicCloudConnectorSolutionTypeSettings(solutionType, solutionSettings, additionalBinaryDataProperties: null);
        }
    }
}
