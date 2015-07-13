namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure.OData;
    using System.Linq.Expressions;
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineSizeListResult>> ListWithHttpMessagesAsync(string location, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
