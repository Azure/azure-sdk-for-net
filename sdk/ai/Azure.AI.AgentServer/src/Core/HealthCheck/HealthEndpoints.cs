using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Azure.AI.AgentServer.Core.HealthCheck;

public static class HealthEndpoints
{
    public static IEndpointRouteBuilder MapHealthChecksEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/liveness");
        endpoints.MapHealthChecks("/readiness");
        return endpoints;
    }
}
