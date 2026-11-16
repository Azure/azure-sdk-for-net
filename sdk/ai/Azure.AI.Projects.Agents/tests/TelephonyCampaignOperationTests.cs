// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001, SCME0006

namespace Azure.AI.Projects.Agents.Tests;

public class TelephonyCampaignOperationTests
{
    private const string Endpoint = "https://example.services.ai.azure.com/api/projects/project";
    private const string OperationId = "initiating/operation +?=&";
    private const string CampaignJson = """
        {"name":"campaign","connection_name":"connection","source":{"type":"phone_number","value":"+15555550100"},
         "status":"running","operation_id":"later-action","etag":"final-etag","created_at":1700000000,"updated_at":1700000000}
        """;

    [Test]
    public async Task CompletionReadsTheCampaignGuardedByTheInitiatingResponse(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool cancel,
        [Values(false, true)] bool typed,
        [Values(false, true)] bool waitUntilCompleted,
        [Values(200, 201)] int createStatus)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync,
            InitialResponse(cancel ? 202 : createStatus),
            MonitorResponse("in_progress"),
            MonitorResponse("succeeded"),
            new MockPipelineResponse(200).WithContent(CampaignJson));
        using CancellationTokenSource cancellation = new();
        RequestOptions options = new() { CancellationToken = cancellation.Token };
        options.SetHeader("x-campaign-test", "retained");
        OperationResult operation = await StartAsync(client, isAsync, cancel, typed, waitUntilCompleted, options);
        if (!waitUntilCompleted)
        {
            Assert.That(operation.HasCompleted, Is.False);
            await UpdateAsync(operation, isAsync, options);
            Assert.That(operation.HasCompleted, Is.False);
            await UpdateAsync(operation, isAsync, options);
        }
        Assert.Multiple(() =>
        {
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Content.ToString(), Is.EqualTo(CampaignJson));
            Assert.That(transport.Requests, Has.Count.EqualTo(4));
        });
        for (int i = 0; i < transport.Requests.Count; i++)
        {
            MockPipelineRequest request = transport.Requests[i];
            Assert.That(request.Uri.GetLeftPart(UriPartial.Authority), Is.EqualTo("https://example.services.ai.azure.com"));
            Assert.That(request.Uri.Query, Does.Contain("api-version=v1"));
            if (!typed)
            {
                Assert.That(request.Headers.TryGetValue("x-campaign-test", out string header), Is.True);
                Assert.That(header, Is.EqualTo("retained"));
            }
            if (i is 1 or 2)
            {
                Assert.That(request.Method, Is.EqualTo("GET"));
                Assert.That(request.Uri.AbsolutePath, Does.Contain("/operations/"));
                Assert.That(Uri.UnescapeDataString(request.Uri.Segments.Last()), Is.EqualTo(OperationId));
            }
            else if (i == 3)
            {
                Assert.That(request.Method, Is.EqualTo("GET"));
                Assert.That(request.Uri.AbsolutePath, Is.EqualTo("/api/projects/project/agents/agent/telephony_campaigns/campaign"));
                Assert.That(Query(request.Uri, "operation_id"), Is.EqualTo(OperationId));
            }
        }
        await UpdateAsync(operation, isAsync, options);
        Assert.That(transport.Requests, Has.Count.EqualTo(4), "A completed operation must not poll again.");
    }

    [Test]
    public async Task GuardFailuresPropagateInsteadOfReturningAReplacementCampaign(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool cancel)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync,
            InitialResponse(cancel ? 202 : 201),
            MonitorResponse("succeeded"),
            new MockPipelineResponse(409).WithContent("""{"code":"campaign_operation_mismatch","message":"Campaign was replaced."}"""));
        OperationResult operation = await StartAsync(client, isAsync, cancel, false, false, new RequestOptions());
        ClientResultException exception = isAsync
            ? Assert.ThrowsAsync<ClientResultException>(async () => { await operation.UpdateStatusAsync(); })
            : Assert.Throws<ClientResultException>(() => operation.UpdateStatus());
        Assert.Multiple(() =>
        {
            Assert.That(exception.Status, Is.EqualTo(409));
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(Query(transport.Requests.Last().Uri, "operation_id"), Is.EqualTo(OperationId));
        });
    }

    [Test]
    public async Task FailedAndCancelledMonitorsDoNotReadTheCampaign(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool cancel,
        [Values("failed", "cancelled")] string status)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync,
            InitialResponse(cancel ? 202 : 201), MonitorResponse(status));
        OperationResult operation = await StartAsync(client, isAsync, cancel, false, false, new RequestOptions());
        await UpdateAsync(operation, isAsync, new RequestOptions());
        using JsonDocument document = JsonDocument.Parse(operation.GetRawResponse().Content);
        Assert.Multiple(() =>
        {
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(document.RootElement.GetProperty("status").GetString(), Is.EqualTo(status));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task AcceptedResponsesRequireAnOperationId(bool isAsync)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync,
            new MockPipelineResponse(201).WithContent(CampaignJson));
        if (isAsync)
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await StartAsync(client, true, false, false, false, new RequestOptions()));
        }
        else
        {
            Assert.Throws<InvalidOperationException>(() =>
                StartAsync(client, false, false, false, false, new RequestOptions()).GetAwaiter().GetResult());
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task DeferredWaitFetchesTheGuardedResource(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool cancel)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync,
            InitialResponse(cancel ? 202 : 201), MonitorResponse("succeeded"),
            new MockPipelineResponse(200).WithContent(CampaignJson));
        OperationResult operation = await StartAsync(client, isAsync, cancel, false, false, new RequestOptions());
        if (isAsync)
        {
            await operation.WaitForCompletionAsync();
        }
        else
        {
            operation.WaitForCompletion();
        }
        Assert.Multiple(() =>
        {
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Content.ToString(), Is.EqualTo(CampaignJson));
            Assert.That(Query(transport.Requests.Last().Uri, "operation_id"), Is.EqualTo(OperationId));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task DeferredWaitPropagatesCancellation(bool isAsync)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync, InitialResponse(201));
        OperationResult operation = await StartAsync(client, isAsync, false, false, false, new RequestOptions());
        transport.OnSendingRequest = message => message.CancellationToken.ThrowIfCancellationRequested();
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();
        if (isAsync)
        {
            Assert.CatchAsync<OperationCanceledException>(async () => await operation.WaitForCompletionAsync(cancellation.Token));
        }
        else
        {
            Assert.Catch<OperationCanceledException>(() => operation.WaitForCompletion(cancellation.Token));
        }
        Assert.That(operation.HasCompleted, Is.False);
    }

    [Test]
    public async Task NoThrowPreservesInitialErrorsWithoutRequiringOperationHeaders(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool cancel)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync,
            new MockPipelineResponse(404).WithContent("""{"code":"NotFound","message":"Campaign does not exist."}"""));
        RequestOptions options = new() { ErrorOptions = ClientErrorBehaviors.NoThrow };
        OperationResult operation = await StartAsync(client, isAsync, cancel, false, true, options);
        Assert.Multiple(() =>
        {
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(404));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        });
    }

    private static async Task<OperationResult> StartAsync(TelephonyCampaigns client, bool isAsync, bool cancel, bool typed, bool wait, RequestOptions options)
    {
        if (cancel)
        {
            return isAsync
                ? typed
                    ? await client.CancelAsync(wait, "agent", "campaign", "etag", "requested-id", options.CancellationToken)
                    : await client.CancelAsync(wait, "agent", "campaign", "etag", "requested-id", options)
                : typed
                    ? client.Cancel(wait, "agent", "campaign", "etag", "requested-id", options.CancellationToken)
                    : client.Cancel(wait, "agent", "campaign", "etag", "requested-id", options);
        }
        TelephonyCampaign campaign = new("connection", new PhoneNumber("+15555550100"));
        using BinaryContent content = BinaryContent.Create(BinaryData.FromString("{}"));
        return isAsync
            ? typed
                ? await client.CreateAsync(wait, "agent", "campaign", campaign, "requested-id", cancellationToken: options.CancellationToken)
                : await client.CreateAsync(wait, "agent", "campaign", content, "requested-id", options: options)
            : typed
                ? client.Create(wait, "agent", "campaign", campaign, "requested-id", cancellationToken: options.CancellationToken)
                : client.Create(wait, "agent", "campaign", content, "requested-id", options: options);
    }

    private static async Task UpdateAsync(OperationResult operation, bool isAsync, RequestOptions options)
    {
        if (isAsync)
        {
            await operation.UpdateStatusAsync(options);
        }
        else
        {
            operation.UpdateStatus(options);
        }
    }

    private static MockPipelineResponse InitialResponse(int status) => new MockPipelineResponse(status)
        .WithHeader("Operation-Id", OperationId)
        .WithHeader("Operation-Location", Endpoint + "/agents/agent/telephony_campaigns/campaign/operations/" + Uri.EscapeDataString(OperationId) + "?api-version=v1")
        .WithHeader("Location", Endpoint + "/agents/agent/telephony_campaigns/campaign?api-version=v1")
        .WithHeader("Retry-After", "0")
        .WithContent(CampaignJson);

    private static MockPipelineResponse MonitorResponse(string status) => new MockPipelineResponse(200)
        .WithHeader("Retry-After", "0")
        .WithContent($$"""{"id":{{JsonSerializer.Serialize(OperationId)}},"status":"{{status}}","kind":"validation","created_at":1700000000}""");

    private static (TelephonyCampaigns Client, MockPipelineTransport Transport) CreateClient(bool isAsync, params MockPipelineResponse[] responses)
    {
        int index = 0;
        MockPipelineTransport transport = new(_ =>
        {
            Assert.That(index, Is.LessThan(responses.Length), "Unexpected campaign request.");
            return responses[index++];
        })
        { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient administration = new(new Uri(Endpoint), new FakeTokenProvider(), new() { Transport = transport });
        return (administration.GetBetaVoiceAgentTelephonyCampaigns(), transport);
    }

    private static string Query(Uri uri, string name)
        => uri.Query.TrimStart('?').Split('&').Select(value => value.Split(new[] { '=' }, 2))
            .Where(value => value.Length == 2 && Uri.UnescapeDataString(value[0]) == name)
            .Select(value => Uri.UnescapeDataString(value[1])).SingleOrDefault();

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);
        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("fake-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);
        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}
