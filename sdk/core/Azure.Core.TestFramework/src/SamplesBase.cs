// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    [NonParallelizable]
    [LiveOnly]
    public abstract class SamplesBase<TEnvironment>: LiveTestBase<TEnvironment> where TEnvironment : TestEnvironment, new()
    {
        private string _previousClientId;
        private string _previousClientSecret;
        private string _previousClientTenantId;

        // Initialize the environment so new DefaultAzureCredential() works
        [OneTimeSetUp]
        public virtual void SetupDefaultAzureCredential()
        {
            _previousClientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            _previousClientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");
            _previousClientTenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");

            Console.WriteLine($"** Relevant vars: {string.Join("|", TestEnvironment.ClientId, TestEnvironment.ClientSecret, TestEnvironment.TenantId)}");

            Console.WriteLine($"TestEnvironment.ClientId is {TestEnvironment.ClientId} of length {TestEnvironment.ClientId.Length}");
            Console.WriteLine($"TestEnvironment.ClientSecret is {TestEnvironment.ClientSecret} of length {TestEnvironment.ClientSecret.Length}");
            Console.WriteLine($"TestEnvironment.TenantId is {TestEnvironment.TenantId} of length {TestEnvironment.TenantId.Length}");

            Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", TestEnvironment.ClientId);
            Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", TestEnvironment.ClientSecret);
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", TestEnvironment.TenantId);
        }

        [OneTimeTearDown]
        public virtual void TearDownDefaultAzureCredential()
        {
            Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", _previousClientId);
            Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", _previousClientSecret);
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", _previousClientTenantId);
        }
    }
}
