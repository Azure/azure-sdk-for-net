// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.HybridCompute.Models;

namespace Azure.ResourceManager.HybridCompute.Mocking
{
    public partial class MockableHybridComputeResourceGroupResource
    {
        /// <summary>
        /// Gets a hybrid machine.
        /// This overload includes a string <paramref name="expand"/> parameter for backward compatibility.
        /// Use <see cref="GetHybridComputeMachine(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<HybridComputeMachineResource>> GetHybridComputeMachineAsync(string machineName, string expand, CancellationToken cancellationToken = default)
            => GetHybridComputeMachineAsync(machineName, string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload includes a string <paramref name="expand"/> parameter for backward compatibility.
        /// Use <see cref="GetHybridComputeMachine(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<HybridComputeMachineResource> GetHybridComputeMachine(string machineName, string expand, CancellationToken cancellationToken = default)
            => GetHybridComputeMachine(machineName, string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);
    }
}
