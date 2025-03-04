// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ServiceNetworking.Models
{
#pragma warning disable 0618
    /// <summary> Model factory for models. </summary>
    public static partial class ArmServiceNetworkingModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ServiceNetworking.TrafficControllerData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="configurationEndpoints"> Configuration Endpoints. </param>
        /// <param name="frontends"> Frontends References List. </param>
        /// <param name="associations"> Associations References List. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <returns> A new <see cref="ServiceNetworking.TrafficControllerData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TrafficControllerData TrafficControllerData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> configurationEndpoints, IEnumerable<SubResource> frontends, IEnumerable<SubResource> associations, ProvisioningState? provisioningState)
            => TrafficControllerData(id, name, resourceType, systemData, tags, location, configurationEndpoints, frontends, associations, null, null, provisioningState.ToString());

        /// <summary> Initializes a new instance of <see cref="ServiceNetworking.AssociationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="associationType"> Association Type. </param>
        /// <param name="subnetId"> Association Subnet. </param>
        /// <param name="provisioningState"> Provisioning State of Traffic Controller Association Resource. </param>
        /// <returns> A new <see cref="ServiceNetworking.AssociationData"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use `TrafficControllerAssociationData` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AssociationData AssociationData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, AssociationType? associationType, ResourceIdentifier subnetId, ProvisioningState? provisioningState)
        {
            tags ??= new Dictionary<string, string>();

            return new AssociationData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                associationType,
                subnetId != null ? ResourceManagerModelFactory.WritableSubResource(subnetId) : null,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ServiceNetworking.FrontendData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="fqdn"> The Fully Qualified Domain Name of the DNS record associated to a Traffic Controller frontend. </param>
        /// <param name="provisioningState"> Provisioning State of Traffic Controller Frontend Resource. </param>
        /// <returns> A new <see cref="ServiceNetworking.FrontendData"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use `TrafficControllerFrontedData` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FrontendData FrontendData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string fqdn, ProvisioningState? provisioningState)
        {
            tags ??= new Dictionary<string, string>();

            return new FrontendData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                fqdn,
                provisioningState,
                serializedAdditionalRawData: null);
        }
    }
#pragma warning restore 0618
}
