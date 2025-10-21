// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.DeviceRegistry.Models
{
    public partial class ArmDeviceRegistryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DeviceRegistryAssetEndpointProfileProperties"/>. </summary>
        /// <param name="uuid"> Globally unique, immutable, non-reusable id. </param>
        /// <param name="targetAddress"> The local valid URI specifying the network address/DNS name of a southbound device. The scheme part of the targetAddress URI specifies the type of the device. The additionalConfiguration field holds further connector type specific configuration. </param>
        /// <param name="endpointProfileType"> Defines the configuration for the connector type that is being used with the endpoint profile. </param>
        /// <param name="authentication"> Defines the client authentication mechanism to the server. </param>
        /// <param name="additionalConfiguration"> Stringified JSON that contains connectivity type specific further configuration (e.g. OPC UA, Modbus, ONVIF). </param>
        /// <param name="discoveredAssetEndpointProfileRef"> Reference to a discovered asset endpoint profile. Populated only if the asset endpoint profile has been created from discovery flow. Discovered asset endpoint profile name must be provided. </param>
        /// <param name="statusErrors"> Read only object to reflect changes that have occurred on the Edge. Similar to Kubernetes status property for custom resources. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <returns> A new <see cref="Models.DeviceRegistryAssetEndpointProfileProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DeviceRegistryAssetEndpointProfileProperties DeviceRegistryAssetEndpointProfileProperties(string uuid = null, Uri targetAddress = null, string endpointProfileType = null, DeviceRegistryAuthentication authentication = null, string additionalConfiguration = null, string discoveredAssetEndpointProfileRef = null, IEnumerable<AssetEndpointProfileStatusError> statusErrors = null, DeviceRegistryProvisioningState? provisioningState = null)
        {
            statusErrors ??= new List<AssetEndpointProfileStatusError>();

            return new DeviceRegistryAssetEndpointProfileProperties(
                uuid,
                targetAddress,
                endpointProfileType,
                authentication,
                additionalConfiguration,
                discoveredAssetEndpointProfileRef,
                statusErrors != null ? new AssetEndpointProfileStatus(statusErrors?.ToList(), additionalBinaryDataProperties: null) : null,
                provisioningState,
                additionalBinaryDataProperties: null);
        }
    }
}
