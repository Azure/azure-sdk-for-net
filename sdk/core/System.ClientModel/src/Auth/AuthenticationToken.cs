// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents an OAuth token and its metadata.
/// </summary>
public class AuthenticationToken
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationToken"/> class.
    /// </summary>
    /// <param name="tokenValue">The access token value.</param>
    /// <param name="tokenType">The type of the access token (e.g., "Bearer").</param>
    /// <param name="expiresOn">The date and time when the token expires.</param>
    /// <param name="refreshOn">Optional. The date and time when the token should be refreshed. Default is null.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="tokenValue"/> is null or empty.</exception>
    public AuthenticationToken(string tokenValue, string tokenType, DateTimeOffset expiresOn, DateTimeOffset? refreshOn = null)
    {
        Argument.AssertNotNullOrEmpty(tokenValue, nameof(tokenValue));

        TokenValue = tokenValue;
        TokenType = tokenType;
        ExpiresOn = expiresOn;
        RefreshOn = refreshOn;
    }

    /// <summary>
    /// Get the token value.
    /// </summary>
    public string TokenValue { get; }

    /// <summary>
    /// Gets the type of the token.
    /// </summary>
    public string TokenType { get; }

    /// <summary>
    /// Gets the time when the provided token expires.
    /// </summary>
    public DateTimeOffset? ExpiresOn { get; }

    /// <summary>
    /// Gets the time when the token should be refreshed.
    /// </summary>
    public DateTimeOffset? RefreshOn { get; }
}
