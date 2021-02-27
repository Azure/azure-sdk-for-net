// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Generic representation of a tracked resource.  All tracked resources should extend this class
    /// </summary>
    public abstract class TrackedResource : Resource
    {
        /// <summary>
        /// Gets the tags.
        /// </summary>
        public virtual IDictionary<string, string> Tags =>
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// Gets or sets the location the resource is in.
        /// </summary>
        public virtual LocationData Location { get; protected set; }

        /// <summary>
        /// Gets or sets the identifier for the resource.
        /// </summary>
        public override ResourceIdentifier Id { get; protected set; }
    }
}
