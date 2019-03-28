// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Diagnostics;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using Azure.Base.Testing;
using NUnit.Framework;

namespace Azure.Base.Tests
{
    // Avoid running these tests in parallel with anything else that's sharing the event source
    [NonParallelizable]
    public class EventSourceTests: PipelineTestBase
    {
        private readonly TestEventListener _listener = new TestEventListener();

        public EventSourceTests()
        {
            _listener.EnableEvents(HttpPipelineEventSource.Singleton, EventLevel.Verbose);
        }

        [Test]
        public void MatchesNameAndGuid()
        {
            // Arrange & Act
            var eventSourceType = typeof(HttpPipelineEventSource);

            // Assert
            Assert.NotNull(eventSourceType);
            Assert.AreEqual("AzureSDK", EventSource.GetName(eventSourceType));
            Assert.AreEqual(Guid.Parse("1015ab6c-4cd8-53d6-aec3-9b937011fa95"), EventSource.GetGuid(eventSourceType));
            Assert.IsNotEmpty(EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"));
        }

        [Test]
        public async Task SendingRequestProducesEvents()
        {
            var handler = new MockHttpClientHandler(httpRequestMessage => {
                var response = new HttpResponseMessage((HttpStatusCode)500);
                response.Content = new ByteArrayContent(new byte[] {6, 7, 8, 9, 0});
                response.Headers.Add("Custom-Response-Header", "Improved value");
                return Task.FromResult(response);
            });
            var transport = new HttpClientTransport(new HttpClient(handler));
            var options = new HttpPipelineOptions(transport)
            {
                LoggingPolicy = LoggingPolicy.Shared
            };

            var pipeline = options.Build("test", "1.0.0");
            string requestId;

            using (var request = pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpVerb.Get, new Uri("https://contoso.a.io"));
                request.AddHeader("Date", "3/26/2019");
                request.AddHeader("Custom-Header", "Value");
                request.Content = HttpPipelineRequestContent.Create(new byte[] {1, 2, 3, 4, 5});
                requestId = request.RequestId;

                var response =  await pipeline.SendRequestAsync(request, CancellationToken.None);

                Assert.AreEqual(500, response.Status);
            }

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 1 &&
                e.Level == EventLevel.Informational &&
                e.EventName == "Request" &&
                e.GetProperty<string>("requestId").Equals(requestId) &&
                e.GetProperty<string>("uri").Equals("https://contoso.a.io/") &&
                e.GetProperty<string>("method").Equals("GET") &&
                e.GetProperty<string>("headers").Contains($"Date:3/26/2019{Environment.NewLine}") &&
                e.GetProperty<string>("headers").Contains($"Custom-Header:Value{Environment.NewLine}")
            ));

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 2 &&
                e.Level == EventLevel.Verbose &&
                e.EventName == "RequestContent" &&
                e.GetProperty<string>("requestId").Equals(requestId) &&
                e.GetProperty<byte[]>("content").SequenceEqual(new byte[] {1, 2 , 3, 4, 5}))
            );

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 5 &&
                e.Level == EventLevel.Informational &&
                e.EventName == "Response" &&
                e.GetProperty<string>("requestId").Equals(requestId) &&
                e.GetProperty<int>("status")  == 500 &&
                e.GetProperty<string>("headers").Contains($"Custom-Response-Header:Improved value{Environment.NewLine}")
            ));

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 6 &&
                e.Level == EventLevel.Verbose &&
                e.EventName == "ResponseContent" &&
                e.GetProperty<string>("requestId").Equals(requestId) &&
                e.GetProperty<byte[]>("content").SequenceEqual(new byte[] {6, 7, 8, 9, 0}))
            );

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 8 &&
                e.Level == EventLevel.Error &&
                e.EventName == "ErrorResponse" &&
                e.GetProperty<string>("requestId").Equals(requestId) &&
                e.GetProperty<int>("status") == 500 &&
                e.GetProperty<string>("headers").Contains($"Custom-Response-Header:Improved value{Environment.NewLine}")
            ));

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 9 &&
                e.Level == EventLevel.Informational &&
                e.EventName == "ErrorResponseContent" &&
                e.GetProperty<string>("requestId").Equals(requestId) &&
                e.GetProperty<byte[]>("content").SequenceEqual(new byte[] {6, 7, 8, 9, 0}))
            );
        }
    }
}