// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    internal class StorageResponseClassifier : ResponseClassifier
    {
        public Uri SecondaryStorageUri { get; }

        public StorageResponseClassifier(Uri secondaryStorageUri)
        {
            SecondaryStorageUri = secondaryStorageUri;
        }

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried.
        /// </summary>
        public override bool IsRetriableException(Exception exception)
        {
            //if (exception is TaskCanceledException taskCanceledException)
            //{
            //    Debug.WriteLine(taskCanceledException.CancellationToken.IsCancellationRequested);
            //    if (!taskCanceledException.CancellationToken.IsCancellationRequested || taskCanceledException.InnerException != null)
            //    {
            //        return true;
            //    }
            //}
            return base.IsRetriableException(exception);
        }

        /// <summary>
        /// Overridden version of IsRetriableResponse that allows for retrying 404 that occurs against the secondary host.
        /// </summary>
        /// <param name="message">The message containing both Response and Request</param>
        /// <returns></returns>
        public override bool IsRetriableResponse(HttpMessage message)
        {
            if (message.Request.Uri.Host == SecondaryStorageUri?.Host && message.Response.Status == Constants.HttpStatusCode.NotFound)
            {
                return true;
            }
            // Retry select Storage Error Codes
            if (message.Response.Status >= 400 &&
                message.Response.Headers.TryGetValue("x-ms-error-code", out var error))
            {
                switch (error)
                {
                    case "InternalError":
                    case "OperationTimedOut":
                    case "ServerBusy":
                    case "CannotVerifyCopySource":
                        return true;
                }
            }
            return base.IsRetriableResponse(message);
        }
    }
}
