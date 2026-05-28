// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Tests
{
    public partial class DocumentTranslationClientLiveTests
    {
        private async Task<DocumentTranslationOperation> CreateSingleTranslationJobAsync(DocumentTranslationClient client, int docsCount = 1)
        {
            var testDocs = CreateDummyTestDocuments(count: docsCount);
            var sourceContainer = await CreateSourceContainerAsync(testDocs);

            var targetContainer = await CreateTargetContainerAsync();
            var input = new DocumentTranslationInput(sourceContainer, targetContainer, "fr");
            var translationOp = await client.StartTranslationAsync(input);

            return translationOp;
        }

        [RecordedTest]
        public async Task GetDocumentStatusesFilterByStatusTest()
        {
            // create client
            var client = GetClient();

            // create translation job
            var operation = await CreateSingleTranslationJobAsync(client, docsCount: 2);
            await operation.WaitForCompletionAsync();

            // list docs
            var options = new GetDocumentStatusesOptions
            {
                Statuses = {DocumentTranslationStatus.Succeeded}
            };
            var result = operation.GetDocumentStatuses(options: options);

            // assert.
            Assert.That(result.All(d => d.Status == DocumentTranslationStatus.Succeeded));
        }

        [RecordedTest]
        public async Task GetDocumentStatusesFilterByIdsTest()
        {
            // create client
            var client = GetClient();

            // create translation job
            var operation = await CreateSingleTranslationJobAsync(client, docsCount: 2);
            await operation.WaitForCompletionAsync();
            var testIds = operation.GetDocumentStatuses().Select(d => d.Id).ToList().GetRange(0, 1);

            // list docs
            var options = new GetDocumentStatusesOptions
            {
                Ids = { testIds[0] }
            };

            var result = operation.GetDocumentStatuses(options: options);

            // assert
            Assert.That(result.All(d => testIds.Contains(d.Id)));
        }

        [RecordedTest]
        public async Task GetDocumentStatusesFilterByCreatedAfter()
        {
            // create client
            var client = GetClient();

            // create translation job
            var operation = await CreateSingleTranslationJobAsync(client, docsCount: 5);
            await operation.WaitForCompletionAsync();

            // option to sort in order of Created On
            var optionsOrdering = new GetDocumentStatusesOptions
            {
                OrderBy = { new DocumentFilterOrder(property: DocumentFilterProperty.CreatedOn, ascending: true) }
            };

            var testCreatedOnDateTimes = operation.GetDocumentStatuses(options: optionsOrdering).Select(d => d.CreatedOn).ToList();

            var optionsCreatedAfterLastDate = new GetDocumentStatusesOptions
            {
                CreatedAfter = testCreatedOnDateTimes[4]
            };

            var optionsCreatedAfterIndex2 = new GetDocumentStatusesOptions
            {
                CreatedAfter = testCreatedOnDateTimes[2]
            };

            var docsAfterLastDate = operation.GetDocumentStatuses(options: optionsCreatedAfterLastDate).ToList();
            var docsAfterIndex2Date = operation.GetDocumentStatuses(options: optionsCreatedAfterIndex2).ToList();

            // Asserting that only the last document is returned
            Assert.AreEqual(1, docsAfterLastDate.Count());

            // Asserting that the last 3/5 docs are returned
             Assert.AreEqual(3, docsAfterIndex2Date.Count());
        }

        [RecordedTest]
        public async Task GetDocumentStatusesFilterByCreatedBefore()
        {
            // create client
            var client = GetClient();

            // create translation job
            var operation = await CreateSingleTranslationJobAsync(client, docsCount: 5);
            await operation.WaitForCompletionAsync();

            // option to sort in order of Created On
            var optionsOrdering = new GetDocumentStatusesOptions
            {
                OrderBy = { new DocumentFilterOrder(property: DocumentFilterProperty.CreatedOn, ascending: true) }
            };

            var testCreatedOnDateTimes = operation.GetDocumentStatuses(options: optionsOrdering).Select(d => d.CreatedOn).ToList();

            var optionsCreatedBeforeFirstDate = new GetDocumentStatusesOptions
            {
                CreatedBefore = testCreatedOnDateTimes[0]
            };

            var optionsCreatedBeforeIndex3 = new GetDocumentStatusesOptions
            {
                CreatedBefore = testCreatedOnDateTimes[3]
            };

            var docsBeforeFirstDate = operation.GetDocumentStatuses(options: optionsCreatedBeforeFirstDate).ToList();
            var docsBeforeIndex3Date = operation.GetDocumentStatuses(options: optionsCreatedBeforeIndex3).ToList();

            // Asserting that only the first document is returned
            Assert.AreEqual(1, docsBeforeFirstDate.Count());

            // Asserting that the first 4/5 docs are returned
            Assert.AreEqual(4, docsBeforeIndex3Date.Count());
        }

        [RecordedTest]
        public async Task GetDocumentStatusesOrderByCreatedOn()
        {
            // create client
            var client = GetClient();

            // create translation job
            var operation = await CreateSingleTranslationJobAsync(client, docsCount: 3);
            await operation.WaitForCompletionAsync();

            // list docs
            var options = new GetDocumentStatusesOptions
            {
                OrderBy = { new DocumentFilterOrder(property: DocumentFilterProperty.CreatedOn, ascending: false) }
            };

            var filterResults = operation.GetDocumentStatuses(options: options);

            // assert
            var timestamp = Recording.UtcNow;
            foreach (var result in filterResults)
            {
                Assert.IsTrue(result.CreatedOn <= timestamp);
                timestamp = result.CreatedOn;
            }
        }
    }
}
