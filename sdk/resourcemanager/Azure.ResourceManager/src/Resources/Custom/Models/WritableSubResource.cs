// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    [PropertyReferenceType]
    public partial class WritableSubResource
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="WritableSubResource"/> for mocking.
        /// </summary>
        [InitializationConstructor]
        public WritableSubResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="WritableSubResource"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
        [SerializationConstructor]
        protected internal WritableSubResource(ResourceIdentifier id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the ARM resource identifier.
        /// </summary>
        /// <value></value>
        public ResourceIdentifier Id { get; set; }
    }
}
