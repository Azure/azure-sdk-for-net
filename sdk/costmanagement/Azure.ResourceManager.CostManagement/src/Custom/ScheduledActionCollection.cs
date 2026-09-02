// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement
{
    // Backward-compat: old CreateOrUpdate/CreateOrUpdateAsync had ifMatch as string; now it's ETag?.
    public partial class ScheduledActionCollection
    {
        /// <summary> Create or update a shared scheduled action within the given scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ScheduledActionResource> CreateOrUpdate(WaitUntil waitUntil, string name, ScheduledActionData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, name, data, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken);
        }

        /// <summary> Create or update a shared scheduled action within the given scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ScheduledActionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, ScheduledActionData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, name, data, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken).ConfigureAwait(false);
        }
    }
}
