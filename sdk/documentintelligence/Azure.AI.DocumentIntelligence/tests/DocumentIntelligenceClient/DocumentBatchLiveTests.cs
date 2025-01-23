// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/47557")]
    public class DocumentBatchLiveTests : DocumentIntelligenceLiveTestBase
    {
        public DocumentBatchLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AnalyzeBatchDocuments()
        {
            var client = CreateDocumentIntelligenceClient();
            var sourceContainerUri = new Uri(TestEnvironment.BatchSourceBlobSasUrl);
            var resultContainerUri = new Uri(TestEnvironment.BatchResultBlobSasUrl);
            var blobSource = new BlobContentSource(sourceContainerUri);
            var options = new AnalyzeBatchDocumentsOptions("prebuilt-read", blobSource, resultContainerUri)
            {
                OverwriteExisting = true
            };

            var operation = await client.AnalyzeBatchDocumentsAsync(WaitUntil.Completed, options);

            Assert.That(operation.HasCompleted);
            Assert.That(operation.HasValue);

            ValidateAcordAnalyzeBatchResult(operation.Value);
        }

        [RecordedTest]
        public async Task GetAnalyzeBatchResult()
        {
            var client = CreateDocumentIntelligenceClient();
            var sourceContainerUri = new Uri(TestEnvironment.BatchSourceBlobSasUrl);
            var resultContainerUri = new Uri(TestEnvironment.BatchResultBlobSasUrl);
            var blobSource = new BlobContentSource(sourceContainerUri);
            var options = new AnalyzeBatchDocumentsOptions("prebuilt-read", blobSource, resultContainerUri)
            {
                OverwriteExisting = true
            };
            var startTime = Recording.UtcNow;

            var operation = await client.AnalyzeBatchDocumentsAsync(WaitUntil.Completed, options);
            var getResponse = await client.GetAnalyzeBatchResultAsync("prebuilt-read", operation.Id);
            var operationDetails = getResponse.Value;

            Assert.That(operationDetails.ResultId, Is.EqualTo(operation.Id));
            Assert.That(operationDetails.Status, Is.EqualTo(DocumentIntelligenceOperationStatus.Succeeded));
            Assert.That(operationDetails.CreatedOn, Is.GreaterThan(startTime - TimeSpan.FromHours(4)));
            Assert.That(operationDetails.LastUpdatedOn, Is.GreaterThanOrEqualTo(operationDetails.CreatedOn));
            Assert.That(operationDetails.PercentCompleted, Is.EqualTo(100));
            Assert.That(operationDetails.Error, Is.Null);

            DocumentAssert.AreEqual(operation.Value, operationDetails.Result);
        }

        [RecordedTest]
        public async Task GetAnalyzeBatchResults()
        {
            var client = CreateDocumentIntelligenceClient();
            var sourceContainerUri = new Uri(TestEnvironment.BatchSourceBlobSasUrl);
            var resultContainerUri = new Uri(TestEnvironment.BatchResultBlobSasUrl);
            var blobSource = new BlobContentSource(sourceContainerUri);
            var options = new AnalyzeBatchDocumentsOptions("prebuilt-read", blobSource, resultContainerUri)
            {
                OverwriteExisting = true
            };

            var operation0 = await client.AnalyzeBatchDocumentsAsync(WaitUntil.Completed, options);
            var operation1 = await client.AnalyzeBatchDocumentsAsync(WaitUntil.Completed, options);
            var getResponse0 = await client.GetAnalyzeBatchResultAsync("prebuilt-read", operation0.Id);
            var getResponse1 = await client.GetAnalyzeBatchResultAsync("prebuilt-read", operation1.Id);

            var expectedIdMapping = new Dictionary<string, AnalyzeBatchOperationDetails>()
            {
                { operation0.Id, getResponse0.Value },
                { operation1.Id, getResponse1.Value }
            };
            var idMapping = new Dictionary<string, AnalyzeBatchOperationDetails>();

            await foreach (AnalyzeBatchOperationDetails operation in client.GetAnalyzeBatchResultsAsync("prebuilt-read"))
            {
                if (expectedIdMapping.ContainsKey(operation.ResultId))
                {
                    idMapping.Add(operation.ResultId, operation);
                }

                if (idMapping.Count == expectedIdMapping.Count)
                {
                    break;
                }
            }

            Assert.That(idMapping.Count, Is.EqualTo(expectedIdMapping.Count));

            foreach (string id in expectedIdMapping.Keys)
            {
                Assert.That(idMapping, Contains.Key(id));

                AnalyzeBatchOperationDetails expected = expectedIdMapping[id];
                AnalyzeBatchOperationDetails actual = idMapping[id];

                Assert.That(actual.ResultId, Is.EqualTo(expected.ResultId));
                Assert.That(actual.Status, Is.EqualTo(expected.Status));
                Assert.That(actual.CreatedOn, Is.EqualTo(expected.CreatedOn));
                Assert.That(actual.LastUpdatedOn, Is.EqualTo(expected.LastUpdatedOn));
                Assert.That(actual.PercentCompleted, Is.Null);

                DocumentAssert.AreEqual(actual.Error, expected.Error);
            }
        }

        [RecordedTest]
        public async Task DeleteAnalyzeBatchResult()
        {
            var client = CreateDocumentIntelligenceClient();
            var sourceContainerUri = new Uri(TestEnvironment.BatchSourceBlobSasUrl);
            var resultContainerUri = new Uri(TestEnvironment.BatchResultBlobSasUrl);
            var blobSource = new BlobContentSource(sourceContainerUri);
            var options = new AnalyzeBatchDocumentsOptions("prebuilt-read", blobSource, resultContainerUri)
            {
                OverwriteExisting = true
            };

            var operation = await client.AnalyzeBatchDocumentsAsync(WaitUntil.Completed, options);
            var response = await client.DeleteAnalyzeBatchResultAsync("prebuilt-read", operation.Id);

            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        private void ValidateAcordAnalyzeBatchResult(AnalyzeBatchResult result)
        {
            Assert.That(result.SucceededCount, Is.EqualTo(6));
            Assert.That(result.FailedCount, Is.EqualTo(0));
            Assert.That(result.SkippedCount, Is.EqualTo(0));

            string expectedSourcePrefix = string.Empty;
            string expectedResultPrefix = string.Empty;

            // We can't validate this in Playback mode since these environment variables
            // are not stored when recording.

            if (Mode == RecordedTestMode.Live)
            {
                int sourceQueryStart = TestEnvironment.BatchSourceBlobSasUrl.IndexOf('?');
                int resultQueryStart = TestEnvironment.BatchResultBlobSasUrl.IndexOf('?');

                expectedSourcePrefix = (sourceQueryStart == -1)
                    ? TestEnvironment.BatchSourceBlobSasUrl
                    : TestEnvironment.BatchSourceBlobSasUrl.Substring(0, sourceQueryStart);

                expectedResultPrefix = (resultQueryStart == -1)
                    ? TestEnvironment.BatchResultBlobSasUrl
                    : TestEnvironment.BatchResultBlobSasUrl.Substring(0, resultQueryStart);
            }

            foreach (var details in result.Details)
            {
                Assert.That(details.SourceUri.AbsoluteUri, Does.StartWith(expectedSourcePrefix));
                Assert.That(details.ResultUri.AbsoluteUri, Does.StartWith(expectedResultPrefix));
                Assert.That(details.Status, Is.EqualTo(DocumentIntelligenceOperationStatus.Succeeded));
                Assert.That(details.Error, Is.Null);
            }
        }
    }
}
