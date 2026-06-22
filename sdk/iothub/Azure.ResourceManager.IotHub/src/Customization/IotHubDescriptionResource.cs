// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

#pragma warning disable CS1591 // Compatibility overloads mirror existing generated API documentation.

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // These shims intentionally preserve public API shapes from the pre-TypeSpec IoT Hub management
    // package. The TypeSpec-generated ARM surface is more strictly aligned with the resource model, but
    // several GA callers rely on older method names, collection entry points, and string-based If-Match
    // overloads. Keeping these members in custom partials lets the generated code remain regeneration-safe
    // while maintaining source and binary compatibility for existing customers.
    public partial class IotHubDescriptionResource
    {
        // The lower-case "iotHubs" route segment is required to keep the generated swagger identical to
        // the checked-in OpenAPI. With that segment casing, the generator no longer treats these private
        // endpoint operations as normal child-resource collection methods on the parent resource. These
        // helpers restore the previous parameterless collection accessors and single-name forwarding
        // methods by using the parent IoT Hub resource identifier as the missing resourceName.
        public virtual IotHubPrivateEndpointConnectionCollection GetIotHubPrivateEndpointConnections()
            => GetCachedClient(client => new IotHubPrivateEndpointConnectionCollection(client, Id));

        [ForwardsClientCalls]
        public virtual async Task<Response<IotHubPrivateEndpointConnectionResource>> GetIotHubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => await GetIotHubPrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);

        [ForwardsClientCalls]
        public virtual Response<IotHubPrivateEndpointConnectionResource> GetIotHubPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => GetIotHubPrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);

        public virtual IotHubPrivateEndpointGroupInformationCollection GetAllIotHubPrivateEndpointGroupInformation()
            => GetCachedClient(client => new IotHubPrivateEndpointGroupInformationCollection(client, Id));

        [ForwardsClientCalls]
        public virtual async Task<Response<IotHubPrivateEndpointGroupInformationResource>> GetIotHubPrivateEndpointGroupInformationAsync(string groupId, CancellationToken cancellationToken = default)
            => await GetAllIotHubPrivateEndpointGroupInformation().GetAsync(groupId, cancellationToken).ConfigureAwait(false);

        [ForwardsClientCalls]
        public virtual Response<IotHubPrivateEndpointGroupInformationResource> GetIotHubPrivateEndpointGroupInformation(string groupId, CancellationToken cancellationToken = default)
            => GetAllIotHubPrivateEndpointGroupInformation().Get(groupId, cancellationToken);
    }
}

#pragma warning restore CS1591
