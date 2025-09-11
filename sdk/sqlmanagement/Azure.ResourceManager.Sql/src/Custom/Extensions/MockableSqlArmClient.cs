// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Sql.Mocking
{
    public partial class MockableSqlArmClient
    {
        /// <summary>
        /// Gets an object representing a <see cref="DistributedAvailabilityGroupResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DistributedAvailabilityGroupResource.CreateResourceIdentifier" /> to create a <see cref="DistributedAvailabilityGroupResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DistributedAvailabilityGroupResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DistributedAvailabilityGroupResource GetDistributedAvailabilityGroupResource(ResourceIdentifier id)
        {
            DistributedAvailabilityGroupResource.ValidateResourceId(id);
            return new DistributedAvailabilityGroupResource(Client, id);
        }
    }
}
