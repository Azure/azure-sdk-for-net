// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline
{
    public abstract class ResponseClassifier
    {
        public static ResponseClassifier Default { get; } = new DefaultResponseClassifier();

        /// <summary>
        /// Specifies if the response should terminate the pipeline and not be retried
        /// </summary>
        public abstract bool IsRetriableResponse(HttpPipelineResponse pipelineResponse);

        /// <summary>
        /// Specifies if the exception should terminate the pipeline and not be retried
        /// </summary>
        public abstract bool IsRetriableException(Exception exception);

        /// <summary>
        /// Specifies if the response is not successful but can be retried
        /// </summary>
        public abstract bool IsErrorResponse(HttpPipelineResponse pipelineResponse);
    }
}
