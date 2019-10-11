﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    public class ResponseClassifier
    {
        /// <summary>
        /// Specifies if the response should terminate the pipeline and not be retried.
        /// </summary>
        public virtual bool IsRetriableResponse(HttpMessage message)
        {
            return message.Response.Status == 429 || message.Response.Status == 503;
        }

        /// <summary>
        /// Specifies if the exception should terminate the pipeline and not be retried.
        /// </summary>
        public virtual bool IsRetriableException(Exception exception)
        {
            return (exception is IOException);
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
