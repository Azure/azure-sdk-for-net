// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.ProviderHub.Mocking
{
    public partial class MockableProviderHubArmClient
    {
        // Preserve the released resource accessor after its removal from generated code.
        /// <summary> Gets a frontload release resource without data. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The frontload release resource. </returns>
        public virtual RegistrationNewRegionFrontloadReleaseResource GetRegistrationNewRegionFrontloadReleaseResource(ResourceIdentifier id)
        {
            RegistrationNewRegionFrontloadReleaseResource.ValidateResourceId(id);
            return new RegistrationNewRegionFrontloadReleaseResource(Client, id);
        }
    }
}
