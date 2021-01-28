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
            var rawClient = new QuantumJobClient(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroup, TestEnvironment.WorkspaceName, TestEnvironment.Location, TestEnvironment.Credential, InstrumentClientOptions(new QuantumJobClientOptions()));

            return InstrumentClient(rawClient);
        }

        [RecordedTest]
        public async Task GetJobsTest()
        {
            var client = CreateClient();

            int index = 0;
            await foreach (JobDetails job in client.GetJobsAsync(CancellationToken.None))
            {
                if (Mode == RecordedTestMode.Playback)
                {
                    Assert.AreEqual("Sanitized", job.ContainerUri);
                    Assert.AreEqual("Sanitized", job.InputDataUri);
                    Assert.AreEqual("Sanitized", job.OutputDataUri);
                }
                else
                {
                    Assert.IsNotEmpty(job.ContainerUri);
                    Assert.IsNotEmpty(job.InputDataUri);
                    Assert.IsNotEmpty(job.OutputDataUri);
                }

                Assert.AreEqual(null, job.CancellationTime);
                Assert.AreEqual(null, job.ErrorData);
                Assert.IsNotEmpty(job.Id);
                Assert.IsNotEmpty(job.InputDataFormat);
                Assert.IsNotEmpty(job.Name);
                Assert.IsNotEmpty(job.OutputDataFormat);
                Assert.IsNotEmpty(job.ProviderId);
                Assert.IsNotNull(job.Status);
                Assert.IsNotEmpty(job.Target);
                ++index;
            }

            // Should have at least a couple jobs in the list.
            Assert.GreaterOrEqual(index, 2);
        }

        [Ignore("Only verifying that the sample builds")]
        public void GetJobsSample()
        {
            #region Snippet:Azure_Quantum_Jobs_GetJobs
            var client = new QuantumJobClient("subscriptionId", "resourceGroupName", "workspaceName", "location");
            var jobs = client.GetJobs();
            #endregion
        }
    }
}
