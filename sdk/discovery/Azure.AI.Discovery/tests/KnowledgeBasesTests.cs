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
    /// Tests for knowledge base operations on <see cref="KnowledgeBases"/> (Bookshelf service):
    /// create-or-update, list, get, start/cancel indexing, search, get operation status, delete.
    /// Ported from the Python <c>test_knowledge_bases.py</c> suite. Test order matters:
    /// <see cref="CreateOrUpdate"/> seeds the shared knowledge base (<c>KNOWLEDGE_BASE_NAME</c>)
    /// that the read/indexing/search tests reuse.
    /// </summary>
    public class KnowledgeBasesTests : DiscoveryTestBase
    {
        public KnowledgeBasesTests(bool isAsync) : base(isAsync)
        {
        }

        private string KbName => TestEnvironment.KnowledgeBaseName;

        private RequestContent KnowledgeBaseBody(string description) => RequestContent.Create(new
        {
            description,
            copilotInstruction = TestEnvironment.KnowledgeBaseCopilotInstruction,
            storageAssetReferences = new[]
            {
                new { id = TestEnvironment.StorageAssetId, userAssignedIdentity = TestEnvironment.UserAssignedIdentity },
            },
        });

        private async Task SleepAsync(int seconds)
        {
            if (Mode == RecordedTestMode.Live)
            {
                await Task.Delay(TimeSpan.FromSeconds(seconds));
            }
        }

        /// <summary>
        /// Starts an indexing run without waiting and returns its operation id. The service allows
        /// only one indexing run per knowledge base at a time and rejects a concurrent start with
        /// 409 ConcurrencyConflict; in that case the in-progress run is reused via lastIndexingRun.
        /// </summary>
        private async Task<string> StartIndexingOperationIdAsync(KnowledgeBases client)
        {
            try
            {
                Operation operation = await client.StartIndexingAsync(WaitUntil.Started, KbName);
                string operationId = ExtractOperationId(operation.GetRawResponse());
                Assert.That(operationId, Is.Not.Empty, "Could not extract operation id from operation-location header.");
                return operationId;
            }
            catch (Azure.RequestFailedException ex) when (ex.Status == 409)
            {
                KnowledgeBase kb = await client.GetAsync(KbName);
                string runId = kb.LastIndexingRun?.RunId;
                Assert.That(runId, Is.Not.Null, "Indexing already in progress but no lastIndexingRun id is available.");
                return runId;
            }
        }

        [RecordedTest]
        [Order(1)]
        public async Task CreateOrUpdate()
        {
            KnowledgeBases client = CreateKnowledgeBasesClient();
            Operation<BinaryData> operation = await client.CreateOrUpdateAsync(
                WaitUntil.Completed,
                KbName,
                KnowledgeBaseBody(TestEnvironment.KnowledgeBaseDescription));

            Assert.That(operation.HasCompleted, Is.True);

            KnowledgeBase kb = await client.GetAsync(KbName);
            Assert.That(kb.Name, Is.EqualTo(KbName));
        }

        [RecordedTest]
        [Order(2)]
        public async Task List()
        {
            KnowledgeBases client = CreateKnowledgeBasesClient();
            var knowledgeBases = new List<KnowledgeBase>();
            await foreach (KnowledgeBase kb in client.GetAllAsync())
            {
                knowledgeBases.Add(kb);
            }

            Assert.That(knowledgeBases.Count, Is.GreaterThan(0));
            foreach (KnowledgeBase kb in knowledgeBases)
            {
                Assert.That(kb.Name, Is.Not.Null);
                Assert.That(kb.Name.Length, Is.LessThanOrEqualTo(24));
                Assert.That(kb.BookshelfName, Is.Not.Null);
                Assert.That(kb.ProvisioningState, Is.Not.Null);
                Assert.That(kb.Status, Is.Not.Null);
            }
        }

        [RecordedTest]
        [Order(3)]
        public async Task Get()
        {
            KnowledgeBases client = CreateKnowledgeBasesClient();
            KnowledgeBase kb = await client.GetAsync(KbName);

            Assert.That(kb, Is.Not.Null);
            Assert.That(kb.Name, Is.EqualTo(KbName));
            Assert.That(kb.BookshelfName, Is.Not.Null);
            Assert.That(kb.ProvisioningState, Is.Not.Null);
            Assert.That(kb.StorageAssetReferences, Is.Not.Null);
        }

        [RecordedTest]
        [Order(4)]
        public async Task StartIndexing()
        {
            KnowledgeBases client = CreateKnowledgeBasesClient();
            string operationId = await StartIndexingOperationIdAsync(client);

            Assert.That(operationId, Is.Not.Empty);
        }

        [RecordedTest]
        [Order(5)]
        public async Task Search()
        {
            KnowledgeBases client = CreateKnowledgeBasesClient();

            var terminal = new HashSet<string> { "succeeded", "failed", "canceled" };
            DateTimeOffset overallDeadline = DateTimeOffset.UtcNow.AddMinutes(40);
            string opStatus = null;
            int attempts = 0;

            // Drive an indexing run to Succeeded (the service dedupes concurrent runs, so a run
            // left terminal-but-not-success by another test triggers a fresh attempt).
            while (DateTimeOffset.UtcNow < overallDeadline && attempts < 3)
            {
                attempts++;
                string operationId = await StartIndexingOperationIdAsync(client);
                while (DateTimeOffset.UtcNow < overallDeadline)
                {
                    KnowledgeBaseOperationResponse op = await client.GetOperationStatusAsync(KbName, operationId);
                    opStatus = op.Status.ToString().ToLowerInvariant();
                    if (terminal.Contains(opStatus))
                    {
                        break;
                    }
                    await SleepAsync(10);
                }
                if (opStatus == "succeeded")
                {
                    break;
                }
                await SleepAsync(10);
            }

            Assert.That(opStatus, Is.EqualTo("succeeded"), $"Indexing did not reach Succeeded within the deadline (attempts: {attempts}).");

            // After the indexing operation reports Succeeded the KB needs a short additional window
            // to become search-ready (typed KB.status reaches Succeeded); until then :search is
            // rejected with KnowledgeBaseNotReady.
            DateTimeOffset readyDeadline = DateTimeOffset.UtcNow.AddMinutes(10);
            while (DateTimeOffset.UtcNow < readyDeadline)
            {
                KnowledgeBase kb = await client.GetAsync(KbName);
                if (kb.Status?.ToString().ToLowerInvariant() == "succeeded")
                {
                    break;
                }
                await SleepAsync(15);
            }

            Operation searchOperation = null;
            while (DateTimeOffset.UtcNow < readyDeadline)
            {
                try
                {
                    searchOperation = await client.SearchAsync(
                        WaitUntil.Started,
                        KbName,
                        new SearchRequest("What are common drug interactions?"));
                    break;
                }
                catch (Azure.RequestFailedException ex) when (ex.Message.Contains("KnowledgeBaseNotReady"))
                {
                    await SleepAsync(15);
                }
            }

            Assert.That(searchOperation, Is.Not.Null, "KnowledgeBase did not become search-ready within the deadline.");
            await searchOperation.WaitForCompletionResponseAsync();
            Assert.That(searchOperation.HasCompleted, Is.True);
        }

        [RecordedTest]
        [Order(6)]
        public async Task CancelIndexing()
        {
            KnowledgeBases client = CreateKnowledgeBasesClient();
            // Start a fresh run to cancel.
            await StartIndexingOperationIdAsync(client);

            Operation cancelOperation = await client.CancelIndexingAsync(WaitUntil.Started, KbName);

            Assert.That(cancelOperation, Is.Not.Null);
        }

        [RecordedTest]
        [Order(7)]
        public async Task GetOperationStatus()
        {
            KnowledgeBases client = CreateKnowledgeBasesClient();
            string operationId = await StartIndexingOperationIdAsync(client);

            KnowledgeBaseOperationResponse status = await client.GetOperationStatusAsync(KbName, operationId);

            Assert.That(status, Is.Not.Null);
            Assert.That(status.Id, Is.Not.Null);
            Assert.That(status.Status.ToString(), Is.Not.Empty);

            // Cleanup: cancel the indexing run we started.
            await client.CancelIndexingAsync(WaitUntil.Started, KbName);
        }

        [RecordedTest]
        [Order(8)]
        public async Task Delete()
        {
            KnowledgeBases client = CreateKnowledgeBasesClient();
            const string sacrificialName = "sdk-test-delete-kb";

            // Create the KB to delete (delete requires a terminal provisioningState).
            await client.CreateOrUpdateAsync(
                WaitUntil.Completed,
                sacrificialName,
                KnowledgeBaseBody("Sacrificial KB for delete test"));

            // Exercises the real service LRO contract by polling the operation-location callback.
            Operation operation = await client.DeleteAsync(WaitUntil.Completed, sacrificialName);
            Assert.That(operation.HasCompleted, Is.True);

            // The resource must no longer be retrievable.
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await client.GetAsync(sacrificialName));
        }
    }
}
