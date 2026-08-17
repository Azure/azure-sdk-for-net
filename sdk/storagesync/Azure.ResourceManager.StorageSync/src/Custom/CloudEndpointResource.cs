// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.StorageSync.Models;

namespace Azure.ResourceManager.StorageSync
{
    public partial class CloudEndpointResource
    {
        /// <summary> Updates a cloud endpoint. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait until the operation has completed; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The cloud endpoint properties to update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An operation representing the update. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use UpdateAsync(WaitUntil, CloudEndpointPatch, CancellationToken) instead.", false)]
        public virtual async Task<ArmOperation<CloudEndpointResource>> UpdateAsync(WaitUntil waitUntil, CloudEndpointCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            var patch = new CloudEndpointPatch
            {
                CloudEndpointUpdateChangeEnumerationIntervalDays = content.ChangeEnumerationIntervalDays
            };
            return await UpdateAsync(waitUntil, patch, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Updates a cloud endpoint. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait until the operation has completed; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The cloud endpoint properties to update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An operation representing the update. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Update(WaitUntil, CloudEndpointPatch, CancellationToken) instead.", false)]
        public virtual ArmOperation<CloudEndpointResource> Update(WaitUntil waitUntil, CloudEndpointCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            var patch = new CloudEndpointPatch
            {
                CloudEndpointUpdateChangeEnumerationIntervalDays = content.ChangeEnumerationIntervalDays
            };
            return Update(waitUntil, patch, cancellationToken);
        }
    }
}
