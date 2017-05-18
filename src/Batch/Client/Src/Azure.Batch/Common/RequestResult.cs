// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the result of a physical request.
    /// </summary>
    public sealed class RequestResult
    {
        /// <summary>
        /// Gets information about the request.
        /// </summary>
        public RequestInformation RequestInformation { get; private set; }

        /// <summary>
        /// Gets the exception hit during execution of the request, if any.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Gets the <see cref="System.Threading.Tasks.Task"/> object associated with the request.
        /// </summary>
        public Task Task { get; internal set; }

        /// <summary>
        /// Initializes a new <see cref="RequestResult"/>.
        /// </summary>
        /// <param name="requestInformation">The information associated with the individual request.</param>
        /// <param name="exception">The exception hit during the execution of the request (or null if there was no exception).</param>
        public RequestResult(RequestInformation requestInformation,  Exception exception)
        {
            this.RequestInformation = requestInformation;
            this.Exception = exception;
        }
    }
}
