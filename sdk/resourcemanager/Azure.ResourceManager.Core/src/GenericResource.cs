// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a generic azure resource along with the instance operations that can be performed on it.
    /// </summary>
    public class GenericResource : GenericResourceOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResource"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="resource"> The data model representing the generic azure resource. </param>
        internal GenericResource(ResourceOperationsBase operations, GenericResourceData resource)
            : base(operations, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets the data representing this generic azure resource.
        /// </summary>
        public GenericResourceData Data { get; }

        /// <inheritdoc/>
        protected override GenericResource GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<GenericResource> GetResourceAsync()
        {
            return Task.FromResult(this);
        }
    }
}
