// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Generic representation of a tracked resource.  All tracked resources should extend this class
    /// </summary>
    [ReferenceType]
    public abstract partial class TrackedResource<TIdentifier> : Resource<TIdentifier> where TIdentifier : TenantResourceIdentifier
    {
        private IDictionary<string, string> _tag = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        /// <summary>
        /// Gets the tags.
        /// </summary>
        public virtual IDictionary<string, string> Tags => _tag;

        /// <summary>
        /// Gets or sets the location the resource is in.
        /// </summary>
        public virtual LocationData Location { get; protected set; }

        /// <summary>
        /// Gets or sets the identifier for the resource.
        /// </summary>
        public override TIdentifier Id { get; protected set; }
    }
}
