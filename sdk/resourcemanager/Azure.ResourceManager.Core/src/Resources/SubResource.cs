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
        /// Initializes an empty instance of <see cref="SubResource"/>.
        /// </summary>
        protected internal SubResource() { }

        /// <summary> Initializes a new instance of SubResource. </summary>
        /// <param name="id"> ARM resource Id. </param>
        protected internal SubResource(string id)
        {
            Id = id;
        }

        /// <summary>
        /// ARM resource identifier.
        /// </summary>
        /// <value></value>
        public virtual ResourceIdentifier Id { get; set; }
    }
}

// Todo: we want to make the default one (SubResource) to represent read-only data,
// that is the pattern we used in Resource and TrackedResource
