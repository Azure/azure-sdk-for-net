// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Generic representation of a tracked resource.  All tracked resources should extend this class
    /// </summary>
    [ReferenceType(typeof(TenantResourceIdentifier))]
    public abstract partial class TrackedResource<TIdentifier> : Resource<TIdentifier>
        where TIdentifier : TenantResourceIdentifier
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="TrackedResource{TIdentifier}"/> for mocking.
        /// </summary>
        protected TrackedResource()
        {
            Tags = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Initializes an empty instance of <see cref="TrackedResource{TIdentifier}"/>.
        /// </summary>
        [InitializationConstructor]
        protected TrackedResource(Location location)
        {
            Tags = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            Location = location;
            Tags = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackedResource{TIdentifier}"/> class for deserialization.
        /// </summary>
        /// <param name="id"> The id of the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="type"> The <see cref="ResourceType"/> of the resource. </param>
        /// <param name="tags"> The tags for the resource. </param>
        /// <param name="location"> The location of the resource. </param>
        [SerializationConstructor]
        protected internal TrackedResource(TIdentifier id, string name, ResourceType type, Location location, IDictionary<string, string> tags)
            : base(id, name, type)
        {
            Tags = tags ?? new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            Location = location;
        }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        public virtual IDictionary<string, string> Tags { get; }

        /// <summary>
        /// Gets or sets the location the resource is in.
        /// </summary>
        public virtual Location Location { get; set; }
    }
}
