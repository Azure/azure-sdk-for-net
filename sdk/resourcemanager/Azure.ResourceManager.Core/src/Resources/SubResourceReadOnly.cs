// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a sub-resource that contains only the read-only ID.
    /// </summary>
    [ReferenceType]
    public partial class SubResourceReadOnly
    {
        /// <summary> Initializes a new instance of SubResourceReadOnly. </summary>
        /// <param name="id"> ARM resource Id. </param>
        protected internal SubResourceReadOnly(string id)
        {
            Id = id;
        }

        /// <summary>
        /// ARM resource identifier (read-only).
        /// </summary>
        /// <value></value>
        public virtual ResourceIdentifier Id { get; protected set; }
    }
}
