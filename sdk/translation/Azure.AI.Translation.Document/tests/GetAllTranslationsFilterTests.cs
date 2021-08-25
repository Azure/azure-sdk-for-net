// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Tests
{
    public partial class DocumentTranslationClientLiveTests
    {
        public async Task<List<string>> CreateTranslationJobsAsync(DocumentTranslationClient client, int jobsCount = 1, int docsPerJob = 1, DocumentTranslationStatus jobTerminalStatus = default)
        {
            // create source container
            if (jobTerminalStatus == DocumentTranslationStatus.Canceled)
            {
                docsPerJob = 20; // in order to avoid job completing before canceling
            }
            var testDocs = CreateDummyTestDocuments(count: docsPerJob);
            var sourceContainer = await CreateSourceContainerAsync(testDocs);

            // create a translation job
            var resultIds = new List<string>();
            for (int i = 1; i <= jobsCount; i++)
            {
                var targetContainer = await CreateTargetContainerAsync();
                var input = new DocumentTranslationInput(sourceContainer, targetContainer, "fr");
                var translationOp = await client.StartTranslationAsync(input);
                resultIds.Add(translationOp.Id);
                if (jobTerminalStatus == DocumentTranslationStatus.Succeeded)
                {
                    await translationOp.WaitForCompletionAsync();
                }
                else if (jobTerminalStatus == DocumentTranslationStatus.Canceled)
                {
                    await translationOp.CancelAsync(default);
                    Thread.Sleep(6000); // wait for cancel status to propagate!
                }
            }

            return resultIds;
        }

        [RecordedTest]
        public async Task GetTranslationStatusesFilterByStatusTest()
        {
            // create client
            var client = GetClient();

            // create test jobs
            await CreateTranslationJobsAsync(client, jobsCount: 1, docsPerJob: 1, jobTerminalStatus: DocumentTranslationStatus.Succeeded);
            var canceledIds = await CreateTranslationJobsAsync(client, jobsCount: 1, jobTerminalStatus: DocumentTranslationStatus.Canceled);

            // list translations with filter
            var canceledStatusList = new List<DocumentTranslationStatus> {
                    DocumentTranslationStatus.Canceled,
                    DocumentTranslationStatus.Canceling
            };
            var options = new GetTranslationStatusesOptions
            {
                Statuses = { canceledStatusList[0], canceledStatusList[1] }
            };

            var filteredTranslations = await client.GetTranslationStatusesAsync(options: options).ToEnumerableAsync();
            var filteredIds = filteredTranslations.Select(t => t.Id).ToList();

            // assert
            Assert.That(filteredTranslations.All(t => canceledStatusList.Contains(t.Status)));
            Assert.True(canceledIds.All(canceledId => filteredIds.Contains(canceledId)));
        }

        [RecordedTest]
        public async Task GetTranslationStatusesFilterByIdsTest()
        {
            // create client
            var client = GetClient();

            // create test jobs
            var allIds = await CreateTranslationJobsAsync(client, jobsCount: 2, docsPerJob: 1, jobTerminalStatus: DocumentTranslationStatus.Succeeded);
            var targetIds = allIds.GetRange(0, 1);

            // list translations with filter
            var options = new GetTranslationStatusesOptions
            {
                Ids = { targetIds[0] }
            };
            var filteredTranslations = await client.GetTranslationStatusesAsync(options: options).ToEnumerableAsync();

            // assert
            Assert.That(filteredTranslations.Any(t => targetIds.Contains(t.Id)));
        }

        [RecordedTest]
        public async Task GetTranslationStatusesFilterByCreatedAfterTest()
        {
            // create client
            var client = GetClient();

            // create test jobs
            await CreateTranslationJobsAsync(client, jobsCount: 1, docsPerJob: 1, jobTerminalStatus: DocumentTranslationStatus.Succeeded);
            var timestamp = Recording.UtcNow;
            var targetIds = await CreateTranslationJobsAsync(client, jobsCount: 1, docsPerJob: 1, jobTerminalStatus: DocumentTranslationStatus.Succeeded);

            // list translations with filter
            var options = new GetTranslationStatusesOptions
            {
                CreatedAfter = timestamp
            };
            var filteredTranslations = await client.GetTranslationStatusesAsync(options: options).ToEnumerableAsync();

            // assert
            Assert.That(filteredTranslations.Any(t => targetIds.Contains(t.Id)));
            Assert.That(filteredTranslations.All(t => t.CreatedOn >= timestamp));
        }

        [RecordedTest]
        public async Task GetTranslationStatusesFilterByCreatedBeforeTest()
        {
            // create client
            var client = GetClient();

            // create test jobs
            var targetIds = await CreateTranslationJobsAsync(client, jobsCount: 1, docsPerJob: 1, jobTerminalStatus: DocumentTranslationStatus.Succeeded);
            var timestamp = Recording.UtcNow;
            await CreateTranslationJobsAsync(client, jobsCount: 1, docsPerJob: 1, jobTerminalStatus: DocumentTranslationStatus.Succeeded);

            // list translations with filter
            var options = new GetTranslationStatusesOptions
            {
                CreatedBefore = timestamp
            };

            var filteredTranslations = await client.GetTranslationStatusesAsync(options: options).ToEnumerableAsync();

            // assert
            Assert.That(filteredTranslations.Any(t => targetIds.Contains(t.Id)));
            Assert.That(filteredTranslations.All(t => t.CreatedOn <= timestamp));
        }

        [RecordedTest]
        public async Task GetTranslationStatusesOrderByCreatedOnTest()
        {
            // create client
            var client = GetClient();

            // create test jobs
            await CreateTranslationJobsAsync(client, jobsCount: 3, docsPerJob: 1, jobTerminalStatus: DocumentTranslationStatus.Succeeded);

            // list translations with filter
            var options = new GetTranslationStatusesOptions
            {
                OrderBy = { new TranslationFilterOrder(property: TranslationFilterProperty.CreatedOn, asc: false) }
            };

            var filteredTranslations = await client.GetTranslationStatusesAsync(options: options).ToEnumerableAsync();

            // assert
            var timestamp = Recording.UtcNow;
            foreach (var result in filteredTranslations)
            {
                Assert.IsTrue(result.CreatedOn <= timestamp);
                timestamp = result.CreatedOn;
            }
        }
    }
}
