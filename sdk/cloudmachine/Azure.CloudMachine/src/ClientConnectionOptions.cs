// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core;

/// <summary>
/// Represents the connection options for a client.
/// </summary>
public readonly struct ClientConnectionOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnectionOptions"/> struct with the specified endpoint and API key.
    /// </summary>
    /// <param name="endpoint">The endpoint URI.</param>
    /// <param name="apiKey">The API key credential.</param>
    public ClientConnectionOptions(Uri endpoint, string apiKey)
    {
        Endpoint = endpoint;
        ApiKeyCredential = apiKey;
        ConnectionKind = ClientConnectionKind.ApiKey;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnectionOptions"/> struct with the specified endpoint and token credential.
    /// </summary>
    /// <param name="endpoint">The endpoint URI.</param>
    /// <param name="credential">The token credential.</param>
    public ClientConnectionOptions(Uri endpoint, TokenCredential credential)
    {
        Endpoint = endpoint;
        TokenCredential = credential;
        ConnectionKind = ClientConnectionKind.EntraId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnectionOptions"/> struct with the specified subclient ID.
    /// </summary>
    /// <param name="subclientId">The subclient ID.</param>
    public ClientConnectionOptions(string subclientId)
    {
        Id = subclientId;
        ConnectionKind = ClientConnectionKind.OutOfBand;
    }

    /// <summary>
    /// Gets the kind of connection used by the client.
    /// </summary>
    public ClientConnectionKind ConnectionKind { get; }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    public Uri Endpoint { get; }

    /// <summary>
    /// Gets the subclient ID.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the API key credential.
    /// </summary>
    public string ApiKeyCredential { get; }

    /// <summary>
    /// Gets the token credential.
    /// </summary>
    public TokenCredential TokenCredential { get; }
}

/// <summary>
/// Specifies the kind of connection used by the client.
/// </summary>
public enum ClientConnectionKind
{
    /// <summary>
    /// Represents a connection using Entra ID.
    /// </summary>
    EntraId,

    /// <summary>
    /// Represents a connection using an API key.
    /// </summary>
    ApiKey,

    /// <summary>
    /// Represents a connection using an out-of-band method.
    /// </summary>
    OutOfBand
}
