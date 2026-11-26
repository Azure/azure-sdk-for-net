// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.Lro.Result;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.Lro.Result
{
    public class LroResultTests : SpectorTestBase
    {
        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task CreateDefault(bool async) => Test(async (host) =>
        {
            var client = new ResultClient(host, null);
            var job = new Job(JobStatus.Running);
            Operation<Job> operation = async
                ? await client.CreateDefaultAsync(WaitUntil.Completed, "default", job)
                : client.CreateDefault(WaitUntil.Completed, "default", job);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual("default", operation.Value.Id);
            Assert.AreEqual(JobStatus.Succeeded, operation.Value.Status);
            Assert.AreEqual("completed", operation.Value.Result?.Value);
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task CreateWithClientLroResult(bool async) => Test(async (host) =>
        {
            var client = new ResultClient(host, null);
            var job = new Job(JobStatus.Running);
            Operation<JobResult> operation = async
                ? await client.CreateWithClientLroResultAsync(WaitUntil.Completed, "client-result", job)
                : client.CreateWithClientLroResult(WaitUntil.Completed, "client-result", job);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual("completed", operation.Value.Value);
        });
    }
}
