
namespace Microsoft.Azure.Management.PowerBIEmbedded
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for PowerBIEmbeddedManagementClient.
    /// </summary>
    public static partial class PowerBIEmbeddedManagementClientExtensions
    {
            /// <summary>
            /// Indicates which operations can be performed by the Power BI Resource
            /// Provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static OperationList GetAvailableOperations(this IPowerBIEmbeddedManagementClient operations)
            {
                return Task.Factory.StartNew(s => ((IPowerBIEmbeddedManagementClient)s).GetAvailableOperationsAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Indicates which operations can be performed by the Power BI Resource
            /// Provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<OperationList> GetAvailableOperationsAsync(this IPowerBIEmbeddedManagementClient operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAvailableOperationsWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
