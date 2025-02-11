// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel;

/// <summary>
/// Represents a credential capable of providing an OAuth token.
/// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
public class Credential
#pragma warning restore AZC0012 // Avoid single word type names
{
    /// <summary>
    /// Creates a new instance of <see cref="Credential"/> using the provided <paramref name="token"/> and <paramref name="expiresOn"/>.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="tokenType"></param>
    /// <param name="expiresOn"></param>
    public Credential(string token, string tokenType, DateTimeOffset expiresOn)
    {
        Token = token;
        TokenType = tokenType;
        ExpiresOn = expiresOn;
    }

    /// <summary>
    /// Get the token value.
    /// </summary>
    public string Token { get; protected set; }

    /// <summary>
    /// Gets the type of the token.
    /// </summary>
    public string TokenType { get; protected set; }

    /// <summary>
    /// Gets the time when the provided token expires.
    /// </summary>
    public DateTimeOffset ExpiresOn { get; protected set; }

    /// <summary>
    /// Gets the time when the token should be refreshed.
    /// </summary>
    public DateTimeOffset? RefreshOn { get; protected set; }
}
