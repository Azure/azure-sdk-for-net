// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Extension methods for mapping the default health probe endpoint.
/// </summary>
internal static class HealthEndpointExtensions
{
    /// <summary>
    /// Maps the <c>GET /readiness</c> health probe endpoint that executes all
    /// registered <see cref="Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck"/>
    /// instances and returns the aggregate status (200 Healthy, 503 Unhealthy).
    /// </summary>
    internal static IEndpointRouteBuilder MapHealthEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/readiness");

        return endpoints;
    }
}
