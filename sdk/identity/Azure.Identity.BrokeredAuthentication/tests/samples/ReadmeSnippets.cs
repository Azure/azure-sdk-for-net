// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity.BrokeredAuthentication;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Samples
{
    public class ReadmeSnippets
    {
        [Test]
        public void ConfigureInteractiveBrowserToUseBroker()
        {
            #region Snippet:ConfigureInteractiveBrowserToUseBroker
            // Create an interactive browser credential which will use the system authentication broker
            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialBrokerOptions());

            // Use the credential to authenticate a secret client
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
            #endregion
        }
    }
}
