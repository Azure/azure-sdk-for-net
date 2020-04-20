// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public static class TrainingOperationExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Response<CustomFormModel>> WaitForCompletionAsync(this Task<TrainingOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
