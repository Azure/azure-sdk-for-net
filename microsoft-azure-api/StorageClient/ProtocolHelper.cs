//-----------------------------------------------------------------------
// <copyright file="ProtocolHelper.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the ProtocolHelper class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Net;

    /// <summary>
    /// Assists in protocol implementation.
    /// </summary>
    internal class ProtocolHelper
    {
        /// <summary>
        /// Gets the web request.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="options">The options.</param>
        /// <param name="retrieveRequest">The retrieve request.</param>
        /// <returns>The web request.</returns>
        internal static HttpWebRequest GetWebRequest(CloudBlobClient serviceClient, BlobRequestOptions options, Func<int, HttpWebRequest> retrieveRequest)
        {
            CommonUtils.AssertNotNull("options", options);            

            int timeoutInSeconds = options.Timeout.RoundUpToSeconds();
            AccessCondition accessCondition = options.AccessCondition;

            var webRequest = retrieveRequest(timeoutInSeconds);
            accessCondition.ApplyCondition(webRequest);
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);

            return webRequest;
        }
    }
}
