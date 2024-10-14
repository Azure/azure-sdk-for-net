// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Core;

public abstract class WorkspaceClient
{
    public abstract TokenCredential Credential { get; }

    public abstract ClientConfiguration? GetConfiguration(string clientId, string? instanceId = default);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientCache Subclients { get; } = new ClientCache();
}

public readonly struct ClientConfiguration
{
    public ClientConfiguration(string endpoint, string? apiKey = default)
    {
        Endpoint = endpoint;
        ApiKey = apiKey;
        CredentialType = apiKey == default ? CredentialType.EntraId : CredentialType.ApiKey;
    }
    public string Endpoint { get; }
    public string? ApiKey { get; }
    public CredentialType CredentialType { get; }
}

public enum CredentialType
{
    EntraId,
    ApiKey,
}
