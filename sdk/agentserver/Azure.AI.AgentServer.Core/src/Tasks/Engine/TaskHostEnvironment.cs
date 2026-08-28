// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Holds environment-scoped state for the resilient-tasks host.
/// </summary>
internal sealed class TaskHostEnvironment
{
    public TaskHostEnvironment(TokenCredential? credential, Uri? endpoint)
    {
        Credential = credential;
        Endpoint = endpoint;
    }

    /// <summary>The credential for hosted-mode authentication, or <see langword="null"/> to use the default.</summary>
    public TokenCredential? Credential { get; }

    /// <summary>The configured Foundry project endpoint, or <see langword="null"/> to use the environment.</summary>
    public Uri? Endpoint { get; }
}
