// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    public abstract class HttpPipelineTransport
    {
        public abstract void Process(HttpPipelineMessage message);

        public abstract Task ProcessAsync(HttpPipelineMessage message);

        public abstract Request CreateRequest();
    }
}
