// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    ///     Abstracts Http client requests.
    /// </summary>
#if Non_Public_SDK
    public interface IHttpClientAbstraction : IDisposable, ILogProvider
#else
    internal interface IHttpClientAbstraction : IDisposable, ILogProvider
#endif
    {
        /// <summary>
        ///     Gets or sets the type of Http request to make.
        /// </summary>
        HttpMethod Method { get; set; }

        /// <summary>
        ///     Gets or sets the Request uri.
        /// </summary>
        Uri RequestUri { get; set; }

        /// <summary>
        ///     Gets or sets the request content.
        /// </summary>
        HttpContent Content { get; set; }

        /// <summary>
        ///     Gets the request headers collection.
        /// </summary>
        IDictionary<string, string> RequestHeaders { get; }

        /// <summary>
        ///     Gets or sets the content type.
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        ///     Gets or sets the time out to use for the request.
        /// </summary>
        TimeSpan Timeout { get; set; }

        /// <summary>
        ///     Initiates the request and returns a task representing the request asynchronously performed.
        /// </summary>
        /// <returns>
        ///     A task representing the response (once it has completed).
        /// </returns>
        Task<IHttpResponseMessageAbstraction> SendAsync();
    }
}
