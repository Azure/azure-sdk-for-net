// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// The base class for all <see cref="AuthenticationTokenProvider"/> implementations.
/// </summary>
public abstract class AuthenticationTokenProvider
{
    /// <summary>
    /// Creates a new instance of <see cref="GetTokenOptions"/> using the provided <paramref name="properties"/>.
    /// </summary>
    /// <param name="properties"></param>
    /// <returns>An instance of <see cref="GetTokenOptions"/> or <c>null</c> if the provided options are not valid.</returns>
    public abstract GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties);

    /// <summary>
    /// Gets a token from the auth provider.
    /// </summary>
    /// <param name="options">The options used by the <see cref="AuthenticationTokenProvider"/> to make a token request.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
    /// <returns></returns>
    public abstract AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the token.
    /// </summary>
    /// <param name="options">The options used by the <see cref="AuthenticationTokenProvider"/> to make a token request.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
    /// <returns></returns>
    public abstract ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken);
}
