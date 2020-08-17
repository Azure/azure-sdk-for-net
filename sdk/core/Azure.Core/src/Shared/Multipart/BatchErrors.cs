// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Errors raised by the batching APIs.
    /// </summary>
    internal static class BatchErrors
    {
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
