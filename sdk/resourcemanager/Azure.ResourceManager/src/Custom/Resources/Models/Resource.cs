// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing the base resource used by all azure resources.
    /// </summary>
    [ReferenceType]
    public abstract class Resource
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="Resource"/>.
        /// </summary>
        [InitializationConstructor]
        protected Resource() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Resource"/> for deserialization.
        /// </summary>
        /// <param name="id"> The id of the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="type"> The <see cref="ResourceType"/> of the resource. </param>
        [SerializationConstructor]
        protected internal Resource(ResourceIdentifier id, string name, ResourceType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        public virtual ResourceIdentifier Id { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        public virtual ResourceType Type { get; }
    }
}
