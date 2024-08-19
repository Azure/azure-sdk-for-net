// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager
{
    /// <summary>
    /// The entry point for all ARM clients.
    /// </summary>
    [CodeGenSuppress("GetTenantResource", typeof(ResourceIdentifier))]
    public partial class ArmClient
    {
        /// <summary>
        /// Gets an object representing a <see cref="GenericResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="GenericResource" /> object. </returns>
        public virtual GenericResource GetGenericResource(ResourceIdentifier id)
        {
            GenericResource.ValidateResourceId(id);
            return new GenericResource(this, id);
        }
    }
}
