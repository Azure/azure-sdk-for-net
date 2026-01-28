// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ProtocolOperationTests
    {
        [Test]
        public void GetRehydrationToken()
        {
            const string OperationId = "oper-ati-oni-d00";
            const string RequestUri = "https://www.example.com/request";
            const string LocationUri = $"https://www.example.com/{OperationId}";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport();
            var pipeline = new HttpPipeline(transport);

            request.Uri.Reset(new Uri(RequestUri));
            response.AddHeader("Location", LocationUri);

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();

            Assert.That(token.HasValue, Is.True);
            Assert.That(token.Value.Id, Is.EqualTo(OperationId));
            Assert.That(token.Value.Version, Is.EqualTo(NextLinkOperationImplementation.RehydrationTokenVersion));
            Assert.That(token.Value.HeaderSource, Is.EqualTo("Location"));
            Assert.That(token.Value.NextRequestUri, Is.EqualTo(LocationUri));
            Assert.That(token.Value.InitialUri, Is.EqualTo(RequestUri));
            Assert.That(token.Value.RequestMethod, Is.EqualTo(RequestMethod.Post));
            Assert.That(token.Value.LastKnownLocation, Is.EqualTo(LocationUri));
            Assert.That(token.Value.FinalStateVia, Is.EqualTo("Location"));
        }

        [Test]
        public void GetRehydrationTokenWithCompletedOperation()
        {
            const string RequestUri = "https://www.example.com/request";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport();
            var pipeline = new HttpPipeline(transport);

            request.Uri.Reset(new Uri(RequestUri));

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();

            Assert.That(token.HasValue, Is.True);
            Assert.That(token.Value.Id, Is.EqualTo("NOT_SET"));
            Assert.That(token.Value.Version, Is.EqualTo(NextLinkOperationImplementation.RehydrationTokenVersion));
            Assert.That(token.Value.HeaderSource, Is.EqualTo("None"));
            Assert.That(token.Value.NextRequestUri, Is.EqualTo(RequestUri));
            Assert.That(token.Value.InitialUri, Is.EqualTo(RequestUri));
            Assert.That(token.Value.RequestMethod, Is.EqualTo(RequestMethod.Post));
            Assert.That(token.Value.LastKnownLocation, Is.Null);
            Assert.That(token.Value.FinalStateVia, Is.EqualTo("Location"));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrationOperationCanPoll(bool isAsync)
        {
            const string RequestUri = "https://www.example.com/request";
            const string LocationUri = "https://www.example.com/oper-ati-oni-d00";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport(response);
            var pipeline = new HttpPipeline(transport);

            request.Uri.Reset(new Uri(RequestUri));
            response.AddHeader("Location", LocationUri);

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();
            _ = isAsync
                ? await Operation.RehydrateAsync(pipeline, token.Value)
                : Operation.Rehydrate(pipeline, token.Value);
            var rehydrationUpdateRequest = transport.SingleRequest;

            Assert.That(rehydrationUpdateRequest.Uri.ToString(), Is.EqualTo(LocationUri));
            Assert.That(rehydrationUpdateRequest.Method, Is.EqualTo(RequestMethod.Get));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrationOperationWithCompletedOperationCanPoll(bool isAsync)
        {
            const string RequestUri = "https://www.example.com/request";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport(response);
            var pipeline = new HttpPipeline(transport);

            request.Uri.Reset(new Uri(RequestUri));

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();
            _ = isAsync
                ? await Operation.RehydrateAsync(pipeline, token.Value)
                : Operation.Rehydrate(pipeline, token.Value);
            var rehydrationUpdateRequest = transport.SingleRequest;

            Assert.That(rehydrationUpdateRequest.Uri.ToString(), Is.EqualTo(RequestUri));
            Assert.That(rehydrationUpdateRequest.Method, Is.EqualTo(RequestMethod.Get));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrationOperationOfTCanPoll(bool isAsync)
        {
            const string RequestUri = "https://www.example.com/request";
            const string LocationUri = "https://www.example.com/oper-ati-oni-d00";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport(response);
            var pipeline = new HttpPipeline(transport);
            using var responseContentStream = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "IntValue": 1,
                    "StringValue": "one"
                }
                """));

            request.Uri.Reset(new Uri(RequestUri));
            response.AddHeader("Location", LocationUri);
            response.ContentStream = responseContentStream;

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();
            var rehydrationOperation = isAsync
                ? await Operation.RehydrateAsync<MockJsonModel>(pipeline, token.Value)
                : Operation.Rehydrate<MockJsonModel>(pipeline, token.Value);
            var rehydrationUpdateRequest = transport.SingleRequest;

            Assert.That(rehydrationUpdateRequest.Uri.ToString(), Is.EqualTo(LocationUri));
            Assert.That(rehydrationUpdateRequest.Method, Is.EqualTo(RequestMethod.Get));

            Assert.That(rehydrationOperation.HasValue, Is.True);
            Assert.That(rehydrationOperation.Value.IntValue, Is.EqualTo(1));
            Assert.That(rehydrationOperation.Value.StringValue, Is.EqualTo("one"));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrationOperationOfTWithCompletedOperationCanPoll(bool isAsync)
        {
            const string RequestUri = "https://www.example.com/request";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport(response);
            var pipeline = new HttpPipeline(transport);
            using var responseContentStream = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "IntValue": 1,
                    "StringValue": "one"
                }
                """));

            request.Uri.Reset(new Uri(RequestUri));
            response.ContentStream = responseContentStream;

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();
            var rehydrationOperation = isAsync
                ? await Operation.RehydrateAsync<MockJsonModel>(pipeline, token.Value)
                : Operation.Rehydrate<MockJsonModel>(pipeline, token.Value);
            var rehydrationUpdateRequest = transport.SingleRequest;

            Assert.That(rehydrationUpdateRequest.Uri.ToString(), Is.EqualTo(RequestUri));
            Assert.That(rehydrationUpdateRequest.Method, Is.EqualTo(RequestMethod.Get));

            Assert.That(rehydrationOperation.HasValue, Is.True);
            Assert.That(rehydrationOperation.Value.IntValue, Is.EqualTo(1));
            Assert.That(rehydrationOperation.Value.StringValue, Is.EqualTo("one"));
        }
    }
}
