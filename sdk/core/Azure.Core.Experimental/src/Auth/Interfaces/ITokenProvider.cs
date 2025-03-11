// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.ClientModel.Auth;

namespace System.ClientModel;

/// <summary>
/// An interface implemented by all <see cref="TokenProvider{TContext}"/> implementations.
/// </summary>
public interface ITokenProvider
{
    /// <summary>
    /// Gets the token.
    /// </summary>
    /// <param name="properties"></param>
    /// <returns></returns>
    object CreateContext(IReadOnlyDictionary<string, object> properties);

    /// <summary>
    /// Gets the token.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Token GetToken(ITokenContext context, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the token.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<Token> GetTokenAsync(ITokenContext context, CancellationToken cancellationToken);
}
