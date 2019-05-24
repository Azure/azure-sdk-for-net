// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Core.Pipeline
{
    public class HttpPipelineMessage
    {
        public CancellationToken CancellationToken { get; }

        public HttpPipelineMessage(CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
        }

        public Request Request { get; set; }

        public Response Response { get; set; }

        public ResponseClassifier ResponseClassifier { get; set; }
    }
}
