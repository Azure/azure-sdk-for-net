// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Tests for Tools operations.
    /// Covers: Run (LRO), GetRunStatus, GetRunStatus with logCount, CancelRun,
    /// GetOperations, GetComputeUsage.
    ///
    /// Tests that need an operation ID start a fresh tool run rather than using
    /// a hardcoded stale ID, mirroring the Python refactored tests.
    /// </summary>
    public class ToolsTests : WorkspaceClientTestBase
    {
        public ToolsTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Helper: start a tool run and return the operation ID parsed from
        /// the initial response.
        /// </summary>
        private async Task<string> StartRunAsync(
            DiscoveryToolsClient toolsClient,
            string projectName,
            string command,
            WaitUntil waitUntil = WaitUntil.Started)
        {
            var content = RequestContent.Create(new
            {
                toolId = TestEnvironment.ToolId,
                nodePoolIds = new[] { TestEnvironment.ToolNodePoolId },
                command,
            });
            var operation = await toolsClient.RunAsync(waitUntil, projectName, content);

            using var doc = JsonDocument.Parse(operation.GetRawResponse().Content);
            return doc.RootElement.GetProperty("id").GetString();
        }

        [RecordedTest]
        public async Task RunTool()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var toolsClient = client.GetDiscoveryToolsClient();
            string projectName = TestEnvironment.ProjectName;

            // Act
            var operationId = await StartRunAsync(
                toolsClient, projectName, "echo \"hello world\"");

            // Assert — the run was accepted
            Assert.That(operationId, Is.Not.Null.And.Not.Empty);
        }

        [RecordedTest]
        public async Task GetRunStatus()
        {
            // Arrange — start a run and wait for completion so status is final
            WorkspaceClient client = CreateWorkspaceClient();
            var toolsClient = client.GetDiscoveryToolsClient();
            string projectName = TestEnvironment.ProjectName;

            var operationId = await StartRunAsync(
                toolsClient, projectName, "echo \"status test\"",
                WaitUntil.Completed);

            // Act
            var status = await toolsClient.GetRunStatusAsync(projectName, operationId);

            // Assert
            ValidateResponse(status.Value, "OperationStatusRunResultError");
        }

        [RecordedTest]
        public async Task GetRunStatusWithLogCount()
        {
            // Arrange — start a run and wait for completion
            WorkspaceClient client = CreateWorkspaceClient();
            var toolsClient = client.GetDiscoveryToolsClient();
            string projectName = TestEnvironment.ProjectName;

            var operationId = await StartRunAsync(
                toolsClient, projectName, "echo \"log count test\"",
                WaitUntil.Completed);

            // Act
            var status = await toolsClient.GetRunStatusAsync(projectName, operationId, logCount: 10);

            // Assert
            ValidateResponse(status.Value, "OperationStatusRunResultError");
        }

        [RecordedTest]
        public async Task CancelRun()
        {
            // Arrange — start a long-running tool run, then cancel it
            WorkspaceClient client = CreateWorkspaceClient();
            var toolsClient = client.GetDiscoveryToolsClient();
            string projectName = TestEnvironment.ProjectName;

            var operationId = await StartRunAsync(
                toolsClient, projectName, "echo \"cancel test\" && sleep 300");

            // Act — cancel the run
            await toolsClient.CancelRunAsync(projectName, operationId);
        }

        [RecordedTest]
        public async Task GetOperations()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var toolsClient = client.GetDiscoveryToolsClient();
            string projectName = TestEnvironment.ProjectName;

            // Act
            var operations = await toolsClient.GetOperationsAsync(projectName);

            // Assert
            ValidateResponse(operations.Value, "PagedOperation");
        }

        [RecordedTest]
        public async Task GetComputeUsage()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var toolsClient = client.GetDiscoveryToolsClient();
            string projectName = TestEnvironment.ProjectName;

            // Act
            var usage = await toolsClient.GetComputeUsageAsync(projectName);

            // Assert
            ValidateResponse(usage.Value, "ComputeUsage");
        }
    }
}