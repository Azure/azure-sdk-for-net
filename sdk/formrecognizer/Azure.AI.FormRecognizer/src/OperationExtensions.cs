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
    /// The set of extension methods for the subclasses of <see cref="Operation{T}" />.
    /// </summary>
    public static class OperationExtensions
    {
        /// <summary>
        /// Periodically calls the server until the long-running operation completes.
        /// </summary>
        /// <param name="operation">The instance that this method was invoked on.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="IReadOnlyList{T}"/>
        /// containing the recognized receipts.</returns>
        public static async Task<Response<RecognizedFormCollection>> WaitForCompletionAsync(this Task<RecognizeReceiptsOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server until the long-running operation completes.
        /// </summary>
        /// <param name="operation">The instance that this method was invoked on.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="IReadOnlyList{T}"/>
        /// containing the recognized business cards.</returns>
        public static async Task<Response<RecognizedFormCollection>> WaitForCompletionAsync(this Task<RecognizeBusinessCardsOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server until the long-running operation completes.
        /// </summary>
        /// <param name="operation">The instance that this method was invoked on.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="IReadOnlyList{T}"/>
        /// containing the recognized business cards.</returns>
        public static async Task<Response<RecognizedFormCollection>> WaitForCompletionAsync(this Task<RecognizeInvoicesOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server until the long-running operation completes.
        /// </summary>
        /// <param name="operation">The instance that this method was invoked on.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="IReadOnlyList{T}"/>
        /// containing the recognized forms.</returns>
        public static async Task<Response<RecognizedFormCollection>> WaitForCompletionAsync(this Task<RecognizeCustomFormsOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server until the long-running operation completes.
        /// </summary>
        /// <param name="operation">The instance that this method was invoked on.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="IReadOnlyList{T}"/>
        /// containing the recognized pages.</returns>
        public static async Task<Response<FormPageCollection>> WaitForCompletionAsync(this Task<RecognizeContentOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server until the long-running operation completes.
        /// </summary>
        /// <param name="operation">The instance that this method was invoked on.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="CustomFormModel"/>
        /// containing meta-data about the trained model.</returns>
        public static async Task<Response<CustomFormModel>> WaitForCompletionAsync(this Task<TrainingOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server until the long-running operation completes.
        /// </summary>
        /// <param name="operation">The instance that this method was invoked on.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="CustomFormModel"/>
        /// containing meta-data about the trained model.</returns>
        public static async Task<Response<CustomFormModel>> WaitForCompletionAsync(this Task<CreateComposedModelOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server until the long-running operation completes.
        /// </summary>
        /// <param name="operation">The instance that this method was invoked on.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="CustomFormModelInfo"/>
        /// containing meta-data about the trained model.</returns>
        public static async Task<Response<CustomFormModelInfo>> WaitForCompletionAsync(this Task<CopyModelOperation> operation, CancellationToken cancellationToken = default)
        {
            var o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
