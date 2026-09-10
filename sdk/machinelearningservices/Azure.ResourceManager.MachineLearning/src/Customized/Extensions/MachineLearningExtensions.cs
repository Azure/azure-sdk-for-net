// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Mocking;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: correcting the resource name also renames the generated ArmClient extension methods.
    // Preserve the shipped MachineLearnin* entry points and route them through their mockable compatibility hooks.
    public static partial class MachineLearningExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="MachineLearninRegistryComponentContainerResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableMachineLearningArmClient.GetMachineLearninRegistryComponentContainerResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="MachineLearninRegistryComponentContainerResource"/> object. </returns>
        [Obsolete("GetMachineLearninRegistryComponentContainerResource is obsolete and will be removed in a future release. Please use GetMachineLearningRegistryComponentContainerResource instead.")]
        public static MachineLearninRegistryComponentContainerResource GetMachineLearninRegistryComponentContainerResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMachineLearningArmClient(client).GetMachineLearninRegistryComponentContainerResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="MachineLearninRegistryComponentVersionResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableMachineLearningArmClient.GetMachineLearninRegistryComponentVersionResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="MachineLearninRegistryComponentVersionResource"/> object. </returns>
        [Obsolete("GetMachineLearninRegistryComponentVersionResource is obsolete and will be removed in a future release. Please use GetMachineLearningRegistryComponentVersionResource instead.")]
        public static MachineLearninRegistryComponentVersionResource GetMachineLearninRegistryComponentVersionResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMachineLearningArmClient(client).GetMachineLearninRegistryComponentVersionResource(id);
        }
    }
}
