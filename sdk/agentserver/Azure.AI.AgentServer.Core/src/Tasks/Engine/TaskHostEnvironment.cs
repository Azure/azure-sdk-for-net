// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Holds environment-scoped state for the resilient-tasks host (currently the
/// optional credential used for hosted-mode authentication). Kept internal so it
/// is not part of the public surface.
/// </summary>
internal sealed class TaskHostEnvironment
{
    private TokenCredential? _credential;

    public TaskHostEnvironment(TokenCredential? credential) => _credential = credential;

    /// <summary>The credential for hosted-mode authentication, or <see langword="null"/> to use the default.</summary>
    public TokenCredential? Credential => Volatile.Read(ref _credential);

    public void AttachCredential(TokenCredential credential)
    {
        ArgumentNullException.ThrowIfNull(credential);
        TokenCredential? existing = Interlocked.CompareExchange(ref _credential, credential, null);
        if (existing is not null && !ReferenceEquals(existing, credential))
        {
            throw new InvalidOperationException(
                "Resilient-tasks services were already configured with a different TokenCredential.");
        }
    }
}
