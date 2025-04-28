// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public partial class ManualInteractiveBrowserCredentialBrokerTests
    {
        /// <summary>
        /// Get the handle of the console window for Linux
        /// </summary>
        [DllImport("libX11")]
        private static extern IntPtr XOpenDisplay(string display);

        [DllImport("libX11")]
        private static extern IntPtr XRootWindow(IntPtr display, int screen);

        [DllImport("libX11")]
        private static extern IntPtr XDefaultRootWindow(IntPtr display);

        [Test]
        // [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrokerAsync()
        {
            IntPtr parentWindowHandle = XRootWindow(XOpenDisplay(null), 0);
            // to fully manually verify the InteractiveBrowserCredential this test should be run both authenticating with a
            // school / organization account as well as a personal live account, i.e. a @outlook.com, @live.com, or @hotmail.com
            var cred = new InteractiveBrowserCredential(new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle));

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        // [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrokerWithDefaultBrokerAccountLinux()
        {
            IntPtr parentWindowHandle = IntPtr.Zero;

            var cred = new InteractiveBrowserCredential(new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)  { UseDefaultBrokerAccount = true });

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }
    }
}