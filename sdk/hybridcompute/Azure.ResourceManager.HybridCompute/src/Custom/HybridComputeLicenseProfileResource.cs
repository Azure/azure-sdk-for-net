// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.HybridCompute.Models;

namespace Azure.ResourceManager.HybridCompute
{
    public partial class HybridComputeLicenseProfileResource
    {
        /// <summary> The operation to update a license profile. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> Parameters supplied to the Update license profile operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Task<ArmOperation<HybridComputeLicenseProfileResource>> UpdateAsync(WaitUntil waitUntil, HybridComputeLicenseProfilePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            return UpdateAsync(waitUntil, patch.ToUpdate(), cancellationToken);
        }

        /// <summary> The operation to update a license profile. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> Parameters supplied to the Update license profile operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<HybridComputeLicenseProfileResource> Update(WaitUntil waitUntil, HybridComputeLicenseProfilePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            return Update(waitUntil, patch.ToUpdate(), cancellationToken);
        }

        /// <summary>
        /// Creates a resource identifier for <see cref="HybridComputeLicenseProfileResource"/> with 3 parameters (backward compat).
        /// The old API had a single default licenseProfile name; the new API requires the licenseProfileName explicitly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, machineName, "default");
    }
}
