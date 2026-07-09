// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Holds environment-scoped state for the resilient-tasks host (currently the
/// optional credential used for hosted-mode authentication). Kept internal so it
/// is not part of the public surface.
/// </summary>
internal sealed class TaskHostEnvironment
{
    public TaskHostEnvironment(TokenCredential? credential) => Credential = credential;

    /// <summary>The credential for hosted-mode authentication, or <see langword="null"/> to use the default.</summary>
    public TokenCredential? Credential { get; }
}
