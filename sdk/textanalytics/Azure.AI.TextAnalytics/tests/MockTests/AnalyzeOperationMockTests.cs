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
        private static readonly string FakeProjectName = "FakeProjectName";
        private static readonly string FakeDeploymentName = "FakeDeploymentName";

        public AnalyzeOperationMockTests(bool isAsync) : base(isAsync)
        {
        }

        private TextAnalyticsClient CreateTestClient(HttpPipelineTransport transport)
        {
            var options = new TextAnalyticsClientOptions()
            {
                Transport = transport
            };

            var client = new TextAnalyticsClient(new Uri(s_endpoint), new AzureKeyCredential(s_apiKey), options);

            return client;
        }

        #region Key phrases

        [Test]
        public async Task AnalyzeOperationKeyPhrasesWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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

        #region Custom Entities

        [Test]
        public async Task AnalyzeOperationRecognizeCustomEntitiesWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var actions = new RecognizeCustomEntitiesAction(FakeProjectName, FakeDeploymentName)
            {
                DisableServiceLogs = true
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

            var expectedContent = "loggingOptOut\":true";
            Assert.AreEqual(expectedContent, logging);
        }
        #endregion

        #region linked entities

        [Test]
        public async Task AnalyzeOperationRecognizeLinkedEntitiesWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

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

        #region Multi Label Classify

        [Test]
        public async Task AnalyzeOperationMultiLabelClassifyWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var actions = new MultiLabelClassifyAction(FakeProjectName, FakeDeploymentName)
            {
                DisableServiceLogs = true
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

            var expectedContent = "loggingOptOut\":true";
            Assert.AreEqual(expectedContent, logging);
        }
        #endregion

        #region Single Label Classify

        [Test]
        public async Task AnalyzeOperationLabelCategoryClassifyWithDisableServiceLogs()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla."
            };

            var actions = new SingleLabelClassifyAction(FakeProjectName, FakeDeploymentName)
            {
                DisableServiceLogs = true
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>() { actions },
            };

            await client.StartAnalyzeActionsAsync(documents, batchActions);

            var contentString = GetString(mockTransport.Requests.Single().Content);
            string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

            var expectedContent = "loggingOptOut\":true";
            Assert.AreEqual(expectedContent, logging);
        }
        #endregion

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
                Assert.AreEqual(-1, contentString.IndexOf("modelVersion"));
            }
            else
            {
                string logging = contentString.Substring(contentString.IndexOf("loggingOptOut"), 19);

                var expectedContent = "loggingOptOut\":true";
                Assert.AreEqual(expectedContent, logging);

                string modelVersion = contentString.Substring(contentString.IndexOf("modelVersion"), 22);

                var expectedModelVersionContent = "modelVersion\":\"latest\"";
                Assert.AreEqual(expectedModelVersionContent, modelVersion);
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
