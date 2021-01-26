// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Quantum.Jobs.Models;
using NUnit.Framework;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobClientLiveTests: RecordedTestBase<QuantumJobClientTestEnvironment>
    {
        public QuantumJobClientLiveTests(bool isAsync) : base(isAsync)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private QuantumJobClient CreateClient()
        {
            var rawClient = new QuantumJobClient(SubscriptionId.value, "sdk-review-rg", "workspace-ms", "westus", default, InstrumentClientOptions(new QuantumJobClientOptions()));

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

            await foreach (JobDetails job in client.GetJobsAsync(CancellationToken.None))
            {
                // TODO what do we want to verify here?
                // Assert.AreEqual(list);
            }
        }
    }
}
