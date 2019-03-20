// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Base.Http.Pipeline
{
    public abstract class HttpPipelineTransport : HttpPipelinePolicy
    {
        public abstract HttpMessage CreateMessage(CancellationToken cancellation);
    }
}
