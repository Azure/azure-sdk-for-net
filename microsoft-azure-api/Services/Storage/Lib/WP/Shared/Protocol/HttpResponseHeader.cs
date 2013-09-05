// -----------------------------------------------------------------------------------------
// <copyright file="HttpResponseHeader.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Shared.Protocol
{
    internal static class HttpResponseHeader
    {
        // Summary:
        //     The Cache-Control header, which specifies caching directives that must be
        //     obeyed by all caching mechanisms along the request/response chain.
        public const string CacheControl = "Cache-Control";

        // Summary:
        //     The Content-Type header, which specifies the MIME type of the accompanying
        //     body data.
        public const string ContentType = "Content-Type";

        // Summary:
        //     The Etag header, which specifies the current value for the requested variant. 
        public const string ETag = "Etag";

        // Summary:
        //     The Last-Modified header, which specifies the date and time the requested
        //     variant was last modified.
        public const string LastModified = "Last-Modified";

        // Summary:
        //     The Content-MD5 header, which specifies the MD5 digest of the accompanying
        //     body data, for the purpose of providing an end-to-end message integrity check.
        public const string ContentMd5 = "Content-MD5";

        // Summary:
        //     The Range header, which specifies the subrange or subranges of the response
        //     that the client requests be returned in lieu of the entire response.
        public const string ContentRange = "Range";

        // Summary:
        //     The Content-Encoding header, which specifies the encodings that have been
        //     applied to the accompanying body data.
        public const string ContentEncoding = "Content-Encoding";

        // Summary:
        //     The Content-Langauge header, which specifies the natural language or languages
        //     of the accompanying body data.
        public const string ContentLanguage = "Content-Langauge";
    }
}
