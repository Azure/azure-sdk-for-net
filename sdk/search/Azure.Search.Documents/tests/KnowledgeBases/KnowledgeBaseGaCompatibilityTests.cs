// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    [TestFixture(false)]
    [TestFixture(true)]
    public class KnowledgeBaseGaCompatibilityTests : ClientTestBase
    {
        public KnowledgeBaseGaCompatibilityTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task GaRetrieveSignaturesSendAuthorization(bool protocol)
        {
            var transport = new MockTransport(SearchTestHelpers.CreateMockJsonResponse(200,
                "{\"response\":[],\"references\":[],\"activity\":[]}"));
            var client = InstrumentClient(new KnowledgeBaseRetrievalClient(
                new Uri("https://fake-search.search.windows.net"), "knowledge-base",
                new AzureKeyCredential("fake-key"), new SearchClientOptions { Transport = transport }));
            using var cancellation = new CancellationTokenSource();

            if (protocol)
            {
                using RequestContent content = RequestContent.Create(new { });
                await client.RetrieveAsync(content, "user-token", new RequestContext
                {
                    CancellationToken = cancellation.Token
                });
            }
            else
            {
                await client.RetrieveAsync(new KnowledgeBaseRetrievalRequest(), "user-token", cancellation.Token);
            }

            Assert.IsTrue(transport.Requests.Single().Headers.TryGetValue(
                "x-ms-query-source-authorization", out string authorization));
            Assert.AreEqual("user-token", authorization);
        }

        [Test]
        public void BaseStreamEventRetainsModelReaderWriterBehavior()
        {
            KnowledgeBaseRetrievalStreamEvent streamEvent = ModelReaderWriter.Read<KnowledgeBaseRetrievalStreamEvent>(
                BinaryData.FromString("{\"futureProperty\":42}"));
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(streamEvent));
            Assert.AreEqual(42, document.RootElement.GetProperty("futureProperty").GetInt32());

            KnowledgeBaseRetrievalStreamEvent factoryEvent = SearchModelFactory.KnowledgeBaseRetrievalStreamEvent();
            Assert.IsNotNull(ModelReaderWriter.Write(factoryEvent));
        }

        [Test]
        public void ReferenceStreamEventRetainsMutableGaCollection()
        {
            var reference = SearchModelFactory.KnowledgeBaseSearchIndexReference("reference-1", 0, null, null, null, null);
            KnowledgeBaseReferencesCompletedStreamEvent streamEvent =
                SearchModelFactory.KnowledgeBaseReferencesCompletedStreamEvent();
            streamEvent.Value.Add(reference);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(streamEvent));
            Assert.AreEqual("reference-1", document.RootElement.GetProperty("value")[0].GetProperty("id").GetString());
        }
    }
}
