// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific network security group.
    /// </summary>
    public class NetworkSecurityGroup : NetworkSecurityGroupOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSecurityGroup"/> class.
        /// </summary>
        /// <param name="operations"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal NetworkSecurityGroup(ResourceOperationsBase operations, NetworkSecurityGroupData resource)
            : base(operations, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets the data representing this network security group.
        /// </summary>
        public NetworkSecurityGroupData Data { get; private set; }

        /// <inheritdoc />
        protected override NetworkSecurityGroup GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<NetworkSecurityGroup> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
