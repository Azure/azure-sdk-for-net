// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// Middleware that reads the W3C <c>baggage</c> header from the incoming request
/// and propagates each key-value pair into the current <see cref="Activity"/> baggage.
/// This ensures baggage propagation works on all target frameworks, including net8.0
/// where ASP.NET Core's built-in propagator does not parse the baggage header.
/// </summary>
internal sealed class W3CBaggagePropagator : IMiddleware
{
    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (Activity.Current is { } activity &&
            context.Request.Headers.TryGetValue("baggage", out var baggageValues))
        {
            var baggageHeader = baggageValues.ToString();
            if (!string.IsNullOrEmpty(baggageHeader))
            {
                ParseAndSetBaggage(activity, baggageHeader);
            }
        }

        await next(context);
    }

    private static void ParseAndSetBaggage(Activity activity, string baggageHeader)
    {
        // W3C Baggage format: key1=value1,key2=value2;property1
        // See https://www.w3.org/TR/baggage/
        foreach (var member in baggageHeader.Split(','))
        {
            var trimmed = member.Trim();
            if (string.IsNullOrEmpty(trimmed))
            {
                continue;
            }

            // Each member is: key=value[;properties]
            // We only care about key=value, ignoring properties.
            var equalsIndex = trimmed.IndexOf('=');
            if (equalsIndex <= 0)
            {
                continue;
            }

            var key = trimmed.Substring(0, equalsIndex).Trim();

            // Value extends to semicolon (start of properties) or end of member.
            var valueAndProps = trimmed.Substring(equalsIndex + 1);
            var semiIndex = valueAndProps.IndexOf(';');
            var value = semiIndex >= 0
                ? valueAndProps.Substring(0, semiIndex).Trim()
                : valueAndProps.Trim();

            if (!string.IsNullOrEmpty(key))
            {
                activity.SetBaggage(key, Uri.UnescapeDataString(value));
            }
        }
    }
}
