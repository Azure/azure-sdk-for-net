// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CoreWCF.IdentityModel.Selectors;
using Microsoft.CoreWCF.Azure.StorageQueues.Channels;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.Tokens
{
    internal class SecurityTokenProviderContainer
    {
        public SecurityTokenProviderContainer(SecurityTokenProvider tokenProvider)
        {
            if (tokenProvider is null) throw new ArgumentNullException(nameof(tokenProvider));
            TokenProvider = tokenProvider;
        }

        public SecurityTokenProvider TokenProvider { get; }

        public Task OpenAsync(CancellationToken token)
        {
            return SecurityUtils.OpenTokenProviderIfRequiredAsync(TokenProvider, token);
        }

        public Task CloseAsync(CancellationToken token)
        {
            return SecurityUtils.CloseTokenProviderIfRequiredAsync(TokenProvider, token);
        }

        public void Abort()
        {
            SecurityUtils.AbortTokenProviderIfRequired(TokenProvider);
        }
    }
}
