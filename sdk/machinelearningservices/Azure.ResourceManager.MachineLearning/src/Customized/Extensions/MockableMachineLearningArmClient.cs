// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Mocking
{
    [CodeGenSuppress("GetMachineLearningOutboundRuleBasicResource", typeof(ResourceIdentifier))]
    public partial class MockableMachineLearningArmClient
    {
        // The matching ArmClient extension is a GA convenience method missing after the spec gained the managed-network outbound rule route.
        // The resource hierarchy is fixed in TypeSpec, but decorators cannot synthesize Mockable* extension members, so this mock hook is kept
        // with the extension shim.
        /// <summary> Gets an object representing a <see cref="MachineLearningOutboundRuleBasicResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MachineLearningOutboundRuleBasicResource"/> object. </returns>
        public virtual MachineLearningOutboundRuleBasicResource GetMachineLearningOutboundRuleBasicResource(ResourceIdentifier id)
        {
            MachineLearningOutboundRuleBasicResource.ValidateResourceId(id);
            return new MachineLearningOutboundRuleBasicResource(Client, id);
        }

        // Customized: correcting the resource name also renames these generated virtual mocking hooks.
        // Keep the shipped MachineLearnin* methods because client.tsp cannot generate compatibility aliases.
        /// <summary> Gets an object representing a <see cref="MachineLearninRegistryComponentContainerResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MachineLearninRegistryComponentContainerResource"/> object. </returns>
        [Obsolete("GetMachineLearninRegistryComponentContainerResource is obsolete and will be removed in a future release. Please use GetMachineLearningRegistryComponentContainerResource instead.")]
        public virtual MachineLearninRegistryComponentContainerResource GetMachineLearninRegistryComponentContainerResource(ResourceIdentifier id)
        {
            MachineLearninRegistryComponentContainerResource.ValidateResourceId(id);
            return new MachineLearninRegistryComponentContainerResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="MachineLearninRegistryComponentVersionResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MachineLearninRegistryComponentVersionResource"/> object. </returns>
        [Obsolete("GetMachineLearninRegistryComponentVersionResource is obsolete and will be removed in a future release. Please use GetMachineLearningRegistryComponentVersionResource instead.")]
        public virtual MachineLearninRegistryComponentVersionResource GetMachineLearninRegistryComponentVersionResource(ResourceIdentifier id)
        {
            MachineLearninRegistryComponentVersionResource.ValidateResourceId(id);
            return new MachineLearninRegistryComponentVersionResource(Client, id);
        }
    }
}
