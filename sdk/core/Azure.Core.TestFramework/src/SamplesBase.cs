// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    [NonParallelizable]
    [LiveOnly]
    public abstract class SamplesBase<TEnvironment> where TEnvironment : TestEnvironment, new()
    {
        private string _previousClientId;
        private string _previousClientSecret;
        private string _previousClientTenantId;

        protected SamplesBase()
        {
            TestEnvironment = new TEnvironment();
        }

        public TEnvironment TestEnvironment { get; }

        // Initialize the environment so new DefaultAzureCredential() works
        [OneTimeSetUp]
        public virtual void SetupDefaultAzureCredential()
        {
            _previousClientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            _previousClientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");
            _previousClientTenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");

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