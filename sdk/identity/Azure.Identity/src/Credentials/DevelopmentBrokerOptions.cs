// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="InteractiveBrowserCredential"/> to use the system authentication broker in lieu of an embedded web view or the system browser.
    /// For more information, see <see href="https://aka.ms/azsdk/net/identity/interactive-brokered-auth">Interactive brokered authentication</see>.
    /// </summary>
    internal class DevelopmentBrokerOptions : InteractiveBrowserCredentialOptions, IMsalSettablePublicClientInitializerOptions, IMsalPublicClientInitializerOptions, ISupportsTenantId
    {
        private Action<PublicClientApplicationBuilder> _beforeBuildClient;
        /// <summary>
        /// Gets or sets whether Microsoft Account (MSA) passthrough is enabled.
        /// </summary>
        public bool? IsLegacyMsaPassthroughEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets whether to authenticate with the default broker account instead of prompting the user with a login dialog.
        /// </summary>
        public bool UseDefaultBrokerAccount { get; set; } = true;

        /// <summary>
        /// Creates a new instance of <see cref="DevelopmentBrokerOptions"/> to configure a <see cref="InteractiveBrowserCredential"/> for broker authentication.
        /// </summary>
        public DevelopmentBrokerOptions() : base()
        {
        }

        Action<PublicClientApplicationBuilder> IMsalSettablePublicClientInitializerOptions.BeforeBuildClient
        {
            get => _beforeBuildClient;
            set => _beforeBuildClient = value;
        }

        Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient => _beforeBuildClient;

        internal override T Clone<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>()
        {
            var clone = base.Clone<T>();

            if (clone is DevelopmentBrokerOptions dboClone)
            {
                dboClone.IsLegacyMsaPassthroughEnabled = IsLegacyMsaPassthroughEnabled;
                dboClone.UseDefaultBrokerAccount = UseDefaultBrokerAccount;
            }
            return clone;
        }
    }
}
