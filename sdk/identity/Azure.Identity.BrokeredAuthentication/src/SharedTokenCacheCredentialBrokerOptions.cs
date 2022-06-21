// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;

namespace Azure.Identity.BrokeredAuthentication
{
    /// <summary>
    /// Options to configure the <see cref="SharedTokenCacheCredential"/> to use the system authentication broker for silent authentication if available.
    /// </summary>
    public class SharedTokenCacheCredentialBrokerOptions : SharedTokenCacheCredentialOptions, IMsalPublicClientInitializerOptions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SharedTokenCacheCredentialBrokerOptions"/>.
        /// </summary>
        public SharedTokenCacheCredentialBrokerOptions()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="SharedTokenCacheCredentialBrokerOptions"/>.
        /// </summary>
        /// <param name="tokenCacheOptions">The <see cref="TokenCachePersistenceOptions"/> that will apply to the token cache used by this credential.</param>
        public SharedTokenCacheCredentialBrokerOptions(TokenCachePersistenceOptions tokenCacheOptions)
            : base(tokenCacheOptions)
        {
        }

        Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient => AddBroker;

        private void AddBroker(PublicClientApplicationBuilder builder)
        {
            builder.WithBrokerPreview();
        }
    }
}
