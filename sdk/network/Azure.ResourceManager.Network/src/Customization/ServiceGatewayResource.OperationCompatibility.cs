// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ServiceGatewayResource type. </summary>
    public partial class ServiceGatewayResource
    {
        /// <summary> Invokes the UpdateAddressLocationsAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> UpdateAddressLocationsAsync(WaitUntil waitUntil, ServiceGatewayUpdateAddressLocationsContent content, CancellationToken cancellationToken = default) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        /// <summary> Invokes the UpdateAddressLocations compatibility operation. </summary>
        public virtual ArmOperation UpdateAddressLocations(WaitUntil waitUntil, ServiceGatewayUpdateAddressLocationsContent content, CancellationToken cancellationToken = default) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        /// <summary> Invokes the UpdateServicesAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> UpdateServicesAsync(WaitUntil waitUntil, ServiceGatewayUpdateServicesContent content, CancellationToken cancellationToken = default) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        /// <summary> Invokes the UpdateServices compatibility operation. </summary>
        public virtual ArmOperation UpdateServices(WaitUntil waitUntil, ServiceGatewayUpdateServicesContent content, CancellationToken cancellationToken = default) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
