// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;

namespace Azure.Identity.Broker
{
    /// <summary>
    /// Options to configure the <see cref="InteractiveBrowserCredential"/> to use the system authentication broker in lieu of an embedded web view or the system browser.
    /// For more information, see <see href="https://aka.ms/azsdk/net/identity/interactive-brokered-auth">Interactive brokered authentication</see>.
    /// </summary>
    internal class DevelopmentBrokerOptions : InteractiveBrowserCredentialOptions, IMsalSettablePublicClientInitializerOptions, IMsalPublicClientInitializerOptions
    {
        private Action<PublicClientApplicationBuilder> _beforeBuildClient;
        /// <summary>
        /// Gets or sets whether Microsoft Account (MSA) passthrough is enabled.
        /// </summary>
        public bool? IsLegacyMsaPassthroughEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether to authenticate with the default broker account instead of prompting the user with a login dialog.
        /// </summary>
        public bool UseDefaultBrokerAccount { get; set; } = true;

        /// <summary>
        /// Creates a new instance of <see cref="DevelopmentBrokerOptions"/> to configure a <see cref="InteractiveBrowserCredential"/> for broker authentication.
        /// </summary>
        public DevelopmentBrokerOptions() : base()
        {
            _beforeBuildClient = AddBroker;

            // Set default value for UseDefaultBrokerAccount on macOS
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                RedirectUri = new(Constants.MacBrokerRedirectUri);
            }
        }

        Action<PublicClientApplicationBuilder> IMsalSettablePublicClientInitializerOptions.BeforeBuildClient
        {
            get => _beforeBuildClient;
            set => _beforeBuildClient = value;
        }

        Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient => _beforeBuildClient;

        private void AddBroker(PublicClientApplicationBuilder builder)
        {
            builder.WithParentActivityOrWindow(() => IntPtr.Zero);
            var options = new BrokerOptions(BrokerOptions.OperatingSystems.Windows | BrokerOptions.OperatingSystems.Linux | BrokerOptions.OperatingSystems.OSX);
            if (IsLegacyMsaPassthroughEnabled.HasValue)
            {
                options.MsaPassthrough = IsLegacyMsaPassthroughEnabled.Value;
            }
            builder.WithBroker(options);
        }
    }
}
