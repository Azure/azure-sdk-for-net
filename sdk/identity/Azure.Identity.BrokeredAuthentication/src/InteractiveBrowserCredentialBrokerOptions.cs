// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;

namespace Azure.Identity.BrokeredAuthentication
{
    /// <summary>
    /// Options to configure the <see cref="InteractiveBrowserCredential"/> to use the system authentication broker in lieu of the system browser if available.
    /// </summary>
    public class InteractiveBrowserCredentialBrokerOptions : InteractiveBrowserCredentialOptions, IMsalPublicClientInitializerOptions
    {
        private readonly IntPtr _parentWindowHandle;

        /// <summary>
        /// Gets or sets whether Microsoft Account (MSA) passthough.
        /// </summary>
        /// <value></value>
        public bool? IsMsaPassthroughEnabled { get; set; }

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
            if (IsMsaPassthroughEnabled.HasValue)
            {
                options.MsaPassthrough = IsMsaPassthroughEnabled.Value;
            }
            builder.WithBroker(options);
        }
    }
}
