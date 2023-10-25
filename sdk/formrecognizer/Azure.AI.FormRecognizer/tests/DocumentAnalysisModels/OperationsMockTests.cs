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
using Azure.Core.Tests;
using NUnit.Framework;

using TestFile = Azure.AI.FormRecognizer.Tests.TestFile;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of mock tests for the <see cref="Operation{T}"/> subclasses.
    /// </summary>
    public class OperationsMockTests : ClientTestBase
    {
        private const string DiagnosticNamespace = "Azure.AI.FormRecognizer.DocumentAnalysis";

        private const string AnalyzeOperationId = "00000000000000000000000000000000/analyzeResults/00000000000000000000000000000000";

        private const string OperationLocation = "https://fake.cognitiveservices.azure.com/formrecognizer/documentModels/prebuilt-receipt/analyzeResults/15b885e2-ce22-4499-8d89-822e16a1722a?api-version=2023-02-28-preview";

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsMockTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public OperationsMockTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="DocumentAnalysisClient" /> with the specified set of options.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The fake <see cref="DocumentAnalysisClient" />.</returns>
        private DocumentAnalysisClient CreateDocumentAnalysisClient(DocumentAnalysisClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new DocumentAnalysisClientOptions();

            return new DocumentAnalysisClient(fakeEndpoint, fakeCredential, options);
        }

        /// <summary>
        /// Creates a fake <see cref="DocumentModelAdministrationClient" /> with the specified set of options.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The fake <see cref="DocumentAnalysisClient" />.</returns>
        private DocumentModelAdministrationClient CreateDocumentModelAdministrationClient(DocumentAnalysisClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new DocumentAnalysisClientOptions();

            return new DocumentModelAdministrationClient(fakeEndpoint, fakeCredential, options);
        }

        [Test]
        public async Task AnalyzeDocumentOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentAnalysisClient(options);

            var operation = new AnalyzeDocumentOperation(AnalyzeOperationId, client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(AnalyzeDocumentOperation)}.{nameof(AnalyzeDocumentOperation.UpdateStatus)}");
        }

        [Test]
        public async Task AnalyzeDocumentOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentAnalysisClient(options);

            var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, "modelId", uri);
            var sameOperation = new AnalyzeDocumentOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void AnalyzeDocumentOperationArgumentValidation()
        {
            DocumentAnalysisClient client = CreateDocumentAnalysisClient();

            Assert.Throws<ArgumentNullException>(() => new AnalyzeDocumentOperation(null, client));
            Assert.Throws<ArgumentException>(() => new AnalyzeDocumentOperation(string.Empty, client));
            Assert.Throws<ArgumentNullException>(() => new AnalyzeDocumentOperation(AnalyzeOperationId, null));
        }

        [Test]
        public void AnalyzeDocumentWithError()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""status"": ""failed"",
                    ""createdDateTime"": ""2021-09-15T23:39:58Z"",
                    ""lastUpdatedDateTime"": ""2021-09-15T23:40:02Z"",
                    ""error"": {
                        ""code"": ""InvalidSomething"",
                        ""message"": ""Invalid Something."",
                        ""details"": [
                            {
                                ""code"": ""InternalServerError"",
                                ""message"": ""An unexpected error occurred.""
                            },
                            {
                                ""code"": ""InvalidContentDimensions"",
                                ""message"": ""The input image dimensions are out of range. Refer to documentation for supported image dimensions."",
                                ""target"": ""2""
                            }
                        ]
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateDocumentAnalysisClient(new DocumentAnalysisClientOptions() { Transport = mockTransport });

            var operation = new AnalyzeDocumentOperation("prebuilt-businessCard/analyzeResults/642ca81c-7d23-4fc9-a7a0-183d85a84664", client);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync());
            Assert.AreEqual("InvalidSomething", ex.ErrorCode);
            Assert.IsTrue(ex.Message.Contains("Invalid Something."));
            Assert.IsTrue(ex.Message.Contains("AdditionInformation"));
        }

        [Test]
        public async Task BuildDocumentModelOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentModelAdministrationClient(options);

            var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.BuildDocumentModelAsync(WaitUntil.Started, uri, DocumentBuildMode.Neural);
            var sameOperation = new BuildDocumentModelOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void BuildModelWithError()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""operationId"": ""31534618802_bc949c32-9281-4d00-a9c9-ef0080bb1b2a"",
                    ""kind"": ""documentModelBuild"",
                    ""status"": ""failed"",
                    ""createdDateTime"": ""2021-09-15T23:39:58Z"",
                    ""lastUpdatedDateTime"": ""2021-09-15T23:40:02Z"",
                    ""resourceLocation"": ""https://mariari-centraluseuap.cognitiveservices.azure.com/formrecognizer/documentModels/1221528251?api-version=2021-09-30-preview"",
                    ""error"": {
                        ""code"": ""InvalidSomething"",
                        ""message"": ""Invalid Something."",
                        ""details"": [
                            {
                                ""code"": ""InternalServerError"",
                                ""message"": ""An unexpected error occurred.""
                            },
                            {
                                ""code"": ""InvalidContentDimensions"",
                                ""message"": ""The input image dimensions are out of range. Refer to documentation for supported image dimensions."",
                                ""target"": ""2""
                            }
                        ]
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateDocumentModelAdministrationClient(new DocumentAnalysisClientOptions() { Transport = mockTransport } );

            var operation = new BuildDocumentModelOperation("31534618802_bc949c32-9281-4d00-a9c9-ef0080bb1b2a", client);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync());
            Assert.AreEqual("InvalidSomething", ex.ErrorCode);
            Assert.IsTrue(ex.Message.Contains("Invalid Something."));
            Assert.IsTrue(ex.Message.Contains("AdditionInformation"));
        }

        [Test]
        public async Task CopyDocumentModelToOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentModelAdministrationClient(options);

            var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.Blank);
            var target = new DocumentModelCopyAuthorization("resourceId", "resourceRegion", "modelId", uri, "token", default);
            var operation = await client.CopyDocumentModelToAsync(WaitUntil.Started, "modelId", target);
            var sameOperation = new CopyDocumentModelToOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void CopyModelToWithError()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""operationId"": ""31534618802_bc949c32-9281-4d00-a9c9-ef0080bb1b2a"",
                    ""kind"": ""documentModelCopy"",
                    ""status"": ""failed"",
                    ""createdDateTime"": ""2021-09-15T23:39:58Z"",
                    ""lastUpdatedDateTime"": ""2021-09-15T23:40:02Z"",
                    ""resourceLocation"": ""https://mariari-centraluseuap.cognitiveservices.azure.com/formrecognizer/documentModels/1221528251?api-version=2021-09-30-preview"",
                    ""error"": {
                        ""code"": ""InvalidSomething"",
                        ""message"": ""Invalid Something."",
                        ""details"": [
                            {
                                ""code"": ""InternalServerError"",
                                ""message"": ""An unexpected error occurred.""
                            },
                            {
                                ""code"": ""InvalidContentDimensions"",
                                ""message"": ""The input image dimensions are out of range. Refer to documentation for supported image dimensions."",
                                ""target"": ""2""
                            }
                        ]
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateDocumentModelAdministrationClient(new DocumentAnalysisClientOptions() { Transport = mockTransport });

            var operation = new CopyDocumentModelToOperation("31534618802_bc949c32-9281-4d00-a9c9-ef0080bb1b2a", client);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync());
            Assert.AreEqual("InvalidSomething", ex.ErrorCode);
            Assert.IsTrue(ex.Message.Contains("Invalid Something."));
            Assert.IsTrue(ex.Message.Contains("AdditionInformation"));
        }

        [Test]
        public async Task ClassifyDocumentOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentAnalysisClient(options);

            var operation = new ClassifyDocumentOperation(AnalyzeOperationId, client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(ClassifyDocumentOperation)}.{nameof(ClassifyDocumentOperation.UpdateStatus)}");
        }

        [Test]
        public async Task ClassifyDocumentOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentAnalysisClient(options);

            var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.ClassifyDocumentFromUriAsync(WaitUntil.Started, "modelId", uri);
            var sameOperation = new ClassifyDocumentOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public async Task BuildDocumentClassifierOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentModelAdministrationClient(options);

            var operation = new BuildDocumentClassifierOperation(AnalyzeOperationId, client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(BuildDocumentClassifierOperation)}.{nameof(BuildDocumentClassifierOperation.UpdateStatus)}");
        }

        [Test]
        public async Task BuildDocumentClassifierOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentModelAdministrationClient(options);

            var documentTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "documentType", new ClassifierDocumentTypeDetails(null, null) }
            };
            var operation = await client.BuildDocumentClassifierAsync(WaitUntil.Started, documentTypes);
            var sameOperation = new BuildDocumentClassifierOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        private static string GetString(RequestContent content)
        {
            if (content == null)
            {
                return null;
            }

            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private void AssertRequestsAreEqual(MockRequest left, MockRequest right)
        {
            Assert.AreEqual(left.Uri.ToString(), right.Uri.ToString());
            Assert.AreEqual(left.Method, right.Method);
            Assert.AreEqual(GetString(left.Content), GetString(right.Content));

            var leftHeaders = left.Headers.ToDictionary(h => h.Name, h => h.Value);
            var rightHeaders = right.Headers.ToDictionary(h => h.Name, h => h.Value);

            // Removing header excepted to be different for each request.
            leftHeaders.Remove("x-ms-client-request-id");
            rightHeaders.Remove("x-ms-client-request-id");

            CollectionAssert.AreEquivalent(leftHeaders, rightHeaders);
        }
    }
}
