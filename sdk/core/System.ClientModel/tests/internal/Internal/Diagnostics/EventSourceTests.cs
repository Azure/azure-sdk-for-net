// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.Diagnostics
{
    // Avoid running these tests in parallel with anything else that's sharing the event source
    [NonParallelizable]
    public class EventSourceTests : SyncAsyncPolicyTestBase
    {
        private const int BackgroundRefreshFailedEvent = 19;
        private const int RequestEvent = 1;
        private const int RequestContentEvent = 2;
        private const int RequestContentTextEvent = 17;
        private const int ResponseEvent = 5;
        private const int ResponseContentEvent = 6;
        private const int ResponseContentBlockEvent = 11;
        private const int ErrorResponseEvent = 8;
        private const int ErrorResponseContentEvent = 9;
        private const int ErrorResponseContentBlockEvent = 12;
        private const int ResponseContentTextEvent = 13;
        private const int ResponseContentTextBlockEvent = 15;
        private const int ErrorResponseContentTextEvent = 14;
        private const int ErrorResponseContentTextBlockEvent = 16;
        private const int ExceptionResponseEvent = 18;

        private TestEventListener _listener;

        private static List<string> s_allowedHeaders = new List<string> (new[] { "Date", "Custom-Header", "Custom-Response-Header" });
        private static List<string> s_allowedQueryParameters = new List<string>(new[] { "api-version" });
        private static PipelineMessageSanitizer _sanitizer = new PipelineMessageSanitizer(s_allowedQueryParameters, s_allowedHeaders);

        public EventSourceTests(bool isAsync) : base(isAsync)
        {
            _listener = new TestEventListener();
            _listener.EnableEvents(ClientModelEventSource.Singleton, EventLevel.Verbose);
        }

        [TearDown]
        public void TearDown()
        {
            _listener?.Dispose();
        }

        [Test]
        public void MatchesNameAndGuid()
        {
            Type eventSourceType = typeof(ClientModelEventSource);

            Assert.NotNull(eventSourceType);
            Assert.AreEqual("System-ClientModel", EventSource.GetName(eventSourceType));
            Assert.AreEqual(Guid.Parse("842b4f87-415e-57bf-4ed4-434dce4701d4"), EventSource.GetGuid(eventSourceType));
            Assert.IsNotEmpty(EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"));
        }

        [Test]
        public async Task SendingRequestProducesEvents()
        {
            var response = new MockResponse(200);
            response.SetContent("Hello, world!");
            response.AddHeader("Custom-Response-Header", "Value");

            ClientPipelineOptions options = new()
            {
                Transport = new MockPipelineTransport("Transport", i => 200),
            };

            ClientPipeline pipeline = ClientPipeline.Create(options);

            PipelineMessage message = pipeline.CreateMessage();
            message.Request.Method = "Get";
            message.Request.Uri = new Uri("http://example.com");
            message.Request.Headers.Add("Custom-Header", "Value");
            message.Request.Headers.Add("Date", "3/28/2024");
            message.Request.Content= BinaryContent.Create(new BinaryData("Hello, world!"));
            message.Request.Headers.Add("x-client-id", "client-id");

            await pipeline.SendSyncOrAsync(message, IsAsync);

            EventWrittenEventArgs args = _listener.SingleEventById(RequestEvent);
            Assert.AreEqual(EventLevel.Informational, args.Level);
        }
    }
}
