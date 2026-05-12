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
        /// <summary>
        /// Gets the model view or instance view of a hybrid machine.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Get(InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridComputeMachineResource>> GetAsync(string expand, CancellationToken cancellationToken = default)
            => GetAsync(string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

        /// <summary>
        /// Gets the model view or instance view of a hybrid machine.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Get(InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridComputeMachineResource> Get(string expand, CancellationToken cancellationToken = default)
            => Get(string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

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
    }
}
