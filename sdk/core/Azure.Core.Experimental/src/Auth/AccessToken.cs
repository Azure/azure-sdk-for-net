// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel;

/// <summary>
/// Represents an OAuth token and its metadata.
/// </summary>
public class AccessToken
{
    /// <summary>
    /// Creates a new instance of <see cref="AccessToken"/> using the provided <paramref name="tokenValue"/> and <paramref name="expiresOn"/>.
    /// </summary>
    /// <param name="tokenValue"></param>
    /// <param name="tokenType"></param>
    /// <param name="expiresOn"></param>
    /// <param name="refreshOn"></param>
    public AccessToken(string tokenValue, string tokenType, DateTimeOffset expiresOn, DateTimeOffset? refreshOn = null)
    {
        TokenValue = tokenValue;
        TokenType = tokenType;
        ExpiresOn = expiresOn;
        RefreshOn = refreshOn;
    }

    /// <summary>
    /// Get the token value.
    /// </summary>
    public string TokenValue { get; protected set; }

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
