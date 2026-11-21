// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    [NonParallelizable]
    public class BatchRecordingSetupTests
    {
        [Test]
        public void ExplicitAzureCliCredentialUsesConfiguredTenant()
        {
            const string credentialVariable = "BATCH_USE_AZURE_CLI_CREDENTIAL";
            const string tenantVariable = "BATCH_TENANT_ID";
            string previousCredential = Environment.GetEnvironmentVariable(credentialVariable);
            string previousTenant = Environment.GetEnvironmentVariable(tenantVariable);
            try
            {
                Environment.SetEnvironmentVariable(credentialVariable, "true");
                Environment.SetEnvironmentVariable(tenantVariable, "72f988bf-86f1-41af-91ab-2d7cd011db47");
                var environment = new TestableEnvironment();

                Assert.IsInstanceOf<AzureCliCredential>(environment.CreateCredential());

                Environment.SetEnvironmentVariable(credentialVariable, "invalid");
                Assert.Throws<FormatException>(() => environment.CreateCredential());
            }
            finally
            {
                Environment.SetEnvironmentVariable(credentialVariable, previousCredential);
                Environment.SetEnvironmentVariable(tenantVariable, previousTenant);
            }
        }

        [Test]
        public void RecordingSanitizesCredentialFields()
        {
            var fixture = new BatchLiveTestBase(false, RecordedTestMode.Playback);

            CollectionAssert.IsSubsetOf(new[]
            {
                "$..password", "$..sshPrivateKey", "$..accountKey", "$..protectedSettings"
            }, fixture.JsonPathSanitizers);
        }

        [Test]
        public void OrdinaryWindowsPoolsUseD2V2AndWindows2022()
        {
            var fixture = new WindowsPoolFixture(null, "test-pool", false);

            BatchPoolCreateOptions options = fixture.CreatePoolOptions(1);

            Assert.AreEqual("Standard_D2_v2", options.VmSize);
            Assert.AreEqual(1, options.TargetDedicatedNodes);
            Assert.AreEqual("windowsserver2022", options.VirtualMachineConfiguration.ImageReference.Offer);
            Assert.AreEqual("2022-datacenter-smalldisk", options.VirtualMachineConfiguration.ImageReference.Sku);
            Assert.AreEqual("batch.node.windows amd64", options.VirtualMachineConfiguration.NodeAgentSkuId);
        }

        private class TestableEnvironment : BatchLiveTestEnvironment
        {
            public TokenCredential CreateCredential() => CreateDeveloperCredential();
        }
    }
}
