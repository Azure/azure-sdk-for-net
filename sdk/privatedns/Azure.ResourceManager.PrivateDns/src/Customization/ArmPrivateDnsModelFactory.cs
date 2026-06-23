// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec exposes the aggregate record-set model internally; suppress its generated factory overload to avoid surfacing internal PrivateDnsRecordSetProperties.

using System.Collections.Generic;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PrivateDns;
using Azure.ResourceManager.Resources.Models;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.PrivateDns.Models
{
    [CodeGenSuppressAttribute("PrivateDnsRecordData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(PrivateDnsRecordSetProperties), typeof(ETag?))]
    [CodeGenSuppressAttribute("VirtualNetworkLinkData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(bool?), typeof(PrivateDnsResolutionPolicy?), typeof(VirtualNetworkLinkState?), typeof(PrivateDnsProvisioningState?), typeof(string), typeof(ETag?))]
    [CodeGenSuppressAttribute("VirtualNetworkLinkData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(WritableSubResource), typeof(bool?), typeof(PrivateDnsResolutionPolicy?), typeof(VirtualNetworkLinkState?), typeof(PrivateDnsProvisioningState?), typeof(ETag?))]
    [CodeGenSuppressAttribute("VirtualNetworkLinkData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ETag?), typeof(ResourceIdentifier), typeof(bool?), typeof(PrivateDnsResolutionPolicy?), typeof(VirtualNetworkLinkState?), typeof(PrivateDnsProvisioningState?))]
    [CodeGenSuppressAttribute("VirtualNetworkLinkData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ETag?), typeof(ResourceIdentifier), typeof(bool?), typeof(VirtualNetworkLinkState?), typeof(PrivateDnsProvisioningState?))]
    public static partial class ArmPrivateDnsModelFactory
    {
        // TypeSpec uses a WritableSubResource wrapper for serialization; preserve the shipped factory overload that takes the virtual network ID directly.
        /// <summary> Initializes a new instance of <see cref="PrivateDns.VirtualNetworkLinkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> The ETag of the virtual network link. </param>
        /// <param name="virtualNetworkId"> The reference of the virtual network. </param>
        /// <param name="registrationEnabled"> Is auto-registration of virtual machine records in the virtual network in the Private DNS zone enabled?. </param>
        /// <param name="privateDnsResolutionPolicy"> The resolution policy on the virtual network link. Only applicable for virtual network links to privatelink zones, and for A,AAAA,CNAME queries. When set to 'NxDomainRedirect', Azure DNS resolver falls back to public resolution if private dns query resolution results in non-existent domain response. </param>
        /// <param name="virtualNetworkLinkState"> The status of the virtual network link to the Private DNS zone. Possible values are 'InProgress' and 'Done'. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="privateDnsProvisioningState"> The provisioning state of the resource. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <returns> A new <see cref="PrivateDns.VirtualNetworkLinkData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkLinkData VirtualNetworkLinkData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, ETag? etag = default, ResourceIdentifier virtualNetworkId = default, bool? registrationEnabled = default, PrivateDnsResolutionPolicy? privateDnsResolutionPolicy = default, VirtualNetworkLinkState? virtualNetworkLinkState = default, PrivateDnsProvisioningState? privateDnsProvisioningState = default)
        {
            return new VirtualNetworkLinkData(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                virtualNetworkId is null && registrationEnabled is null && privateDnsResolutionPolicy is null && virtualNetworkLinkState is null && privateDnsProvisioningState is null ? default : new VirtualNetworkLinkProperties(
                    virtualNetworkId is null ? default : new WritableSubResource { Id = virtualNetworkId },
                    registrationEnabled,
                    privateDnsResolutionPolicy,
                    virtualNetworkLinkState,
                    privateDnsProvisioningState,
                    default),
                etag,
                default);
        }

        // TypeSpec uses a WritableSubResource wrapper for serialization; preserve the shipped factory overload that takes the virtual network ID directly.
        /// <summary> Initializes a new instance of <see cref="PrivateDns.VirtualNetworkLinkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> The ETag of the virtual network link. </param>
        /// <param name="virtualNetworkId"> The reference of the virtual network. </param>
        /// <param name="registrationEnabled"> Is auto-registration of virtual machine records in the virtual network in the Private DNS zone enabled?. </param>
        /// <param name="virtualNetworkLinkState"> The status of the virtual network link to the Private DNS zone. Possible values are 'InProgress' and 'Done'. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="privateDnsProvisioningState"> The provisioning state of the resource. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <returns> A new <see cref="PrivateDns.VirtualNetworkLinkData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkLinkData VirtualNetworkLinkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ResourceIdentifier virtualNetworkId, bool? registrationEnabled, VirtualNetworkLinkState? virtualNetworkLinkState, PrivateDnsProvisioningState? privateDnsProvisioningState)
        {
            return new VirtualNetworkLinkData(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                virtualNetworkId is null && registrationEnabled is null && virtualNetworkLinkState is null && privateDnsProvisioningState is null ? default : new VirtualNetworkLinkProperties(
                    virtualNetworkId is null ? default : new WritableSubResource { Id = virtualNetworkId },
                    registrationEnabled,
                    default,
                    virtualNetworkLinkState,
                    privateDnsProvisioningState,
                    default),
                etag,
                default);
        }
    }
}
