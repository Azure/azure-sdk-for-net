// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Azure.AI.AgentServer.Hosting;

/// <summary>
/// Extension methods for mapping the default health probe endpoint.
/// </summary>
internal static class HealthEndpointExtensions
{
    /// <summary>
    /// Maps the <c>GET /healthy</c> liveness probe endpoint that returns HTTP 200.
    /// </summary>
    internal static IEndpointRouteBuilder MapHealthEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/healthy", () => Results.Ok())
            .ExcludeFromDescription();

        return endpoints;
    }
}
