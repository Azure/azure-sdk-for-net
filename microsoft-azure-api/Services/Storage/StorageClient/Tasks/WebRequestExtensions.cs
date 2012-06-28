//-----------------------------------------------------------------------
// <copyright file="WebRequestExtensions.cs" company="Microsoft">
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
// <summary>
//    Contains code for the WebRequestExtensions class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;

    /// <summary>
    /// A set of extension methods for a webrequest.
    /// </summary>
    internal static class WebRequestExtensions
    {
        /// <summary>
        /// Gets an asynchronous response to a given Web request.
        /// </summary>
        /// <param name="req">The requested that is used for operation.</param>
        /// <param name="service">The service.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>A task that yields the response.</returns>
        [DebuggerNonUserCode]
        internal static Task<WebResponse> GetResponseAsyncWithTimeout(this WebRequest req, CloudQueueClient service, TimeSpan? timeout)
        {
            Task<WebResponse> serverTask = req.GetResponseAsync(service);

            Task<WebResponse> wrappedTask = TimeoutHelper.GetTimeoutWrappedTask(timeout, serverTask);
            return wrappedTask;
        }

        /// <summary>
        /// Gets an asynchronous response to a given Web request.
        /// </summary>
        /// <param name="req">The requested that is used for operation.</param>
        /// <param name="service">The service.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>A task that yields the response.</returns>
        [DebuggerNonUserCode]
        internal static Task<WebResponse> GetResponseAsyncWithTimeout(this WebRequest req, CloudBlobClient service, TimeSpan? timeout)
        {
            Task<WebResponse> serverTask = req.GetResponseAsync(service);

            Task<WebResponse> wrappedTask = TimeoutHelper.GetTimeoutWrappedTask(timeout, serverTask);
            return wrappedTask;
        }

        /// <summary>
        /// Gets an asynchronous response to a given Web request.
        /// </summary>
        /// <param name="req">The requested that is used for operation.</param>
        /// <param name="service">The service.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>A task that yields the response.</returns>
        [DebuggerNonUserCode]
        internal static Task<WebResponse> GetResponseAsyncWithTimeout(this WebRequest req, CloudTableClient service, TimeSpan? timeout)
        {
            Task<WebResponse> serverTask = req.GetResponseAsync(service);

            Task<WebResponse> wrappedTask = TimeoutHelper.GetTimeoutWrappedTask(timeout, serverTask);
            return wrappedTask;
        }

        /// <summary>
        /// Gets an asynchronous request stream for a given Web request.
        /// </summary>
        /// <param name="req">The requested that is used for operation.</param>
        /// <returns>A task that yields a stream.</returns>
        [DebuggerNonUserCode]
        internal static Task<Stream> GetRequestStreamAsync(this WebRequest req)
        {
            return new APMTask<Stream>(req.BeginGetRequestStream, req.EndGetRequestStream, req.Abort);
        }

        /// <summary>
        /// Gets an asynchronous response to a given Web request.
        /// </summary>
        /// <param name="req">The requested that is used for operation.</param>
        /// <param name="service">The service.</param>
        /// <returns>A task that yields the response.</returns>
        [DebuggerNonUserCode]
        private static Task<WebResponse> GetResponseAsync(this WebRequest req, CloudBlobClient service)
        {
            return new APMTask<WebResponse>(
                req.BeginGetResponse,
                (asyncresult) => service.EndGetResponse(asyncresult, req),
                req.Abort);
        }

        /// <summary>
        /// Gets an asynchronous response to a given Web request.
        /// </summary>
        /// <param name="req">The requested that is used for operation.</param>
        /// <param name="service">The service.</param>
        /// <returns>A task that yields the response.</returns>
        [DebuggerNonUserCode]
        private static Task<WebResponse> GetResponseAsync(this WebRequest req, CloudQueueClient service)
        {
            return new APMTask<WebResponse>(
                req.BeginGetResponse,
                (asyncresult) => service.EndGetResponse(asyncresult, req),
                req.Abort);
        }

        /// <summary>
        /// Gets an asynchronous response to a given Web request.
        /// </summary>
        /// <param name="req">The requested that is used for operation.</param>
        /// <param name="service">The service.</param>
        /// <returns>A task that yields the response.</returns>
        [DebuggerNonUserCode]
        private static Task<WebResponse> GetResponseAsync(this WebRequest req, CloudTableClient service)
        {
            return new APMTask<WebResponse>(
                req.BeginGetResponse,
                (asyncresult) => service.EndGetResponse(asyncresult, req),
                req.Abort);
        }
    }
}
