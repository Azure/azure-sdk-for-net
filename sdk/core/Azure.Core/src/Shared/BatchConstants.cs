// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    /// Constants used by the batching APIs.
    /// </summary>
    internal static class BatchConstants
    {
        public const int KB = 1024;
        public const int NoStatusCode = 0;
        public const int RequestBufferSize = KB;
        public const int ResponseLineSize = 4 * KB;
        public const int ResponseBufferSize = 16 * KB;

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
    }
}
