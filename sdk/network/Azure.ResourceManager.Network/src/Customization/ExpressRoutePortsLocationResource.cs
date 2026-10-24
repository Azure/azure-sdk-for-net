// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Network
{
    public partial class ExpressRoutePortsLocationResource
    {
        // Preserve the obsolete 1.15.0 AddTag signature; location tag operations do not generate.
        // TODO: Restore the original generic ARM tag implementation; this existing stub breaks behavioral compatibility.
        /// <summary> Adds a tag to the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public virtual Response<ExpressRoutePortsLocationResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        // Preserve the obsolete 1.15.0 RemoveTag signature; location tag operations do not generate.
        // TODO: Restore the original generic ARM tag implementation; this existing stub breaks behavioral compatibility.
        /// <summary> Removes a tag by key from the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public virtual Response<ExpressRoutePortsLocationResource> RemoveTag(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        // Preserve the obsolete 1.15.0 SetTags signature; location tag operations do not generate.
        // TODO: Restore the original generic ARM tag implementation; this existing stub breaks behavioral compatibility.
        /// <summary> Replaces the tags on the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public virtual Response<ExpressRoutePortsLocationResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        // Preserve the obsolete 1.15.0 AddTagAsync signature; location tag operations do not generate.
        // TODO: Restore the original generic ARM tag implementation; this existing stub breaks behavioral compatibility.
        /// <summary> Adds a tag to the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<Response<ExpressRoutePortsLocationResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        // Preserve the obsolete 1.15.0 RemoveTagAsync signature; location tag operations do not generate.
        // TODO: Restore the original generic ARM tag implementation; this existing stub breaks behavioral compatibility.
        /// <summary> Removes a tag by key from the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<Response<ExpressRoutePortsLocationResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        // Preserve the obsolete 1.15.0 SetTagsAsync signature; location tag operations do not generate.
        // TODO: Restore the original generic ARM tag implementation; this existing stub breaks behavioral compatibility.
        /// <summary> Replaces the tags on the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<Response<ExpressRoutePortsLocationResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
