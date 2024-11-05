// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.CognitiveServices.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.ResourceManager.CognitiveServices
{
    /// <summary>
    /// CognitiveServicesCommitmentPlanResource
    /// </summary>
    public partial class CognitiveServicesCommitmentPlanResource
    {
        /// <summary>
        /// UpdateAsync
        /// </summary>
        public virtual async Task<ArmOperation<CognitiveServicesCommitmentPlanResource>> UpdateAsync(WaitUntil waitUntil, CognitiveServicesCommitmentPlanPatch commitmentPlan, CancellationToken cancellationToken = default)
        {
            var patchPayload = new PatchResourceTagsAndSku(commitmentPlan.Tags, null, commitmentPlan.Sku);
            return await this.UpdateAsync(waitUntil, patchPayload, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update
        /// </summary>
        public virtual ArmOperation<CognitiveServicesCommitmentPlanResource> Update(WaitUntil waitUntil, CognitiveServicesCommitmentPlanPatch commitmentPlan, CancellationToken cancellationToken = default)
        {
            var patchPayload = new PatchResourceTagsAndSku(commitmentPlan.Tags, null, commitmentPlan.Sku);
            return this.Update(waitUntil, patchPayload, cancellationToken);
        }
    }
}
