//-----------------------------------------------------------------------
// <copyright file="ProtocolHelper.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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
