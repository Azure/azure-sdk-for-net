// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;
#if (NETFRAMEWORK)
using Microsoft.Identity.Client.Desktop;
#endif

namespace Azure.Identity.BrokeredAuthentication
{
    /// <summary>
    /// Options to configure the <see cref="SharedTokenCacheCredential"/> to use the system authentication broker for silent authentication if available.
    /// </summary>
    public class SharedTokenCacheCredentialBrokerOptions : SharedTokenCacheCredentialOptions, IMsalPublicClientInitializerOptions
    {
        Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient => AddBroker;

        private void AddBroker(PublicClientApplicationBuilder builder)
        {
#if (NETFRAMEWORK)
            builder.WithWindowsBroker();
#else
            builder.WithBroker();
#endif
        }
    }
}
