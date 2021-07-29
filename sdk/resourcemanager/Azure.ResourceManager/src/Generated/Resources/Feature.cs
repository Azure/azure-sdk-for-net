// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a Feature along with the instance operations that can be performed on it.
    /// </summary>
    public class Feature : FeatureOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Feature"/> class for mocking.
        /// </summary>
        protected Feature()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature"/> class.
        /// </summary>
        /// <param name="operations"> The operations to copy the client options from. </param>
        /// <param name="resource"> The FeatureData to use in these operations. </param>
        internal Feature(ResourceOperations operations, FeatureData resource)
            : base(operations, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets the data representing this Feature.
        /// </summary>
        public virtual FeatureData Data { get; }
    }
}
