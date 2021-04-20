// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    [ReferenceType]
    public abstract class SubResource
    {
        /// <summary>
        /// ARM resource identifier.
        /// </summary>
        /// <value></value>
        public virtual ResourceIdentifier Id { get; set; }
    }
}
