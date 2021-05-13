// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    [ReferenceType]
    public partial class SubResource
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="SubResource"/> for mocking.
        /// </summary>
        [InitializationConstructor]
        public SubResource()
        {
        }

        /// <summary> Initializes a new instance of SubResource. </summary>
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
