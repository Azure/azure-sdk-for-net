// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests.Models
{
    /// <summary>
    /// The suite of mock tests for the <see cref="Operation{T}"/> subclasses.
    /// </summary>
    public class OperationsMockTests : ClientTestBase
    {
        private const string DiagnosticNamespace = "Azure.AI.FormRecognizer";

        private const string PrebuiltOperationLocation = "https://fake.cognitiveservices.azure.com/formrecognizer/v2.1/layout/analyzeResults/abe0e5a4-1df1-4288-bfd9-334b5ad7cdb3";

        private const string CustomOperationLocation = "https://fake.cognitiveservices.azure.com/formrecognizer/v2.1/custom/models/ceb5aaea-63cf-43f3-99d2-ea0fe1f234d1/analyzeresults/235deffa-cb8a-45d0-8405-df399237de8a";

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsMockTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public OperationsMockTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task RecognizeContentOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var operation = new RecognizeContentOperation("00000000-0000-0000-0000-000000000000", client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(RecognizeContentOperation)}.{nameof(RecognizeContentOperation.UpdateStatus)}");
        }

        [Test]
        public async Task RecognizeContentOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, PrebuiltOperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeContentFromUriAsync(uri);
            var sameOperation = new RecognizeContentOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void RecognizeContentOperationRequiredParameters()
        {
            FormRecognizerClient client = CreateFormRecognizerClient();

            Assert.Throws<ArgumentNullException>(() => new RecognizeContentOperation("00000000 - 0000 - 0000 - 0000 - 000000000000", null));
        }

        [Test]
        public async Task RecognizeReceiptsOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var operation = new RecognizeReceiptsOperation("00000000-0000-0000-0000-000000000000", client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(RecognizeReceiptsOperation)}.{nameof(RecognizeReceiptsOperation.UpdateStatus)}");
        }

        [Test]
        public async Task RecognizeReceiptsOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, PrebuiltOperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeReceiptsFromUriAsync(uri);
            var sameOperation = new RecognizeReceiptsOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void RecognizeReceiptsOperationRequiredParameters()
        {
            FormRecognizerClient client = CreateFormRecognizerClient();

            Assert.Throws<ArgumentNullException>(() => new RecognizeReceiptsOperation("00000000 - 0000 - 0000 - 0000 - 000000000000", null));
        }

        [Test]
        public async Task RecognizeBusinessCardsOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var operation = new RecognizeBusinessCardsOperation("00000000-0000-0000-0000-000000000000", client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(RecognizeBusinessCardsOperation)}.{nameof(RecognizeBusinessCardsOperation.UpdateStatus)}");
        }

        [Test]
        public async Task RecognizeBusinessCardsOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, PrebuiltOperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeBusinessCardsFromUriAsync(uri);
            var sameOperation = new RecognizeBusinessCardsOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void RecognizeBusinessCardsOperationRequiredParameters()
        {
            FormRecognizerClient client = CreateFormRecognizerClient();

            Assert.Throws<ArgumentNullException>(() => new RecognizeBusinessCardsOperation(null, client));
            Assert.Throws<ArgumentException>(() => new RecognizeBusinessCardsOperation(string.Empty, client));
            Assert.Throws<ArgumentNullException>(() => new RecognizeBusinessCardsOperation("00000000 - 0000 - 0000 - 0000 - 000000000000", null));
        }

        [Test]
        public async Task RecognizeInvoicesOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var operation = new RecognizeInvoicesOperation("00000000-0000-0000-0000-000000000000", client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(RecognizeInvoicesOperation)}.{nameof(RecognizeInvoicesOperation.UpdateStatus)}");
        }

        [Test]
        public async Task RecognizeInvoicesOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, PrebuiltOperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeInvoicesFromUriAsync(uri);
            var sameOperation = new RecognizeInvoicesOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void RecognizeInvoicesOperationRequiredParameters()
        {
            FormRecognizerClient client = CreateFormRecognizerClient();

            Assert.Throws<ArgumentNullException>(() => new RecognizeInvoicesOperation(null, client));
            Assert.Throws<ArgumentException>(() => new RecognizeInvoicesOperation(string.Empty, client));
            Assert.Throws<ArgumentNullException>(() => new RecognizeInvoicesOperation("00000000 - 0000 - 0000 - 0000 - 000000000000", null));
        }

        [Test]
        public async Task RecognizeIdentityDocumentsOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var operation = new RecognizeIdentityDocumentsOperation("00000000-0000-0000-0000-000000000000", client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(RecognizeIdentityDocumentsOperation)}.{nameof(RecognizeIdentityDocumentsOperation.UpdateStatus)}");
        }

        [Test]
        public async Task RecognizeIdentityDocumentsOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, PrebuiltOperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeIdentityDocumentsFromUriAsync(uri);
            var sameOperation = new RecognizeIdentityDocumentsOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void RecognizeIdentityDocumentsOperationRequiredParameters()
        {
            FormRecognizerClient client = CreateFormRecognizerClient();

            Assert.Throws<ArgumentNullException>(() => new RecognizeIdentityDocumentsOperation("00000000 - 0000 - 0000 - 0000 - 000000000000", null));
        }

        [Test]
        public async Task RecognizeCustomFormsOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var operation = new RecognizeCustomFormsOperation("00000000-0000-0000-0000-000000000000/analyzeResults/00000000-0000-0000-0000-000000000000", client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(RecognizeCustomFormsOperation)}.{nameof(RecognizeCustomFormsOperation.UpdateStatus)}");
        }

        [Test]
        public async Task RecognizeCustomFormsOperationCanPollFromNewObject()
        {
            using var emptyResponseBody0 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var emptyResponseBody1 = new MemoryStream(Encoding.UTF8.GetBytes("{}"));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = emptyResponseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = emptyResponseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, CustomOperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormRecognizerClient(options);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeCustomFormsFromUriAsync(Guid.NewGuid().ToString(), uri);
            var sameOperation = new RecognizeCustomFormsOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void RecognizeCustomFormsOperationRequiredParameters()
        {
            FormRecognizerClient client = CreateFormRecognizerClient();

            Assert.Throws<ArgumentNullException>(() => new RecognizeCustomFormsOperation(null, client));
            Assert.Throws<ArgumentException>(() => new RecognizeCustomFormsOperation(string.Empty, client));
            Assert.Throws<ArgumentNullException>(() => new RecognizeCustomFormsOperation("00000000 - 0000 - 0000 - 0000 - 000000000000", null));
        }

        [Test]
        public async Task TrainingOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""modelInfo"": {
                        ""status"": ""creating""
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormTrainingClient(options);

            var operation = new TrainingOperation("00000000-0000-0000-0000-000000000000", client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(CreateCustomFormModelOperation)}.{nameof(CreateCustomFormModelOperation.UpdateStatus)}");
        }

        [Test]
        public async Task TrainingOperationCanPollFromNewObject()
        {
            string jsonResponse = """
                {
                    "modelInfo": {
                        "status": "creating"
                    }
                }
                """;
            using var responseBody0 = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse));
            using var responseBody1 = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse));
            using var postResponse = new MockResponse(201);
            using var getResponse0 = new MockResponse(200) { ContentStream = responseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = responseBody1 };

            postResponse.AddHeader(new HttpHeader("Location", CustomOperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormTrainingClient(options);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartTrainingAsync(uri, false);
            var sameOperation = new TrainingOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void TrainingOperationRequiredParameters()
        {
            FormTrainingClient client = CreateFormTrainingClient();

            Assert.Throws<ArgumentNullException>(() => new TrainingOperation("00000000 - 0000 - 0000 - 0000 - 000000000000", null));
        }

        [Test]
        public async Task CreateComposedModelOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""modelInfo"": {
                        ""status"": ""creating""
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormTrainingClient(options);

            var operation = new CreateComposedModelOperation("00000000-0000-0000-0000-000000000000", client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(CreateCustomFormModelOperation)}.{nameof(CreateCustomFormModelOperation.UpdateStatus)}");
        }

        [Test]
        public async Task CreateComposedModelOperationCanPollFromNewObject()
        {
            string jsonResponse = """
                {
                    "modelInfo": {
                        "status": "creating"
                    }
                }
                """;
            using var responseBody0 = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse));
            using var responseBody1 = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse));
            using var postResponse = new MockResponse(201);
            using var getResponse0 = new MockResponse(200) { ContentStream = responseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = responseBody1 };

            postResponse.AddHeader(new HttpHeader("Location", CustomOperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormTrainingClient(options);

            var modelIds = new List<string>() { Guid.NewGuid().ToString() };
            var operation = await client.StartCreateComposedModelAsync(modelIds);
            var sameOperation = new CreateComposedModelOperation(operation.Id, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void CreateComposedModelOperationRequiredParameters()
        {
            FormTrainingClient client = CreateFormTrainingClient();

            Assert.Throws<ArgumentNullException>(() => new CreateComposedModelOperation("00000000 - 0000 - 0000 - 0000 - 000000000000", null));
        }

        [Test]
        public async Task CopyModelOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{}"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormTrainingClient(options);

            var operation = new CopyModelOperation("00000000-0000-0000-0000-000000000000/copyresults/00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000", client);

            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }

            testListener.AssertScope($"{nameof(CopyModelOperation)}.{nameof(CopyModelOperation.UpdateStatus)}");
        }

        [Test]
        public async Task CopyModelOperationCanPollFromNewObject()
        {
            string jsonResponse = """
                {
                    "modelInfo": {
                        "status": "creating"
                    }
                }
                """;
            using var responseBody0 = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse));
            using var responseBody1 = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse));
            using var postResponse = new MockResponse(202);
            using var getResponse0 = new MockResponse(200) { ContentStream = responseBody0 };
            using var getResponse1 = new MockResponse(200) { ContentStream = responseBody1 };

            postResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, CustomOperationLocation));

            var mockTransport = new MockTransport(new[] { postResponse, getResponse0, getResponse1 });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormTrainingClient(options);

            var targetAuth = new CopyAuthorization(Guid.NewGuid().ToString(), string.Empty, 0, string.Empty, string.Empty);
            var operation = await client.StartCopyModelAsync(Guid.NewGuid().ToString(), targetAuth);
            var sameOperation = new CopyModelOperation(operation.Id, targetAuth.ModelId, client);

            await operation.UpdateStatusAsync();
            await sameOperation.UpdateStatusAsync();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            AssertRequestsAreEqual(mockTransport.Requests[1], mockTransport.Requests[2]);
        }

        [Test]
        public void CopyModelOperationRequiredParameters()
        {
            FormTrainingClient client = CreateFormTrainingClient();
            string operationId = "00000000-0000-0000-0000-000000000000/copyresults/00000000-0000-0000-0000-000000000000";
            string targetId = "00000000-0000-0000-0000-000000000000";

            Assert.Throws<ArgumentNullException>(() => new CopyModelOperation(null, targetId, client));
            Assert.Throws<ArgumentException>(() => new CopyModelOperation(string.Empty, targetId, client));
            Assert.Throws<ArgumentNullException>(() => new CopyModelOperation(operationId, targetId, null));
        }

        /// <summary>
        /// Creates a fake <see cref="FormRecognizerClient" /> with the specified set of options.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The fake <see cref="FormRecognizerClient" />.</returns>
        private FormRecognizerClient CreateFormRecognizerClient(FormRecognizerClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new FormRecognizerClientOptions();

            return new FormRecognizerClient(fakeEndpoint, fakeCredential, options);
        }

        /// <summary>
        /// Creates a fake <see cref="FormTrainingClient" /> with the specified set of options.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The fake <see cref="FormTrainingClient" />.</returns>
        private FormTrainingClient CreateFormTrainingClient(FormRecognizerClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new FormRecognizerClientOptions();

            return new FormTrainingClient(fakeEndpoint, fakeCredential, options);
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
