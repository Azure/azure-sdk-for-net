// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public static partial class ArmContainerInstanceModelFactory
    {
        // we have this customization because the order of properties changed in the consolidation when a model has multiple `allOf` in their swagger definition.
        /// <summary> Initializes a new instance of <see cref="ContainerInstance.ContainerGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="zones"> The zones for the container group. </param>
        /// <param name="identity"> The identity of the container group, if configured. </param>
        /// <param name="provisioningState"> The provisioning state of the container group. This only appears in the response. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="imageRegistryCredentials"> The image registry credentials by which the container group is created from. </param>
        /// <param name="restartPolicy">
        /// Restart policy for all containers within the container group.
        /// - `Always` Always restart
        /// - `OnFailure` Restart on failure
        /// - `Never` Never restart
        ///
        /// </param>
        /// <param name="ipAddress"> The IP address type of the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <param name="volumes"> The list of volumes that can be mounted by containers in this container group. </param>
        /// <param name="instanceView"> The instance view of the container group. Only valid in response. </param>
        /// <param name="diagnosticsLogAnalytics"> The diagnostic information for a container group. </param>
        /// <param name="subnetIds"> The subnet resource IDs for a container group. </param>
        /// <param name="dnsConfig"> The DNS config information for a container group. </param>
        /// <param name="sku"> The SKU for a container group. </param>
        /// <param name="encryptionProperties"> The encryption properties for a container group. </param>
        /// <param name="initContainers"> The init containers for a container group. </param>
        /// <param name="extensions"> extensions used by virtual kubelet. </param>
        /// <param name="confidentialComputeCcePolicy"> The properties for confidential container group. </param>
        /// <param name="priority"> The priority of the container group. </param>
        /// <returns> A new <see cref="ContainerInstance.ContainerGroupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerGroupData ContainerGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, ManagedServiceIdentity identity, string provisioningState, IEnumerable<ContainerInstanceContainer> containers, IEnumerable<ContainerGroupImageRegistryCredential> imageRegistryCredentials, ContainerGroupRestartPolicy? restartPolicy, ContainerGroupIPAddress ipAddress, ContainerInstanceOperatingSystemType osType, IEnumerable<ContainerVolume> volumes, ContainerGroupInstanceView instanceView, ContainerGroupLogAnalytics diagnosticsLogAnalytics, IEnumerable<ContainerGroupSubnetId> subnetIds, ContainerGroupDnsConfiguration dnsConfig, ContainerGroupSku? sku, ContainerGroupEncryptionProperties encryptionProperties, IEnumerable<InitContainerDefinitionContent> initContainers, IEnumerable<DeploymentExtensionSpec> extensions, string confidentialComputeCcePolicy, ContainerGroupPriority? priority)
        {
            return new ContainerGroupData(id, name, resourceType, systemData, tags, location, identity, provisioningState, null, containers.ToList(), imageRegistryCredentials.ToList(), restartPolicy, ipAddress, default, volumes.ToList(), instanceView, null, subnetIds.ToList(), dnsConfig, sku, encryptionProperties, initContainers.ToList(), extensions.ToList(), null, priority, null, zones.ToList(), null);
        }
    }
}
