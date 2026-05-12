// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.HybridCompute.Models;

namespace Azure.ResourceManager.HybridCompute
{
    public partial class HybridComputeMachineCollection
    {
        /// <summary>
        /// Gets a hybrid machine.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Get(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridComputeMachineResource>> GetAsync(string machineName, string expand, CancellationToken cancellationToken = default)
            => GetAsync(machineName, string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Get(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridComputeMachineResource> Get(string machineName, string expand, CancellationToken cancellationToken = default)
            => Get(machineName, string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

        /// <summary>
        /// Checks if a hybrid machine exists.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="ExistsAsync(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string machineName, string expand, CancellationToken cancellationToken = default)
            => ExistsAsync(machineName, string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

        /// <summary>
        /// Checks if a hybrid machine exists.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Exists(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string machineName, string expand, CancellationToken cancellationToken = default)
            => Exists(machineName, string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

        /// <summary>
        /// Gets a hybrid machine if it exists.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="GetIfExistsAsync(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<HybridComputeMachineResource>> GetIfExistsAsync(string machineName, string expand, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(machineName, string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

        /// <summary>
        /// Gets a hybrid machine if it exists.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="GetIfExists(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<HybridComputeMachineResource> GetIfExists(string machineName, string expand, CancellationToken cancellationToken = default)
            => GetIfExists(machineName, string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);
    }
}
