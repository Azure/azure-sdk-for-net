// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Tests;

internal class HeaderTestPolicy(IReadOnlyDictionary<string, string> _headers) : PipelinePolicy
{
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        // Add your desired header name and value
        foreach (KeyValuePair<string, string> header in _headers)
        {
            message.Request.Headers.Add(header.Key, header.Value);
        }
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        // Add your desired header name and value
        foreach (KeyValuePair<string, string> header in _headers)
        {
            message.Request.Headers.Add(header.Key, header.Value);
        }
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
