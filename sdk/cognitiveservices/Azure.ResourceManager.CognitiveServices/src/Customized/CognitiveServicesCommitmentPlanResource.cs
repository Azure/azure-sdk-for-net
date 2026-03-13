// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.CognitiveServices.Models;

namespace Azure.ResourceManager.CognitiveServices
{
    /// <summary>
    /// CognitiveServicesCommitmentPlanResource
    /// </summary>
    public partial class CognitiveServicesCommitmentPlanResource
    {
        /// <summary>
        /// UpdateAsync (Compatible version, only Tags and Sku can be updated.)
        /// </summary>
        public virtual async Task<ArmOperation<CognitiveServicesCommitmentPlanResource>> UpdateAsync(WaitUntil waitUntil, CognitiveServicesCommitmentPlanPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            CommitmentPlanData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
            current.Tags.ReplaceWith(patch.Tags);
            current.Sku = patch.Sku;
            return await UpdateAsync(waitUntil, current, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update (Compatible version, only Tags and Sku can be updated.)
        /// </summary>
        public virtual ArmOperation<CognitiveServicesCommitmentPlanResource> Update(WaitUntil waitUntil, CognitiveServicesCommitmentPlanPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            CommitmentPlanData current = Get(cancellationToken: cancellationToken).Value.Data;
            current.Tags.ReplaceWith(patch.Tags);
            current.Sku = patch.Sku;
            return Update(waitUntil, current, cancellationToken);
        }
    }
}
