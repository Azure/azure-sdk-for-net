namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IVirtualMachineSizesOperations
    {
        /// <summary>
        /// Lists virtual-machine-sizes available in a location for a
        /// subscription.
        /// </summary>
        /// <param name='location'>
        /// The location upon which virtual-machine-sizes is queried.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineSizeListResult>> ListWithOperationResponseAsync(string location, CancellationToken cancellationToken = default(CancellationToken));
    }
}
