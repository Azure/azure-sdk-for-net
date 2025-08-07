// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.WCF.Azure.StorageQueues.Channels;
using System;
using System.IdentityModel.Selectors;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Microsoft.WCF.Azure.Tokens
{
    internal class SecurityTokenProviderContainer
    {
        public SecurityTokenProviderContainer(SecurityTokenProvider tokenProvider)
        {
            ArgumentNullException.ThrowIfNull(tokenProvider);
            TokenProvider = tokenProvider;
        }

        public SecurityTokenProvider TokenProvider { get; }

        public void Open(TimeSpan timeout)
        {
            SecurityUtils.OpenTokenProviderIfRequired(TokenProvider, timeout);
        }

        public void Close(TimeSpan timeout)
        {
            SecurityUtils.CloseTokenProviderIfRequired(TokenProvider, timeout);
        }

        public Task OpenAsync(TimeSpan timeout)
        {
            return SecurityUtils.OpenTokenProviderIfRequiredAsync(TokenProvider, timeout);
        }

        public Task CloseAsync(TimeSpan timeout)
        {
            return SecurityUtils.CloseTokenProviderIfRequiredAsync(TokenProvider, timeout);
        }

        public void Abort()
        {
            SecurityUtils.AbortTokenProviderIfRequired(TokenProvider);
        }
    }
}
