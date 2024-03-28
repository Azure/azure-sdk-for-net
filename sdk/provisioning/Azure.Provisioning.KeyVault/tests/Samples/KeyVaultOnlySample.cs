// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.KeyVaults;

namespace Azure.Provisioning.Tests.Samples
{
    internal class KeyVaultOnlySample
    {
        #region Snippet:SampleInfrastructure
        public class SampleInfrastructure : Infrastructure
        {
        }
        #endregion

        public void Sample()
        {
            #region Snippet:KeyVaultOnly
            // Create a new infrastructure
            var infrastructure = new SampleInfrastructure();

            // Add a new key vault
            var keyVault = infrastructure.AddKeyVault();

            // You can call Build to convert the infrastructure into bicep files
            infrastructure.Build();
            #endregion
        }
    }
}
