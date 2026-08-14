// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Mocking
{
    /// <summary> Compatibility declaration for the MockableNetworkArmClient type. </summary>
    [CodeGenSuppress("GetNetworkInterfaceResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetPublicIPAddressResource", typeof(ResourceIdentifier))]
    public partial class MockableNetworkArmClient
    {
        /// <summary> Gets an object representing a <see cref="NetworkInterfaceResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetworkInterfaceResource"/> object. </returns>
        public virtual NetworkInterfaceResource GetNetworkInterfaceResource(ResourceIdentifier id)
        {
            NetworkInterfaceResource.ValidateResourceId(id);
            return new NetworkInterfaceResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="PublicIPAddressResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PublicIPAddressResource"/> object. </returns>
        public virtual PublicIPAddressResource GetPublicIPAddressResource(ResourceIdentifier id)
        {
            PublicIPAddressResource.ValidateResourceId(id);
            return new PublicIPAddressResource(Client, id);
        }
    }
}
