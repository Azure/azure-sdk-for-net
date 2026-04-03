// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

// Backward-compat ModelFactory overload for TypeSpec migration (ApiCompat MembersMustExist).
// The old GA overload has non-optional params with slightly different types (e.g., InitContainerDefinitionContent).
// The new generated overload has all-optional params and wraps properties in ContainerGroupPropertiesProperties.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public static partial class ArmContainerInstanceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstance.ContainerGroupData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerGroupData ContainerGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, ManagedServiceIdentity identity, string provisioningState, IEnumerable<ContainerInstanceContainer> containers, IEnumerable<ContainerGroupImageRegistryCredential> imageRegistryCredentials, ContainerGroupRestartPolicy? restartPolicy, ContainerGroupIPAddress ipAddress, ContainerInstanceOperatingSystemType osType, IEnumerable<ContainerVolume> volumes, ContainerGroupInstanceView instanceView, ContainerGroupLogAnalytics diagnosticsLogAnalytics, IEnumerable<ContainerGroupSubnetId> subnetIds, ContainerGroupDnsConfiguration dnsConfig, ContainerGroupSku? sku, ContainerGroupEncryptionProperties encryptionProperties, IEnumerable<InitContainerDefinitionContent> initContainers, IEnumerable<DeploymentExtensionSpec> extensions, string confidentialComputeCcePolicy, ContainerGroupPriority? priority)
        {
            return new ContainerGroupData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                location,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                (zones ?? new ChangeTrackingList<string>()).ToList(),
                identity,
                new ContainerGroupPropertiesProperties(
                    provisioningState,
                    new ChangeTrackingList<ContainerGroupSecretReference>(),
                    (containers ?? new ChangeTrackingList<ContainerInstanceContainer>()).ToList(),
                    (imageRegistryCredentials ?? new ChangeTrackingList<ContainerGroupImageRegistryCredential>()).ToList(),
                    restartPolicy,
                    ipAddress,
                    osType,
                    (volumes ?? new ChangeTrackingList<ContainerVolume>()).ToList(),
                    instanceView,
                    diagnosticsLogAnalytics != null ? new ContainerGroupDiagnostics(diagnosticsLogAnalytics, null) : null,
                    (subnetIds ?? new ChangeTrackingList<ContainerGroupSubnetId>()).ToList(),
                    dnsConfig,
                    sku,
                    encryptionProperties,
                    (initContainers ?? new ChangeTrackingList<InitContainerDefinitionContent>()).Select(i => (InitContainerDefinition)i).ToList(),
                    (extensions ?? new ChangeTrackingList<DeploymentExtensionSpec>()).ToList(),
                    confidentialComputeCcePolicy != null ? new ConfidentialComputeProperties(confidentialComputeCcePolicy, null) : null,
                    priority,
                    default,
                    default,
                    default,
                    default,
                    additionalBinaryDataProperties: null));
        }
    }
}
