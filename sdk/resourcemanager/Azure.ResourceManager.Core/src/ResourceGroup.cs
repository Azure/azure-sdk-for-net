// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a ResourceGroup along with the instance operations that can be performed on it.
    /// </summary>
    public class ResourceGroup : ResourceGroupOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroup"/> class for mocking.
        /// </summary>
        protected ResourceGroup()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroup"/> class.
        /// </summary>
        /// <param name="operations"> The operations to copy the client options from. </param>
        /// <param name="resource"> The ResourceGroupData to use in these operations. </param>
        internal ResourceGroup(ResourceOperationsBase operations, ResourceGroupData resource)
            : base(operations, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets the data representing this ResourceGroup.
        /// </summary>
        public virtual ResourceGroupData Data { get; }

        /// <inheritdoc />
        protected override ResourceGroup GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<ResourceGroup> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
