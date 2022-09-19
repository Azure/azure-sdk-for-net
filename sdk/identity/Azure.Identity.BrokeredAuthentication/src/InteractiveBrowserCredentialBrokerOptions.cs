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
        private IntPtr _parentWindowHandle;
        private bool _msaPassthrough;

        /// <summary>
        /// Creates a new instance of <see cref="InteractiveBrowserCredentialBrokerOptions"/> to configure a <see cref="InteractiveBrowserCredential"/>.
        /// </summary>
        /// <param name="parentWindowHandle">Handle of the parent window the system authentication broker should be docked to.</param>
        /// <param name="msaPassthrough">A legacy option available only to old Microsoft applications. Should be avoided where possible. Support is experimental.</param>
        public InteractiveBrowserCredentialBrokerOptions(IntPtr parentWindowHandle, bool msaPassthrough = false) : base()
        {
            _parentWindowHandle = parentWindowHandle;
            _msaPassthrough = msaPassthrough;
        }

        Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient => AddBroker;

        private void AddBroker(PublicClientApplicationBuilder builder)
        {
            builder.WithBrokerPreview()
            .WithParentActivityOrWindow(() => _parentWindowHandle)
            .WithWindowsBrokerOptions(new WindowsBrokerOptions()
            {
                MsaPassthrough = _msaPassthrough
            });
        }
    }
}
