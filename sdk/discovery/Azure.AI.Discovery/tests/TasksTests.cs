// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Tests for Tasks operations.
    /// Covers: Get, GetAll (Paged), GetAll with filter, Create, Update, Delete,
    /// Start, AddComment, AddExecutionHistory.
    ///
    /// Every test that needs a task creates one inline via the protocol method
    /// and captures the server-assigned name. This avoids stale hardcoded task
    /// IDs and ordering dependencies between tests.
    /// </summary>
    public class TasksTests : WorkspaceClientTestBase
    {
        public TasksTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Helper: create a task via the protocol method and return its
        /// server-assigned name. The protocol method is used because the
        /// service returns 201 but the typed method only accepts 200.
        /// </summary>
        private async Task<string> CreateTaskAsync(
            DiscoveryTasksClient tasksClient,
            string projectName,
            string investigationName,
            string title = "sdk-test-task",
            string description = "Test task for C# SDK",
            bool withAssignee = false)
        {
            var body = withAssignee
                ? (object)new
                {
                    title,
                    description,
                    assignedTo = new { id = TestEnvironment.AgentName, type = "Application" }
                }
                : new { title, description };

            var response = await tasksClient.CreateAsync(
                projectName, investigationName,
                RequestContent.Create(body),
                new RequestContext { ErrorOptions = ErrorOptions.NoThrow });
            Assert.That(response.Status, Is.EqualTo(200).Or.EqualTo(201));

            using var doc = JsonDocument.Parse(response.Content);
            return doc.RootElement.GetProperty("name").GetString();
        }

        /// <summary>
        /// Helper: best-effort cleanup — delete a task, ignoring failures so a
        /// mid-test assertion failure doesn't cascade into teardown noise.
        /// </summary>
        private async System.Threading.Tasks.Task DeleteTaskQuietAsync(
            DiscoveryTasksClient tasksClient,
            string projectName,
            string investigationName,
            string taskName)
        {
            try
            {
                await tasksClient.DeleteAsync(projectName, investigationName, taskName);
            }
            catch { }
        }

        [RecordedTest]
        public async Task ListTasks()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Ensure at least one task exists
            string taskName = await CreateTaskAsync(tasksClient, projectName, investigationName,
                title: "task-for-list-test");
            try
            {
                // Act
                var tasks = new List<DiscoveryTask>();
                await foreach (var task in tasksClient.GetAllAsync(projectName, investigationName))
                {
                    tasks.Add(task);
                }

                // Assert
                Assert.That(tasks, Is.Not.Null);
                Assert.That(tasks.Count, Is.GreaterThan(0));
            }
            finally
            {
                await DeleteTaskQuietAsync(tasksClient, projectName, investigationName, taskName);
            }
        }

        [RecordedTest]
        public async Task ListTasksWithFilter()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Ensure at least one 'New' task exists
            string taskName = await CreateTaskAsync(tasksClient, projectName, investigationName,
                title: "task-for-filter-test");
            try
            {
                // Act
                var tasks = new List<DiscoveryTask>();
                await foreach (var task in tasksClient.GetAllAsync(projectName, investigationName,
                    filter: "status eq 'New'"))
                {
                    tasks.Add(task);
                }

                // Assert
                Assert.That(tasks, Is.Not.Null);
            }
            finally
            {
                await DeleteTaskQuietAsync(tasksClient, projectName, investigationName, taskName);
            }
        }

        [RecordedTest]
        public async Task GetTask()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string taskName = await CreateTaskAsync(tasksClient, projectName, investigationName,
                title: "task-for-get-test");
            try
            {
                // Act
                var task = await tasksClient.GetAsync(projectName, investigationName, taskName);

                // Assert
                ValidateResponse(task.Value, "DiscoveryTask");
                Assert.That(task.Value.Name, Is.EqualTo(taskName));
            }
            finally
            {
                await DeleteTaskQuietAsync(tasksClient, projectName, investigationName, taskName);
            }
        }

        [RecordedTest]
        public async Task CreateTask()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Act
            string taskName = await CreateTaskAsync(tasksClient, projectName, investigationName,
                title: TestConstants.TaskTitle,
                description: TestConstants.TaskDescription,
                withAssignee: true);

            // Assert — CreateTaskAsync already asserts 200/201
            Assert.That(taskName, Is.Not.Null.And.Not.Empty);

            // Cleanup
            await DeleteTaskQuietAsync(tasksClient, projectName, investigationName, taskName);
        }

        [RecordedTest]
        public async Task UpdateTask()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string taskName = await CreateTaskAsync(tasksClient, projectName, investigationName,
                title: "task-for-update-test");
            try
            {
                // Act - PATCH via RequestContent
                var content = RequestContent.Create(new { title = TestConstants.UpdatedTaskTitle });
                var response = await tasksClient.UpdateAsync(
                    projectName, investigationName, taskName, content);

                // Assert
                Assert.That(response.Status, Is.EqualTo(200).Or.EqualTo(201));
            }
            finally
            {
                await DeleteTaskQuietAsync(tasksClient, projectName, investigationName, taskName);
            }
        }

        [RecordedTest]
        public async Task DeleteTask()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string taskName = await CreateTaskAsync(tasksClient, projectName, investigationName,
                title: "task-for-delete-test");

            // Act & Assert — should not throw
            await tasksClient.DeleteAsync(projectName, investigationName, taskName);
        }

        [RecordedTest]
        public async Task StartTask()
        {
            // Arrange - create a task with assignee so it can be started
            WorkspaceClient client = CreateWorkspaceClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string taskName = await CreateTaskAsync(tasksClient, projectName, investigationName,
                title: "task-for-start-test", withAssignee: true);
            try
            {
                // Act
                var task = await tasksClient.StartAsync(projectName, investigationName, taskName);

                // Assert
                Assert.That(task.Value, Is.Not.Null);
            }
            finally
            {
                await DeleteTaskQuietAsync(tasksClient, projectName, investigationName, taskName);
            }
        }

        [RecordedTest]
        public async Task AddCommentToTask()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string taskName = await CreateTaskAsync(tasksClient, projectName, investigationName,
                title: "task-for-comment-test");
            try
            {
                var comment = new TaskComment(TestConstants.CommentUser, ByType.User, TestConstants.CommentText);

                // Act
                var task = await tasksClient.AddCommentAsync(taskName, projectName, investigationName, comment);

                // Assert
                Assert.That(task.Value, Is.Not.Null);
            }
            finally
            {
                await DeleteTaskQuietAsync(tasksClient, projectName, investigationName, taskName);
            }
        }

        [RecordedTest]
        public async Task AddExecutionHistoryToTask()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var tasksClient = client.GetDiscoveryTasksClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string taskName = await CreateTaskAsync(tasksClient, projectName, investigationName,
                title: "task-for-exec-history-test");
            try
            {
                var body = new
                {
                    createdAt = Recording.UtcNow,
                    action = "completed",
                    createdBy = TestEnvironment.AgentName,
                    createdByType = "Application"
                };

                // Act
                var response = await tasksClient.AddExecutionHistoryAsync(
                    projectName, investigationName, taskName,
                    RequestContent.Create(body),
                    new RequestContext { ErrorOptions = ErrorOptions.NoThrow });

                // Assert
                Assert.That(response.Status, Is.EqualTo(200).Or.EqualTo(201));
            }
            finally
            {
                await DeleteTaskQuietAsync(tasksClient, projectName, investigationName, taskName);
            }
        }
    }
}