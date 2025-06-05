// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.Core.Rest
{
    /// <summary>
    /// Exception thrown when a REST call fails.
    /// </summary>
    public class RestCallFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestCallFailedException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="response"></param>
        public RestCallFailedException(string message, PipelineResponse response)
            : base(message, new System.ClientModel.ClientResultException(response)) { }
    }
}
