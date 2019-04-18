// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Core.Pipeline
{
    public class DefaultResponseClassifier : ResponseClassifier
    {
        public static DefaultResponseClassifier Singleton { get; } = new DefaultResponseClassifier();

        protected DefaultResponseClassifier()
        {
        }

        public override bool IsRetriableResponse(HttpPipelineResponse pipelineResponse)
        {
            return pipelineResponse.Status == 429 || pipelineResponse.Status == 503;
        }

        public override bool IsRetriableException(Exception exception)
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
