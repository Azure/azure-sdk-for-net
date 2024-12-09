// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Azure.Core;

/// <summary>
/// Represents the connection options for a client.
/// </summary>
public readonly struct ClientConnection
{
    /// <summary>
    /// Do not use this constructor. It is only for the JSON serializer.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientConnection() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnection"/> struct with the specified endpoint and API key.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="locator"></param>
    /// <param name="apiKey">The API key credential.</param>
    public ClientConnection(string id, string locator, string apiKey)
    {
        Id = id;
        Locator = locator;
        ApiKeyCredential = apiKey;
        Authentication = ClientAuthenticationMethod.ApiKey;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnection"/> struct with the specified subclient ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="locator">The subclient ID.</param>
    /// <param name="auth"></param>
    public ClientConnection(string id, string locator, ClientAuthenticationMethod auth = ClientAuthenticationMethod.EntraId)
    {
        Id = id;
        Locator = locator;
        Authentication = auth;
    }

    /// <summary>
    /// Gets the kind of connection used by the client.
    /// </summary>
    public ClientAuthenticationMethod Authentication { get; }

    /// <summary>
    /// Gets the key.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// This is either URI or name, or something like that.
    /// </summary>
    public string Locator { get; }

    /// <summary>
    /// Gets the API key credential.
    /// </summary>
    public string ApiKeyCredential { get; }

    /// <summary>
    /// Converts the connection to a URI.
    /// </summary>
    /// <returns></returns>
    public Uri ToUri() => new(Locator);

    /// <summary>
    /// Returns a string representation of the connection.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{Id} => {Locator}";
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
