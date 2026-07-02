// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Unit tests for Azure.AI.Discovery Workspace models.
    /// These tests verify model initialization without making HTTP calls.
    /// </summary>
    public class WorkspaceModelsUnitTests
    {
        [Test]
        public void DiscoveryTag_CanBeInitialized()
        {
            // Arrange & Act - DiscoveryTag has parameterless constructor with settable properties
            var tag = new DiscoveryTag
            {
                Key = "environment",
                Value = "production"
            };

            // Assert
            Assert.That(tag, Is.Not.Null);
            Assert.That(tag.Key, Is.EqualTo("environment"));
            Assert.That(tag.Value, Is.EqualTo("production"));
        }

        [Test]
        public void DiscoveryTask_CanBeInitialized()
        {
            // Arrange & Act - DiscoveryTask has parameterless constructor with settable properties
            var task = new DiscoveryTask
            {
                Title = "Test task title",
                InvestigationId = "investigation-123"
            };

            // Assert
            Assert.That(task, Is.Not.Null);
            Assert.That(task.Title, Is.EqualTo("Test task title"));
            Assert.That(task.InvestigationId, Is.EqualTo("investigation-123"));
        }

        [Test]
        public void DiscoveryTask_WithOptionalParameters()
        {
            // Arrange & Act
            var task = new DiscoveryTask
            {
                Title = "Test task title",
                InvestigationId = "investigation-123",
                Description = "Test description",
                Priority = TaskPriority.Low
            };

            // Assert
            Assert.That(task.Title, Is.EqualTo("Test task title"));
            Assert.That(task.Description, Is.EqualTo("Test description"));
            Assert.That(task.Priority, Is.EqualTo(TaskPriority.Low));
        }

        [Test]
        public void StartTaskRequest_CanBeInitialized()
        {
            // Arrange & Act
            var request = new StartTaskRequest();

            // Assert
            Assert.That(request, Is.Not.Null);
        }

        [Test]
        public void InfraOverrides_CanBeInitialized()
        {
            // Arrange & Act
            var overrides = new InfraOverrides();

            // Assert
            Assert.That(overrides, Is.Not.Null);
        }

        [Test]
        public void TaskComment_CanBeInitialized()
        {
            // Arrange & Act - TaskComment requires createdAt, createdBy, createdByType, and text
            var comment = new TaskComment(
                createdBy: "user-123",
                createdByType: ByType.User,
                text: "This is a comment");

            // Assert
            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Text, Is.EqualTo("This is a comment"));
            Assert.That(comment.CreatedBy, Is.EqualTo("user-123"));
        }

        [Test]
        public void TaskAssignee_CanBeInitialized()
        {
            // Arrange & Act - TaskAssignee requires id and type
            var assignee = new TaskAssignee("user-123", ByType.User);

            // Assert
            Assert.That(assignee, Is.Not.Null);
            Assert.That(assignee.Id, Is.EqualTo("user-123"));
            Assert.That(assignee.Type, Is.EqualTo(ByType.User));
        }

        [Test]
        public void OperationState_EnumValuesExist()
        {
            // Assert - verify enum values can be accessed
            Assert.That(OperationState.NotStarted.ToString(), Is.EqualTo("NotStarted"));
            Assert.That(OperationState.Running.ToString(), Is.EqualTo("Running"));
            Assert.That(OperationState.Succeeded.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(OperationState.Failed.ToString(), Is.EqualTo("Failed"));
            Assert.That(OperationState.Canceled.ToString(), Is.EqualTo("Canceled"));
        }

        [Test]
        public void TaskStatus_EnumValuesExist()
        {
            // Assert - verify enum values can be accessed (actual values: New, OnHold, Complete, etc.)
            Assert.That(TaskStatus.New.ToString(), Is.EqualTo("New"));
            Assert.That(TaskStatus.OnHold.ToString(), Is.EqualTo("OnHold"));
            Assert.That(TaskStatus.Complete.ToString(), Is.EqualTo("Complete"));
        }

        [Test]
        public void InvestigationStatus_EnumValuesExist()
        {
            // Assert - verify enum values can be accessed (actual values: Created, Validated, Failed)
            Assert.That(InvestigationStatus.Created.ToString(), Is.EqualTo("Created"));
            Assert.That(InvestigationStatus.Validated.ToString(), Is.EqualTo("Validated"));
            Assert.That(InvestigationStatus.Failed.ToString(), Is.EqualTo("Failed"));
        }

        [Test]
        public void RunStatus_EnumValuesExist()
        {
            // Assert - verify enum values can be accessed
            Assert.That(RunStatus.Running.ToString(), Is.EqualTo("Running"));
            Assert.That(RunStatus.Succeeded.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(RunStatus.Failed.ToString(), Is.EqualTo("Failed"));
        }

        [Test]
        public void DiscoveryEngineStatus_EnumValuesExist()
        {
            // Assert - verify enum values can be accessed (actual values: Inactive, Active)
            Assert.That(DiscoveryEngineStatus.Inactive.ToString(), Is.EqualTo("Inactive"));
            Assert.That(DiscoveryEngineStatus.Active.ToString(), Is.EqualTo("Active"));
        }

        [Test]
        public void ByType_EnumValuesExist()
        {
            // Assert - verify ByType enum values
            Assert.That(ByType.User.ToString(), Is.Not.Null);
            Assert.That(ByType.Application.ToString(), Is.Not.Null);
            Assert.That(ByType.System.ToString(), Is.Not.Null);
        }

        [Test]
        public void DiscoveryModelFactory_CanCreateDiscoveryInvestigation()
        {
            // Arrange & Act
            var investigation = DiscoveryModelFactory.DiscoveryInvestigation(
                name: "test-investigation");

            // Assert
            Assert.That(investigation, Is.Not.Null);
            Assert.That(investigation.Name, Is.EqualTo("test-investigation"));
        }

        [Test]
        public void DiscoveryModelFactory_CanCreateDiscoveryTag()
        {
            // Arrange & Act
            var tag = DiscoveryModelFactory.DiscoveryTag(
                key: "environment",
                value: "production");

            // Assert
            Assert.That(tag, Is.Not.Null);
            Assert.That(tag.Key, Is.EqualTo("environment"));
            Assert.That(tag.Value, Is.EqualTo("production"));
        }

        [Test]
        public void WorkspaceClient_CanGetSubClients()
        {
            // This test verifies the client factory methods exist
            // Actual client creation requires credentials and endpoint

            // Assert - verify the method signatures exist by checking the type
            var clientType = typeof(WorkspaceClient);
            var investigationsMethod = clientType.GetMethod("GetDiscoveryInvestigationsClient");
            var conversationsMethod = clientType.GetMethod("GetDiscoveryConversationsClient");
            var tasksMethod = clientType.GetMethod("GetDiscoveryTasksClient");
            var toolsMethod = clientType.GetMethod("GetDiscoveryToolsClient");

            Assert.That(investigationsMethod, Is.Not.Null, "GetDiscoveryInvestigationsClient method should exist");
            Assert.That(conversationsMethod, Is.Not.Null, "GetDiscoveryConversationsClient method should exist");
            Assert.That(tasksMethod, Is.Not.Null, "GetDiscoveryTasksClient method should exist");
            Assert.That(toolsMethod, Is.Not.Null, "GetDiscoveryToolsClient method should exist");
        }
    }
}
