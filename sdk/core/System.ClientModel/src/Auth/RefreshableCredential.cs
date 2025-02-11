// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a provider that can provide a credential.
/// </summary>
public abstract class RefreshableCredential : Credential
{
    /// <summary>
    /// Gets or sets the refresh strategy.
    /// </summary>
    public RefreshStrategy RefreshStrategy { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="RefreshableCredential"/> using the provided <paramref name="refreshStrategy"/>.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="tokenType"></param>
    /// <param name="expiry"></param>
    /// <param name="refreshStrategy"></param>
    public RefreshableCredential(string token, string tokenType, DateTimeOffset expiry, RefreshStrategy refreshStrategy)
        : base(token, tokenType, expiry)
    {
        RefreshStrategy = refreshStrategy;
    }
}

/// <summary>
/// Represents a provider that can provide a credential.
/// </summary>
public abstract class RefreshStrategy
{
    /// <summary>
    /// Refreshes the credential.
    /// </summary>
    /// <param name="credential"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract Task RefreshAsync(RefreshableCredential credential, CancellationToken cancellationToken);
}
