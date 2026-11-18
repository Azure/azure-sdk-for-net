// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

// search-preview:2026-11-01-preview {
#pragma warning disable SCME0004 // Exercise the experimental multipart convenience APIs.
namespace Azure.Search.Documents.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class SearchFileIngestionMockTests : ClientTestBase
    {
        private const string OperationLocation = "https://fake-search.search.windows.net/knowledgesources('files')/files/operations/op-1?api-version=2026-11-01-preview";

        public SearchFileIngestionMockTests(bool isAsync) : base(isAsync) { }

        private SearchIndexClient CreateClient(MockTransport transport) => InstrumentClient(new SearchIndexClient(
            new Uri("https://fake-search.search.windows.net"), new AzureKeyCredential("fake-api-key"),
            new SearchClientOptions { Transport = transport }));

        private static MockResponse Accepted()
        {
            var response = new MockResponse(202);
            response.AddHeader("Operation-Id", "op-1");
            response.AddHeader("Operation-Location", OperationLocation);
            response.AddHeader("Retry-After", "0");
            response.SetContent("""{"id":"op-1","kind":"knowledgeSourceFileIngestion","status":"Running"}""");
            return response;
        }

        private static MockResponse Status(string json)
        {
            var response = new MockResponse(200);
            response.AddHeader("Retry-After", "0");
            response.SetContent(json);
            return response;
        }

        private async Task<Operation<KnowledgeSourceFile>> Start(SearchIndexClient client, bool replace, WaitUntil waitUntil)
        {
            var metadata = new FileUploadMetadata { FileName = "reports/document.txt", Metadata = { ["category"] = "company" } };
            BinaryData content = BinaryData.FromString("Test document content");
            return replace
                ? await client.IngestKnowledgeSourceFileReplacementAsync(waitUntil, "files", "file-1", new UpdateKnowledgeSourceFileContent(metadata, content))
                : await client.IngestKnowledgeSourceFileMultipartAsync(waitUntil, "files", new UploadKnowledgeSourceFileMultipartContent(metadata, content));
        }

        [TestCase(false, WaitUntil.Started)]
        [TestCase(true, WaitUntil.Started)]
        [TestCase(false, WaitUntil.Completed)]
        [TestCase(true, WaitUntil.Completed)]
        public async Task IngestionPollsToTypedResult(bool replace, WaitUntil waitUntil)
        {
            var responses = new Queue<MockResponse>(new[]
            {
                Accepted(),
                Status("""{"id":"op-1","kind":"knowledgeSourceFileIngestion","status":"Running"}"""),
                Status("""{"id":"op-1","kind":"knowledgeSourceFileIngestion","status":"Succeeded","result":{"fileId":"file-1","fileName":"reports/document.txt","fileSizeBytes":21,"prefix":"reports","metadata":{"category":"company"},"parsingMode":"text","extractionMode":"minimal"}}""")
            });
            string multipart = null;
            var transport = new MockTransport(request =>
            {
                if (request.Method == RequestMethod.Post)
                {
                    using var stream = new MemoryStream();
                    request.Content.WriteTo(stream, CancellationToken.None);
                    multipart = Encoding.UTF8.GetString(stream.ToArray());
                }
                return responses.Dequeue();
            });
            Operation<KnowledgeSourceFile> operation = await Start(CreateClient(transport), replace, waitUntil);

            if (waitUntil == WaitUntil.Started)
            {
                Assert.AreEqual(1, transport.Requests.Count);
                Assert.IsFalse(operation.HasCompleted);
                Assert.IsFalse(operation.HasValue);
                if (IsAsync)
                {
                    await operation.UpdateStatusAsync();
                    Assert.IsFalse(operation.HasCompleted);
                    await operation.UpdateStatusAsync();
                }
                else
                {
                    operation.UpdateStatus();
                    Assert.IsFalse(operation.HasCompleted);
                    operation.UpdateStatus();
                }
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual("file-1", operation.Value.FileId);
            Assert.AreEqual("reports/document.txt", operation.Value.FileName);
            Assert.AreEqual(21, operation.Value.FileSizeBytes);
            Assert.AreEqual("reports", operation.Value.Prefix);
            Assert.AreEqual("company", operation.Value.Metadata["category"]);
            Assert.AreEqual(FileKnowledgeSourceExtractionMode.Minimal, operation.Value.ExtractionMode);
            Assert.AreEqual(3, transport.Requests.Count);
            var initial = transport.Requests.First();
            Assert.AreEqual(RequestMethod.Post, initial.Method);
            Assert.That(Uri.UnescapeDataString(initial.Uri.ToString()), Does.Contain(replace
                ? "/knowledgesources('files')/files('file-1'):ingest"
                : "/knowledgesources('files')/files:ingest"));
            Assert.IsTrue(initial.Headers.TryGetValue("Content-Type", out string contentType));
            Assert.That(contentType, Does.StartWith("multipart/form-data; boundary="));
            Assert.That(multipart, Does.Contain("reports/document.txt"));
            Assert.That(multipart, Does.Contain("Test document content"));
            Assert.That(multipart, Does.Contain("company"));
            foreach (var poll in transport.Requests.Skip(1))
            {
                Assert.AreEqual(RequestMethod.Get, poll.Method);
                Assert.AreEqual(OperationLocation, poll.Uri.ToString());
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task FailedIngestionPreservesServiceError(bool replace)
        {
            var transport = new MockTransport(Accepted(), Status("""
                {"id":"op-1","kind":"knowledgeSourceFileIngestion","status":"Failed","error":{"code":"InvalidFile","message":"File cannot be ingested"}}
                """));
            Operation<KnowledgeSourceFile> operation = await Start(CreateClient(transport), replace, WaitUntil.Started);

            RequestFailedException error = IsAsync
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync())
                : Assert.Throws<RequestFailedException>(() => operation.UpdateStatus());

            Assert.AreEqual("InvalidFile", error.ErrorCode);
            Assert.That(error.Message, Does.Contain("File cannot be ingested"));
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(2, transport.Requests.Count);
        }

        [Test]
        public async Task GetRetainedOperationPreservesTypedStatusAndFileMetadata()
        {
            var transport = new MockTransport(Status("""
                {"id":"op-1","kind":"knowledgeSourceFileIngestion","status":"Succeeded",
                  "result":{"fileId":"file-1","fileName":"reports/document.txt","metadata":{"category":"company"}}}
                """));

            var result = await CreateClient(transport).GetKnowledgeSourceFileIngestionOperationAsync("files", "op-1");

            Assert.AreEqual("op-1", result.Value.Id);
            Assert.AreEqual("Succeeded", result.Value.Status.ToString());
            Assert.AreEqual("file-1", result.Value.Result.FileId);
            Assert.AreEqual("company", result.Value.Result.Metadata["category"]);
            Assert.AreEqual(OperationLocation, transport.Requests.Single().Uri.ToString());
            Assert.AreEqual(RequestMethod.Get, transport.Requests.Single().Method);
        }

        [Test]
        public async Task RetainedOperationsFollowContinuationAndPreserveResultsAndErrors()
        {
            string nextLink = "https://fake-search.search.windows.net/knowledgesources('files')/files/operations?api-version=2026-11-01-preview&continuationToken=next";
            var transport = new MockTransport(
                Status($$$$"""
                    {"value":[{"id":"op-1","kind":"knowledgeSourceFileIngestion","status":"Succeeded","result":{"fileId":"file-1"}}],"@odata.nextLink":"{{{{nextLink}}}}"}
                    """),
                Status("""{"value":[{"id":"op-2","kind":"knowledgeSourceFileIngestion","status":"Failed","error":{"code":"InvalidFile","message":"File cannot be ingested"}}]}"""));
            var client = CreateClient(transport);
            var operations = await client.GetKnowledgeSourceFileIngestionOperationsAsync("files", pageSize: 1).ToEnumerableAsync();

            Assert.AreEqual(2, operations.Count);
            Assert.AreEqual("op-1", operations[0].Id);
            Assert.AreEqual("file-1", operations[0].Result.FileId);
            Assert.AreEqual("op-2", operations[1].Id);
            Assert.AreEqual("InvalidFile", operations[1].Error.Code);
            Assert.That(transport.Requests.First().Uri.ToString(), Does.Contain("pageSize=1"));
            Assert.AreEqual(nextLink, transport.Requests.Last().Uri.ToString());
            Assert.AreEqual(2, transport.Requests.Count);
        }
    }
}
#pragma warning restore SCME0004
// search-preview:2026-11-01-preview }
