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
        // Backward-compat justification: TypeSpec generation places license profile create-or-update on the collection,
        // but the GA SDK exposed this PUT operation as resource-level CreateOrUpdate methods.
        /// <summary> The operation to create or update a license profile. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Parameters supplied to the Create or Update license profile operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<HybridComputeLicenseProfileResource>> CreateOrUpdateAsync(WaitUntil waitUntil, HybridComputeLicenseProfileData data, CancellationToken cancellationToken = default)
        {
            return GetCachedClient(client => new HybridComputeLicenseProfileCollection(client, Id.Parent)).CreateOrUpdateAsync(waitUntil, data, cancellationToken);
        }

        /// <summary> The operation to create or update a license profile. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Parameters supplied to the Create or Update license profile operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<HybridComputeLicenseProfileResource> CreateOrUpdate(WaitUntil waitUntil, HybridComputeLicenseProfileData data, CancellationToken cancellationToken = default)
        {
            return GetCachedClient(client => new HybridComputeLicenseProfileCollection(client, Id.Parent)).CreateOrUpdate(waitUntil, data, cancellationToken);
        }

        // Backward-compat justification: the GA license profile resource identifier helper assumed the implicit default profile name.
        /// <summary>
        /// Creates a resource identifier for <see cref="HybridComputeLicenseProfileResource"/> with 3 parameters (backward compat).
        /// The old API had a single default licenseProfile name; the new API requires the licenseProfileName explicitly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, machineName, "default");
    }
}
