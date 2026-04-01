// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// Middleware that reads the <c>x-request-id</c> header from the incoming request
/// and propagates its value into the current <see cref="Activity"/> baggage
/// for end-to-end correlation.
/// </summary>
internal sealed class RequestIdBaggagePropagator : IMiddleware
{
    private const string RequestIdHeader = "x-request-id";
    private const string BaggageKey = "x-request-id";

    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Headers.TryGetValue(RequestIdHeader, out var requestIdValues))
        {
            var requestId = requestIdValues.ToString();
            if (!string.IsNullOrEmpty(requestId))
            {
                Activity.Current?.SetBaggage(BaggageKey, requestId);
            }
        }

        await next(context);
    }
}
