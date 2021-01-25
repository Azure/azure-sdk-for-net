// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobsClientLiveTests: RecordedTestBase<QuantumJobsClientTestEnvironment>
    {
        public QuantumJobsClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private QuantumJobsClient CreateClient()
        {
            var rawClient = new QuantumJobsClient(SubscriptionId.value, "sdk-review-rg", "workspace-ms", "westus", default, InstrumentClientOptions(new QuantumJobsClientOptions()));

            return InstrumentClient(rawClient);
        }

        // Create SubscriptionId.cs like so and put in your id:
        // namespace Azure.Quantum.Jobs.Tests
        // {
        //     internal class SubscriptionId
        //     {
        //         public string value = "<yourid>";
        //     }
        // }

        [RecordedTest]
        public async Task CanGetList()
        {
            var client = CreateClient();
            var jobs = client.Jobs.ListAsync(CancellationToken.None).Result;
            var list = await client.ListAsync();

            //Assert.AreEqual(list);
        }
    }
}
