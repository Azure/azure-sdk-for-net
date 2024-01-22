// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;

namespace Azure.Identity.Broker
{
    /// <summary>
    /// Options to configure the <see cref="SharedTokenCacheCredential"/> to use the system authentication broker for silent authentication if available.
    /// </summary>
    public class SharedTokenCacheCredentialBrokerOptions : SharedTokenCacheCredentialOptions, IMsalPublicClientInitializerOptions
    {
        /// <summary>
        /// Gets or sets whether Microsoft Account (MSA) passthrough is enabled.
        /// </summary>
        /// <value></value>
        public bool? IsLegacyMsaPassthroughEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether proof of possession is required.
        /// </summary>
        public bool IsProofOfPossessionRequired { get; set; }

        /// <summary>
        /// Gets or sets whether to authenticate with the currently signed in user instead of prompting the user with a login dialog.
        /// </summary>
        public bool UseOperatingSystemAccount { get; set; }

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
            var options = new BrokerOptions(BrokerOptions.OperatingSystems.Windows);
            if (IsLegacyMsaPassthroughEnabled.HasValue)
            {
                options.MsaPassthrough = IsLegacyMsaPassthroughEnabled.Value;
            }
            builder.WithBroker(options);
        }
    }
}
