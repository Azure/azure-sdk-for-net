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
        protected Task WaitForJobCancellation(List<string> jobIDs, DocumentTranslationClient client)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                var options = new GetTranslationStatusesOptions();

                foreach (var result in jobIDs)
                {
                    options.Ids.Add(result);
                }

                bool cancellationHasPropagated = false; // flag for successful cancelling

                return TestRetryHelper.RetryAsync(async () =>
                {
                    var statuses = await client.GetTranslationStatusesAsync(options: options).ToEnumerableAsync();
                    cancellationHasPropagated = statuses.TrueForAll(status => status.Status == DocumentTranslationStatus.Canceled);

                    if (!cancellationHasPropagated)
                        throw new InvalidOperationException("Cancellation not propagated to all documents");
                    else
                        return (Response)null;
                },
                maxIterations: 100, delay: TimeSpan.FromSeconds(5));
            }
        }

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
                }
            }

            //ensure that cancel status has propagated before returning
            if (jobTerminalStatus == DocumentTranslationStatus.Canceled)
            {
                await WaitForJobCancellation(resultIds, client);
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

            // getting only translations from the last few hours
            var recentTimestamp = Recording.UtcNow.AddHours(-6);

            var options = new GetTranslationStatusesOptions
            {
                Statuses = { canceledStatusList[0], canceledStatusList[1] },
                CreatedAfter = recentTimestamp
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

            // timestamp before creating a translation job
            var timestamp = Recording.UtcNow;

            // create test jobs
            await CreateTranslationJobsAsync(client, jobsCount: 1, docsPerJob: 1, jobTerminalStatus: DocumentTranslationStatus.Succeeded);

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

            // getting only translations from the last hour
            var recentTimestamp = Recording.UtcNow.AddHours(-1);

            // list translations with filter
            var options = new GetTranslationStatusesOptions
            {
                CreatedBefore = timestamp,
                CreatedAfter = recentTimestamp
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

            // getting only translations from the last few hours
            var recentTimestamp = Recording.UtcNow.AddHours(-6);

            // list translations with filter
            var options = new GetTranslationStatusesOptions
            {
                OrderBy = { new TranslationFilterOrder(property: TranslationFilterProperty.CreatedOn, ascending: false) },
                CreatedAfter = recentTimestamp
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
