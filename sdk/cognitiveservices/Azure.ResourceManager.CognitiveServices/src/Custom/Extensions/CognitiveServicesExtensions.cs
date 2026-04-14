// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.CognitiveServices.Mocking;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices
{
    public static partial class CognitiveServicesExtensions
    {
        // This method is used to support the mitigation solution of using a single data model for both CapabilityHost and ProjectCapabilityHost resources.
        /// <summary>
        /// Gets an object representing a <see cref="CognitiveServicesProjectCapabilityHostResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CognitiveServicesProjectCapabilityHostResource.CreateResourceIdentifier" /> to create a <see cref="CognitiveServicesProjectCapabilityHostResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableCognitiveServicesArmClient.GetCognitiveServicesProjectCapabilityHostResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="CognitiveServicesProjectCapabilityHostResource"/> object. </returns>
        public static CognitiveServicesProjectCapabilityHostResource GetCognitiveServicesProjectCapabilityHostResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableCognitiveServicesArmClient(client).GetCognitiveServicesProjectCapabilityHostResource(id);
        }
    }
}
