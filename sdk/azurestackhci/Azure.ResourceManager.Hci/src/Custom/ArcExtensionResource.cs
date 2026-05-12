// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Hci.Models;

namespace Azure.ResourceManager.Hci
{
    public partial class ArcExtensionResource
    {
        /// <summary> Update Extension for HCI cluster (backward-compat overload using ArcExtensionData). </summary>
        [Obsolete("This method is now deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<ArcExtensionResource>> UpdateAsync(WaitUntil waitUntil, ArcExtensionData data, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This method is obsolete, use the overload that takes ArcExtensionPatch instead.");

        /// <summary> Update Extension for HCI cluster (backward-compat overload using ArcExtensionData). </summary>
        [Obsolete("This method is now deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ArcExtensionResource> Update(WaitUntil waitUntil, ArcExtensionData data, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This method is obsolete, use the overload that takes ArcExtensionPatch instead.");

        /// <summary> Upgrade Machine Extensions (backward-compat overload using ExtensionUpgradeContent). </summary>
        [Obsolete("This method is now deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> UpgradeAsync(WaitUntil waitUntil, ExtensionUpgradeContent content, CancellationToken cancellationToken = default)
            => await UpgradeAsync(waitUntil, (ArcExtensionUpgradeContent)content, cancellationToken).ConfigureAwait(false);

        /// <summary> Upgrade Machine Extensions (backward-compat overload using ExtensionUpgradeContent). </summary>
        [Obsolete("This method is now deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Upgrade(WaitUntil waitUntil, ExtensionUpgradeContent content, CancellationToken cancellationToken = default)
            => Upgrade(waitUntil, (ArcExtensionUpgradeContent)content, cancellationToken);
    }
}
