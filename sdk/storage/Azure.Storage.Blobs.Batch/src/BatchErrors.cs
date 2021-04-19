// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// Errors raised by the batching APIs.
    /// </summary>
    internal static class BatchErrors
    {
        public static InvalidOperationException UseDelayedResponseEarly() =>
            new InvalidOperationException($"Cannot use the {nameof(Response)} before calling {nameof(BlobBatchClient)}.{nameof(BlobBatchClient.SubmitBatch)}");

        public static ArgumentException CannotResubmitBatch(string argumentName) =>
            new ArgumentException($"Cannot submit a batch that has already been submitted.", argumentName);

        public static ArgumentException BatchClientDoesNotMatch(string argumentName) =>
            new ArgumentException($"The {nameof(BlobBatchClient)} used to create the {nameof(BlobBatch)} must be used to submit it.", argumentName);

        public static ArgumentException CannotSubmitEmptyBatch(string argumentName) =>
            new ArgumentException($"Cannot submit an empty batch.", argumentName);

        public static InvalidOperationException BatchAlreadySubmitted() =>
            new InvalidOperationException($"Cannot modify a batch that has already been submitted.");

        public static InvalidOperationException OnlyHomogenousOperationsAllowed(BlobBatchOperationType operationType) =>
            new InvalidOperationException($"{nameof(BlobBatch)} only supports one operation type per batch and is already being used for {operationType} operations.");

        public static InvalidOperationException UnexpectedResponseCount(int expected, int actual) =>
            new InvalidOperationException($"Expected {expected.ToString(CultureInfo.InvariantCulture)} responses for the batch request, not {actual.ToString(CultureInfo.InvariantCulture)}.");

        public static AggregateException ResponseFailures(IList<Exception> failures) =>
            new AggregateException($"{failures.Count.ToString(CultureInfo.InvariantCulture)} batch operation(s) failed.", failures);

        public static InvalidOperationException InvalidBatchContentType(string contentType) =>
            new InvalidOperationException($"Expected {HttpHeader.Names.ContentType} to start with {BatchConstants.MultipartContentTypePrefix} but received {contentType}");

        public static InvalidOperationException InvalidHttpStatusLine(string statusLine) =>
            new InvalidOperationException($"Expected an HTTP status line, not {statusLine}");

        public static InvalidOperationException InvalidHttpHeaderLine(string headerLine) =>
            new InvalidOperationException($"Expected an HTTP header line, not {headerLine}");

        public static RequestFailedException InvalidResponse(ClientDiagnostics clientDiagnostics, Response response, Exception innerException) =>
            clientDiagnostics.CreateRequestFailedExceptionWithContent(response, message: "Invalid response", innerException: innerException);
    }
}
