//-----------------------------------------------------------------------
// <copyright file="WebRequestExtensions.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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
