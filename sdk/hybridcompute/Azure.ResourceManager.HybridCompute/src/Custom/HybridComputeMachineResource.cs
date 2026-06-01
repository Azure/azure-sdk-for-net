// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.HybridCompute.Models;

namespace Azure.ResourceManager.HybridCompute
{
    public partial class HybridComputeMachineResource
    {
        // Backward-compat justification: the GA machine resource exposed the GetValidationDetailsForMachinePrivateLinkScope legacy name.
        /// <summary>
        /// Returns the Azure Arc PrivateLinkScope's validation details for a given machine.
        /// This method was renamed to <see cref="GetValidationDetailsForMachineAsync(CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PrivateLinkScopeValidationDetails>> GetValidationDetailsForMachinePrivateLinkScopeAsync(CancellationToken cancellationToken = default)
            => GetValidationDetailsForMachineAsync(cancellationToken);

        /// <summary>
        /// Returns the Azure Arc PrivateLinkScope's validation details for a given machine.
        /// This method was renamed to <see cref="GetValidationDetailsForMachine(CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PrivateLinkScopeValidationDetails> GetValidationDetailsForMachinePrivateLinkScope(CancellationToken cancellationToken = default)
            => GetValidationDetailsForMachine(cancellationToken);

        // Backward-compat justification: the GA machine resource exposed an accessor for the implicit default license profile.
        /// <summary> Gets the default license profile resource for this machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual HybridComputeLicenseProfileResource GetHybridComputeLicenseProfile()
        {
            return GetCachedClient(client => new HybridComputeLicenseProfileResource(client, HybridComputeLicenseProfileResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name)));
        }
    }
}
