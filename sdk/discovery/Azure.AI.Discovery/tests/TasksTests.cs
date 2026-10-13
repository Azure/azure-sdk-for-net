// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Tests for task operations on <see cref="DiscoveryTasksClient"/>
    /// (create, get, list, update, delete, start, add comment, add execution history).
    /// Ported from the Python <c>test_tasks.py</c> suite. Each test is self-contained:
    /// it creates the task it needs and cleans it up.
    /// </summary>
    public class TasksTests : DiscoveryTestBase
    {
        public TasksTests(bool isAsync) : base(isAsync)
        {
        }

        private string Project => TestEnvironment.ProjectName;
        private string Investigation => TestEnvironment.InvestigationName;

        private async Task<DiscoveryTask> CreateTaskAsync(
            DiscoveryTasksClient client,
            string title = "sdk-test-task",
            string description = "Test task for .NET SDK")
        {
            return await client.CreateAsync(
                Project,
                Investigation,
                new DiscoveryTask
                {
                    Title = title,
                    Priority = TaskPriority.High,
                    Description = description,
                    AssignedTo = new TaskAssignee(TestEnvironment.AgentName, DiscoveryActorType.Application),
                    InvestigationId = InvestigationPath(),
                });
        }

        private static async Task DeleteTaskQuietAsync(DiscoveryTasksClient client, string project, string investigation, string taskName)
        {
            try
            {
                await client.DeleteAsync(project, investigation, taskName);
            }
            catch
            {
                // Best-effort cleanup.
            }
        }

        [RecordedTest]
        [Order(1)]
        public async Task ListTasks()
        {
            DiscoveryTasksClient client = CreateTasksClient();
            DiscoveryTask created = await CreateTaskAsync(client, title: "task-for-list-test");
            try
            {
                var tasks = new List<DiscoveryTask>();
                await foreach (DiscoveryTask t in client.GetAllAsync(Project, Investigation))
                {
                    tasks.Add(t);
                }

                Assert.That(tasks.Count, Is.GreaterThan(0));
                foreach (DiscoveryTask t in tasks)
                {
                    Assert.That(t.Title, Is.Not.Null);
                    Assert.That(t.Status, Is.Not.Null);
                }
            }
            finally
            {
                await DeleteTaskQuietAsync(client, Project, Investigation, created.Name);
            }
        }

        [RecordedTest]
        [Order(2)]
        public async Task CreateTask()
        {
            DiscoveryTasksClient client = CreateTasksClient();
            DiscoveryTask task = await CreateTaskAsync(client, title: "A new sdk task");
            try
            {
                Assert.That(task, Is.Not.Null);
                Assert.That(task.Title, Is.EqualTo("A new sdk task"));
                Assert.That(task.Description, Is.EqualTo("Test task for .NET SDK"));
            }
            finally
            {
                await DeleteTaskQuietAsync(client, Project, Investigation, task.Name);
            }
        }

        [RecordedTest]
        [Order(3)]
        public async Task GetTask()
        {
            DiscoveryTasksClient client = CreateTasksClient();
            DiscoveryTask created = await CreateTaskAsync(client, title: "task-for-get-test");
            try
            {
                DiscoveryTask task = await client.GetAsync(Project, Investigation, created.Name);

                Assert.That(task, Is.Not.Null);
                Assert.That(task.Title, Is.EqualTo("task-for-get-test"));
                Assert.That(task.Status, Is.Not.Null);
                Assert.That(task.CreatedOn, Is.Not.Null);
                Assert.That(task.AssignedTo, Is.Not.Null);
            }
            finally
            {
                await DeleteTaskQuietAsync(client, Project, Investigation, created.Name);
            }
        }

        [RecordedTest]
        [Order(4)]
        public async Task UpdateTask()
        {
            DiscoveryTasksClient client = CreateTasksClient();
            DiscoveryTask created = await CreateTaskAsync(client, title: "task-for-update-test");
            try
            {
                RequestContent content = RequestContent.Create(new
                {
                    title = "Updated sdk task title",
                    description = "Updated sdk task description",
                });
                Response response = await client.StableUpdateAsync(Project, Investigation, created.Name, content);
                var updated = (DiscoveryTask)response;

                Assert.That(updated.Title, Is.EqualTo("Updated sdk task title"));
                Assert.That(updated.Description, Is.EqualTo("Updated sdk task description"));
            }
            finally
            {
                await DeleteTaskQuietAsync(client, Project, Investigation, created.Name);
            }
        }

        [RecordedTest]
        [Order(5)]
        public async Task DeleteTask()
        {
            DiscoveryTasksClient client = CreateTasksClient();
            DiscoveryTask created = await CreateTaskAsync(client, title: "task-for-delete-test");

            Response response = await client.DeleteAsync(Project, Investigation, created.Name);

            Assert.That(response.Status, Is.InRange(200, 299));
        }

        [RecordedTest]
        [Order(6)]
        public async Task ListTasksWithFilter()
        {
            DiscoveryTasksClient client = CreateTasksClient();
            DiscoveryTask created = await CreateTaskAsync(client, title: "task-for-filter-test");
            try
            {
                var tasks = new List<DiscoveryTask>();
                await foreach (DiscoveryTask t in client.GetAllAsync(Project, Investigation, filter: "status eq 'New'"))
                {
                    tasks.Add(t);
                }

                Assert.That(tasks, Is.Not.Null);
            }
            finally
            {
                await DeleteTaskQuietAsync(client, Project, Investigation, created.Name);
            }
        }

        [RecordedTest]
        [Order(7)]
        public async Task StartTask()
        {
            DiscoveryTasksClient client = CreateTasksClient();
            DiscoveryTask created = await CreateTaskAsync(client, title: "task-for-start-test");
            try
            {
                DiscoveryTask task = await client.StartAsync(Project, Investigation, created.Name);

                Assert.That(task, Is.Not.Null);
                Assert.That(task.Status, Is.Not.Null);
            }
            finally
            {
                await DeleteTaskQuietAsync(client, Project, Investigation, created.Name);
            }
        }

        [RecordedTest]
        [Order(8)]
        public async Task AddComment()
        {
            DiscoveryTasksClient client = CreateTasksClient();
            DiscoveryTask created = await CreateTaskAsync(client, title: "task-for-comment-test");
            try
            {
                DiscoveryTask task = await client.AddCommentAsync(
                    Project,
                    Investigation,
                    created.Name,
                    new TaskComment("test-user", DiscoveryActorType.User, "Test comment")
                    {
                        Timestamp = new DateTimeOffset(2026, 4, 8, 21, 0, 0, TimeSpan.Zero),
                    });

                Assert.That(task, Is.Not.Null);
                Assert.That(task.Title, Is.Not.Null);
            }
            finally
            {
                await DeleteTaskQuietAsync(client, Project, Investigation, created.Name);
            }
        }

        [RecordedTest]
        [Order(9)]
        public async Task AddExecutionHistory()
        {
            DiscoveryTasksClient client = CreateTasksClient();
            DiscoveryTask created = await CreateTaskAsync(client, title: "task-for-exec-history-test");
            try
            {
                DiscoveryTask task = await client.AddExecutionHistoryAsync(
                    Project,
                    Investigation,
                    created.Name,
                    new ExecutionHistoryEntry(
                        new DateTimeOffset(2026, 4, 8, 21, 0, 0, TimeSpan.Zero),
                        "completed",
                        TestEnvironment.AgentName,
                        DiscoveryActorType.Application)
                    {
                        Summary = "Task execution completed",
                    });

                Assert.That(task, Is.Not.Null);
                Assert.That(task.Title, Is.Not.Null);
                Assert.That(task.Status, Is.Not.Null);
            }
            finally
            {
                await DeleteTaskQuietAsync(client, Project, Investigation, created.Name);
            }
        }
    }
}
