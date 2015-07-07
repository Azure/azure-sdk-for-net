namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq.Expressions;
    using Microsoft.Azure;
    using Models;

    public static partial class VirtualMachineSizesOperationsExtensions
    {
            /// <summary>
            /// Lists virtual-machine-sizes available in a location for a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// The location upon which virtual-machine-sizes is queried.
            /// </param>
            public static VirtualMachineSizeListResult List(this IVirtualMachineSizesOperations operations, string location)
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineSizesOperations)s).ListAsync(location), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists virtual-machine-sizes available in a location for a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// The location upon which virtual-machine-sizes is queried.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualMachineSizeListResult> ListAsync( this IVirtualMachineSizesOperations operations, string location, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineSizeListResult> result = await operations.ListWithHttpMessagesAsync(location, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
