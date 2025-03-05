// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Auth;

/// <summary>
/// The base class for all <see cref="ITokenProvider"/> implementations.
/// </summary>
/// <typeparam name="TContext">A type that implements <see cref="ITokenContext"/></typeparam>
public abstract class TokenProvider<TContext> : ITokenProvider where TContext : ITokenContext
{
    /// <summary>
    /// Creates a context.
    /// </summary>
    /// <param name="properties"></param>
    /// <returns></returns>
    public abstract TContext CreateContext(IReadOnlyDictionary<string, object> properties);

    /// <summary>
    /// Gets the token.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract Token GetAccessToken(TContext context, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the token.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract ValueTask<Token> GetAccessTokenAsync(TContext context, CancellationToken cancellationToken);

    object ITokenProvider.CreateContext(IReadOnlyDictionary<string, object> properties)
        => CreateContext(properties);

    Token ITokenProvider.GetToken(ITokenContext context, CancellationToken cancellationToken)
        => GetAccessToken((TContext)context, cancellationToken);

    ValueTask<Token> ITokenProvider.GetTokenAsync(ITokenContext context, CancellationToken cancellationToken)
        => GetAccessTokenAsync((TContext)context, cancellationToken);
}
