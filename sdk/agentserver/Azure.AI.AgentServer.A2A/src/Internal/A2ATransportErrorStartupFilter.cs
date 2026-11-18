// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Azure.AI.AgentServer.A2A.Internal;

internal sealed class A2ATransportErrorStartupFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) => app =>
    {
        app.Use(async (context, nextRequest) =>
        {
            string? path = context.Request.Path.Value?.TrimEnd('/');
            if (string.Equals(path, "/a2a", StringComparison.OrdinalIgnoreCase)
                || string.Equals(path, "/a2a/.well-known/agent-card.json", StringComparison.OrdinalIgnoreCase))
            {
                // Routing can reject the method before any endpoint filter runs.
                context.Response.OnStarting(() =>
                {
                    A2ATransportResult.ClassifyHttpError(context.Response);
                    return Task.CompletedTask;
                });
            }

            await nextRequest(context).ConfigureAwait(false);
        });
        next(app);
    };
}
