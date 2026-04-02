// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes
{
    // Generator bug workaround (https://github.com/Azure/azure-sdk-for-net/issues/57645):
    // Multi-scope resource generates duplicate GetExtensionTypeInterfaceResource methods (one per scope).
    // Suppress the generated duplicates and provide a single implementation.
    [CodeGenSuppress("GetExtensionTypeInterfaceResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class KubernetesConfigurationExtensionTypesExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="ExtensionTypeInterfaceResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableKubernetesConfigurationExtensionTypesArmClient.GetExtensionTypeInterfaceResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ExtensionTypeInterfaceResource"/> object. </returns>
        public static ExtensionTypeInterfaceResource GetExtensionTypeInterfaceResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableKubernetesConfigurationExtensionTypesArmClient(client).GetExtensionTypeInterfaceResource(id);
        }
    }
}
