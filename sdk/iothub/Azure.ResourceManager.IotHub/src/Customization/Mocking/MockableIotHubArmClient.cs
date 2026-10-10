// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.IotHub;

namespace Azure.ResourceManager.IotHub.Mocking
{
    // Customization justification:
    // The private endpoint group information child resource is restored in custom code for SDK
    // compatibility while the TypeSpec model stays swagger-compatible. This partial keeps the matching
    // mockable ArmClient entry point available for tests and mocking scenarios.
    public partial class MockableIotHubArmClient
    {
        /// <summary> Gets an object representing a <see cref="IotHubPrivateEndpointGroupInformationResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        public virtual IotHubPrivateEndpointGroupInformationResource GetIotHubPrivateEndpointGroupInformationResource(ResourceIdentifier id)
        {
            IotHubPrivateEndpointGroupInformationResource.ValidateResourceId(id);
            return new IotHubPrivateEndpointGroupInformationResource(Client, id);
        }
    }
}
