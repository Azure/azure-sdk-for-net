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
            Sanitizer = new QuantumJobClientRecordedTestSanitizer();

            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private QuantumJobClient CreateClient()
        {
            var rawClient = new QuantumJobClient(TestEnvironment.SubscriptionId, "sdk-review-rg", "workspace-ms", "westus", TestEnvironment.Credential, InstrumentClientOptions(new QuantumJobClientOptions()));

            return InstrumentClient(rawClient);
        }

        [RecordedTest]
        public async Task CanGetList()
        {
            var client = CreateClient();

            int index = 0;
            await foreach (JobDetails job in client.GetJobsAsync(CancellationToken.None))
            {
                if (index == 0)
                {
                    Assert.AreEqual(null, job.CancellationTime);
                    Assert.AreEqual("Sanitized", job.ContainerUri);
                    Assert.AreEqual(null, job.ErrorData);
                    Assert.AreEqual("1be7199c-5d16-11eb-8f86-3e22fb0c562e", job.Id);
                    Assert.AreEqual("microsoft.qio.v2", job.InputDataFormat);
                    Assert.AreEqual("Sanitized", job.InputDataUri);
                    Assert.AreEqual("first-demo", job.Name);
                    Assert.AreEqual("microsoft.qio-results.v2", job.OutputDataFormat);
                    Assert.AreEqual("Sanitized", job.OutputDataUri);
                    Assert.AreEqual("microsoft", job.ProviderId);
                    Assert.AreEqual(JobStatus.Succeeded, job.Status);
                    Assert.AreEqual("microsoft.paralleltempering-parameterfree.cpu", job.Target);
                }
                else if (index == 1)
                {
                    Assert.AreEqual(null, job.CancellationTime);
                    Assert.AreEqual("Sanitized", job.ContainerUri);
                    Assert.AreEqual(null, job.ErrorData);
                    Assert.AreEqual("a962c244-5d16-11eb-9803-3e22fb0c562e", job.Id);
                    Assert.AreEqual("microsoft.qio.v2", job.InputDataFormat);
                    Assert.AreEqual("Sanitized", job.InputDataUri);
                    Assert.AreEqual("first-demo", job.Name);
                    Assert.AreEqual("microsoft.qio-results.v2", job.OutputDataFormat);
                    Assert.AreEqual("Sanitized", job.OutputDataUri);
                    Assert.AreEqual("microsoft", job.ProviderId);
                    Assert.AreEqual(JobStatus.Succeeded, job.Status);
                    Assert.AreEqual("microsoft.paralleltempering-parameterfree.cpu", job.Target);
                }

                ++index;
            }

            // Should have at least a couple jobs in the list.
            Assert.GreaterOrEqual(index, 2);
        }
    }
}
