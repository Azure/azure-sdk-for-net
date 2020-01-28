// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [ClientTestFixture]
    public class FailureSimulationTransportTests : SyncAsyncTestBase
    {
        public FailureSimulationTransportTests(bool isAsync) : base(isAsync) { }

        [SimulateFailure]
        [TestCase(RecordedTestMode.Live)]
        [TestCase(RecordedTestMode.Record)]
        public async Task TestRetry(RecordedTestMode mode)
        {
            var transport = CreateMockTransport(r => new MockResponse(200));
            var perCallPolicy = new TestPolicy(IsAsync);
            var perRetryPolicy = new TestPolicy(IsAsync);
            var recording = new TestRecording(mode, string.Empty, null, null);
            try
            {
                HttpPipeline pipeline = BuildPipeline(recording, transport, perCallPolicy, perRetryPolicy);

                Response response = IsAsync
                    ? await pipeline.SendRequestAsync(pipeline.CreateRequest(), CancellationToken.None)
                    : pipeline.SendRequest(pipeline.CreateRequest(), CancellationToken.None);

                Assert.AreEqual(200, response.Status);
                Assert.AreEqual(1, perCallPolicy.CallCount);
                Assert.AreEqual(2, perRetryPolicy.CallCount);
            }
            finally
            {
                recording.Dispose(false);
            }
        }

        [TestCase(RecordedTestMode.Live)]
        [TestCase(RecordedTestMode.Record)]
        public async Task NoTestRetry(RecordedTestMode mode)
        {
            var transport = CreateMockTransport(r => new MockResponse(200));
            var perCallPolicy = new TestPolicy(IsAsync);
            var perRetryPolicy = new TestPolicy(IsAsync);
            var recording = new TestRecording(mode, string.Empty, null, null);
            try
            {
                HttpPipeline pipeline = BuildPipeline(recording, transport, perCallPolicy, perRetryPolicy);

                Response response = IsAsync
                    ? await pipeline.SendRequestAsync(pipeline.CreateRequest(), CancellationToken.None)
                    : pipeline.SendRequest(pipeline.CreateRequest(), CancellationToken.None);

                Assert.AreEqual(200, response.Status);
                Assert.AreEqual(1, perCallPolicy.CallCount);
                Assert.AreEqual(1, perRetryPolicy.CallCount);
            }
            finally
            {
                recording.Dispose(false);
            }
        }

        [TestRetry]
        [TestCase(RecordedTestMode.Live)]
        [TestCase(RecordedTestMode.Record)]
        public async Task CustomRetryLogic(RecordedTestMode mode)
        {
            var transport = CreateMockTransport(r => new MockResponse(200));
            var perCallPolicy = new TestPolicy(IsAsync);
            var perRetryPolicy = new TestPolicy(IsAsync);
            var recording = new TestRecording(mode, string.Empty, null, null);
            try
            {
                HttpPipeline pipeline = BuildPipeline(recording, transport, perCallPolicy, perRetryPolicy, new CustomResponseClassifier());

                Request request = pipeline.CreateRequest();

                Response response = IsAsync
                    ? await pipeline.SendRequestAsync(request, CancellationToken.None)
                    : pipeline.SendRequest(request, CancellationToken.None);

                Assert.AreEqual(200, response.Status);
                Assert.AreEqual(1, perCallPolicy.CallCount);
                Assert.AreEqual(1, perRetryPolicy.CallCount);

                perCallPolicy.CallCount = 0;
                perRetryPolicy.CallCount = 0;
                request = pipeline.CreateRequest();
                request.Headers.Add("test-header", "test-value");

                response = IsAsync
                    ? await pipeline.SendRequestAsync(request, CancellationToken.None)
                    : pipeline.SendRequest(request, CancellationToken.None);

                Assert.AreEqual(200, response.Status);
                Assert.AreEqual(1, perCallPolicy.CallCount);
                Assert.AreEqual(2, perRetryPolicy.CallCount);
            }
            finally
            {
                recording.Dispose(false);
            }
        }

        private static HttpPipeline BuildPipeline(TestRecording recording, HttpPipelineTransport transport, HttpPipelinePolicy perCallPolicy, HttpPipelinePolicy perRetryPolicy, ResponseClassifier classifier = null) =>
            HttpPipelineBuilder.Build(recording.InstrumentClientOptions(new TestOptions {Transport = transport}), new[] { perCallPolicy }, new[] { perRetryPolicy }, classifier ?? new ResponseClassifier());

        private class CustomResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(HttpMessage message) => base.IsRetriableResponse(message)  || message.Response.Status == 499;
        }

        private class TestRetryAttribute : SimulateFailureAttribute
        {
            public override bool CanFail(HttpMessage message) => message.Request.ContainsHeader("test-header");

            public override void Fail(HttpMessage message) => message.Response = new MockResponse(499);
        }

        private class TestOptions : ClientOptions { }

        private class TestPolicy : HttpPipelinePolicy
        {
            private readonly bool _isAsync;

            public int CallCount { get; set; }

            public TestPolicy(bool isAsync)
            {
                _isAsync = isAsync;
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                if (_isAsync)
                {
                    CallCount++;
                }

                return ProcessNextAsync(message, pipeline);
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                if (!_isAsync)
                {
                    CallCount++;
                }

                ProcessNext(message, pipeline);
            }
        }
    }
}
