// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET8_0_OR_GREATER
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.IdentityBinding
{
    [LiveOnly(Reason = "Requires an AKS pod configured for identity binding.")]
    [NonParallelizable]
    public class WorkloadIdentityBindingLiveTests
    {
        [OneTimeSetUp]
        public void RequireIdentityBindingEnvironment()
        {
            if (!string.Equals(Environment.GetEnvironmentVariable("AZURE_CORE_IDENTITY_BINDING_TESTS"), "true", StringComparison.OrdinalIgnoreCase))
            {
                Assert.Ignore("Run with AZURE_CORE_IDENTITY_BINDING_TESTS=true using tests\\IdentityBinding\\Run-WorkloadIdentityBindingTests.ps1.");
            }
        }

        [Test]
        public async Task AuthenticateWithProxy()
        {
            await RunScenarioAsync("enabled").ConfigureAwait(false);
        }

        [Test]
        public async Task AuthenticateWithoutProxy()
        {
            await RunScenarioAsync("disabled").ConfigureAwait(false);
        }

        private static async Task RunScenarioAsync(string mode)
        {
            int result = await WorkloadIdentityBindingScenarioRunner.RunAsync(new[] { mode }).ConfigureAwait(false);
            Assert.That(result, Is.Zero, "See the redacted scenario results for the authentication failure.");
            TestContext.Out.WriteLine(JsonSerializer.Serialize(new
            {
                scenario = "nunit",
                passed = true,
                details = new
                {
                    assembly = typeof(WorkloadIdentityBindingLiveTests).Assembly.GetName().Name,
                    test = TestContext.CurrentContext.Test.FullName
                }
            }));
        }
    }
}
#endif
