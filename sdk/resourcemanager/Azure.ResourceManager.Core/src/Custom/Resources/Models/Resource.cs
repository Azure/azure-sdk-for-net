// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the base resource used by all azure resources.
    /// </summary>
    [ReferenceType(typeof(TenantResourceIdentifier))]
    public abstract class Resource<TIdentifier>
        where TIdentifier : TenantResourceIdentifier
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="Resource{TIdentifier}"/>.
        /// </summary>
        [InitializationConstructor]
        protected Resource() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Resource{TIdentifier}"/> for deserialization.
        /// </summary>
        /// <param name="id"> The id of the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="type"> The <see cref="ResourceType"/> of the resource. </param>
        [SerializationConstructor]
        protected internal Resource(TIdentifier id, string name, ResourceType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        public virtual TIdentifier Id { get; }

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
