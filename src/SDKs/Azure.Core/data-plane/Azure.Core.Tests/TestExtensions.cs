// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core.Tests
{
    public static class TestExtensions
    {
        public static HttpPipelineRequest CreateSampleGetRequest(this HttpPipeline pipeline)
        {
            HttpPipelineRequest request = pipeline.CreateRequest();
            request.Method = HttpPipelineMethod.Get;
            request.UriBuilder.Uri = new Uri("http://example.com");
            return request;
        }
    }
}
