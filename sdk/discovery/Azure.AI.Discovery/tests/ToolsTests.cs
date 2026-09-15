// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Tests for tool operations on <see cref="DiscoveryToolsClient"/>
    /// (run, get run status, cancel run, get operations, get compute usage).
    /// Ported from the Python <c>test_tools.py</c> suite. The run/cancel tests are
    /// long-running operations that consume compute and require a valid
    /// <c>TOOL_ID</c> and <c>NODE_POOL_ID</c> to be configured.
    /// </summary>
    public class ToolsTests : DiscoveryTestBase
    {
        public ToolsTests(bool isAsync) : base(isAsync)
        {
        }

        private string Project => TestEnvironment.ProjectName;
        private ResourceIdentifier ToolId => new ResourceIdentifier(TestEnvironment.ToolId);
        private ResourceIdentifier[] NodePoolIds => new[] { new ResourceIdentifier(TestEnvironment.NodePoolId) };

        private async Task<Operation<RunResult>> BeginRunAsync(DiscoveryToolsClient client, string command, Azure.WaitUntil waitUntil)
            => await client.RunAsync(waitUntil, Project, ToolId, NodePoolIds, command);

        [RecordedTest]
        [Order(1)]
        public async Task BeginRun()
        {
            DiscoveryToolsClient client = CreateToolsClient();
            Operation<RunResult> operation = await BeginRunAsync(client, "echo \"hello world\"", Azure.WaitUntil.Completed);

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value, Is.Not.Null);
        }

        [RecordedTest]
        [Order(2)]
        public async Task GetRunStatus()
        {
            DiscoveryToolsClient client = CreateToolsClient();
            Operation<RunResult> operation = await BeginRunAsync(client, "echo \"status test\"", Azure.WaitUntil.Started);
            string operationId = ExtractOperationId(operation.GetRawResponse());
            Assert.That(operationId, Is.Not.Empty);
            await operation.WaitForCompletionAsync();

            RunOperationStatus status = await client.GetRunStatusAsync(Project, operationId);

            Assert.That(status, Is.Not.Null);
            Assert.That(status.Status.ToString(), Is.Not.Empty);
        }

        [RecordedTest]
        [Order(3)]
        public async Task GetRunStatusWithLogCount()
        {
            DiscoveryToolsClient client = CreateToolsClient();
            Operation<RunResult> operation = await BeginRunAsync(client, "echo \"log count test\"", Azure.WaitUntil.Started);
            string operationId = ExtractOperationId(operation.GetRawResponse());
            await operation.WaitForCompletionAsync();

            RunOperationStatus status = await client.GetRunStatusAsync(Project, operationId, logCount: 10);

            Assert.That(status, Is.Not.Null);
            Assert.That(status.Status.ToString(), Is.Not.Empty);
        }

        [RecordedTest]
        [Order(4)]
        public async Task BeginCancelRunLro()
        {
            DiscoveryToolsClient client = CreateToolsClient();

            // Start a long-running command so there is time to cancel it.
            Operation<RunResult> operation = await BeginRunAsync(client, "echo \"cancel test\" && sleep 300", Azure.WaitUntil.Started);
            string operationId = ExtractOperationId(operation.GetRawResponse());

            Operation<RunResult> cancelOperation = await client.CancelRunLroAsync(Azure.WaitUntil.Started, Project, operationId);

            // A cancelled run reaches a terminal "Canceled" state, which the LRO machinery
            // surfaces as a failure; for a cancel operation that is the success path.
            try
            {
                await cancelOperation.WaitForCompletionAsync();
            }
            catch (Azure.RequestFailedException)
            {
                // Expected when the terminal status is Canceled.
            }

            Assert.That(cancelOperation.HasCompleted, Is.True);
        }

        [RecordedTest]
        [Order(5)]
        public async Task GetOperations()
        {
            DiscoveryToolsClient client = CreateToolsClient();
            PagedOperation operations = await client.GetOperationsAsync(Project);

            Assert.That(operations, Is.Not.Null);
            Assert.That(operations.Value, Is.Not.Null);
        }

        [RecordedTest]
        [Order(6)]
        public async Task GetComputeUsage()
        {
            DiscoveryToolsClient client = CreateToolsClient();
            ComputeUsage usage = await client.GetComputeUsageAsync(Project);

            Assert.That(usage, Is.Not.Null);
        }
    }
}
