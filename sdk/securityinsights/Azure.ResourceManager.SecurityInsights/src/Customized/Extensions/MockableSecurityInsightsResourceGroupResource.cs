// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.SecurityInsights.Mocking
{
    // Compatibility mitigation: the TypeSpec migration does not emit this resource-group mockable extension type,
    // but the GA SDK exposed it for tests and mocking scenarios. Keep until the compatibility shim is no longer needed.
    /// <summary> A class to add extension methods to <see cref="Azure.ResourceManager.Resources.ResourceGroupResource"/>. </summary>
    public partial class MockableSecurityInsightsResourceGroupResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableSecurityInsightsResourceGroupResource"/> class for mocking. </summary>
        protected MockableSecurityInsightsResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableSecurityInsightsResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableSecurityInsightsResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
