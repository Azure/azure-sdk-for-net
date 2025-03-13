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
    /// CognitiveServicesAccountDeploymentResource
    /// </summary>
    public partial class CognitiveServicesAccountDeploymentResource
    {
        /// <summary>
        /// UpdateAsync (Compatible version, only Tags and Sku can be updated.)
        /// </summary>
        public virtual async Task<ArmOperation<CognitiveServicesAccountDeploymentResource>> UpdateAsync(WaitUntil waitUntil, CognitiveServicesAccountDeploymentData data, CancellationToken cancellationToken = default)
        {
            var patchPayload = new PatchResourceTagsAndSku(data.Tags, null, data.Sku);
            return await this.UpdateAsync(waitUntil, patchPayload, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update (Compatible version, only Tags and Sku can be updated.)
        /// </summary>
        public virtual ArmOperation<CognitiveServicesAccountDeploymentResource> Update(WaitUntil waitUntil, CognitiveServicesAccountDeploymentData data, CancellationToken cancellationToken = default)
        {
            var patchPayload = new PatchResourceTagsAndSku(data.Tags, null, data.Sku);
            return this.Update(waitUntil, patchPayload, cancellationToken);
        }
    }
}
