// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // GroupIdInformation is defined in TypeSpec, but its operations are scoped out of C# generation to
    // avoid duplicate data-returning methods on IotHubDescriptionResource. This partial restores the
    // stable child-resource ArmClient entry point and delegates to the custom mockable client wrapper.
    public static partial class IotHubExtensions
    {
        /// <summary> Gets an object representing a <see cref="IotHubPrivateEndpointGroupInformationResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        public static IotHubPrivateEndpointGroupInformationResource GetIotHubPrivateEndpointGroupInformationResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableIotHubArmClient(client).GetIotHubPrivateEndpointGroupInformationResource(id);
        }
    }
}
