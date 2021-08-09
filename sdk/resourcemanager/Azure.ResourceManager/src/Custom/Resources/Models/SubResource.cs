// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing a sub-resource that contains only the read-only ID.
    /// </summary>
    [ReferenceType]
    public partial class SubResource
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="SubResource"/> for mocking.
        /// </summary>
        [InitializationConstructor]
        protected SubResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SubResource"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
        [SerializationConstructor]
        protected internal SubResource(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the ARM resource identifier.
        /// </summary>
        /// <value></value>
        public virtual ResourceIdentifier Id { get; }
    }
}
