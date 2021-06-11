// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing an expanded generic azure resource along with the instance operations that can be performed on it.
    /// </summary>
    public class GenericResourceExpanded : GenericResourceExpandedOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceExpanded"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="resource"> The data model representing the generic azure resource. </param>
        internal GenericResourceExpanded(ResourceOperationsBase operations, GenericResourceExpandedData resource)
            : base(operations, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets the data representing this generic azure resource.
        /// </summary>
        public virtual GenericResourceExpandedData Data { get; }

        /// <inheritdoc/>
        protected override GenericResourceExpanded GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<GenericResourceExpanded> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
