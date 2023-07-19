// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

public class StaticCredential : TokenCredential
{
    private static AccessToken _token = new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow);
    private ValueTask<AccessToken> _tokenValueTask = new ValueTask<AccessToken>(new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.MaxValue));

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        => _token;

    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        => _tokenValueTask;
}
