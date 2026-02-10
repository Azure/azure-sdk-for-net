// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Context;

/// <summary>
/// Resolves the Azure AI Foundry project endpoint from environment configuration.
/// </summary>
public static class FoundryProjectEndpointResolver
{
    /// <summary>
    /// The environment variable name containing the Foundry project endpoint.
    /// </summary>
    public const string ProjectEndpointEnvironmentVariableName = "AZURE_AI_PROJECT_ENDPOINT";

    /// <summary>
    /// Attempts to resolve the Foundry project endpoint from environment variables.
    /// </summary>
    /// <param name="projectEndpoint">Resolved endpoint when available and valid; otherwise, null.</param>
    /// <returns>True if a valid endpoint was resolved; otherwise, false.</returns>
    public static bool TryResolveProjectEndpointFromEnvironment(out Uri? projectEndpoint)
    {
        var endpointFromEnv = Environment.GetEnvironmentVariable(ProjectEndpointEnvironmentVariableName);
        if (string.IsNullOrWhiteSpace(endpointFromEnv) ||
            !Uri.TryCreate(endpointFromEnv, UriKind.Absolute, out var parsedEndpoint))
        {
            projectEndpoint = null;
            return false;
        }

        projectEndpoint = parsedEndpoint;
        return true;
    }

    /// <summary>
    /// Resolves the Foundry project endpoint from environment variables.
    /// </summary>
    /// <returns>The resolved Foundry project endpoint.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the endpoint environment variable is missing or invalid.
    /// </exception>
    public static Uri ResolveProjectEndpointFromEnvironment()
    {
        if (TryResolveProjectEndpointFromEnvironment(out var endpoint) && endpoint != null)
        {
            return endpoint;
        }

        throw new InvalidOperationException(
            $"{ProjectEndpointEnvironmentVariableName} must be set to an absolute URI to resolve tools.");
    }
}
