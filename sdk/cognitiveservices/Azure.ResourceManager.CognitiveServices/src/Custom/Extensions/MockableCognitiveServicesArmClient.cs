// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.CognitiveServices;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices.Mocking
{
    public partial class MockableCognitiveServicesArmClient : ArmResource
    {
        // This method is used to support the mitigation solution of using a single data model for both CapabilityHost and ProjectCapabilityHost resources.
        /// <summary>
        /// Gets an object representing a <see cref="CognitiveServicesProjectCapabilityHostResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CognitiveServicesProjectCapabilityHostResource.CreateResourceIdentifier" /> to create a <see cref="CognitiveServicesProjectCapabilityHostResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CognitiveServicesProjectCapabilityHostResource"/> object. </returns>
        public virtual CognitiveServicesProjectCapabilityHostResource GetCognitiveServicesProjectCapabilityHostResource(ResourceIdentifier id)
        {
            CognitiveServicesProjectCapabilityHostResource.ValidateResourceId(id);
            return new CognitiveServicesProjectCapabilityHostResource(Client, id);
        }
    }
}
