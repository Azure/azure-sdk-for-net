// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net;
using Azure.AI.AgentServer.Core;
using NUnit.Framework;
using OpenAI.Responses;

#pragma warning disable AAAS005, OPENAI001

namespace Azure.AI.AgentServer.Invocations.Tests;

public class OriginalSubjectModelTransportTests
{
    [Test]
    public async Task ReusedClientReceivesOnlyCurrentPerCallAttribution()
    {
        var transport = new CaptureTransport();
        using var httpClient = new HttpClient(transport);
        var client = new ResponsesClient(new ApiKeyCredential("test-key"), new ResponsesClientOptions
        {
            Endpoint = new Uri("http://model.test"),
            Transport = new HttpClientPipelineTransport(httpClient),
        });

        async Task InvokeAsync(FoundryAgentRequestContext context)
        {
            var options = new RequestOptions();
            foreach (var header in context.ModelAttributionHeaders())
            {
                options.SetHeader(header.Key, header.Value);
            }

            await client.CreateResponseAsync(BinaryContent.Create(BinaryData.FromString("""{"model":"test","input":"hello"}""")), options);
        }

        await InvokeAsync(new FoundryAgentRequestContext
        {
            CallId = "call-one",
            OriginalSubject = new FoundryOriginalSubject("one", "tenant", "user"),
        });
        await InvokeAsync(new FoundryAgentRequestContext { CallId = "call-two" });

        Assert.That(transport.Headers, Has.Count.EqualTo(2));
        Assert.That(transport.Headers[0]["x-ms-foundry-baggage"], Does.StartWith("foundry.original_subject="));
        Assert.That(transport.Headers[0]["x-agent-foundry-call-id"], Is.EqualTo("call-one"));
        Assert.That(transport.Headers[0].ContainsKey("x-ms-original-subject"), Is.False);
        Assert.That(transport.Headers[1].ContainsKey("x-ms-foundry-baggage"), Is.False);
        Assert.That(transport.Headers[1].ContainsKey("x-agent-foundry-call-id"), Is.False);
        Assert.That(transport.Headers[1].ContainsKey("x-ms-original-subject"), Is.False);
    }

    private sealed class CaptureTransport : HttpMessageHandler
    {
        public List<Dictionary<string, string>> Headers { get; } = new();

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Headers.Add(request.Headers.ToDictionary(h => h.Key, h => string.Join(",", h.Value), StringComparer.OrdinalIgnoreCase));
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}"),
            });
        }
    }
}
