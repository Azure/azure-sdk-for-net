// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Auth;

/// <summary>
/// The base class for all <see cref="TokenProvider"/> implementations.
/// </summary>
public abstract class TokenProvider
{
    /// <summary>
    /// Creates a new instance of <see cref="TokenFlowProperties"/> using the provided <paramref name="properties"/>.
    /// </summary>
    /// <param name="properties"></param>
    /// <returns></returns>
    public abstract TokenFlowProperties? CreateContext(IReadOnlyDictionary<string, object> properties);

    /// <summary>
    /// Gets a token from the auth provider.
    /// </summary>
    /// <param name="properties">The options used by the <see cref="TokenProvider"/> to make a token request.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
    /// <returns></returns>
    public abstract Token GetToken(TokenFlowProperties properties, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the token.
    /// </summary>
    /// <param name="properties">The options used by the <see cref="TokenProvider"/> to make a token request.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
    /// <returns></returns>
    public abstract ValueTask<Token> GetTokenAsync(TokenFlowProperties properties, CancellationToken cancellationToken);
}
