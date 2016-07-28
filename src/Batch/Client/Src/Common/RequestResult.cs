// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
