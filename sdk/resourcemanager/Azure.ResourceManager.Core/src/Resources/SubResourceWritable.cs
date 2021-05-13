// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a sub-resource that contains only the read-only ID.
    /// </summary>
    [ReferenceType]
    public partial class SubResourceWritable
    {
        /// <summary> Initializes a new instance of SubResourceReadOnly. </summary>
        [InitializationConstructor]
        public SubResourceWritable()
        {
        }

        /// <summary> Initializes a new instance of SubResourceReadOnly. </summary>
        /// <param name="id"> ARM resource Id. </param>
        [SerializationConstructor]
        protected internal SubResourceWritable(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the ARM resource identifier.
        /// </summary>
        /// <value></value>
        public virtual ResourceIdentifier Id { get; set; }
    }
}
