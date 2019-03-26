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
            string correlationId;

            using (var request = pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpVerb.Get, new Uri("https://contoso.a.io"));
                request.AddHeader("Date", "3/26/2019");
                request.AddHeader("Custom-Header", "Value");
                request.Content = HttpPipelineRequestContent.Create(new byte[] {1, 2, 3, 4, 5});
                correlationId = request.CorrelationId;

                var response =  await pipeline.SendRequestAsync(request, CancellationToken.None);

                Assert.AreEqual(500, response.Status);
            }

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 1 &&
                e.Level == EventLevel.Informational &&
                e.EventName == "Request" &&
                GetStringProperty(e, "correlationId").Equals(correlationId) &&
                GetStringProperty(e, "uri").Equals("https://contoso.a.io/") &&
                GetStringProperty(e, "method").Equals("GET") &&
                GetStringProperty(e, "headers").Contains($"Date:3/26/2019{Environment.NewLine}") &&
                GetStringProperty(e, "headers").Contains($"Custom-Header:Value{Environment.NewLine}")
            ));

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 2 &&
                e.Level == EventLevel.Verbose &&
                e.EventName == "RequestContent" &&
                GetStringProperty(e, "correlationId").Equals(correlationId) &&
                ((byte[])GetProperty(e, "content")).SequenceEqual(new byte[] {1, 2 , 3, 4, 5}))
            );

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 5 &&
                e.Level == EventLevel.Informational &&
                e.EventName == "Response" &&
                GetStringProperty(e, "correlationId").Equals(correlationId) &&
                (int)GetProperty(e, "status") == 500 &&
                GetStringProperty(e, "headers").Contains($"Custom-Response-Header:Improved value{Environment.NewLine}")
            ));

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 6 &&
                e.Level == EventLevel.Verbose &&
                e.EventName == "ResponseContent" &&
                GetStringProperty(e, "correlationId").Equals(correlationId) &&
                ((byte[])GetProperty(e, "content")).SequenceEqual(new byte[] {6, 7, 8, 9, 0}))
            );

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 8 &&
                e.Level == EventLevel.Error &&
                e.EventName == "ErrorResponse" &&
                GetStringProperty(e, "correlationId").Equals(correlationId) &&
                (int)GetProperty(e, "status") == 500 &&
                GetStringProperty(e, "headers").Contains($"Custom-Response-Header:Improved value{Environment.NewLine}")
            ));

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 9 &&
                e.Level == EventLevel.Informational &&
                e.EventName == "ErrorResponseContent" &&
                GetStringProperty(e, "correlationId").Equals(correlationId) &&
                ((byte[])GetProperty(e, "content")).SequenceEqual(new byte[] {6, 7, 8, 9, 0}))
            );
        }

        private object GetProperty(EventWrittenEventArgs data, string propName)
            => data.Payload[data.PayloadNames.IndexOf(propName)];

        private string GetStringProperty(EventWrittenEventArgs data, string propName)
            => data.Payload[data.PayloadNames.IndexOf(propName)] as string;
    }
}