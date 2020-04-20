// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;

namespace Azure.AI.FormRecognizer
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
        public static async Task<Response<IReadOnlyList<RecognizedReceipt>>> WaitForCompletionAsync(this Task<RecognizeReceiptsOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Response<IReadOnlyList<RecognizedForm>>> WaitForCompletionAsync(this Task<RecognizeCustomFormsOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Response<IReadOnlyList<FormPage>>> WaitForCompletionAsync(this Task<RecognizeContentOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

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
