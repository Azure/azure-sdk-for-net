// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.KeyVaults;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Samples
{
    internal class KeyVaultOnlySample : ProvisioningTestBase
    {
        public KeyVaultOnlySample(bool async) : base(async)
        {
        }

        #region Snippet:SampleInfrastructure
        public class SampleInfrastructure : Infrastructure
        {
            public SampleInfrastructure() : base(envName: "Sample", tenantId: Guid.Empty, subscriptionId: Guid.Empty, configuration: new Configuration { UseInteractiveMode = true })
            {
            }
        }
        #endregion

        [Test]
        public void Sample_HelloWorld()
        {
            #region Snippet:KeyVaultOnly
            // Create a new infrastructure
            var infrastructure = new SampleInfrastructure();

            // Add a new key vault
            var keyVault = infrastructure.AddKeyVault();

            // You can call Build to convert the infrastructure into bicep files.
#if SNIPPET
            infrastructure.Build();
#else
            infrastructure.Build(GetOutputPath());
#endif
            #endregion
        }

        [Test]
        public void UsingParameters()
        {
            #region Snippet:KeyVaultOnlyWithParameter
            var infrastructure = new SampleInfrastructure();

            var keyVault = infrastructure.AddKeyVault();

            keyVault.AssignProperty(
                data => data.Properties.EnableSoftDelete,
                new Parameter("enableSoftDelete", defaultValue: true, parameterType: BicepType.Bool, description: "Enable soft delete for the key vault."));

#if SNIPPET
            infrastructure.Build();
#else
            infrastructure.Build(GetOutputPath());
#endif
            #endregion
        }

        [Test]
        public void AddingOutputs()
        {
            #region Snippet:KeyVaultOnlyAddingOutput
            var infrastructure = new SampleInfrastructure();

            var keyVault = infrastructure.AddKeyVault();

            keyVault.AssignProperty(
                data => data.Properties.EnableSoftDelete,
                new Parameter("enableSoftDelete", defaultValue: true, parameterType: BicepType.Bool, description: "Enable soft delete for the key vault."));

            keyVault.AddOutput("VAULT_URI", data => data.Properties.VaultUri);

#if SNIPPET
            infrastructure.Build();
#else
            infrastructure.Build(GetOutputPath());
#endif
            #endregion
        }
    }
}
