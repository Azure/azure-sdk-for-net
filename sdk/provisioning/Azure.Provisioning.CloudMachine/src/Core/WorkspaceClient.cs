// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Core;

public abstract class WorkspaceClient
{
    public abstract TokenCredential Credential { get; }

    public abstract WorkspaceClientConnection? GetConnection(string clientId);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientCache Subclients { get; } = new ClientCache();
}

public readonly struct WorkspaceClientConnection
{
    public WorkspaceClientConnection(string endpoint, string? apiKey = default)
    {
        Endpoint = endpoint;
        ApiKey = apiKey;
        CredentailType = apiKey == default ? CredentialType.EntraId : CredentialType.ApiKey;
    }
    public string Endpoint { get; }
    public string? ApiKey { get; }
    public CredentialType CredentailType { get; }
}

public enum CredentialType
{
    EntraId,
    ApiKey,
}
