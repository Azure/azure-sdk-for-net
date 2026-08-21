// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ManufacturingPlatform;

namespace Azure.ResourceManager.ManufacturingPlatform.Models
{
    public static partial class ArmManufacturingPlatformModelFactory
    {
        // This keeps model-factory mocking support for read-only flattened properties. Regeneration does not
        // emit this method because the model has a public constructor, but that constructor cannot set the internal envelopes.
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <param name="version"> Mds Resource Version. </param>
        /// <param name="enableCopilot"> Enable Copilot. </param>
        /// <param name="enableDiagnosticSettings"> Enable Diagnostic Settings. </param>
        /// <param name="aadApplicationId"> AAD Application Id. </param>
        /// <param name="aksAdminGroupId"> AKS Admin Group Id. </param>
        /// <param name="serviceUri"> Service Url. </param>
        /// <param name="aksProfileId"> Resource Id of AKS Resource. </param>
        /// <param name="storageProfileId"> Resource Id of Storage Resource. </param>
        /// <param name="databaseCosmosId"> Resource Id of Cosmos Resource. </param>
        /// <param name="adxProfile"> Profile of Adx Created. </param>
        /// <param name="redisProfileId"> Resource Id of Azure Redis Cache Resource. </param>
        /// <param name="monitoringProfileId"> Resource Id of Application Insights Resource. </param>
        /// <param name="eventHubProfile"> Profile of EventHub Resource. </param>
        /// <param name="functionAppProfileId"> Resource Id of Azure Function App Resource. </param>
        /// <param name="openAIProfile"> Profile of OpenAI Resource. </param>
        /// <param name="managedResourceGroupConfiguration"> Configuration of the managed resource group associated with the resource. </param>
        /// <param name="managedOnBehalfOfBrokerResources"> Associated broker resources managed on behalf of the service. </param>
        /// <param name="cmkKeyUri"> URI of Key in AKV. </param>
        /// <param name="fabricProfile"> Profile of Fabric resources. </param>
        /// <param name="userManagedOpenAIProfile"> Profile of User Managed OpenAI Resource. </param>
        /// <param name="denyAssignmentExclusions"> Deny Assignments exclusion list. </param>
        /// <param name="resourceState"> State of the resource. </param>
        /// <param name="redundancyState"> Zone redundancy state for resources. </param>
        /// <returns> A new <see cref="Models.ManufacturingDataServiceProperties"/> instance for mocking. </returns>
        public static ManufacturingDataServiceProperties ManufacturingDataServiceProperties(ManufacturingPlatformProvisioningState? provisioningState = default, string version = default, bool? enableCopilot = default, bool? enableDiagnosticSettings = default, Guid aadApplicationId = default, Guid? aksAdminGroupId = default, string serviceUri = default, ResourceIdentifier aksProfileId = default, ResourceIdentifier storageProfileId = default, ResourceIdentifier databaseCosmosId = default, AdxProfile adxProfile = default, ResourceIdentifier redisProfileId = default, ResourceIdentifier monitoringProfileId = default, EventHubProfile eventHubProfile = default, ResourceIdentifier functionAppProfileId = default, OpenAIProfile openAIProfile = default, ManagedResourceGroupConfiguration managedResourceGroupConfiguration = default, IEnumerable<ManagedOnBehalfOfBrokerResourceInfo> managedOnBehalfOfBrokerResources = default, string cmkKeyUri = default, FabricProfile fabricProfile = default, UserManagedOpenAIProfile userManagedOpenAIProfile = default, IEnumerable<DenyAssignmentExclusion> denyAssignmentExclusions = default, ManufacturingPlatformResourceState? resourceState = default, ManufacturingPlatformRedundancyState? redundancyState = default)
        {
            denyAssignmentExclusions ??= new ChangeTrackingList<DenyAssignmentExclusion>();

            return new ManufacturingDataServiceProperties(
                provisioningState,
                version,
                enableCopilot,
                enableDiagnosticSettings,
                aadApplicationId,
                aksAdminGroupId,
                serviceUri,
                aksProfileId is null ? default : new AksProfile(aksProfileId, default),
                storageProfileId is null ? default : new StorageProfile(storageProfileId, default),
                databaseCosmosId is null ? default : new DatabaseProfile(databaseCosmosId, default),
                adxProfile,
                redisProfileId is null ? default : new RedisProfile(redisProfileId, default),
                monitoringProfileId is null ? default : new MonitoringProfile(monitoringProfileId, default),
                eventHubProfile,
                functionAppProfileId is null ? default : new FunctionAppProfile(functionAppProfileId, default),
                openAIProfile,
                managedResourceGroupConfiguration,
                managedOnBehalfOfBrokerResources is null ? default : new ManagedOnBehalfOfConfiguration((managedOnBehalfOfBrokerResources ?? new ChangeTrackingList<ManagedOnBehalfOfBrokerResourceInfo>()).ToList(), default),
                cmkKeyUri is null ? default : new CmkProfile(cmkKeyUri, default),
                fabricProfile,
                userManagedOpenAIProfile,
                (denyAssignmentExclusions ?? new ChangeTrackingList<DenyAssignmentExclusion>()).ToList(),
                resourceState,
                redundancyState,
                default);
        }
    }
}
