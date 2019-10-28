// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal interface IExtendedTokenCredential
    {
        ValueTask<ExtendedAccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken);

        ExtendedAccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken);
    }
}
