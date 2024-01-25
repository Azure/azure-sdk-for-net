// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;

namespace Azure.Identity.Broker
{
    /// <summary>
    /// Options to configure the <see cref="InteractiveBrowserCredential"/> to use the system authentication broker in lieu of an embedded web view or the system browser.
    /// </summary>
    public class InteractiveBrowserCredentialBrokerOptions : InteractiveBrowserCredentialOptions, IMsalPublicClientInitializerOptions
    {
        private readonly IntPtr _parentWindowHandle;

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
        /// Creates a new instance of <see cref="InteractiveBrowserCredentialBrokerOptions"/> to configure a <see cref="InteractiveBrowserCredential"/>.
        /// </summary>
        /// <param name="parentWindowHandle">Handle of the parent window the system authentication broker should be docked to.</param>
        public InteractiveBrowserCredentialBrokerOptions(IntPtr parentWindowHandle) : base()
        {
            _parentWindowHandle = parentWindowHandle;
        }

        Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient => AddBroker;

        private void AddBroker(PublicClientApplicationBuilder builder)
        {
            builder.WithParentActivityOrWindow(() => _parentWindowHandle);
            var options = new BrokerOptions(BrokerOptions.OperatingSystems.Windows);
            if (IsLegacyMsaPassthroughEnabled.HasValue)
            {
                options.MsaPassthrough = IsLegacyMsaPassthroughEnabled.Value;
            }
            builder.WithBroker(options);
        }
    }
}
