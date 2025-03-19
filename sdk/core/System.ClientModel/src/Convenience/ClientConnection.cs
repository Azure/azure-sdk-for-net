// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents the connection options for a client.
/// </summary>
public readonly struct ClientConnection
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnection"/> struct with an API key credential.
    /// </summary>
    /// <param name="id">The identifier for the connection.</param>
    /// <param name="locator">The endpoint or resource identifier.</param>
    /// <param name="apiKey">The API key credential.</param>
    public ClientConnection(string id, string locator, string apiKey)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id cannot be null or empty.", nameof(id));
        if (string.IsNullOrWhiteSpace(locator))
            throw new ArgumentException("Locator cannot be null or empty.", nameof(locator));
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new ArgumentException("API Key cannot be null or empty.", nameof(apiKey));

        Id = id;
        Locator = locator;
        Authentication = ClientAuthenticationMethod.ApiKey;
        ApiKeyCredential = apiKey;
        Credential = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnection"/> struct with a token credential.
    /// </summary>
    /// <param name="id">The identifier for the connection.</param>
    /// <param name="locator">The endpoint or resource identifier.</param>
    /// <param name="credential">The token credential.</param>
    public ClientConnection(string id, string locator, object credential)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id cannot be null or empty.", nameof(id));
        if (string.IsNullOrWhiteSpace(locator))
            throw new ArgumentException("Locator cannot be null or empty.", nameof(locator));
        if (credential is null)
            throw new ArgumentNullException(nameof(credential), "Credential cannot be null.");

        Id = id;
        Locator = locator;
        Authentication = ClientAuthenticationMethod.Credential;
        Credential = credential;
        ApiKeyCredential = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnection"/> struct with a with no authentication.
    /// </summary>
    /// <param name="id">The identifier for the connection.</param>
    /// <param name="locator">The endpoint or resource identifier.</param>
    public ClientConnection(string id, string locator)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id cannot be null or empty.", nameof(id));
        if (string.IsNullOrWhiteSpace(locator))
            throw new ArgumentException("Locator cannot be null or empty.", nameof(locator));

        Id = id;
        Locator = locator;
        Authentication = ClientAuthenticationMethod.NoAuth;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnection"/> struct with the specified subclient ID.
    /// It is only for the JSON serializer.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="locator">The subclient ID.</param>
    /// <param name="auth"></param>
    internal ClientConnection(string id, string locator, ClientAuthenticationMethod auth)
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
    /// Gets the connection identifier.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// This is either URI, name, or something similar.
    /// </summary>
    public string Locator { get; }

    /// <summary>
    /// Gets the API key credential, if applicable.
    /// </summary>
    public string? ApiKeyCredential { get; }

    /// <summary>
    /// Gets the token credential, if applicable.
    /// Since TokenCredential is not available in this package, using object type as a placeholder.
    /// </summary>
    public object? Credential { get; }

    /// <summary>
    /// Tries to convert the connection locator to a URI.
    /// </summary>
    /// <param name="uri">When this method returns, contains the URI representation of the connection if the conversion succeeded; otherwise, null.</param>
    /// <returns><c>true</c> if the conversion was successful; otherwise, <c>false</c>.</returns>
    public bool TryGetLocatorAsUri(out Uri? uri)
    {
        return Uri.TryCreate(Locator, UriKind.Absolute, out uri);
    }

    /// <summary>
    /// Returns a string representation of the connection.
    /// </summary>
    /// <returns>A string in the format 'Id => Locator'.</returns>
    public override string ToString() => $"{Id} => {Locator}";
}
