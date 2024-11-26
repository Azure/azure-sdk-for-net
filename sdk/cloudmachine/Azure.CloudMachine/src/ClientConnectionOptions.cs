// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core;

/// <summary>
/// Represents the connection options for a client.
/// </summary>
public readonly struct ClientConnectionOptions
{
    /// <summary>
    /// Do not use this constructor. It is only for the JSON serializer.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientConnectionOptions() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnectionOptions"/> struct with the specified endpoint and API key.
    /// </summary>
    /// <param name="endpoint">The endpoint URI.</param>
    /// <param name="apiKey">The API key credential.</param>
    public ClientConnectionOptions(Uri endpoint, string apiKey)
    {
        Endpoint = endpoint;
        ApiKeyCredential = apiKey;
        Authentication = ClientAuthenticationMethod.ApiKey;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnectionOptions"/> struct with the specified endpoint and token credential.
    /// </summary>
    /// <param name="endpoint">The endpoint URI.</param>
    public ClientConnectionOptions(Uri endpoint)
    {
        Endpoint = endpoint;
        Authentication = ClientAuthenticationMethod.EntraId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnectionOptions"/> struct with the specified subclient ID.
    /// </summary>
    /// <param name="subclientId">The subclient ID.</param>
    public ClientConnectionOptions(string subclientId)
    {
        SubclientId = subclientId;
        Authentication = ClientAuthenticationMethod.Subclient;
    }

    /// <summary>
    /// Gets the kind of connection used by the client.
    /// </summary>
    public ClientAuthenticationMethod Authentication { get; }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    public Uri Endpoint { get; }

    /// <summary>
    /// Gets the subclient ID.
    /// </summary>
    public string SubclientId { get; }

    /// <summary>
    /// Gets the API key credential.
    /// </summary>
    public string ApiKeyCredential { get; }
}

/// <summary>
/// Specifies the kind of connection used by the client.
/// </summary>
public enum ClientAuthenticationMethod
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
    Subclient
}
