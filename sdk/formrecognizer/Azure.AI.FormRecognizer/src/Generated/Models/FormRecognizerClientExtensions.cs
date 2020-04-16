// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public static class FormRecognizerClientExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="formRecognizerClient"></param>
        /// <param name="formFileStream"></param>
        /// <param name="recognizeOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static ValueTask<Response<IReadOnlyList<FormPage>>> RecognizeContentAsync(this FormRecognizerClient formRecognizerClient, Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
            => formRecognizerClient.StartRecognizeContentAsync(formFileStream, recognizeOptions, cancellationToken).WaitForCompletionAsync<IReadOnlyList<FormPage>, RecognizeContentOperation>(cancellationToken);

        /// <summary>
        /// </summary>
        /// <param name="formRecognizerClient"></param>
        /// <param name="receiptFileUri"></param>
        /// <param name="receiptLocale"></param>
        /// <param name="recognizeOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static ValueTask<Response<IReadOnlyList<RecognizedReceipt>>> RecognizeReceiptsFromUriAsync(this FormRecognizerClient formRecognizerClient, Uri receiptFileUri, string receiptLocale = "en-US", RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
            => formRecognizerClient.StartRecognizeReceiptsFromUriAsync(receiptFileUri, receiptLocale, recognizeOptions, cancellationToken).WaitForCompletionAsync<IReadOnlyList<RecognizedReceipt>, RecognizeReceiptsOperation>(cancellationToken);
    }
}
