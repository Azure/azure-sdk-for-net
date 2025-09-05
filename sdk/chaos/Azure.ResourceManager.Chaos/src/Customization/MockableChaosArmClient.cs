// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Chaos.Mocking
{
    public partial class MockableChaosArmClient
    {
        /// <summary>
        /// Gets an object representing a <see cref="ChaosCapabilityTypeResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ChaosCapabilityTypeResource.CreateResourceIdentifier" /> to create a <see cref="ChaosCapabilityTypeResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ChaosCapabilityTypeResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public virtual ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(ResourceIdentifier id)
        {
            ChaosCapabilityTypeResource.ValidateResourceId(id);
            return new ChaosCapabilityTypeResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ChaosTargetTypeResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ChaosTargetTypeResource.CreateResourceIdentifier" /> to create a <see cref="ChaosTargetTypeResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ChaosTargetTypeResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public virtual ChaosTargetTypeResource GetChaosTargetTypeResource(ResourceIdentifier id)
        {
            ChaosTargetTypeResource.ValidateResourceId(id);
            return new ChaosTargetTypeResource(Client, id);
        }
    }
}
