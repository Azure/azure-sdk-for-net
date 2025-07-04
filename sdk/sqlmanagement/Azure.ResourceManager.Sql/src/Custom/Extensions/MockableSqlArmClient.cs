// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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

        /// <summary>
        /// Gets an object representing a <see cref="ServiceObjectiveResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ServiceObjectiveResource.CreateResourceIdentifier" /> to create a <see cref="ServiceObjectiveResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ServiceObjectiveResource"/> object. </returns>
        [Obsolete]
        public virtual ServiceObjectiveResource GetServiceObjectiveResource(ResourceIdentifier id)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets an object representing a <see cref="SqlServerCommunicationLinkResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SqlServerCommunicationLinkResource.CreateResourceIdentifier" /> to create a <see cref="SqlServerCommunicationLinkResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SqlServerCommunicationLinkResource"/> object. </returns>
        [Obsolete]
        public virtual SqlServerCommunicationLinkResource GetSqlServerCommunicationLinkResource(ResourceIdentifier id)
        {
            throw new NotSupportedException();
        }
    }
}
