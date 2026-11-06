// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.Tests.Shared;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    [NonParallelizable]
    public class TestEnvironmentCredentialTests
    {
        private static readonly string[] VariableNames =
        {
            "TF_BUILD",
            "AZURE_TENANT_ID",
            "AZURESUBSCRIPTION_TENANT_ID",
            "AZURESUBSCRIPTION_CLIENT_ID",
            "AZURESUBSCRIPTION_SERVICE_CONNECTION_ID",
            "SYSTEM_ACCESSTOKEN",
            "SYSTEM_OIDCREQUESTURI"
        };

        private readonly Dictionary<string, string> _originalValues = new();

        [SetUp]
        public void SetUp()
        {
            foreach (string name in VariableNames)
            {
                _originalValues[name] = Environment.GetEnvironmentVariable(name);
                Environment.SetEnvironmentVariable(name, null);
            }
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var entry in _originalValues)
            {
                Environment.SetEnvironmentVariable(entry.Key, entry.Value);
            }
            _originalValues.Clear();
        }

        [TestCase(null)]
        [TestCase("11111111-1111-1111-1111-111111111111")]
        public void LocalAuthenticationUsesDefaultAzureCredential(string tenantId)
        {
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", tenantId);
            Assert.That(AiTestEnvironmentBootstrap.CreateCredential(), Is.InstanceOf<DefaultAzureCredential>());
        }

        [Test]
        public void PipelineAuthenticationUsesOnlyTheServiceConnection()
        {
            SetPipelineVariables();
            Assert.That(AiTestEnvironmentBootstrap.CreateCredential(), Is.InstanceOf<AzurePipelinesCredential>());
        }

        [TestCase("AZURESUBSCRIPTION_TENANT_ID")]
        [TestCase("AZURESUBSCRIPTION_CLIENT_ID")]
        [TestCase("AZURESUBSCRIPTION_SERVICE_CONNECTION_ID")]
        [TestCase("SYSTEM_ACCESSTOKEN")]
        public void MissingPipelineMetadataDoesNotFallBackToAnotherIdentity(string name)
        {
            SetPipelineVariables();
            Environment.SetEnvironmentVariable(name, null);
            var exception = Assert.Throws<InvalidOperationException>(() => AiTestEnvironmentBootstrap.CreateCredential());
            Assert.That(exception.Message, Does.Contain(name));
        }

        [Test]
        public void PipelineTenantMustMatchTheProvisionedTarget()
        {
            SetPipelineVariables();
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "44444444-4444-4444-4444-444444444444");
            var exception = Assert.Throws<InvalidOperationException>(() => AiTestEnvironmentBootstrap.CreateCredential());
            Assert.That(exception.Message, Does.Contain("does not match AZURE_TENANT_ID"));
        }

        private static void SetPipelineVariables()
        {
            Environment.SetEnvironmentVariable("TF_BUILD", "true");
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "11111111-1111-1111-1111-111111111111");
            Environment.SetEnvironmentVariable("AZURESUBSCRIPTION_TENANT_ID", "11111111-1111-1111-1111-111111111111");
            Environment.SetEnvironmentVariable("AZURESUBSCRIPTION_CLIENT_ID", "22222222-2222-2222-2222-222222222222");
            Environment.SetEnvironmentVariable("AZURESUBSCRIPTION_SERVICE_CONNECTION_ID", "33333333-3333-3333-3333-333333333333");
            Environment.SetEnvironmentVariable("SYSTEM_ACCESSTOKEN", "unit-test-placeholder");
            Environment.SetEnvironmentVariable("SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/example/_apis/distributedtask/hubs/build/plans/example/jobs/example/oidctoken");
        }
    }
}
