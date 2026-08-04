// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;
using Azure.ResourceManager.ScVmm.Models;

namespace Azure.ResourceManager.ScVmm
{
    public partial class ScVmmAvailabilitySetResource
    {
        // TypeSpec generates resource-specific tags patch models; AutoRest shipped this Update
        // overload with the shared ScVmmResourcePatch model. Map tags to the generated patch.
        /// <summary> Updates an AvailabilitySet resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> The update content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation<ScVmmAvailabilitySetResource>> UpdateAsync(WaitUntil waitUntil, ScVmmResourcePatch patch, CancellationToken cancellationToken = default)
        {
            return UpdateAsync(waitUntil, ToAvailabilitySetPatch(patch), cancellationToken);
        }

        // TypeSpec generates resource-specific tags patch models; AutoRest shipped this Update
        // overload with the shared ScVmmResourcePatch model. Map tags to the generated patch.
        /// <summary> Updates an AvailabilitySet resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> The update content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<ScVmmAvailabilitySetResource> Update(WaitUntil waitUntil, ScVmmResourcePatch patch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, ToAvailabilitySetPatch(patch), cancellationToken);
        }

        private static ScVmmAvailabilitySetPatch ToAvailabilitySetPatch(ScVmmResourcePatch patch)
        {
            Argument.AssertNotNull(patch, nameof(patch));
            var result = new ScVmmAvailabilitySetPatch();
            foreach (var tag in patch.Tags)
            {
                result.Tags.Add(tag);
            }
            return result;
        }
    }
}
