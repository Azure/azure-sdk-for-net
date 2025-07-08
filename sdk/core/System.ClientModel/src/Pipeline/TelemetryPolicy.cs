// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// A pipeline policy that adds user agent telemetry headers to HTTP requests.
/// </summary>
public class TelemetryPolicy : PipelinePolicy
{
    private readonly string _defaultHeader;

    /// <summary>
    /// Initializes a new instance of the <see cref="TelemetryPolicy"/> class.
    /// </summary>
    /// <param name="telemetryDetails">The telemetry details to include in the User-Agent header.</param>
    public TelemetryPolicy(ClientTelemetryDetails telemetryDetails)
    {
        _defaultHeader = telemetryDetails.ToString();
    }

    /// <summary>
    /// Process the pipeline message synchronously.
    /// </summary>
    /// <param name="message">The pipeline message to process.</param>
    /// <param name="pipeline">The remaining pipeline policies.</param>
    /// <param name="currentIndex">The current index in the pipeline.</param>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        AddUserAgentHeader(message);
        ProcessNext(message, pipeline, currentIndex);
    }

    /// <summary>
    /// Process the pipeline message asynchronously.
    /// </summary>
    /// <param name="message">The pipeline message to process.</param>
    /// <param name="pipeline">The remaining pipeline policies.</param>
    /// <param name="currentIndex">The current index in the pipeline.</param>
    /// <returns>A ValueTask representing the asynchronous operation.</returns>
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