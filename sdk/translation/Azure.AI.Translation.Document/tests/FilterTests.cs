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
        [RecordedTest]
        public async Task GetAllTranslationStatusesFilterByStatusTest()
        {
            // prepare test
            var client = GetClient();
            var testDocs = CreateDummyTestDocuments(count: 10); // using a lot of docs -> make operation take long time -> we can cancel and not worry about finished status!
            var sourceContainer = await CreateSourceContainerAsync(testDocs);
            var targetContainer = await CreateTargetContainerAsync();

            // create a translation job
            var input = new DocumentTranslationInput(sourceContainer, targetContainer, "fr");
            var translationOp = await client.StartTranslationAsync(input);
            await translationOp.CancelAsync(default);
            Thread.Sleep(3000); // wait for cancel status to propagate!

            // list translations with filter
            var cancelledStatusList = new List<DocumentTranslationStatus> {
                    DocumentTranslationStatus.Cancelled,
                    DocumentTranslationStatus.Cancelling
            };
            var filter = new TranslationFilter(
                statuses: cancelledStatusList
            );
            var submittedTranslations = await client.GetAllTranslationStatusesAsync(filter: filter).ToEnumerableAsync();

            // assert
            Assert.That(submittedTranslations.Any(t => string.Equals(t.Id, translationOp.Id, StringComparison.OrdinalIgnoreCase) ));
            Assert.That(submittedTranslations.All(t => cancelledStatusList.Contains(t.Status) ));
        }
    }
}
