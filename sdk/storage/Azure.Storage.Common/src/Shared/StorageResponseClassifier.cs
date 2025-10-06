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

            // Retry select Copy Source Error Codes.
            if (message.Response.Status >= 400 &&
                message.Response.Headers.TryGetValue(Constants.HeaderNames.CopySourceErrorCode, out string copySourceError))
            {
                switch (copySourceError)
                {
                    case Constants.ErrorCodes.InternalError:
                    case Constants.ErrorCodes.OperationTimedOut:
                    case Constants.ErrorCodes.ServerBusy:
                        return true;
                }
            }

            return base.IsRetriableResponse(message);
        }

        /// <inheritdoc />
        public override bool IsErrorResponse(HttpMessage message)
        {
            switch (message.Response.Status)
            {
                case 409:
                    // We're not considering Container/BlobAlreadyExists as errors when the request has conditional headers.
                    // Convenience methods like BlobContainerClient.CreateIfNotExists will cause a lot of these responses and
                    // we don't want them polluting AppInsights with noise.  See RequestActivityPolicy for how this is applied.

                    RequestHeaders requestHeaders = message.Request.Headers;

                    if (message.Response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out var error) &&
                        (error == Constants.ErrorCodes.ContainerAlreadyExists ||
                         error == Constants.ErrorCodes.BlobAlreadyExists))
                    {
                        var isConditional =
                            requestHeaders.Contains(HttpHeader.Names.IfMatch) ||
                            requestHeaders.Contains(HttpHeader.Names.IfNoneMatch) ||
                            requestHeaders.Contains(HttpHeader.Names.IfModifiedSince) ||
                            requestHeaders.Contains(HttpHeader.Names.IfUnmodifiedSince);
                        return !isConditional;
                    }

                    break;
            }

            return base.IsErrorResponse(message);
        }
    }
}
