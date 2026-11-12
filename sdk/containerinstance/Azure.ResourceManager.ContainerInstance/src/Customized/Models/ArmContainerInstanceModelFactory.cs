// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    // Restores the GA factory surface retained for package compatibility.
    public static partial class ArmContainerInstanceModelFactory
    {
        /// <summary> Properties of a SandboxGroup. </summary>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <param name="networkSubnets"> The list of subnets associated with the SandboxGroup. </param>
        /// <param name="managementResourceGroupId"> The ARM resource ID of the management resource group associated with this SandboxGroup. </param>
        /// <returns> A new <see cref="Models.ContainerGroupSandboxProperties"/> instance for mocking. </returns>
        public static ContainerGroupSandboxProperties ContainerGroupSandboxProperties(ContainerGroupSandboxProvisioningState? provisioningState = default, IEnumerable<ContainerSandboxGroupSubnetReference> networkSubnets = default, ResourceIdentifier managementResourceGroupId = default)
        {
            return new ContainerGroupSandboxProperties(provisioningState, networkSubnets is null ? default : new SandboxGroupNetworkProfile((networkSubnets ?? new ChangeTrackingList<ContainerSandboxGroupSubnetReference>()).ToList(), default), managementResourceGroupId, default);
        }

        /// <summary> A SandboxGroup tracked resource. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="properties"> The resource-specific properties for this resource. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <returns> A new <see cref="ContainerInstance.ContainerGroupSandboxData"/> instance for mocking. </returns>
        public static ContainerGroupSandboxData ContainerGroupSandboxData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, ContainerGroupSandboxProperties properties = default, ManagedServiceIdentity identity = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new ContainerGroupSandboxData(id, name, resourceType, systemData, tags ?? new ChangeTrackingDictionary<string, string>(), location, properties, identity, default);
        }

        /// <summary> The type used for updating a SandboxGroup resource. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <returns> A new <see cref="Models.ContainerSandboxGroupPatch"/> instance for mocking. </returns>
        public static ContainerSandboxGroupPatch ContainerSandboxGroupPatch(IDictionary<string, string> tags = default, ManagedServiceIdentity identity = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new ContainerSandboxGroupPatch(tags ?? new ChangeTrackingDictionary<string, string>(), identity, default);
        }

        /// <summary> The result of getting an access token for a SandboxGroup. </summary>
        /// <param name="endpoint"> The endpoint URL to use with the access token. </param>
        /// <param name="accessToken"> The access token used to authenticate against the endpoint. </param>
        /// <param name="notAfterOn"> The UTC date and time at which the access token expires. </param>
        /// <returns> A new <see cref="Models.ContainerSandboxGroupAccessToken"/> instance for mocking. </returns>
        public static ContainerSandboxGroupAccessToken ContainerSandboxGroupAccessToken(System.Uri endpoint = default, string accessToken = default, System.DateTimeOffset notAfterOn = default)
        {
            return new ContainerSandboxGroupAccessToken(endpoint, accessToken, notAfterOn, default);
        }
    }
}
