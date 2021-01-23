// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobsClientLiveTests: RecordedTestBase<QuantumJobsClientTestEnvironment>
    {
        public QuantumJobsClientLiveTests(bool isAsync) : base(isAsync)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private QuantumJobsClient CreateClient()
        {
            return InstrumentClient(new QuantumJobsClient(
                new Uri(TestEnvironment.KeyVaultUri),
                TestEnvironment.Credential,
                InstrumentClientOptions(new QuantumJobsClientOptions())
            ));
        }

        [Test]
        public async Task CanGetSecret()
        {
            var client = CreateClient();

            var secret = await client.GetSecretAsync("TestSecret");

            Assert.AreEqual("Very secret value", secret.Value.Value);
        }
    }
}
