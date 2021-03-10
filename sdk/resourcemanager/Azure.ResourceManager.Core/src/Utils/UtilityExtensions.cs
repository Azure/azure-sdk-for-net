// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class containing utility extensions
    /// </summary>
    public static class UtilityExtensions
    {
        /// <summary>
        /// An extension method for supporting replacing one dictionary content with another one.
        /// This is used to support resource tags.
        /// </summary>
        /// <param name="dest"> The destination dictionary in which the content will be replaced. </param>
        /// <param name="src"> The source dictionary from which the content is copied from. </param>
        /// <returns> The destination dictionary that has been altered. </returns>
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv.Key, kv.Value);
            }

            return dest;
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="operation"> The instance this method acts on. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public static Response<TOperations> WaitForCompletion<TOperations>(this Operation<TOperations> operation, CancellationToken cancellationToken = default)
        {
            //TODO: Remove after ADO 5665 is closed
            var pollingInterval = ArmOperationHelpers<TOperations>.DefaultPollingInterval;
            while (true)
            {
                operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return Response.FromValue(operation.Value, operation.GetRawResponse());
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }
    }
}
