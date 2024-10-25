// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core;

public abstract class ClientWorkspace
{
    public abstract ClientConnectionOptions GetConnectionOptions(Type clientType, string? instanceId = default);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientCache Subclients { get; } = new ClientCache();
}

public readonly struct ClientConnectionOptions
{
    public ClientConnectionOptions(Uri endpoint, string apiKey)
    {
        Endpoint = endpoint;
        ApiKeyCredential = apiKey;
        ConnectionKind = ClientConnectionKind.ApiKey;
    }
    public ClientConnectionOptions(Uri endpoint, TokenCredential credential)
    {
        Endpoint = endpoint;
        TokenCredential = credential;
        ConnectionKind = ClientConnectionKind.EntraId;
    }
    public ClientConnectionOptions(string subclientId)
    {
        Id = subclientId;
        ConnectionKind = ClientConnectionKind.OutOfBand;
    }

    public ClientConnectionKind ConnectionKind { get; }

    public Uri? Endpoint { get; }
    public string? Id { get; }
    public string? ApiKeyCredential { get; }
    public TokenCredential? TokenCredential { get; }
}

public enum ClientConnectionKind
{
    EntraId,
    ApiKey,
    OutOfBand
}
