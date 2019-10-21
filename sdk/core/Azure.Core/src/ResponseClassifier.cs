// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Core
{
    public class ResponseClassifier
    {
        /// <summary>
        /// Specifies if the request should be retried.
        /// </summary>
        public virtual bool IsRetriableResponse(HttpMessage message)
        {
            return message.Response.Status == 429 || message.Response.Status == 503;
        }

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried.
        /// </summary>
        public virtual bool IsRetriableException(Exception exception)
        {
            return (exception is IOException) ||
                   (exception is RequestFailedException requestFailed && requestFailed.Status == 0);
        }

        /// <summary>
        /// Specifies if the response is not successful but can be retried.
        /// </summary>
        public virtual bool IsErrorResponse(HttpMessage message)
        {
            var statusKind = message.Response.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }
    }
}
