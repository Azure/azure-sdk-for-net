// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Agents;

/// <summary> The AgentsClient. </summary>
internal partial class AddQueryParameterPolicy : PipelinePolicy
{
    private readonly KeyValuePair<string, string> _pair;

    public AddQueryParameterPolicy(string key, string value)
    {
        _pair = new(key, value);
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        EnsureQueryParameter(ref message);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        EnsureQueryParameter(ref message);
        return ProcessNextAsync(message, pipeline, currentIndex);
    }

    private void EnsureQueryParameter(ref PipelineMessage message)
    {
        if (message?.Request?.Uri is Uri requestUri)
        {
            RawRequestUriBuilder builder = new();
            builder.Reset(requestUri);
            if (!builder.Query.Contains(_pair.Key))
            {
                builder.AppendQuery(_pair.Key, _pair.Value, escapeValue: true);
            }
            message.Request.Uri = builder.ToUri();
        }
    }
}
