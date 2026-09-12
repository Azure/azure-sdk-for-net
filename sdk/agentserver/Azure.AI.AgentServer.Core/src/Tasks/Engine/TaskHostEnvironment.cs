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
    private readonly object _gate = new();
    private TokenCredential? _credential;
    private Uri? _endpoint;

    public TaskHostEnvironment(TokenCredential? credential, Uri? endpoint)
    {
        _credential = credential;
        _endpoint = endpoint;
    }

    /// <summary>The credential for hosted-mode authentication, or <see langword="null"/> to use the default.</summary>
    public TokenCredential? Credential
    {
        get
        {
            lock (_gate)
            {
                return _credential;
            }
        }
    }

    /// <summary>The configured Foundry project endpoint, or <see langword="null"/> to use the environment.</summary>
    public Uri? Endpoint
    {
        get
        {
            lock (_gate)
            {
                return _endpoint;
            }
        }
    }

    public void AttachConfiguration(TokenCredential? credential, Uri? endpoint)
    {
        lock (_gate)
        {
            if (credential is not null
                && _credential is not null
                && !ReferenceEquals(_credential, credential))
            {
                throw new InvalidOperationException(
                    "Resilient-tasks services were already configured with a different TokenCredential.");
            }

            if (endpoint is not null
                && _endpoint is not null
                && _endpoint != endpoint)
            {
                throw new InvalidOperationException(
                    "Resilient-tasks services were already configured with a different endpoint.");
            }

            _credential ??= credential;
            _endpoint ??= endpoint;
        }
    }
}
