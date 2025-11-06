using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Azure.AI.AgentServer.Core.HealthCheck;

/// <summary>
/// Provides extension methods for mapping health check endpoints.
/// </summary>
public static class HealthEndpoints
{
    /// <summary>
    /// Maps health check endpoints for liveness and readiness probes.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    /// <returns>The endpoint route builder for chaining.</returns>
    public static IEndpointRouteBuilder MapHealthChecksEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/liveness");
        endpoints.MapHealthChecks("/readiness");
        return endpoints;
    }
}
