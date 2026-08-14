// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Microsoft.Azure.PostgreSQL.Auth;

/// <summary>
/// A simple <see cref="TokenCredential"/> that returns a fixed token string.
/// Used by unit tests to verify token parsing and username extraction.
/// </summary>
public class TestTokenCredential : TokenCredential
{
    private readonly string _token;

    public TestTokenCredential(string token)
    {
        _token = token;
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return new AccessToken(_token, DateTimeOffset.UtcNow.AddHours(1));
    }

    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return new ValueTask<AccessToken>(new AccessToken(_token, DateTimeOffset.UtcNow.AddHours(1)));
    }
}
