// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a sub-resource that contains only the read-only ID.
    /// </summary>
    [ReferenceType]
    public abstract class SubResourceReadOnly
    {
        /// <summary>
        /// ARM resource identifier (read-only).
        /// </summary>
        /// <value></value>
        public virtual ResourceIdentifier Id { get; }
    }
}
