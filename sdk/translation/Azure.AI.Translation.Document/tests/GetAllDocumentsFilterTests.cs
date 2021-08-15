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
            var filter = new DocumentFilter
            {
                Statuses = {DocumentTranslationStatus.Succeeded}
            };
            var result = operation.GetDocumentStatuses(filter: filter);

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
            var filter = new DocumentFilter
            {
                Ids = { testIds[0] }
            };

            var result = operation.GetDocumentStatuses(filter: filter);

            // assert
            Assert.That(result.All(d => testIds.Contains(d.Id)));
        }

        [Ignore("no way to test this filter")]
        [RecordedTest]
        public void GetDocumentStatusesFilterByCreatedAfter()
        {
        }

        [Ignore("no way to test this filter")]
        [RecordedTest]
        public void GetDocumentStatusesFilterByCreatedBefore()
        {
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
            var filter = new DocumentFilter
            {
                OrderBy = { new DocumentFilterOrder(property: DocumentFilterProperty.CreatedOn, asc: false) }
            };

            var filterResults = operation.GetDocumentStatuses(filter: filter);

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
