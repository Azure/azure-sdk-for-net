// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// A pipeline policy that adds user agent telemetry headers to HTTP requests.
/// </summary>
internal class TelemetryPolicy : PipelinePolicy
{
    private readonly string _defaultHeader;

    public TelemetryPolicy(TelemetryDetails telemetryDetails)
    {
        _defaultHeader = telemetryDetails.ToString();
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        AddUserAgentHeader(message);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        AddUserAgentHeader(message);
        await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
    }

    private void AddUserAgentHeader(PipelineMessage message)
    {
        if (message.TryGetProperty(typeof(UserAgentValueKey), out var userAgent))
        {
            message.Request.Headers.Add("User-Agent", (string)userAgent!);
        }
        else
        {
            message.Request.Headers.Add("User-Agent", _defaultHeader);
        }
    }
}