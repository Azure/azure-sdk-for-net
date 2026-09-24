// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // Restores released Bastion update APIs for backward compatibility. The NetworkTagsObject overloads adapt to the
    // canonical generated BastionHostPatch operations; the unsupported BastionHostData overloads retain their signatures.
    public partial class BastionHostResource
    {
        /// <summary> Invokes the asynchronous Bastion Host update operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release, please use `BastionHostCollection.CreateOrUpdateAsync` instead.", false)]
        public virtual Task<ArmOperation<BastionHostResource>> UpdateAsync(WaitUntil waitUntil, BastionHostData data, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the Bastion Host update operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release, please use `BastionHostCollection.CreateOrUpdate` instead.", false)]
        public virtual ArmOperation<BastionHostResource> Update(WaitUntil waitUntil, BastionHostData data, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        /// <summary> Updates tags for this Bastion Host resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait until the operation completes; <see cref="WaitUntil.Started"/> otherwise. </param>
        /// <param name="networkTagsObject"> Parameters supplied to update Bastion Host tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="networkTagsObject"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release, please use `UpdateAsync(WaitUntil, BastionHostPatch, CancellationToken)` instead.", false)]
        public virtual Task<ArmOperation<BastionHostResource>> UpdateAsync(WaitUntil waitUntil, NetworkTagsObject networkTagsObject, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(networkTagsObject, nameof(networkTagsObject));
            var patch = new BastionHostPatch();
            patch.Tags.ReplaceWith(networkTagsObject.Tags);
            return UpdateAsync(waitUntil, patch, cancellationToken);
        }

        /// <summary> Updates tags for this Bastion Host resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait until the operation completes; <see cref="WaitUntil.Started"/> otherwise. </param>
        /// <param name="networkTagsObject"> Parameters supplied to update Bastion Host tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="networkTagsObject"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release, please use `Update(WaitUntil, BastionHostPatch, CancellationToken)` instead.", false)]
        public virtual ArmOperation<BastionHostResource> Update(WaitUntil waitUntil, NetworkTagsObject networkTagsObject, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(networkTagsObject, nameof(networkTagsObject));
            var patch = new BastionHostPatch();
            patch.Tags.ReplaceWith(networkTagsObject.Tags);
            return Update(waitUntil, patch, cancellationToken);
        }
    }
}
