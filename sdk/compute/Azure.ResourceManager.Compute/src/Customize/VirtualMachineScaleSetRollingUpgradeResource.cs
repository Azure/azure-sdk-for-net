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
    // on the singleton rolling-upgrade resource. These are marked Obsolete and throw at runtime
    // because the underlying REST client API changed in the TypeSpec migration.
    public partial class VirtualMachineScaleSetRollingUpgradeResource
    {
        /// <summary> Add a tag to the current resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<VirtualMachineScaleSetRollingUpgradeResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineScaleSetRollingUpgradeResource. Use the parent VirtualMachineScaleSetResource to manage tags.");

        /// <summary> Add a tag to the current resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<VirtualMachineScaleSetRollingUpgradeResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineScaleSetRollingUpgradeResource. Use the parent VirtualMachineScaleSetResource to manage tags.");

        /// <summary> Replace the tags on the resource with the given set. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<VirtualMachineScaleSetRollingUpgradeResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineScaleSetRollingUpgradeResource. Use the parent VirtualMachineScaleSetResource to manage tags.");

        /// <summary> Replace the tags on the resource with the given set. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<VirtualMachineScaleSetRollingUpgradeResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineScaleSetRollingUpgradeResource. Use the parent VirtualMachineScaleSetResource to manage tags.");

        /// <summary> Removes a tag by key from the resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<VirtualMachineScaleSetRollingUpgradeResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineScaleSetRollingUpgradeResource. Use the parent VirtualMachineScaleSetResource to manage tags.");

        /// <summary> Removes a tag by key from the resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<VirtualMachineScaleSetRollingUpgradeResource> RemoveTag(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Tag operations are not supported on VirtualMachineScaleSetRollingUpgradeResource. Use the parent VirtualMachineScaleSetResource to manage tags.");
    }
}