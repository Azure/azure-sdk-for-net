// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public static class OperationExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async ValueTask<Response<IReadOnlyList<RecognizedReceipt>>> WaitForCompletionAsync(this Task<RecognizeReceiptsOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
