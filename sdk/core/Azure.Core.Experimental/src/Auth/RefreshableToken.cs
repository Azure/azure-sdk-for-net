// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a Token capable of refreshing itself.
/// </summary>
public abstract class RefreshableToken : AccessToken
{
    /// <summary>
    /// Creates a new instance of <see cref="AccessToken"/> using the provided <paramref name="tokenValue"/> and <paramref name="expiresOn"/>.
    /// </summary>
    /// <param name="tokenValue"></param>
    /// <param name="tokenType"></param>
    /// <param name="expiresOn"></param>
    /// <param name="refreshOn"></param>
    public RefreshableToken(string tokenValue, string tokenType, DateTimeOffset expiresOn, DateTimeOffset? refreshOn = null)
        : base(tokenValue, tokenType, expiresOn, refreshOn)
    { }

    /// <summary>
    /// Refreshes the token
    /// </summary>
    public abstract Task RefreshAsync(CancellationToken cancellationToken);
}
