// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Validates the final static endpoint table before the host starts serving
/// requests. Endpoint mutation after pipeline construction, including a custom
/// startup filter that adds routes after invoking its continuation, is outside
/// the AgentServer hosting contract.
/// </summary>
internal sealed class InvocationsEndpointOwnershipValidator : IStartupFilter
{
    private readonly EndpointDataSource _endpointDataSource;

    public InvocationsEndpointOwnershipValidator(EndpointDataSource endpointDataSource)
    {
        _endpointDataSource = endpointDataSource;
    }

    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        ArgumentNullException.ThrowIfNull(next);
        return application =>
        {
            next(application);
            Validate(_endpointDataSource.Endpoints);
        };
    }

    internal static void Validate(IReadOnlyList<Endpoint> endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var allRoutes = endpoints.OfType<RouteEndpoint>().ToArray();
        var owners = allRoutes
            .Where(static endpoint =>
                endpoint.Metadata.GetMetadata<InvocationsEndpointOwnerMetadata>() is not null)
            .ToArray();
        var activeRoutes = allRoutes
            .Where(static endpoint => !IsSuppressed(endpoint))
            .ToArray();

        foreach (var owner in owners)
        {
            if (IsSuppressed(owner))
            {
                throw CreateInvalidOwnerException(owner, "owner_suppressed");
            }

            if (!SupportsGet(owner))
            {
                throw CreateInvalidOwnerException(owner, "owner_not_get_capable");
            }

            if (!TryGetLiteralPath(owner.RoutePattern, out var ownerPath))
            {
                throw CreateInvalidOwnerException(owner, "non_literal_owner_route");
            }

            var matchingOwners = owners.Count(candidate =>
                TryGetLiteralPath(candidate.RoutePattern, out var candidatePath) &&
                string.Equals(candidatePath, ownerPath, StringComparison.OrdinalIgnoreCase) &&
                SupportsGet(candidate));
            if (matchingOwners != 1)
            {
                throw new InvalidOperationException(
                    $"Invocations endpoint ownership validation failed: conflict=duplicate_owner " +
                    $"path='{ownerPath}' owner='Azure.AI.AgentServer.Invocations.InvocationsWebSocket' " +
                    $"count={matchingOwners}.");
            }

            foreach (var candidate in activeRoutes)
            {
                if (ReferenceEquals(candidate, owner) ||
                    candidate.Metadata.GetMetadata<InvocationsEndpointOwnerMetadata>() is not null ||
                    !SupportsGet(candidate) ||
                    !TryGetLiteralPath(candidate.RoutePattern, out var candidatePath) ||
                    !string.Equals(candidatePath, ownerPath, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                throw new InvalidOperationException(
                    $"Invocations endpoint ownership validation failed: conflict=foreign_exact_route " +
                    $"path='{ownerPath}' owner='Azure.AI.AgentServer.Invocations.InvocationsWebSocket' " +
                    $"foreign_pattern='{candidate.RoutePattern.RawText}' " +
                    $"foreign_methods='{GetMethodDescription(candidate)}' " +
                    $"foreign_display_name='{candidate.DisplayName ?? "(unnamed)"}'.");
            }
        }
    }

    internal static bool TryGetLiteralPath(RoutePattern pattern, out string path)
    {
        ArgumentNullException.ThrowIfNull(pattern);

        var segments = new List<string>(pattern.PathSegments.Count);
        foreach (var segment in pattern.PathSegments)
        {
            if (segment.Parts.Count != 1 || segment.Parts[0] is not RoutePatternLiteralPart literal)
            {
                path = string.Empty;
                return false;
            }

            segments.Add(literal.Content);
        }

        path = segments.Count == 0 ? "/" : "/" + string.Join('/', segments);
        return true;
    }

    private static bool SupportsGet(Endpoint endpoint)
    {
        var methods = endpoint.Metadata.GetMetadata<IHttpMethodMetadata>();
        return methods is null ||
            methods.HttpMethods.Count == 0 ||
            methods.HttpMethods.Contains(HttpMethods.Get, StringComparer.OrdinalIgnoreCase);
    }

    private static bool IsSuppressed(Endpoint endpoint) =>
        endpoint.Metadata.GetMetadata<ISuppressMatchingMetadata>()?.SuppressMatching == true;

    private static string GetMethodDescription(Endpoint endpoint)
    {
        var methods = endpoint.Metadata.GetMetadata<IHttpMethodMetadata>();
        return methods is null || methods.HttpMethods.Count == 0
            ? "*"
            : string.Join(',', methods.HttpMethods);
    }

    private static InvalidOperationException CreateInvalidOwnerException(
        RouteEndpoint endpoint,
        string conflict) =>
        new(
            $"Invocations endpoint ownership validation failed: conflict={conflict} " +
            $"owner='Azure.AI.AgentServer.Invocations.InvocationsWebSocket' " +
            $"pattern='{endpoint.RoutePattern.RawText}'.");
}
