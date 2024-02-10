// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Samples
{
    public class ReadmeSnippets
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [Test]
        public void ConfigureInteractiveBrowserToUseBroker()
        {
            #region Snippet:ConfigureInteractiveBrowserToUseBroker
            IntPtr parentWindowHandle = GetForegroundWindow();

            // Create an interactive browser credential which will use the system authentication broker
            var credential = new InteractiveBrowserCredential(
                new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle));

            // Use the credential to authenticate a secret client
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
            #endregion
        }

        [Test]
        public void ConfigureInteractiveBrowserToUseDefaultOsAccount()
        {
            IntPtr parentWindowHandle = GetForegroundWindow();

            #region Snippet:ConfigureInteractiveBrowserToUseDefaultOsAccount
            var credential = new InteractiveBrowserCredential(
                new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)
                {
                    UseOperatingSystemAccount = true,
                });
            #endregion

            // Use the credential to authenticate a secret client
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
        }
    }
}
