// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class TelephonyCallJobPaginationTests
{
    private static readonly Uri Endpoint = new("https://example.services.ai.azure.com/api/projects/project");
    private const string InitialCursor = "initial/opaque+token=";
    private const string FirstCursor = "job-first/opaque+token=";
    private const string LastCursor = "job-last/opaque+token=";

    [TestCase("GetTelephonyCallJobs")]
    [TestCase("GetTelephonyCallJobsAsync")]
    [TestCase("DeleteTelephonyCallJob")]
    [TestCase("DeleteTelephonyCallJobAsync")]
    public void CallJobListAndDeleteRemainInternal(string name)
    {
        MethodInfo[] methods = typeof(BetaVoiceAgentsTelephony)
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(method => method.Name == name).ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(methods, Has.Length.EqualTo(2), "Keep the existing typed and protocol overloads only.");
            Assert.That(methods.All(method => method.IsAssembly), Is.True, "Call-job list/delete must not become public APIs.");
        });
    }

    [Test]
    public async Task PagingPreservesDirectionFiltersOptionsAndRawPages(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool protocol,
        [Values(false, true)] bool backward,
        [Values(false, true)] bool hasMore)
    {
        string[] responses = hasMore ? [Page(1, true), Page(2, false)] : [Page(1, false)];
        (BetaVoiceAgentsTelephony client, MockPipelineTransport transport) = CreateClient(isAsync, responses);
        using CancellationTokenSource cancellation = new();
        RequestOptions options = new() { CancellationToken = cancellation.Token };
        options.SetHeader("x-pagination-test", "retained");
        transport.OnSendingRequest = message => Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
        List<ClientResult> pages = [];
        ContinuationToken firstToken;
        ContinuationToken lastToken;

        if (isAsync)
        {
            AsyncCollectionResult collection = CreateAsyncCollection(client, protocol, backward, options);
            await foreach (ClientResult page in collection.GetRawPagesAsync())
            {
                pages.Add(page);
            }
            firstToken = collection.GetContinuationToken(pages[0]);
            lastToken = collection.GetContinuationToken(pages[pages.Count - 1]);
        }
        else
        {
            CollectionResult collection = CreateCollection(client, protocol, backward, options);
            pages.AddRange(collection.GetRawPages());
            firstToken = collection.GetContinuationToken(pages[0]);
            lastToken = collection.GetContinuationToken(pages[pages.Count - 1]);
        }

        Assert.Multiple(() =>
        {
            Assert.That(pages, Has.Count.EqualTo(responses.Length));
            Assert.That(transport.Requests, Has.Count.EqualTo(responses.Length));
            Assert.That(firstToken?.ToBytes().ToString(), Is.EqualTo(hasMore ? backward ? FirstCursor : LastCursor : null));
            Assert.That(lastToken, Is.Null, "has_more=false terminates paging even when both boundary IDs are retained.");
        });
        for (int i = 0; i < pages.Count; i++)
        {
            MockPipelineRequest request = transport.Requests[i];
            Dictionary<string, string> query = request.Uri.Query.TrimStart('?').Split('&')
                .Select(component => component.Split(new[] { '=' }, 2))
                .ToDictionary(parts => Uri.UnescapeDataString(parts[0]), parts => Uri.UnescapeDataString(parts[1]));
            PipelineResponse response = pages[i].GetRawResponse();
            Assert.Multiple(() =>
            {
                Assert.That(request.Method, Is.EqualTo("GET"));
                Assert.That(request.Uri.GetLeftPart(UriPartial.Authority), Is.EqualTo(Endpoint.GetLeftPart(UriPartial.Authority)));
                Assert.That(request.Uri.AbsolutePath, Is.EqualTo(Endpoint.AbsolutePath + "/agents/agent/telephony_call_jobs"));
                Assert.That(query["limit"], Is.EqualTo("7"));
                Assert.That(query["order"], Is.EqualTo("asc"));
                Assert.That(query["status"], Is.EqualTo("queued"));
                Assert.That(query["campaign_name"], Is.EqualTo("campaign"));
                Assert.That(query["api-version"], Is.EqualTo("v1"));
                Assert.That(query, Does.Not.ContainKey(backward ? "after" : "before"));
                Assert.That(query[backward ? "before" : "after"], Is.EqualTo(i == 0 ? InitialCursor : backward ? FirstCursor : LastCursor));
                if (protocol)
                {
                    Assert.That(request.Headers.TryGetValue("x-pagination-test", out string header), Is.True);
                    Assert.That(header, Is.EqualTo("retained"));
                }
                Assert.That(response.Status, Is.EqualTo(200));
                Assert.That(response.Content.ToString(), Is.EqualTo(responses[i]));
                Assert.That(response.Headers.TryGetValue("x-pagination-page", out string pageHeader), Is.True);
                Assert.That(pageHeader, Is.EqualTo(i.ToString(CultureInfo.InvariantCulture)));
            });
        }
    }

    [Test]
    public async Task NonterminalPageRequiresTheCursorForItsDirection(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool protocol,
        [Values(false, true)] bool backward,
        [Values(null, "")] string missingCursor)
    {
        (BetaVoiceAgentsTelephony client, MockPipelineTransport transport) = CreateClient(isAsync,
            Page(1, true, backward ? missingCursor : FirstCursor, backward ? LastCursor : missingCursor));
        RequestOptions options = new();
        JsonException tokenException;
        JsonException enumerationException;
        if (isAsync)
        {
            AsyncCollectionResult collection = CreateAsyncCollection(client, protocol, backward, options);
            await using IAsyncEnumerator<ClientResult> enumerator = collection.GetRawPagesAsync().GetAsyncEnumerator();
            Assert.That(await enumerator.MoveNextAsync(), Is.True, "The raw response must remain accessible.");
            tokenException = Assert.Throws<JsonException>(() => collection.GetContinuationToken(enumerator.Current));
            enumerationException = Assert.ThrowsAsync<JsonException>(async () => { await enumerator.MoveNextAsync(); });
        }
        else
        {
            CollectionResult collection = CreateCollection(client, protocol, backward, options);
            using IEnumerator<ClientResult> enumerator = collection.GetRawPages().GetEnumerator();
            Assert.That(enumerator.MoveNext(), Is.True, "The raw response must remain accessible.");
            tokenException = Assert.Throws<JsonException>(() => collection.GetContinuationToken(enumerator.Current));
            enumerationException = Assert.Throws<JsonException>(() => enumerator.MoveNext());
        }
        Assert.Multiple(() =>
        {
            Assert.That(tokenException.Message, Does.Contain(backward ? "first_id" : "last_id"));
            Assert.That(enumerationException.Message, Is.EqualTo(tokenException.Message));
            Assert.That(transport.Requests, Has.Count.EqualTo(1), "An invalid page must fail before another request.");
        });
    }

    [Test]
    public async Task TypedEnumerationReturnsBothPagesAndStops(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool backward)
    {
        (BetaVoiceAgentsTelephony client, MockPipelineTransport transport) = CreateClient(isAsync, Page(1, true), Page(2, false));
        string after = backward ? null : InitialCursor;
        string before = backward ? InitialCursor : null;
        List<string> ids = [];
        if (isAsync)
        {
            await foreach (TelephonyCallJob job in client.GetTelephonyCallJobsAsync("agent", after: after, before: before))
            {
                ids.Add(job.Id);
            }
        }
        else
        {
            ids.AddRange(client.GetTelephonyCallJobs("agent", after: after, before: before).Select(job => job.Id));
        }
        Assert.Multiple(() =>
        {
            Assert.That(ids, Is.EqualTo(new[] { "job_1", "job_2" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        });
    }

    [Test]
    public async Task ContinuationRequestPropagatesCallerCancellation(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool protocol)
    {
        (BetaVoiceAgentsTelephony client, MockPipelineTransport transport) = CreateClient(isAsync, Page(1, true), Page(2, false));
        using CancellationTokenSource cancellation = new();
        RequestOptions options = new() { CancellationToken = cancellation.Token };
        int requests = 0;
        bool cancellationObserved = false;
        transport.OnSendingRequest = message =>
        {
            if (++requests == 2)
            {
                cancellation.Cancel();
                cancellationObserved = message.CancellationToken.IsCancellationRequested;
                message.CancellationToken.ThrowIfCancellationRequested();
            }
        };
        if (isAsync)
        {
            AsyncCollectionResult collection = CreateAsyncCollection(client, protocol, false, options);
            await using IAsyncEnumerator<ClientResult> enumerator = collection.GetRawPagesAsync().GetAsyncEnumerator();
            Assert.That(await enumerator.MoveNextAsync(), Is.True);
            Assert.CatchAsync<OperationCanceledException>(async () => { await enumerator.MoveNextAsync(); });
        }
        else
        {
            CollectionResult collection = CreateCollection(client, protocol, false, options);
            using IEnumerator<ClientResult> enumerator = collection.GetRawPages().GetEnumerator();
            Assert.That(enumerator.MoveNext(), Is.True);
            Assert.Catch<OperationCanceledException>(() => enumerator.MoveNext());
        }
        Assert.That(cancellationObserved, Is.True, "The continuation request's linked token must observe caller cancellation.");
    }

    private static CollectionResult CreateCollection(BetaVoiceAgentsTelephony client, bool protocol, bool backward, RequestOptions options)
    {
        string after = backward ? null : InitialCursor;
        string before = backward ? InitialCursor : null;
        return protocol
            ? client.GetTelephonyCallJobs("agent", 7, "asc", after, before, "queued", "campaign", options)
            : client.GetTelephonyCallJobs("agent", 7, AgentListOrder.Ascending, after, before, TelephonyCallJobStatus.Queued, "campaign", options.CancellationToken);
    }

    private static AsyncCollectionResult CreateAsyncCollection(BetaVoiceAgentsTelephony client, bool protocol, bool backward, RequestOptions options)
    {
        string after = backward ? null : InitialCursor;
        string before = backward ? InitialCursor : null;
        return protocol
            ? client.GetTelephonyCallJobsAsync("agent", 7, "asc", after, before, "queued", "campaign", options)
            : client.GetTelephonyCallJobsAsync("agent", 7, AgentListOrder.Ascending, after, before, TelephonyCallJobStatus.Queued, "campaign", options.CancellationToken);
    }

    private static string Page(int number, bool hasMore, string firstId = FirstCursor, string lastId = LastCursor)
    {
        string data = $$"""
            {
              "id":"job_{{number}}",
              "agent_name":"agent",
              "destination":{"type":"phone_number","value":"+15555550101"},
              "connection_name":"connection",
              "source":{"type":"phone_number","value":"+15555550100"},
              "status":"queued",
              "retry_policy":{"type":"fixed_interval","max_attempts":1,"interval":0},
              "attempt_count":0,
              "revision":1,
              "created_at":1700000000,
              "updated_at":1700000000,
              "campaign_name":"campaign"
            }
            """;
        string first = firstId == null ? "" : $"\"first_id\":{JsonSerializer.Serialize(firstId)},";
        string last = lastId == null ? "" : $"\"last_id\":{JsonSerializer.Serialize(lastId)},";
        return $$"""{"data":[{{data}}],{{first}}{{last}}"has_more":{{hasMore.ToString().ToLowerInvariant()}}}""";
    }

    private static (BetaVoiceAgentsTelephony Client, MockPipelineTransport Transport) CreateClient(bool isAsync, params string[] responses)
    {
        int index = 0;
        MockPipelineTransport transport = new(_ =>
        {
            int responseIndex = Interlocked.Increment(ref index) - 1;
            Assert.That(responseIndex, Is.LessThan(responses.Length), "The client requested an unexpected extra page.");
            return new MockPipelineResponse(200)
                .WithHeader("x-pagination-page", responseIndex.ToString(CultureInfo.InvariantCulture))
                .WithContent(responses[responseIndex]);
        })
        {
            ExpectSyncPipeline = !isAsync
        };
        AgentAdministrationClient administration = new(Endpoint, new FakeTokenProvider(),
            new AgentAdministrationClientOptions(AgentAdministrationClientOptions.ServiceVersion.V1) { Transport = transport });
        return (administration.GetBetaVoiceAgentTelephony(), transport);
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
