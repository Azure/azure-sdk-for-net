// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;

namespace Azure.Identity.Broker
{
    /// <summary>
    /// Options to configure the <see cref="InteractiveBrowserCredential"/> to use the system authentication broker in lieu of an embedded web view or the system browser.
    /// For more information, see <see href="https://aka.ms/azsdk/net/identity/broker">Use a broker</see>.
    /// </summary>
    public class InteractiveBrowserCredentialBrokerOptions : InteractiveBrowserCredentialOptions, IMsalPublicClientInitializerOptions
    {
        private readonly IntPtr _parentWindowHandle;

        /// <summary>
        /// Gets or sets whether Microsoft Account (MSA) passthrough is enabled.
        /// </summary>
        public bool? IsLegacyMsaPassthroughEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether to authenticate with the default broker account instead of prompting the user with a login dialog.
        /// </summary>
        public bool UseDefaultBrokerAccount { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="InteractiveBrowserCredentialBrokerOptions"/> to configure a <see cref="InteractiveBrowserCredential"/>.
        /// </summary>
        /// <param name="parentWindowHandle">Handle of the parent window the system authentication broker should be docked to.</param>
        public InteractiveBrowserCredentialBrokerOptions(IntPtr parentWindowHandle) : base()
        {
            _parentWindowHandle = parentWindowHandle;

            // Set default value for UseDefaultBrokerAccount on macOS
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                RedirectUri = new(Constants.MacBrokerRedirectUri);
            }
        }

        Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient => AddBroker;

        private void AddBroker(PublicClientApplicationBuilder builder)
        {
            builder.WithParentActivityOrWindow(() => _parentWindowHandle);
            var options = new BrokerOptions(BrokerOptions.OperatingSystems.Windows | BrokerOptions.OperatingSystems.Linux | BrokerOptions.OperatingSystems.OSX);
            if (IsLegacyMsaPassthroughEnabled.HasValue)
            {
                options.MsaPassthrough = IsLegacyMsaPassthroughEnabled.Value;
            }
            builder.WithBroker(options);
        }
    }
}
