// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Compute.Batch.Custom
{
    internal static class Constants
    {
        /// <summary>
        /// Header Name constant values.
        /// </summary>
        internal static class HeaderNames
        {
            public const string OCPPrefix = "ocp-";
            public const string OCPDate = "ocp-date";
            public const string SharedKey = "SharedKey";
            public const string Authorization = "Authorization";
            public const string ContentEncoding = "Content-Encoding";
            public const string ContentLanguage = "Content-Language";
            public const string ContentLength = "Content-Length";
            public const string ContentMD5 = "Content-MD5";
            public const string ContentType = "Content-Type";
            public const string IfModifiedSince = "If-Modified-Since";
            public const string IfMatch = "If-Match";
            public const string IfNoneMatch = "If-None-Match";
            public const string IfUnmodifiedSince = "If-Unmodified-Since";
            public const string Range = "Range";
            public const string ContentRange = "Content-Range";
            public const string LastModified = "Last-Modified";
            public const string ETag = "ETag";
        }
    }
}
