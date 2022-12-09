// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of mock tests for the <see cref="Operation{T}"/> subclasses.
    /// </summary>
    public class OperationsMockTests : ClientTestBase
    {
        private const string DiagnosticNamespace = "Azure.AI.FormRecognizer.DocumentAnalysis";

        private const string AnalyzeOperationId = "00000000000000000000000000000000/analyzeResults/00000000000000000000000000000000";

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
    }
}
