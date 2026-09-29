// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Tests for investigation operations on <see cref="DiscoveryInvestigationsClient"/>.
    /// Ported from the Python <c>test_investigations.py</c> suite. Test order matters:
    /// <see cref="CreateOrReplaceNew"/> creates the shared investigation
    /// (<c>AZURE_DISCOVERY_INVESTIGATION_NAME</c>) that the remaining lifecycle tests reuse.
    /// </summary>
    public class InvestigationsTests : DiscoveryTestBase
    {
        public InvestigationsTests(bool isAsync) : base(isAsync)
        {
        }

        private string Project => TestEnvironment.ProjectName;
        private string Investigation => TestEnvironment.InvestigationName;

        [RecordedTest]
        [Order(1)]
        public async Task CreateOrReplaceNew()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();
            DiscoveryInvestigation investigation = await client.CreateOrReplaceAsync(
                Project,
                Investigation,
                new DiscoveryInvestigation { Description = "New investigation", DisplayName = "New Test" });

            Assert.That(investigation, Is.Not.Null);
            Assert.That(investigation.Description, Is.EqualTo("New investigation"));
            Assert.That(investigation.DisplayName, Is.EqualTo("New Test"));
        }

        [RecordedTest]
        [Order(2)]
        public async Task ListInvestigations()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();
            PagedInvestigation page = await client.GetAllAsync(Project);

            Assert.That(page.Value, Is.Not.Null);
            Assert.That(page.Value.Count, Is.GreaterThan(0));
            foreach (DiscoveryInvestigation inv in page.Value)
            {
                Assert.That(inv.ProjectName, Is.EqualTo(Project));
                Assert.That(inv.Status, Is.Not.Null);
                Assert.That(inv.CreatedOn, Is.Not.Null);
            }
        }

        [RecordedTest]
        [Order(3)]
        public async Task GetInvestigation()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();
            DiscoveryInvestigation investigation = await client.GetAsync(Project, Investigation);

            Assert.That(investigation, Is.Not.Null);
            Assert.That(investigation.ProjectName, Is.EqualTo(Project));
            Assert.That(investigation.Status, Is.Not.Null);
            Assert.That(investigation.CreatedOn, Is.Not.Null);
            Assert.That(investigation.LastModifiedOn, Is.Not.Null);
        }

        [RecordedTest]
        [Order(4)]
        public async Task UpdateDiscoveryEngine()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();

            // Creating the Discovery Engine requires at least one task in the investigation
            // (the project must also contain a user-created agent). Create one so the engine
            // is provisioned for this and the subsequent engine lifecycle tests.
            DiscoveryTasksClient tasksClient = CreateTasksClient();
            await tasksClient.CreateAsync(
                Project,
                Investigation,
                new DiscoveryTask { Title = "engine-precondition-task", Description = "Ensures the investigation has a task so the Discovery Engine can be created." });

            RequestContent content = RequestContent.Create(new { systemPrompt = "Updated system prompt for test" });
            Response response = await client.UpdateDiscoveryEngineAsync(Project, Investigation, content);
            var engine = (DiscoveryEngine)response;

            Assert.That(engine, Is.Not.Null);
        }

        [RecordedTest]
        [Order(5)]
        public async Task GetDiscoveryEngine()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();
            DiscoveryEngine engine = await client.GetDiscoveryEngineAsync(Project, Investigation);

            Assert.That(engine, Is.Not.Null);
        }

        [RecordedTest]
        [Order(6)]
        public async Task StartDiscoveryEngine()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();
            DiscoveryTasksClient tasksClient = CreateTasksClient();

            // Discovery Engine requires at least one task in the investigation before starting.
            DiscoveryTask task = await tasksClient.CreateAsync(
                Project,
                Investigation,
                new DiscoveryTask { Title = "test-task", Description = "Task for engine start test" });

            DiscoveryEngine engine = await client.StartDiscoveryEngineAsync(Project, Investigation);

            await tasksClient.DeleteAsync(Project, Investigation, task.Name);

            Assert.That(engine, Is.Not.Null);
        }

        [RecordedTest]
        [Order(7)]
        public async Task GetDiscoveryEngineMemory()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();
            PagedWorkingMemoryEntry memory = await client.GetDiscoveryEngineMemoryAsync(Project, Investigation);

            Assert.That(memory, Is.Not.Null);
        }

        [RecordedTest]
        [Order(8)]
        public async Task StopDiscoveryEngine()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();
            DiscoveryEngine engine = await client.StopDiscoveryEngineAsync(Project, Investigation);

            Assert.That(engine, Is.Not.Null);
        }

        [RecordedTest]
        [Order(9)]
        public async Task CreateOrReplaceUpdate()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();
            DiscoveryInvestigation investigation = await client.CreateOrReplaceAsync(
                Project,
                Investigation,
                new DiscoveryInvestigation { Description = "Updated via replace", DisplayName = "updated-new-test" });

            Assert.That(investigation, Is.Not.Null);
            Assert.That(investigation.Description, Is.EqualTo("Updated via replace"));
            Assert.That(investigation.DisplayName, Is.EqualTo("updated-new-test"));
        }

        [RecordedTest]
        [Order(10)]
        public async Task UpdateInvestigation()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();
            RequestContent content = RequestContent.Create(new { description = "Updated description", displayName = "updated-test" });
            Response response = await client.UpdateAsync(Project, Investigation, content);
            var investigation = (DiscoveryInvestigation)response;

            Assert.That(investigation, Is.Not.Null);
            Assert.That(investigation.Description, Is.EqualTo("Updated description"));
        }

        [RecordedTest]
        [Order(11)]
        public async Task GetOperationStatus()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();

            // Create a sacrificial investigation to delete.
            await client.CreateOrReplaceAsync(
                Project,
                "test-op-status",
                new DiscoveryInvestigation { Description = "Sacrificial investigation for getOperationStatus test", DisplayName = "Op Status Test" });

            // Start the delete LRO without waiting for completion.
            Operation<DiscoveryInvestigation> operation = await client.DeleteAsync(WaitUntil.Started, Project, "test-op-status");

            string opLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string value) ? value : "";
            string[] segments = opLocation.Split(new[] { "/operations/" }, System.StringSplitOptions.None);
            string operationId = segments[segments.Length - 1].Split('?')[0];
            Assert.That(operationId, Is.Not.Empty, "Could not extract operation_id from operation-location header.");

            InvestigationOperationStatus status =
                await client.GetOperationStatusAsync(Project, "test-op-status", operationId);

            Assert.That(status, Is.Not.Null);
            Assert.That(status.Status.ToString(), Is.Not.Empty);
        }

        [RecordedTest]
        [Order(12)]
        public async Task BeginDelete()
        {
            DiscoveryInvestigationsClient client = CreateInvestigationsClient();

            // Create a sacrificial investigation to delete.
            await client.CreateOrReplaceAsync(
                Project,
                "sdk-test-delete",
                new DiscoveryInvestigation { Description = "Sacrificial investigation for delete test", DisplayName = "Delete Status Test" });

            Operation<DiscoveryInvestigation> operation = await client.DeleteAsync(WaitUntil.Completed, Project, "sdk-test-delete");

            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
