// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
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
        private string DiagnosticNamespace = "Azure.AI.FormRecognizer";

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsMockTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public OperationsMockTests(bool isAsync) : base(isAsync)
        {
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

            await operation.UpdateStatusAsync();

            testListener.AssertScope($"{nameof(RecognizeContentOperation)}.{nameof(RecognizeContentOperation.UpdateStatus)}");
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

            await operation.UpdateStatusAsync();

            testListener.AssertScope($"{nameof(RecognizeReceiptsOperation)}.{nameof(RecognizeReceiptsOperation.UpdateStatus)}");
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

            await operation.UpdateStatusAsync();

            testListener.AssertScope($"{nameof(RecognizeCustomFormsOperation)}.{nameof(RecognizeCustomFormsOperation.UpdateStatus)}");
        }

        [Test]
        public async Task TrainingOperationCreatesDiagnosticScopeOnUpdate()
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"
                {
                    ""modelInfo"": {
                        ""status"": ""creating"",
                        ""modelId"": ""00000000-0000-0000-0000-000000000000""
                    }
                }"));

            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new FormRecognizerClientOptions() { Transport = mockTransport };
            var client = CreateFormTrainingClient(options);

            var operation = new TrainingOperation("00000000-0000-0000-0000-000000000000", client);

            await operation.UpdateStatusAsync();

            testListener.AssertScope($"{nameof(TrainingOperation)}.{nameof(TrainingOperation.UpdateStatus)}");
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

            await operation.UpdateStatusAsync();

            testListener.AssertScope($"{nameof(CopyModelOperation)}.{nameof(CopyModelOperation.UpdateStatus)}");
        }
    }
}
