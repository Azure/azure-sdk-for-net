// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.MgmtTypeSpec.Tests;
using Azure.Generator.MgmtTypeSpec.Tests.Models;
using Azure.ResourceManager;
using NUnit.Framework;
using IPAddress = Azure.Generator.MgmtTypeSpec.Tests.Models.IPAddress;

namespace Azure.Generator.Management.Tests.Providers
{
    public class HttpMessageDisposalTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string FooId = "/subscriptions/" + SubscriptionId + "/resourceGroups/group/providers/MgmtTypeSpec/foos/foo";
        private const string ActionBody = """{"address":"127.0.0.1"}""";

        public enum Outcome { Success, SendFailure, ErrorResponse, InvalidJson }

        [Test]
        public async Task OperationDisposesMessage([Values] bool isAsync, [Values] Outcome outcome)
        {
            using var handler = new TestHandler { Outcome = outcome };
            using var httpClient = new HttpClient(handler);
            var capture = new CapturePolicy();
            var client = CreateClient(httpClient, capture);
            var resource = client.GetAcronymWidgetResource(AcronymWidgetResource.CreateResourceIdentifier(
                SubscriptionId, "group", "source", "widget"));

            async Task Invoke()
            {
                var content = new IPAddress("127.0.0.1");
                var response = isAsync ? await resource.ConfigureAsync(content) : resource.Configure(content);
                Assert.That(response.Value.Address, Is.EqualTo("127.0.0.1"));
                Assert.That(response.GetRawResponse().Content.ToString(), Is.EqualTo(ActionBody));
            }

            switch (outcome)
            {
                case Outcome.Success:
                    await Invoke();
                    break;
                case Outcome.SendFailure:
                    Assert.ThrowsAsync<InvalidOperationException>(Invoke);
                    break;
                case Outcome.ErrorResponse:
                    Assert.ThrowsAsync<RequestFailedException>(Invoke);
                    break;
                case Outcome.InvalidJson:
                    Assert.CatchAsync<JsonException>(Invoke);
                    break;
            }

            AssertDisposed(capture);
        }

        [Test]
        public async Task LongRunningOperationOutlivesInitialMessage(
            [Values] bool isAsync,
            [Values(WaitUntil.Started, WaitUntil.Completed)] WaitUntil waitUntil,
            [Values] bool completesImmediately)
        {
            using var handler = new TestHandler { IsLongRunning = true, CompletesImmediately = completesImmediately };
            using var httpClient = new HttpClient(handler);
            var capture = new CapturePolicy();
            var resource = CreateClient(httpClient, capture).GetFooResource(new ResourceIdentifier(FooId));
            var content = new FooActionRequest("request");

            var operation = isAsync
                ? await resource.FooActionAsync(waitUntil, content)
                : resource.FooAction(waitUntil, content);

            AssertDisposed(capture);
            Assert.That(operation.GetRawResponse().Content, Is.Not.Null);
            if (isAsync)
            {
                await operation.WaitForCompletionAsync();
            }
            else
            {
                operation.WaitForCompletion();
            }

            Assert.That(operation.Value.Msg, Is.EqualTo("done"));
            Assert.That(operation.GetRawResponse().Content.ToString(), Does.Contain("done"));
            AssertDisposed(capture);
        }

        private static ArmClient CreateClient(HttpClient httpClient, CapturePolicy capture)
        {
            var options = new ArmClientOptions { Transport = new HttpClientTransport(httpClient) };
            options.Retry.MaxRetries = 0;
            options.AddPolicy(capture, HttpPipelinePosition.PerCall);
            return new ArmClient(new TestCredential(), SubscriptionId, options);
        }

        private static void AssertDisposed(CapturePolicy capture)
        {
            Assert.That(capture.Messages, Is.Not.Empty);
            Assert.That(capture.Messages.All(message => !message.HasResponse), Is.True,
                "Disposing HttpMessage must release its response reference.");
            Assert.That(capture.Contents.All(content => content.Disposals == 1), Is.True,
                "Disposing HttpMessage must dispose its request content exactly once.");
        }

        private sealed class CapturePolicy : HttpPipelineSynchronousPolicy
        {
            public List<HttpMessage> Messages { get; } = [];
            public List<TrackingContent> Contents { get; } = [];

            public override void OnSendingRequest(HttpMessage message)
            {
                Messages.Add(message);
                var content = new TrackingContent(message.Request.Content ?? RequestContent.Create(Array.Empty<byte>()));
                Contents.Add(content);
                message.Request.Content = content;
            }
        }

        private sealed class TrackingContent(RequestContent inner) : RequestContent
        {
            public int Disposals { get; private set; }

            public override void WriteTo(Stream stream, CancellationToken cancellationToken) =>
                inner.WriteTo(stream, cancellationToken);

            public override Task WriteToAsync(Stream stream, CancellationToken cancellationToken) =>
                inner.WriteToAsync(stream, cancellationToken);

            public override bool TryComputeLength(out long length) => inner.TryComputeLength(out length);

            public override void Dispose()
            {
                Disposals++;
                inner.Dispose();
            }
        }

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new("test", DateTimeOffset.MaxValue);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new(GetToken(requestContext, cancellationToken));
        }

        private sealed class TestHandler : HttpMessageHandler
        {
            public Outcome Outcome { get; init; }
            public bool IsLongRunning { get; init; }
            public bool CompletesImmediately { get; init; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
                Task.FromResult(Send(request, cancellationToken));

            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (Outcome == Outcome.SendFailure)
                {
                    throw new InvalidOperationException("Send failed.");
                }

                var status = Outcome == Outcome.ErrorResponse ? HttpStatusCode.BadRequest : HttpStatusCode.OK;
                var body = Outcome switch
                {
                    Outcome.ErrorResponse => """{"error":{"code":"BadRequest","message":"Rejected."}}""",
                    Outcome.InvalidJson => "{",
                    _ => ActionBody
                };
                if (IsLongRunning)
                {
                    body = request.RequestUri!.AbsolutePath.EndsWith("/status")
                        ? """{"status":"Succeeded","msg":"done"}"""
                        : """{"msg":"done"}""";
                    if (!CompletesImmediately && request.RequestUri.AbsolutePath.EndsWith("/exportDependencies"))
                    {
                        var accepted = new HttpResponseMessage(HttpStatusCode.Accepted) { Content = new StringContent("{}") };
                        accepted.Headers.Add("Azure-AsyncOperation", "https://management.azure.com/status");
                        accepted.Headers.Location = new Uri("https://management.azure.com/result");
                        accepted.Headers.Add("Retry-After", "0");
                        return accepted;
                    }
                }
                return new HttpResponseMessage(status) { Content = new StringContent(body) };
            }
        }
    }
}
