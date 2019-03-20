// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public abstract class HttpPipelinePolicy
    {
        public abstract Task ProcessAsync(HttpMessage message);

        protected HttpPipelineEventSource Log = HttpPipelineEventSource.Singleton;
    }
}
