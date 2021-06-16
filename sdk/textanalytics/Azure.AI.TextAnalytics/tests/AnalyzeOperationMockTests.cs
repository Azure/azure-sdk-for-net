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
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class AnalyzeOperationMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso-textanalytics.cognitiveservices.azure.com/";
        private static readonly string s_apiKey = "FakeapiKey";

        public AnalyzeOperationMockTests(bool isAsync) : base(isAsync)
        {
        }

        private TextAnalyticsClient CreateTestClient(HttpPipelineTransport transport)
        {
            var options = new TextAnalyticsClientOptions
            {
                Transport = transport
            };

            var client = new TextAnalyticsClient(new Uri(s_endpoint), new AzureKeyCredential(s_apiKey), options);

            return client;
        }

        [Test]
        public async Task AnalyzeOperationKeyPhrasesWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var actions = new ExtractKeyPhrasesAction()
            {
                DisableServiceLogs = true
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

            var expectedContent = "loggingOptOut\":true";
            Assert.AreEqual(expectedContent, logging);
        }

        [Test]
        public async Task AnalyzeOperationRecognizeEntitiesWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var actions = new RecognizeEntitiesAction()
            {
                DisableServiceLogs = true
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

            var expectedContent = "loggingOptOut\":true";
            Assert.AreEqual(expectedContent, logging);
        }

        [Test]
        public async Task AnalyzeOperationRecognizeLinkedEntitiesWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var actions = new RecognizeLinkedEntitiesAction()
            {
                DisableServiceLogs = true
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeLinkedEntitiesActions = new List<RecognizeLinkedEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

            var expectedContent = "loggingOptOut\":true";
            Assert.AreEqual(expectedContent, logging);
        }

        [Test]
        public async Task AnalyzeOperationRecognizePiiEntitiesWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var actions = new RecognizePiiEntitiesAction()
            {
                DisableServiceLogs = true
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

            var expectedContent = "loggingOptOut\":true";
            Assert.AreEqual(expectedContent, logging);
        }

        [Test]
        public async Task AnalyzeOperationWithActionsError()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""displayName"": ""AnalyzeOperationBatchWithErrorTest"",
                    ""jobId"": ""75d521bc-c2aa-4d8a-aabe-713e72d53a2d"",
                    ""lastUpdateDateTime"": ""2021-03-03T22:39:37Z"",
                    ""createdDateTime"": ""2021-03-03T22:39:36Z"",
                    ""expirationDateTime"": ""2021-03-04T22:39:36Z"",
                    ""status"": ""succeeded"",
                    ""errors"": [
                      {
                        ""code"": ""InvalidRequest"",
                        ""message"": ""Some error"",
                        ""target"": ""#/tasks/entityRecognitionPiiTasks/0""
                      },
                      {
                        ""code"": ""InvalidRequest"",
                        ""message"": ""Some error"",
                        ""target"": ""#/tasks/entityRecognitionTasks/0""
                      },
                      {
                        ""code"": ""InvalidRequest"",
                        ""message"": ""Some error"",
                        ""target"": ""#/tasks/keyPhraseExtractionTasks/0""
                      },
                      {
                        ""code"": ""InvalidRequest"",
                        ""message"": ""Some error"",
                        ""target"": ""#/tasks/entityLinkingTasks/0""
                      },
                      {
                        ""code"": ""InvalidRequest"",
                        ""message"": ""Some error"",
                        ""target"": ""#/tasks/sentimentAnalysisTasks/0""
                      }
                    ],
                    ""tasks"": {
                      ""details"": {
                        ""name"": ""AnalyzeOperationBatchWithErrorTest"",
                        ""lastUpdateDateTime"": ""2021-03-03T22:39:37Z""
                      },
                      ""completed"": 0,
                      ""failed"": 5,
                      ""inProgress"": 0,
                      ""total"": 5,
                      ""entityRecognitionTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""name"": ""something"",
                          ""state"": ""failed""
                        }
                      ],
                      ""entityRecognitionPiiTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""name"": ""something"",
                          ""state"": ""failed""
                        }
                      ],
                      ""keyPhraseExtractionTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""name"": ""something"",
                          ""state"": ""failed""
                        }
                      ],
                      ""entityLinkingTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""name"": ""something"",
                          ""state"": ""failed""
                        }
                      ],
                      ""sentimentAnalysisTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""name"": ""something"",
                          ""state"": ""failed""
                        }
                      ]
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { new RecognizeEntitiesAction() },
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { new RecognizePiiEntitiesAction() },
                RecognizeLinkedEntitiesActions = new List<RecognizeLinkedEntitiesAction>() { new RecognizeLinkedEntitiesAction() },
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { new AnalyzeSentimentAction() },
                DisplayName = "AnalyzeOperationBatchWithErrorTest"
            };

            var operation = new AnalyzeActionsOperation("75d521bc-c2aa-4d8a-aabe-713e72d53a2d", client);
            await operation.UpdateStatusAsync();

            Assert.AreEqual(5, operation.ActionsFailed);
            Assert.AreEqual(0, operation.ActionsSucceeded);
            Assert.AreEqual(0, operation.ActionsInProgress);
            Assert.AreEqual(5, operation.ActionsTotal);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            RecognizeEntitiesActionResult entitiesActionsResults = resultCollection.RecognizeEntitiesResults.FirstOrDefault();
            ExtractKeyPhrasesActionResult keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults.FirstOrDefault();
            RecognizePiiEntitiesActionResult piiActionsResults = resultCollection.RecognizePiiEntitiesResults.FirstOrDefault();
            RecognizeLinkedEntitiesActionResult entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesResults.FirstOrDefault();
            AnalyzeSentimentActionResult analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults.FirstOrDefault();

            Assert.IsTrue(entitiesActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => entitiesActionsResults.DocumentsResults.GetType());

            Assert.IsTrue(keyPhrasesActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => entitiesActionsResults.DocumentsResults.GetType());

            Assert.IsTrue(piiActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => entitiesActionsResults.DocumentsResults.GetType());

            Assert.IsTrue(entityLinkingActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => entitiesActionsResults.DocumentsResults.GetType());

            Assert.IsTrue(analyzeSentimentActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => entitiesActionsResults.DocumentsResults.GetType());
        }

        private static string GetString(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
