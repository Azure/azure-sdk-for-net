// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents the connection options for a client.
/// </summary>
public readonly struct ClientConnection
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnection"/> struct with a token credential.
    /// </summary>
    /// <param name="id">The identifier for the connection.</param>
    /// <param name="locator">The endpoint or resource identifier.</param>
    /// <param name="credential">The client credential.</param>
    /// <param name="credentialKind">The kind of connection used by the client.</param>
    public ClientConnection(string id, string locator, object credential, CredentialKind credentialKind)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id cannot be null or empty.", nameof(id));
        if (string.IsNullOrWhiteSpace(locator))
            throw new ArgumentException("Locator cannot be null or empty.", nameof(locator));
        if (credential is null)
            throw new ArgumentNullException(nameof(credential), "Credential cannot be null.");

        Id = id;
        Locator = locator;
        Credential = credential;
        CredentialKind = credentialKind;
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
        CredentialKind = CredentialKind.None;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConnection"/> struct with the specified subclient ID.
    /// It is only for the JSON serializer.
    /// </summary>
    /// <param name="id">The identifier for the connection.</param>
    /// <param name="locator">The endpoint or resource identifier.</param>
    /// <param name="credentialKind">The kind of connection used by the client</param>
    internal ClientConnection(string id, string locator, CredentialKind credentialKind)
    {
        Id = id;
        Locator = locator;
        CredentialKind = credentialKind;
    }

    /// <summary>
    /// Gets the connection identifier.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// This is either URI, name, or something similar.
    /// </summary>
    public string Locator { get; }

    /// <summary>
    /// Gets the credential.
    /// </summary>
    public object? Credential { get; }

    /// <summary>
    /// Gets the kind of connection used by the client.
    /// </summary>
    public CredentialKind CredentialKind { get; }

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
