// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// A mock token credential to be used for testing.
/// </summary>
public class MockTokenCredential : TokenCredential
{
    /// <summary>
    /// Event raised when a token is requested.
    /// </summary>
    public event EventHandler<TokenRequestContext>? TokenRequested;

    /// <inheritdoc />
    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        TokenRequested?.Invoke(this, requestContext);
        return new AccessToken("TEST TOKEN " + string.Join(",", requestContext.Scopes), DateTimeOffset.MaxValue);
    }

    /// <inheritdoc />
    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return new(GetToken(requestContext, cancellationToken));
    }
}
