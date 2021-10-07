// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// Constants used by the batching APIs.
    /// </summary>
    internal static class BatchConstants
    {
        public const int NoStatusCode = 0;
        public const int RequestBufferSize = Constants.KB;
        public const int ResponseLineSize = 4 * Constants.KB;
        public const int ResponseBufferSize = 16 * Constants.KB;

        public const string XmsVersionName = "x-ms-version";
        public const string XmsClientRequestIdName = "x-ms-client-request-id";
        public const string XmsReturnClientRequestIdName = "x-ms-return-client-request-id";
        public const string ContentIdName = "Content-ID";
        public const string ContentLengthName = "Content-Length";

        public const string MultipartContentTypePrefix = "multipart/mixed; boundary=";
        public const string RequestContentType = "Content-Type: application/http";
        public const string RequestContentTransferEncoding = "Content-Transfer-Encoding: binary";
        public const string BatchSeparator = "--";
        public const string HttpVersion = "HTTP/1.1";

#pragma warning disable CA1802 // Use literals where appropriate
        public static readonly string DelayedResponsePropertyName = $"{nameof(BlobBatchClient)}.{nameof(BlobBatchClient.SubmitBatch)}:DelayedResponse";
#pragma warning restore CA1802 // Use literals where appropriate
    }
}
