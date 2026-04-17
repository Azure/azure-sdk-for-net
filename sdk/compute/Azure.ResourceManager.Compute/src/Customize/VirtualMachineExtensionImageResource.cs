// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: preserve AddTag/RemoveTag/SetTags signatures that were available
    // on VirtualMachineExtensionImageResource. These are marked Obsolete and throw at runtime
    // because the underlying internal field names changed in the TypeSpec migration.
    public partial class VirtualMachineExtensionImageResource
    {
        /// <summary> Add a tag to the current resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<VirtualMachineExtensionImageResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineExtensionImageResource.");

        /// <summary> Add a tag to the current resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<VirtualMachineExtensionImageResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineExtensionImageResource.");

        /// <summary> Replace the tags on the resource with the given set. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<VirtualMachineExtensionImageResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineExtensionImageResource.");

        /// <summary> Replace the tags on the resource with the given set. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<VirtualMachineExtensionImageResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineExtensionImageResource.");

        /// <summary> Removes a tag by key from the resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<VirtualMachineExtensionImageResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineExtensionImageResource.");

        /// <summary> Removes a tag by key from the resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<VirtualMachineExtensionImageResource> RemoveTag(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineExtensionImageResource.");
    }
}