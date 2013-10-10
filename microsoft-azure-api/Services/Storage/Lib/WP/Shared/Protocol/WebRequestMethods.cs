// -----------------------------------------------------------------------------------------
// <copyright file="WebRequestMethods.cs" company="Microsoft">
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
    public static class WebRequestMethods
    {
        // Summary:
        //     Represents the types of HTTP protocol methods that can be used with an HTTP
        //     request.
        public static class Http
        {
            // Summary:
            //     Represents the HTTP CONNECT protocol method that is used with a proxy that
            //     can dynamically switch to tunneling, as in the case of SSL tunneling.
            public const string Connect = "CONNECT";

            // Summary:
            //     Represents an HTTP GET protocol method.
            public const string Get = "GET";

            // Summary:
            //     Represents an HTTP HEAD protocol method. The HEAD method is identical to
            //     GET except that the server only returns message-headers in the response,
            //     without a message-body.
            public const string Head = "HEAD";

            // Summary:
            //     Represents an HTTP MKCOL request that creates a new collection (such as a
            //     collection of pages) at the location specified by the request-Uniform Resource
            //     Identifier (URI).
            public const string MkCol = "MKCOL";

            // Summary:
            //     Represents an HTTP POST protocol method that is used to post a new entity
            //     as an addition to a URI.
            public const string Post = "POST";

            // Summary:
            //     Represents an HTTP PUT protocol method that is used to replace an entity
            //     identified by a URI.
            public const string Put = "PUT";
        }
    }
}
