// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class OperationsMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso-textanalytics.cognitiveservices.azure.com/";
        private static readonly string s_apiKey = "FakeapiKey";

        public OperationsMockTests(bool isAsync) : base(isAsync)
        {
        }

        private TextAnalyticsClient CreateTestClient(HttpPipelineTransport transport)
        {
            var options = new TextAnalyticsClientOptions()
            {
                Transport = transport
            };

            return new TextAnalyticsClient(new Uri(s_endpoint), new AzureKeyCredential(s_apiKey), options);
        }

        #region Analyze

        [Test]
        public async Task CreateAnalyzeOperationConvenienceSetsOperationId()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla.",
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "My cat and my dog might need to see a veterinarian."
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);

            OperationContinuationToken continuationToken = OperationContinuationToken.Deserialize(operation.Id);

            Assert.IsNull(continuationToken.ShowStats);
            Assert.AreEqual("2a96a91f-7edf-4931-a880-3fdee1d56f15", continuationToken.JobId);
            Assert.AreEqual(3, continuationToken.InputDocumentOrder.Count);
            Assert.AreEqual(0, continuationToken.InputDocumentOrder["0"]);
            Assert.AreEqual(1, continuationToken.InputDocumentOrder["1"]);
            Assert.AreEqual(2, continuationToken.InputDocumentOrder["2"]);
        }

        [Test]
        public async Task CreateAnalyzeOperationSetsOperationId()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("134234", "Elon Musk is the CEO of SpaceX and Tesla.")
                {
                     Language = "en",
                },
                new TextDocumentInput("324232", "Tesla stock is up by 400% this year.")
                {
                     Language = "en",
                }
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);

            OperationContinuationToken continuationToken = OperationContinuationToken.Deserialize(operation.Id);

            Assert.IsNull(continuationToken.ShowStats);
            Assert.AreEqual("2a96a91f-7edf-4931-a880-3fdee1d56f15", continuationToken.JobId);
            Assert.AreEqual(2, continuationToken.InputDocumentOrder.Count);
            Assert.AreEqual(0, continuationToken.InputDocumentOrder["134234"]);
            Assert.AreEqual(1, continuationToken.InputDocumentOrder["324232"]);
        }

        [Test]
        public void CreateAnalyzeOperationFromFakeValidOperationId()
        {
            var jobId = "2a96a91f-7edf-4931-a880-3fdee1d56f15";

            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", $"something/jobs/{jobId}?api-version=myVersion"));
            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var inputOrder = new Dictionary<string, int>(1) { { "0", 0 } };
            string operationId = OperationContinuationToken.Serialize(jobId, inputOrder, true);

            var operation = new AnalyzeActionsOperation(operationId, client);
            Assert.AreEqual(operationId, operation.Id);
        }

        [Test]
        public void CreateAnalyzeOperationWrongOperationId()
        {
            var client = CreateTestClient(new MockTransport());

            var ex = Assert.Throws<ArgumentException>(() => new AnalyzeActionsOperation("2a96a91f-7edf-4931-a880-3fdee1d56f15", client));
            Assert.IsInstanceOf<FormatException>(ex.InnerException);
        }

        [Test]
        public void CreateAnalyzeOperationWrongTokenVersion()
        {
            var client = CreateTestClient(new MockTransport());
            var order = new Dictionary<string, int>() { { "0", 0 } };

            var token = new OperationContinuationToken("2a96a91f-7edf-4931-a880-3fdee1d56f15", order, null);
            token.Version = "wrong-version";

            string operationId = token.Serialize();

            var ex = Assert.Throws<ArgumentException>(() => new AnalyzeActionsOperation(operationId, client));
            Assert.IsInstanceOf<ArgumentException>(ex.InnerException);
        }

        [Test]
        public void CreateAnalyzeOperationMissingJobId()
        {
            var client = CreateTestClient(new MockTransport());
            var order = new Dictionary<string, int>() { { "0", 0 } };

            string operationId = OperationContinuationToken.Serialize(null, order, null);

            var ex = Assert.Throws<ArgumentException>(() => new AnalyzeActionsOperation(operationId, client));
            Assert.IsInstanceOf<ArgumentNullException>(ex.InnerException);
        }

        [Test]
        public void CreateAnalyzeOperationMissingDocumentOrder()
        {
            var client = CreateTestClient(new MockTransport());
            var order = new Dictionary<string, int>();

            var token = new OperationContinuationToken("2a96a91f-7edf-4931-a880-3fdee1d56f15", order, null);
            token.InputDocumentOrder = null;

            string operationId = token.Serialize();

            var ex = Assert.Throws<ArgumentException>(() => new AnalyzeActionsOperation(operationId, client));
            Assert.IsInstanceOf<ArgumentNullException>(ex.InnerException);
        }

        [Test]
        public async Task CancelAnalyzeOperation()
        {
            RequestUriBuilder actionUri = new();
            actionUri.Reset(new Uri(s_endpoint));
            actionUri.Path = "/language/analyze-text/jobs";

            RequestUriBuilder statusUri = new();
            statusUri.Reset(new Uri(s_endpoint));
            statusUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234";

            RequestUriBuilder cancelUri = new();
            cancelUri.Reset(new Uri(s_endpoint));
            cancelUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234:cancel";

            ConcurrentQueue<(MockRequest Request, MockResponse Response)> messages = new(new[]
            {
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = actionUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""running"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":1}}")
                ),
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = cancelUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""cancelled"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":0}}")
                ),
            });

            MockTransport transport = new(request =>
            {
                if (!messages.TryDequeue(out (MockRequest Request, MockResponse Response) message))
                {
                    throw new AssertionException($"No more response for request to {request.Method} {request.Uri}");
                }

                if (RequestComparer.Shared.Equals(message.Request, request))
                {
                    return message.Response;
                }

                throw new AssertionException($"Request to {request.Method} {request.Uri} does not match queued request to {message.Request.Method} {message.Request.Uri}");
            })
            {
                ExpectSyncPipeline = !IsAsync,
            };

            TextAnalyticsClient client = InstrumentClient(CreateTestClient(transport));
            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(new[] { "100mg ibuprofen" }, new TextAnalyticsActions { AnalyzeHealthcareEntitiesActions = new[] { new AnalyzeHealthcareEntitiesAction() } }, "en");

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
                await operation.CancelAsync();

                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
            else
            {
                operation.UpdateStatus();
                operation.Cancel();

                RequestFailedException ex = Assert.Throws<RequestFailedException>(() => operation.WaitForCompletion());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
        }

        #endregion Analyze

        #region Healthcare

        [Test]
        public async Task CreateHealthcareOperationConvenienceSetsOperationId()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure."
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents);

            OperationContinuationToken continuationToken = OperationContinuationToken.Deserialize(operation.Id);

            Assert.IsFalse(continuationToken.ShowStats);
            Assert.AreEqual("2a96a91f-7edf-4931-a880-3fdee1d56f15", continuationToken.JobId);
            Assert.AreEqual(2, continuationToken.InputDocumentOrder.Count);
            Assert.AreEqual(0, continuationToken.InputDocumentOrder["0"]);
            Assert.AreEqual(1, continuationToken.InputDocumentOrder["1"]);
        }

        [Test]
        public async Task CreateHealthcareOperationSetsOperationId()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", "something/jobs/2a96a91f-7edf-4931-a880-3fdee1d56f15?api-version=myVersion"));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("134234", "Subject is taking 100mg of ibuprofen twice daily")
                {
                     Language = "en",
                },
                new TextDocumentInput("324232", "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure.")
                {
                     Language = "en",
                }
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents);

            OperationContinuationToken continuationToken = OperationContinuationToken.Deserialize(operation.Id);

            Assert.IsFalse(continuationToken.ShowStats);
            Assert.AreEqual("2a96a91f-7edf-4931-a880-3fdee1d56f15", continuationToken.JobId);
            Assert.AreEqual(2, continuationToken.InputDocumentOrder.Count);
            Assert.AreEqual(0, continuationToken.InputDocumentOrder["134234"]);
            Assert.AreEqual(1, continuationToken.InputDocumentOrder["324232"]);
        }

        [Test]
        public void CreateHealthcareOperationFromFakeValidOperationId()
        {
            var jobId = "2a96a91f-7edf-4931-a880-3fdee1d56f15";

            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader("Operation-Location", $"something/jobs/{jobId}?api-version=myVersion"));
            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var client = CreateTestClient(mockTransport);

            var inputOrder = new Dictionary<string, int>(1) { { "0", 0 } };
            string operationId = OperationContinuationToken.Serialize(jobId, inputOrder, true);

            var operation = new AnalyzeHealthcareEntitiesOperation(operationId, client);
            Assert.AreEqual(operationId, operation.Id);
        }

        [Test]
        public void CreateHealthcareOperationWrongOperationId()
        {
            var client = CreateTestClient(new MockTransport());

            var ex = Assert.Throws<ArgumentException>(() => new AnalyzeHealthcareEntitiesOperation("2a96a91f-7edf-4931-a880-3fdee1d56f15", client));
            Assert.IsInstanceOf<FormatException>(ex.InnerException);
        }

        [Test]
        public void CreateHealthcareOperationWrongTokenVersion()
        {
            var client = CreateTestClient(new MockTransport());
            var order = new Dictionary<string, int>() { { "0", 0 } };

            var token = new OperationContinuationToken("2a96a91f-7edf-4931-a880-3fdee1d56f15", order, null);
            token.Version = "wrong-version";

            string operationId = token.Serialize();

            var ex = Assert.Throws<ArgumentException>(() => new AnalyzeHealthcareEntitiesOperation(operationId, client));
            Assert.IsInstanceOf<ArgumentException>(ex.InnerException);
        }

        [Test]
        public void CreateHealthcareOperationMissingJobId()
        {
            var client = CreateTestClient(new MockTransport());
            var order = new Dictionary<string, int>() { { "0", 0 } };

            string operationId = OperationContinuationToken.Serialize(null, order, null);

            var ex = Assert.Throws<ArgumentException>(() => new AnalyzeHealthcareEntitiesOperation(operationId, client));
            Assert.IsInstanceOf<ArgumentNullException>(ex.InnerException);
        }

        [Test]
        public void CreateHealthcareOperationMissingDocumentOrder()
        {
            var client = CreateTestClient(new MockTransport());
            var order = new Dictionary<string, int>();

            var token = new OperationContinuationToken("2a96a91f-7edf-4931-a880-3fdee1d56f15", order, null);
            token.InputDocumentOrder = null;

            string operationId = token.Serialize();

            var ex = Assert.Throws<ArgumentException>(() => new AnalyzeHealthcareEntitiesOperation(operationId, client));
            Assert.IsInstanceOf<ArgumentNullException>(ex.InnerException);
        }

        [Test]
        public async Task CancelHealthcareOperation()
        {
            RequestUriBuilder actionUri = new();
            actionUri.Reset(new Uri(s_endpoint));
            actionUri.Path = "/language/analyze-text/jobs";

            RequestUriBuilder statusUri = new();
            statusUri.Reset(new Uri(s_endpoint));
            statusUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234";

            RequestUriBuilder cancelUri = new();
            cancelUri.Reset(new Uri(s_endpoint));
            cancelUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234:cancel";

            ConcurrentQueue<(MockRequest Request, MockResponse Response)> messages = new(new[]
            {
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = actionUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""running"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":1}}")
                ),
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = cancelUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""cancelled"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":0}}")
                ),
            });

            MockTransport transport = new(request =>
            {
                if (!messages.TryDequeue(out (MockRequest Request, MockResponse Response) message))
                {
                    throw new AssertionException($"No more response for request to {request.Method} {request.Uri}");
                }

                if (RequestComparer.Shared.Equals(message.Request, request))
                {
                    return message.Response;
                }

                throw new AssertionException($"Request to {request.Method} {request.Uri} does not match queued request to {message.Request.Method} {message.Request.Uri}");
            })
            {
                ExpectSyncPipeline = !IsAsync,
            };

            TextAnalyticsClient client = InstrumentClient(CreateTestClient(transport));
            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(new[] { "100mg ibuprofen" }, "en");

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
                await operation.CancelAsync();

                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
            else
            {
                operation.UpdateStatus();
                operation.Cancel();

                RequestFailedException ex = Assert.Throws<RequestFailedException>(() => operation.WaitForCompletion());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
        }

        #endregion Healthcare

        #region Recognize Custom Entities

        [Test]
        public async Task CancelRecognizeCustomEntitiesOperation()
        {
            RequestUriBuilder actionUri = new();
            actionUri.Reset(new Uri(s_endpoint));
            actionUri.Path = "/language/analyze-text/jobs";

            RequestUriBuilder statusUri = new();
            statusUri.Reset(new Uri(s_endpoint));
            statusUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234";

            RequestUriBuilder cancelUri = new();
            cancelUri.Reset(new Uri(s_endpoint));
            cancelUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234:cancel";

            ConcurrentQueue<(MockRequest Request, MockResponse Response)> messages = new(new[]
            {
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = actionUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""running"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":1}}")
                ),
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = cancelUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""cancelled"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":0}}")
                ),
            });

            MockTransport transport = new(request =>
            {
                if (!messages.TryDequeue(out (MockRequest Request, MockResponse Response) message))
                {
                    throw new AssertionException($"No more response for request to {request.Method} {request.Uri}");
                }

                if (RequestComparer.Shared.Equals(message.Request, request))
                {
                    return message.Response;
                }

                throw new AssertionException($"Request to {request.Method} {request.Uri} does not match queued request to {message.Request.Method} {message.Request.Uri}");
            })
            {
                ExpectSyncPipeline = !IsAsync,
            };

            TextAnalyticsClient client = InstrumentClient(CreateTestClient(transport));
            RecognizeCustomEntitiesOperation operation = await client.StartRecognizeCustomEntitiesAsync(new[] { "100mg ibuprofen" }, "project", "deployment", "en");

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
                await operation.CancelAsync();

                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
            else
            {
                operation.UpdateStatus();
                operation.Cancel();

                RequestFailedException ex = Assert.Throws<RequestFailedException>(() => operation.WaitForCompletion());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
        }

        #endregion

        #region Single Label Classify

        [Test]
        public async Task CancelSingleLabelClassifyDocumentOperation()
        {
            RequestUriBuilder actionUri = new();
            actionUri.Reset(new Uri(s_endpoint));
            actionUri.Path = "/language/analyze-text/jobs";

            RequestUriBuilder statusUri = new();
            statusUri.Reset(new Uri(s_endpoint));
            statusUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234";

            RequestUriBuilder cancelUri = new();
            cancelUri.Reset(new Uri(s_endpoint));
            cancelUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234:cancel";

            ConcurrentQueue<(MockRequest Request, MockResponse Response)> messages = new(new[]
            {
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = actionUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""running"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":1}}")
                ),
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = cancelUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""cancelled"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":0}}")
                ),
            });

            MockTransport transport = new(request =>
            {
                if (!messages.TryDequeue(out (MockRequest Request, MockResponse Response) message))
                {
                    throw new AssertionException($"No more response for request to {request.Method} {request.Uri}");
                }

                if (RequestComparer.Shared.Equals(message.Request, request))
                {
                    return message.Response;
                }

                throw new AssertionException($"Request to {request.Method} {request.Uri} does not match queued request to {message.Request.Method} {message.Request.Uri}");
            })
            {
                ExpectSyncPipeline = !IsAsync,
            };

            TextAnalyticsClient client = InstrumentClient(CreateTestClient(transport));
            ClassifyDocumentOperation operation = await client.StartSingleLabelClassifyAsync(new[] { "It was the best of times, it was the worst of times." }, "project", "deployment", "en");

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
                await operation.CancelAsync();

                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
            else
            {
                operation.UpdateStatus();
                operation.Cancel();

                RequestFailedException ex = Assert.Throws<RequestFailedException>(() => operation.WaitForCompletion());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
        }

        #endregion

        #region Multi Label Classify

        [Test]
        public async Task CancelMultiLabelClassifyDocumentOperation()
        {
            RequestUriBuilder actionUri = new();
            actionUri.Reset(new Uri(s_endpoint));
            actionUri.Path = "/language/analyze-text/jobs";

            RequestUriBuilder statusUri = new();
            statusUri.Reset(new Uri(s_endpoint));
            statusUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234";

            RequestUriBuilder cancelUri = new();
            cancelUri.Reset(new Uri(s_endpoint));
            cancelUri.Path = "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234:cancel";

            ConcurrentQueue<(MockRequest Request, MockResponse Response)> messages = new(new[]
            {
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = actionUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""running"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":1}}")
                ),
                (
                    new MockRequest { Method = RequestMethod.Post, Uri = cancelUri },
                    new MockResponse(202).WithHeader("operation-location", "/language/analyze-text/jobs/12341234-1234-1234-1234-123412341234")
                ),
                (
                    new MockRequest { Method = RequestMethod.Get, Uri = statusUri },
                    new MockResponse(200).WithContent(@"{""jobId"":""12341234-1234-1234-1234-123412341234"",""status"":""cancelled"",""tasks"":{""total"":1,""completed"":0,""failed"":0,""inProgress"":0}}")
                ),
            });

            MockTransport transport = new(request =>
            {
                if (!messages.TryDequeue(out (MockRequest Request, MockResponse Response) message))
                {
                    throw new AssertionException($"No more response for request to {request.Method} {request.Uri}");
                }

                if (RequestComparer.Shared.Equals(message.Request, request))
                {
                    return message.Response;
                }

                throw new AssertionException($"Request to {request.Method} {request.Uri} does not match queued request to {message.Request.Method} {message.Request.Uri}");
            })
            {
                ExpectSyncPipeline = !IsAsync,
            };

            TextAnalyticsClient client = InstrumentClient(CreateTestClient(transport));
            ClassifyDocumentOperation operation = await client.StartMultiLabelClassifyAsync(new[] { "It was the best of times, it was the worst of times." }, "project", "deployment", "en");

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
                await operation.CancelAsync();

                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
            else
            {
                operation.UpdateStatus();
                operation.Cancel();

                RequestFailedException ex = Assert.Throws<RequestFailedException>(() => operation.WaitForCompletion());
                Assert.That(ex.Message, Contains.Substring("canceled"));
            }
        }

        #endregion
    }
}
