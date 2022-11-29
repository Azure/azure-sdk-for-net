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

namespace Azure.AI.TextAnalytics.Legacy.Tests
{
    public class AnalyzeOperationMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso-textanalytics.cognitiveservices.azure.com/";
        private static readonly string s_apiKey = "FakeapiKey";

        public AnalyzeOperationMockTests(bool isAsync) : base(isAsync)
        {
        }

        private TextAnalyticsClient CreateTestClient(HttpPipelineTransport transport, TextAnalyticsClientOptions.ServiceVersion version = TextAnalyticsClientOptions.ServiceVersion.V3_1, bool instrument = false)
        {
            var options = new TextAnalyticsClientOptions(version)
            {
                Transport = transport
            };

            var client = new TextAnalyticsClient(new Uri(s_endpoint), new AzureKeyCredential(s_apiKey), options);

            if (instrument)
            {
                return InstrumentClient(client);
            }

            return client;
        }

        #region Key phrases

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
        public async Task AnalyzeOperationKeyPhrasesFromRequestOptions()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new TextAnalyticsRequestOptions();

            var actions = new ExtractKeyPhrasesAction(options);

            TextAnalyticsActions batchActions = new()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString);
        }

        [Test]
        public async Task AnalyzeOperationKeyPhrasesFromRequestOptionsFull()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new TextAnalyticsRequestOptions()
            {
                ModelVersion = "latest",
                DisableServiceLogs = true,
                IncludeStatistics = false
            };

            var actions = new ExtractKeyPhrasesAction(options);

            TextAnalyticsActions batchActions = new()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString, true);
        }

        #endregion Key phrases

        #region entities

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
        public async Task AnalyzeOperationRecognizeEntitiesWithRequestOptions()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new TextAnalyticsRequestOptions();

            var actions = new RecognizeEntitiesAction(options);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString);
        }

        [Test]
        public async Task AnalyzeOperationRecognizeEntitiesWithRequestOptionsFull()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new TextAnalyticsRequestOptions()
            {
                ModelVersion = "latest",
                DisableServiceLogs = true,
                IncludeStatistics = false
            };

            var actions = new RecognizeEntitiesAction(options);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString, true);
        }

        #endregion entities

        #region linked entities

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
        public async Task AnalyzeOperationRecognizeLinkedEntitiesWithRequestOptions()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new TextAnalyticsRequestOptions();

            var actions = new RecognizeLinkedEntitiesAction(options);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeLinkedEntitiesActions = new List<RecognizeLinkedEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString);
        }

        [Test]
        public async Task AnalyzeOperationRecognizeLinkedEntitiesWithRequestOptionsFull()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new TextAnalyticsRequestOptions()
            {
                ModelVersion = "latest",
                DisableServiceLogs = true,
                IncludeStatistics = false
            };

            var actions = new RecognizeLinkedEntitiesAction(options);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeLinkedEntitiesActions = new List<RecognizeLinkedEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString, true);
        }

        #endregion linked entities

        #region Pii entities

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
        public async Task AnalyzeOperationRecognizePiiEntitiesWithPiiOptions()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new RecognizePiiEntitiesOptions();

            var actions = new RecognizePiiEntitiesAction(options);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString);
            Assert.AreEqual(-1, contentString.IndexOf("domain"));
            Assert.AreEqual(-1, contentString.IndexOf("piiCategories"));
        }

        [Test]
        public async Task AnalyzeOperationRecognizePiiEntitiesWithPiiOptionsFull()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new RecognizePiiEntitiesOptions()
            {
                ModelVersion = "latest",
                DisableServiceLogs = true,
                IncludeStatistics = true,
                DomainFilter = (TextAnalytics.PiiEntityDomain)PiiEntityDomain.ProtectedHealthInformation,
                CategoriesFilter = { PiiEntityCategory.USSocialSecurityNumber }
            };

            var actions = new RecognizePiiEntitiesAction(options);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString, true);

            string domaintFilter = contentString.Substring(contentString.IndexOf("domain"), 13);

            var expectedDomainFilterContent = "domain\":\"phi\"";
            Assert.AreEqual(expectedDomainFilterContent, domaintFilter);

            string piiCategories = contentString.Substring(contentString.IndexOf("piiCategories"), 41);

            var expectedPiiCategoriesContent = "piiCategories\":[\"USSocialSecurityNumber\"]";
            Assert.AreEqual(expectedPiiCategoriesContent, piiCategories);
        }

        #endregion Pii entities

        #region Analyze sentiment

        [Test]
        public async Task AnalyzeOperationAnalyzeSentimentWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var actions = new AnalyzeSentimentAction()
            {
                DisableServiceLogs = true
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

            var expectedContent = "loggingOptOut\":true";
            Assert.AreEqual(expectedContent, logging);
        }

        [Test]
        public async Task AnalyzeOperationAnalyzeSentimentWithAnalyzeSentimentOptions()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new AnalyzeSentimentOptions();

            var actions = new AnalyzeSentimentAction(options);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString);
            Assert.AreEqual(-1, contentString.IndexOf("opinionMining"));
        }

        [Test]
        public async Task AnalyzeOperationAnalyzeSentimentWithAnalyzeSentimentOptionsFull()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var options = new AnalyzeSentimentOptions()
            {
                ModelVersion = "latest",
                DisableServiceLogs = true,
                IncludeStatistics = true,
                IncludeOpinionMining = true
            };

            var actions = new AnalyzeSentimentAction(options);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            ValidateRequestOptions(contentString, true);

            string opinionMining = contentString.Substring(contentString.IndexOf("opinionMining"), 19);

            var expectedOpinionMiningContent = "opinionMining\":true";
            Assert.AreEqual(expectedOpinionMiningContent, opinionMining);
        }

        #endregion Analyze sentiment

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
                      ""failed"": 9,
                      ""inProgress"": 0,
                      ""total"": 9,
                      ""entityRecognitionTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""taskName"": ""something"",
                          ""state"": ""failed""
                        }
                      ],
                      ""entityRecognitionPiiTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""taskName"": ""something"",
                          ""state"": ""failed""
                        }
                      ],
                      ""keyPhraseExtractionTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""taskName"": ""something"",
                          ""state"": ""failed""
                        }
                      ],
                      ""entityLinkingTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""taskName"": ""something"",
                          ""state"": ""failed""
                        }
                      ],
                      ""sentimentAnalysisTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""taskName"": ""something"",
                          ""state"": ""failed""
                        }
                      ]
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            AnalyzeActionsOperation operation = CreateOperation(client);
            await operation.UpdateStatusAsync();

            Assert.AreEqual(9, operation.ActionsFailed);
            Assert.AreEqual(0, operation.ActionsSucceeded);
            Assert.AreEqual(0, operation.ActionsInProgress);
            Assert.AreEqual(9, operation.ActionsTotal);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            RecognizeEntitiesActionResult entitiesActionsResults = resultCollection.RecognizeEntitiesResults.FirstOrDefault();
            ExtractKeyPhrasesActionResult keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults.FirstOrDefault();
            RecognizePiiEntitiesActionResult piiActionsResults = resultCollection.RecognizePiiEntitiesResults.FirstOrDefault();
            RecognizeLinkedEntitiesActionResult entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesResults.FirstOrDefault();
            AnalyzeSentimentActionResult analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults.FirstOrDefault();
            RecognizeCustomEntitiesActionResult recognizeCustomEntitiesActionResults = resultCollection.RecognizeCustomEntitiesResults.FirstOrDefault();
            SingleLabelClassifyActionResult singleLabelClassifyActionResult = resultCollection.SingleLabelClassifyResults.FirstOrDefault();
            MultiLabelClassifyActionResult multiLabelClassifyActionResult = resultCollection.MultiLabelClassifyResults.FirstOrDefault();

            Assert.IsTrue(entitiesActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => entitiesActionsResults.DocumentsResults.GetType());

            Assert.IsTrue(keyPhrasesActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => keyPhrasesActionsResults.DocumentsResults.GetType());

            Assert.IsTrue(piiActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => piiActionsResults.DocumentsResults.GetType());

            Assert.IsTrue(entityLinkingActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => entityLinkingActionsResults.DocumentsResults.GetType());

            Assert.IsTrue(analyzeSentimentActionsResults.HasError);
            Assert.Throws<InvalidOperationException>(() => analyzeSentimentActionsResults.DocumentsResults.GetType());
        }

        [Test]
        public void AnalyzeOperationWithGenericError()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""displayName"": ""AnalyzeOperationBatchWithErrorTest"",
                    ""jobId"": ""75d521bc-c2aa-4d8a-aabe-713e72d53a2d"",
                    ""lastUpdateDateTime"": ""2021-03-03T22:39:37Z"",
                    ""createdDateTime"": ""2021-03-03T22:39:36Z"",
                    ""expirationDateTime"": ""2021-03-04T22:39:36Z"",
                    ""status"": ""failed"",
                    ""errors"": [
                      {
                        ""code"": ""InternalServerError"",
                        ""message"": ""Some error""
                      }
                    ],
                    ""tasks"": {
                      ""details"": {
                        ""name"": ""AnalyzeOperationBatchWithErrorTest"",
                        ""lastUpdateDateTime"": ""2021-03-03T22:39:37Z""
                      },
                      ""completed"": 0,
                      ""failed"": 1,
                      ""inProgress"": 0,
                      ""total"": 1,
                      ""entityRecognitionTasks"": [
                        {
                          ""lastUpdateDateTime"": ""2021-03-03T22:39:37.1716697Z"",
                          ""taskName"": ""something"",
                          ""state"": ""failed""
                        }
                      ]
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);

            var operation = CreateOperation(client);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync());
            Assert.AreEqual("InternalServerError", ex.ErrorCode);
            Assert.IsTrue(ex.Message.Contains("Some error"));
        }

        [Test]
        public void AnalyzeActionsNotSupported()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = CreateTestClient(new MockTransport(), TextAnalyticsClientOptions.ServiceVersion.V3_0, true);
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeActionsAsync(new[] { "test" }, new TextAnalyticsActions
            {
                AnalyzeSentimentActions = new[]
                {
                    new AnalyzeSentimentAction(),
                },
            }));

            if (IsAsync)
            {
                Assert.AreEqual("TextAnalyticsClient.StartAnalyzeActionsAsync is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
            else
            {
                Assert.AreEqual("TextAnalyticsClient.StartAnalyzeActions is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
        }

        [Test]
        public void RecognizePiiEntitiesNotSupported()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = CreateTestClient(new MockTransport(), TextAnalyticsClientOptions.ServiceVersion.V3_0, true);
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.RecognizePiiEntitiesAsync("test"));

            if (IsAsync)
            {
                Assert.AreEqual("TextAnalyticsClient.RecognizePiiEntitiesAsync is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
            else
            {
                Assert.AreEqual("TextAnalyticsClient.RecognizePiiEntities is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
        }

        [Test]
        public void RecognizePiiEntitiesBatchNotSupported()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = CreateTestClient(new MockTransport(), TextAnalyticsClientOptions.ServiceVersion.V3_0, true);
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.RecognizePiiEntitiesBatchAsync(new[] { "test" }));

            if (IsAsync)
            {
                Assert.AreEqual("TextAnalyticsClient.RecognizePiiEntitiesBatchAsync is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
            else
            {
                Assert.AreEqual("TextAnalyticsClient.RecognizePiiEntitiesBatch is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
        }

        [Test]
        public void StartAnalyzeHealthcareEntitiesNotSupported()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = CreateTestClient(new MockTransport(), TextAnalyticsClientOptions.ServiceVersion.V3_0, true);
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeHealthcareEntitiesAsync(new[] { "test" }));

            if (IsAsync)
            {
                Assert.AreEqual("TextAnalyticsClient.StartAnalyzeHealthcareEntitiesAsync is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
            else
            {
                Assert.AreEqual("TextAnalyticsClient.StartAnalyzeHealthcareEntities is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
        }

        private static string GetString(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private static void ValidateRequestOptions(string contentString, bool full = false)
        {
            if (!full)
            {
                Assert.AreEqual(-1, contentString.IndexOf("loggingOptOut"));
                Assert.AreEqual(-1, contentString.IndexOf("model-version"));
                Assert.AreEqual(-1, contentString.IndexOf("show-stats"));
            }
            else
            {
                string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

                var expectedContent = "loggingOptOut\":true";
                Assert.AreEqual(expectedContent, logging);

                string modelVersion = contentString.Substring(contentString.IndexOf("model-version"), 23);

                var expectedModelVersionContent = "model-version\":\"latest\"";
                Assert.AreEqual(expectedModelVersionContent, modelVersion);

                Assert.AreEqual(-1, contentString.IndexOf("show-stats"));
            }
        }

        private AnalyzeActionsOperation CreateOperation(TextAnalyticsClient client)
        {
            var inputOrder = new Dictionary<string, int>(1) { { "0", 0 } };
            var operationId = OperationContinuationToken.Serialize("75d521bc-c2aa-4d8a-aabe-713e72d53a2d", inputOrder, null);

            return new AnalyzeActionsOperation(operationId, client);
        }
    }
}
