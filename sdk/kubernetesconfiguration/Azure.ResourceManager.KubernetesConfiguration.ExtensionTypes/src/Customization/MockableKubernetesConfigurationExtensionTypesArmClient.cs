// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Mocking
{
    // Generator bug workaround (https://github.com/Azure/azure-sdk-for-net/issues/57645):
    // Multi-scope resource generates duplicate GetExtensionTypeInterfaceResource methods (one per scope).
    // Suppress the generated duplicates and provide a single implementation.
    [CodeGenSuppress("GetExtensionTypeInterfaceResource", typeof(ResourceIdentifier))]
    public partial class MockableKubernetesConfigurationExtensionTypesArmClient
    {
        /// <summary> Gets an object representing a <see cref="ExtensionTypeInterfaceResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ExtensionTypeInterfaceResource"/> object. </returns>
        public virtual ExtensionTypeInterfaceResource GetExtensionTypeInterfaceResource(ResourceIdentifier id)
        {
            ExtensionTypeInterfaceResource.ValidateResourceId(id);
            return new ExtensionTypeInterfaceResource(Client, id);
        }
    }
}
