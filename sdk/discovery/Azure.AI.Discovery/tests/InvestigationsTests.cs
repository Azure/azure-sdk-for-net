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
    /// Tests for Investigations operations.
    /// Covers all 9 methods: Get, GetOperationStatus, CreateOrReplace, CreateOrUpdate,
    /// Delete (LRO), GetAll (Paged), GetDiscoveryEngine, GetDiscoveryEngineMemory, UpdateDiscoveryEngine.
    /// </summary>
    public class InvestigationsTests : WorkspaceClientTestBase
    {
        public InvestigationsTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListInvestigations()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;

            // Act
            var result = await investigationsClient.GetAllAsync(projectName);
            var investigations = result.Value;

            // Assert
            Assert.That(investigations, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetInvestigation()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Act
            var investigation = await investigationsClient.GetAsync(projectName, investigationName);

            // Assert
            ValidateResponse(investigation.Value, "DiscoveryInvestigation");
            Assert.That(investigation.Value.Name, Is.EqualTo(investigationName));
        }

        [RecordedTest]
        public async Task GetInvestigationOperationStatus()
        {
            // Arrange - start a delete LRO to get an operation ID
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = "test-op-status";

            // Create a sacrificial investigation
            var resource = new DiscoveryInvestigation { Description = TestConstants.InvestigationDescription, DisplayName = TestConstants.InvestigationDisplayName };
            await investigationsClient.CreateOrReplaceAsync(projectName, investigationName, resource);

            // Use protocol method to get raw 202 response with Operation-Location header
            // ProtocolOperation.Id throws NotSupportedException, so we parse the header directly
            var deleteOp = await investigationsClient.DeleteAsync(
                WaitUntil.Started,
                projectName,
                investigationName,
                new RequestContext());

            // Get initial response and parse Operation-Location header for operation ID
            var rawResponse = deleteOp.GetRawResponse();
            rawResponse.Headers.TryGetValue("Operation-Location", out string operationLocation);
            // Format: .../operations/{operationId}?api-version=...
            int opsIndex = operationLocation.IndexOf("/operations/") + "/operations/".Length;
            int queryIndex = operationLocation.IndexOf('?', opsIndex);
            string operationId = queryIndex >= 0
                ? operationLocation.Substring(opsIndex, queryIndex - opsIndex)
                : operationLocation.Substring(opsIndex);

            // Wait for delete to complete
            await deleteOp.WaitForCompletionResponseAsync();

            // Act
            var status = await investigationsClient.GetOperationStatusAsync(
                projectName, investigationName, operationId);

            // Assert
            Assert.That(status.Value, Is.Not.Null);
            Assert.That(status.Value.Status, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CreateOrReplaceInvestigation()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestConstants.CreateInvestigationName;
            var resource = new DiscoveryInvestigation { Description = TestConstants.InvestigationDescription, DisplayName = TestConstants.InvestigationDisplayName };

            // Act
            var investigation = await investigationsClient.CreateOrReplaceAsync(
                projectName, investigationName, resource);

            // Assert
            ValidateResponse(investigation.Value, "DiscoveryInvestigation");
            Assert.That(investigation.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CreateOrUpdateInvestigation()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Act - PATCH via RequestContent
            var content = RequestContent.Create(new { description = TestConstants.UpdatedDescription });
            var response = await investigationsClient.CreateOrUpdateAsync(
                projectName, investigationName, content);

            // Assert
            Assert.That(response.Status, Is.EqualTo(200).Or.EqualTo(201));
        }

        [RecordedTest]
        public async Task DeleteInvestigation()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestConstants.DeleteInvestigationName;

            // First create an investigation to delete
            var resource = new DiscoveryInvestigation { Description = TestConstants.InvestigationDescription, DisplayName = TestConstants.InvestigationDisplayName };
            await investigationsClient.CreateOrReplaceAsync(projectName, investigationName, resource);

            // Act
            var operation = await investigationsClient.DeleteAsync(
                WaitUntil.Completed,
                projectName,
                investigationName);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }

        [RecordedTest]
        public async Task GetDiscoveryEngine()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Act
            var engine = await investigationsClient.GetDiscoveryEngineAsync(
                projectName, investigationName);

            // Assert
            ValidateResponse(engine.Value, "DiscoveryEngine");
            Assert.That(engine.Value.DiscoveryEngineStatus, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetDiscoveryEngineMemory()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Act
            var memory = await investigationsClient.GetDiscoveryEngineMemoryAsync(
                projectName, investigationName);

            // Assert
            ValidateResponse(memory.Value, "PagedWorkingMemoryEntry");
        }

        [RecordedTest]
        public async Task UpdateDiscoveryEngine()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Act - creates the engine if it doesn't exist
            var content = RequestContent.Create(new { status = "Active" });
            var response = await investigationsClient.UpdateDiscoveryEngineAsync(
                projectName, investigationName, content);

            // Assert
            Assert.That(response.Status, Is.EqualTo(200));
        }

        [RecordedTest]
        public async Task StartDiscoveryEngine()
        {
            // Arrange — the discovery engine requires at least one task in the
            // investigation before it can be started, so create one inline.
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            var createBody = new
            {
                title = "Task for engine start test",
                description = "Temporary task created to satisfy StartDiscoveryEngine prerequisite"
            };
            var createResponse = await tasksClient.CreateAsync(
                projectName, investigationName,
                RequestContent.Create(createBody),
                new RequestContext { ErrorOptions = ErrorOptions.NoThrow });
            Assert.That(createResponse.Status, Is.EqualTo(200).Or.EqualTo(201));

            using var doc = JsonDocument.Parse(createResponse.Content);
            string taskName = doc.RootElement.GetProperty("name").GetString();

            // Act
            var response = await investigationsClient.StartDiscoveryEngineAsync(
                projectName, investigationName);

            // Cleanup
            await tasksClient.DeleteAsync(projectName, investigationName, taskName);

            // Assert
            Assert.That(response.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task StopDiscoveryEngine()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var investigationsClient = client.GetDiscoveryInvestigationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Act
            var response = await investigationsClient.StopDiscoveryEngineAsync(
                projectName, investigationName);

            // Assert
            Assert.That(response.Value, Is.Not.Null);
        }
    }
}
