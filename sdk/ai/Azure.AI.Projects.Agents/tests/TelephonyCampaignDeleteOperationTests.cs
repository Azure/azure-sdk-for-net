// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001, SCME0006

namespace Azure.AI.Projects.Agents.Tests;

public class TelephonyCampaignDeleteOperationTests
{
    private const string Endpoint = "https://example.services.ai.azure.com/api/projects/project";
    private const string OperationLocation = Endpoint + "/agents/agent/telephony_campaigns/campaign/operations/delete%2Foperation?api-version=v1";

    [Test]
    public async Task AcceptedDeletePollsOnlyTheOperationMonitor(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool typed,
        [Values(false, true)] bool waitUntilCompleted)
    {
        var (client, transport) = CreateClient(isAsync,
            AcceptedResponse(),
            MonitorResponse("in_progress"),
            MonitorResponse("succeeded"));
        RequestOptions options = new();
        options.SetHeader("x-campaign-test", "retained");

        OperationResult operation = await DeleteAsync(client, isAsync, typed, waitUntilCompleted, options);
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
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
        });
        AssertDeleteRequest(transport.Requests[0], expectCustomHeader: !typed);
        foreach (MockPipelineRequest request in transport.Requests.Skip(1))
        {
            Assert.Multiple(() =>
            {
                Assert.That(request.Method, Is.EqualTo("GET"));
                Assert.That(request.Uri.AbsoluteUri, Is.EqualTo(OperationLocation));
                Assert.That(request.Uri.AbsolutePath, Does.Not.EndWith("/campaign"));
                if (!typed)
                {
                    Assert.That(request.Headers.TryGetValue("x-campaign-test", out string value), Is.True);
                    Assert.That(value, Is.EqualTo("retained"));
                }
            });
        }

        await UpdateAsync(operation, isAsync, options);
        Assert.That(transport.Requests, Has.Count.EqualTo(3), "A completed deletion must not issue another request.");
    }

    [Test]
    public async Task DeferredDeleteWaitsWithoutFetchingTheDeletedCampaign(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool typed)
    {
        var (client, transport) = CreateClient(isAsync, AcceptedResponse(), MonitorResponse("succeeded"));
        OperationResult operation = await DeleteAsync(client, isAsync, typed, false, new RequestOptions());

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
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[1].Uri.AbsoluteUri, Is.EqualTo(OperationLocation));
        });
    }

    [Test]
    public async Task NoContentDeleteIsAlreadyCompleted(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool typed,
        [Values(false, true)] bool waitUntilCompleted)
    {
        var (client, transport) = CreateClient(isAsync, new MockPipelineResponse(204));
        OperationResult operation = await DeleteAsync(client, isAsync, typed, waitUntilCompleted, new RequestOptions());

        Assert.Multiple(() =>
        {
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        });
        AssertDeleteRequest(transport.Requests[0], expectCustomHeader: false);
    }

    [Test]
    public async Task MonitorFailureCompletesWithoutExtraRequests(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool typed)
    {
        var (client, transport) = CreateClient(isAsync, AcceptedResponse(), MonitorResponse("failed"));
        OperationResult operation = await DeleteAsync(client, isAsync, typed, false, new RequestOptions());
        await UpdateAsync(operation, isAsync, new RequestOptions());

        Assert.Multiple(() =>
        {
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Content.ToString(), Does.Contain("\"failed\""));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        });
    }

    [Test]
    public async Task HttpMonitorFailurePropagatesAndLeavesOperationIncomplete(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool typed)
    {
        var (client, transport) = CreateClient(isAsync,
            AcceptedResponse(),
            new MockPipelineResponse(500).WithContent("""{"code":"monitor_failed","message":"Try again."}"""));
        OperationResult operation = await DeleteAsync(client, isAsync, typed, false, new RequestOptions());

        ClientResultException exception = isAsync
            ? Assert.ThrowsAsync<ClientResultException>(async () => await operation.UpdateStatusAsync())
            : Assert.Throws<ClientResultException>(() => operation.UpdateStatus());
        Assert.Multiple(() =>
        {
            Assert.That(exception.Status, Is.EqualTo(500));
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        });
    }

    [Test]
    public async Task InitialErrorsThrowByDefaultAndNoThrowPreservesResponse(
        [Values(false, true)] bool isAsync,
        [Values(409, 412)] int status,
        [Values(false, true)] bool noThrow)
    {
        const string error = """{"code":"campaign_conflict","message":"Campaign cannot be deleted."}""";
        var (client, transport) = CreateClient(isAsync, new MockPipelineResponse(status).WithContent(error));
        RequestOptions options = new() { ErrorOptions = noThrow ? ClientErrorBehaviors.NoThrow : ClientErrorBehaviors.Default };

        if (noThrow)
        {
            OperationResult operation = await DeleteAsync(client, isAsync, false, true, options);
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.GetRawResponse().Status, Is.EqualTo(status));
                Assert.That(operation.GetRawResponse().Content.ToString(), Is.EqualTo(error));
            });
        }
        else
        {
            ClientResultException exception = isAsync
                ? Assert.ThrowsAsync<ClientResultException>(async () => await client.DeleteAsync(true, "agent", "campaign", "\"etag\"", "delete-operation", options))
                : Assert.Throws<ClientResultException>(() => client.Delete(true, "agent", "campaign", "\"etag\"", "delete-operation", options));
            Assert.That(exception.Status, Is.EqualTo(status));
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task DeferredWaitPropagatesCancellation(bool isAsync)
    {
        var (client, transport) = CreateClient(isAsync, AcceptedResponse());
        OperationResult operation = await DeleteAsync(client, isAsync, false, false, new RequestOptions());
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
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    private static async Task<OperationResult> DeleteAsync(
        TelephonyCampaigns client, bool isAsync, bool typed, bool waitUntilCompleted, RequestOptions options)
        => isAsync
            ? typed
                ? await client.DeleteAsync(waitUntilCompleted, "agent", "campaign", "\"etag\"", "delete-operation", options.CancellationToken)
                : await client.DeleteAsync(waitUntilCompleted, "agent", "campaign", "\"etag\"", "delete-operation", options)
            : typed
                ? client.Delete(waitUntilCompleted, "agent", "campaign", "\"etag\"", "delete-operation", options.CancellationToken)
                : client.Delete(waitUntilCompleted, "agent", "campaign", "\"etag\"", "delete-operation", options);

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

    private static MockPipelineResponse AcceptedResponse() => new MockPipelineResponse(202)
        .WithHeader("Operation-Location", OperationLocation)
        .WithHeader("Retry-After", "0");

    private static MockPipelineResponse MonitorResponse(string status) => new MockPipelineResponse(200)
        .WithHeader("Retry-After", "0")
        .WithContent($$"""{"id":"delete-operation","status":"{{status}}","kind":"delete","created_at":1700000000}""");

    private static void AssertDeleteRequest(MockPipelineRequest request, bool expectCustomHeader)
    {
        Assert.Multiple(() =>
        {
            Assert.That(request.Method, Is.EqualTo("DELETE"));
            Assert.That(request.Uri.AbsolutePath, Is.EqualTo("/api/projects/project/agents/agent/telephony_campaigns/campaign"));
            Assert.That(request.Uri.Query, Is.EqualTo("?api-version=v1"));
            Assert.That(request.Headers.TryGetValue("If-Match", out string etag), Is.True);
            Assert.That(etag, Is.EqualTo("\"etag\""));
            Assert.That(request.Headers.TryGetValue("Operation-Id", out string operationId), Is.True);
            Assert.That(operationId, Is.EqualTo("delete-operation"));
            if (expectCustomHeader)
            {
                Assert.That(request.Headers.TryGetValue("x-campaign-test", out string value), Is.True);
                Assert.That(value, Is.EqualTo("retained"));
            }
        });
    }

    private static (TelephonyCampaigns Client, MockPipelineTransport Transport) CreateClient(
        bool isAsync, params MockPipelineResponse[] responses)
    {
        int index = 0;
        MockPipelineTransport transport = new(_ =>
        {
            Assert.That(index, Is.LessThan(responses.Length), "Unexpected campaign request.");
            return responses[index++];
        })
        { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient administration = new(
            new Uri(Endpoint), new FakeTokenProvider(), new AgentAdministrationClientOptions
            {
                Transport = transport,
                RetryPolicy = new ClientRetryPolicy(0)
            });
        return (administration.GetBetaVoiceAgentTelephonyCampaigns(), transport);
    }

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);
        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("fake-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);
        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}
