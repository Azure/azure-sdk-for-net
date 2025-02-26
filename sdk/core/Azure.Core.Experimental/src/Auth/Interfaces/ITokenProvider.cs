// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a provider that can provide a token.
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
    Token GetAccessToken(object context, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the token.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<Token> GetAccessTokenAsync(object context, CancellationToken cancellationToken);
}
