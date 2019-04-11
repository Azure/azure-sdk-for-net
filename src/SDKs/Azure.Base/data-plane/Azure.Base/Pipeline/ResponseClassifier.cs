// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Base.Pipeline
{
    public abstract class ResponseClassifier
    {
        /// <summary>
        /// Specifies if the response should terminate the pipeline and not be retried
        /// </summary>
        public abstract bool IsFatalErrorResponse(HttpPipelineResponse pipelineResponse);

        /// <summary>
        /// Specifies if the exception should terminate the pipeline and not be retried
        /// </summary>
        public abstract bool IsFatalException(Exception exception);

        /// <summary>
        /// Specifies if the response is not successful but can be retried
        /// </summary>
        public abstract bool IsErrorResponse(HttpPipelineResponse pipelineResponse);
    }

    public class DefaultResponseClassifier : ResponseClassifier
    {
        public static DefaultResponseClassifier Singleton { get; } = new DefaultResponseClassifier();

        public override bool IsFatalErrorResponse(HttpPipelineResponse pipelineResponse)
        {
            return false;
        }

        public override bool IsFatalException(Exception exception)
        {
            return !(exception is IOException);
        }

        public override bool IsErrorResponse(HttpPipelineResponse pipelineResponse)
        {
            var statusKind = pipelineResponse.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }
    }
}
