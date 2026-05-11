// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// An <see cref="AuthenticationTokenProvider"/> that returns a fixed,
/// caller-supplied API key as the token value. The key is captured at
/// construction time (snapshot semantics) — there is no refresh and no
/// background work. <see cref="GetTokenOptions"/> are accepted but ignored;
/// any caller-supplied scope produces the same token.
/// </summary>
internal sealed class ApiKeyTokenProvider : AuthenticationTokenProvider
{
    private readonly AuthenticationToken _token;

    /// <summary>
    /// Initializes a new instance of <see cref="ApiKeyTokenProvider"/> that
    /// always returns <paramref name="apiKey"/> as the token value.
    /// </summary>
    /// <param name="apiKey">The API key to return as the access-token value.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="apiKey"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="apiKey"/> is empty.</exception>
    public ApiKeyTokenProvider(string apiKey)
    {
        Argument.AssertNotNullOrEmpty(apiKey, nameof(apiKey));
        _token = new AuthenticationToken(apiKey, "Bearer", DateTimeOffset.MaxValue, refreshOn: null);
    }

    /// <inheritdoc />
    public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
    {
        // API-key auth is scope-agnostic; accept whatever properties the caller
        // hands us so the resulting GetTokenOptions round-trip is non-lossy.
        if (properties is null)
        {
            return null;
        }
        return new GetTokenOptions(properties);
    }

    /// <inheritdoc />
    public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken) => _token;

    /// <inheritdoc />
    public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
        => new(_token);
}
