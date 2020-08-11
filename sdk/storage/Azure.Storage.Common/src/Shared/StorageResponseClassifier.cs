// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage
{
    internal class StorageResponseClassifier : ResponseClassifier
    {
        /// <summary>
        /// The secondary URI to be used for retries on failed read requests
        /// </summary>
        public Uri SecondaryStorageUri { get; set; }

        /// <summary>
        /// Overridden version of IsRetriableResponse that allows for Storage specific retry logic.
        /// </summary>
        /// <param name="message">The message containing both Response and Request</param>
        /// <returns></returns>
        public override bool IsRetriableResponse(HttpMessage message)
        {
            // If secondary storage Uri was specified, we want to retry if the current attempt was against the secondary Uri, and we
            // get a response of NotFound. This is because the resource may not have been propagated to secondary Uri yet.
            if (SecondaryStorageUri != null &&
                message.Request.Uri.Host == SecondaryStorageUri.Host &&
                message.Response.Status == Constants.HttpStatusCode.NotFound)
            {
                return true;
            }

            // Retry select Storage service error codes
            if (message.Response.Status >= 400 &&
                message.Response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out var error))
            {
                switch (error)
                {
                    case Constants.ErrorCodes.InternalError:
                    case Constants.ErrorCodes.OperationTimedOut:
                    case Constants.ErrorCodes.ServerBusy:
                        return true;
                }
            }
            return base.IsRetriableResponse(message);
        }
    }
}
