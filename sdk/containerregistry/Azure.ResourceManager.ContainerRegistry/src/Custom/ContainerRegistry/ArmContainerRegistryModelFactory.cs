// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public static partial class ArmContainerRegistryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryImportSource"/>. </summary>
        /// <param name="resourceId"> The resource identifier of the source Azure Container Registry. </param>
        /// <param name="registryAddress"> The address of the source registry (e.g. 'mcr.microsoft.com'). </param>
        /// <param name="credentials"> Credentials used when importing from a registry URI. </param>
        /// <param name="sourceImage"> The repository, tag, or manifest digest of the source image. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryImportSource"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryImportSource ContainerRegistryImportSource(ResourceIdentifier resourceId, string registryAddress, ContainerRegistryImportSourceCredentials credentials, string sourceImage)
        {
            // The generated compatibility overload discarded registryAddress.
            return new ContainerRegistryImportSource(resourceId, registryUri: null, credentials, sourceImage, additionalBinaryDataProperties: null)
            {
                RegistryAddress = registryAddress
            };
        }
    }
}
