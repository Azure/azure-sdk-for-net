// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity
{
    [NonParallelizable]
    public class ManagedIdentityCredentialEnvironmentTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public void AdditionalVariablesAreAppliedAndRestored(bool clearClientId)
        {
            var baseline = new Dictionary<string, string>
            {
                { "IDENTITY_ENDPOINT", "http://original-endpoint" },
                { "AZURE_TOKEN_CREDENTIALS", "EnvironmentCredential" },
                { "AZURE_CLIENT_ID", "original-client-id" }
            };
            var original = baseline.Keys.ToDictionary(name => name, Environment.GetEnvironmentVariable);
            try
            {
                // Establish the baseline without holding TestEnvVar's non-reentrant lock.
                foreach (var variable in baseline)
                {
                    Environment.SetEnvironmentVariable(variable.Key, variable.Value);
                }
                var fixture = new EnvironmentTestFixture();
                string imdsEndpoint = fixture.TestEnvironment.ImdsEndpoint;
                var additionalVariables = new Dictionary<string, string>
                {
                    { "IDENTITY_ENDPOINT", "http://overridden-endpoint" },
                    { "AZURE_TOKEN_CREDENTIALS", "ManagedIdentityCredential" }
                };
                if (clearClientId)
                {
                    additionalVariables["AZURE_CLIENT_ID"] = null;
                }

                using (fixture.CreateEnvironment(additionalVariables))
                {
                    Assert.AreEqual("http://overridden-endpoint", Environment.GetEnvironmentVariable("IDENTITY_ENDPOINT"));
                    Assert.AreEqual(imdsEndpoint, Environment.GetEnvironmentVariable("IMDS_ENDPOINT"));
                    Assert.AreEqual("ManagedIdentityCredential", Environment.GetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS"));
                    Assert.AreEqual(clearClientId ? null : "original-client-id", Environment.GetEnvironmentVariable("AZURE_CLIENT_ID"));
                }

                foreach (var variable in baseline)
                {
                    Assert.AreEqual(variable.Value, Environment.GetEnvironmentVariable(variable.Key));
                }
                using (fixture.CreateEnvironment())
                {
                    Assert.AreEqual(fixture.TestEnvironment.IdentityEndpoint, Environment.GetEnvironmentVariable("IDENTITY_ENDPOINT"));
                    Assert.AreEqual("EnvironmentCredential", Environment.GetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS"));
                }
            }
            finally
            {
                foreach (var variable in original)
                {
                    Environment.SetEnvironmentVariable(variable.Key, variable.Value);
                }
            }
        }

        private class EnvironmentTestFixture : ManagedIdentityCredentialLiveTestBase
        {
            public EnvironmentTestFixture() : base(false, RecordedTestMode.Live)
            {
            }

            public IDisposable CreateEnvironment(Dictionary<string, string> additionalVariables = null)
                => ReadOrRestoreManagedIdentityEnvironment(additionalVariables);
        }
    }
}
