// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.AI.AgentServer.Core.Context;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.AgentServer.AgentFramework.Extensions;

internal static class FoundryConversationThreadRepositoryFactory
{
    public static IAgentThreadRepository? Create(
        TokenCredential credential,
        Uri? projectEndpoint = null)
    {
        ArgumentNullException.ThrowIfNull(credential);

        if (!TryResolveProjectEndpoint(projectEndpoint, out var resolvedProjectEndpoint))
        {
            return null;
        }

        return new FoundryConversationThreadRepository(resolvedProjectEndpoint, credential);
    }

    public static IAgentThreadRepository? CreateWithDefaultCredential(Uri? projectEndpoint = null)
    {
        if (!TryResolveProjectEndpoint(projectEndpoint, out var resolvedProjectEndpoint))
        {
            return null;
        }

        return new FoundryConversationThreadRepository(
            resolvedProjectEndpoint,
            new DefaultAzureCredential());
    }

    private static bool TryResolveProjectEndpoint(Uri? projectEndpoint, out Uri resolvedProjectEndpoint)
    {
        if (projectEndpoint != null)
        {
            resolvedProjectEndpoint = projectEndpoint;
            return true;
        }

        if (FoundryProjectEndpointResolver.TryResolveProjectEndpointFromEnvironment(out var endpoint) &&
            endpoint != null)
        {
            resolvedProjectEndpoint = endpoint;
            return true;
        }

        resolvedProjectEndpoint = default!;
        return false;
    }
}
