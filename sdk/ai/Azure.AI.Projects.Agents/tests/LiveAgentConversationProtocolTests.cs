// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class LiveAgentConversationProtocolTests
{
    private const string Endpoint = "https://example.services.ai.azure.com/api/projects/project";
    private const string Route = "/agents/agent/endpoint/protocols/voice/live/conversations";

    [Test]
    public void AdministrationAccessorIsCachedExperimentalAndSharesPipeline()
    {
        (AgentAdministrationClient administration, _) = CreateClient(false, "{}");
        BetaVoiceAgentsLiveConversations[] clients = new BetaVoiceAgentsLiveConversations[32];
        Parallel.For(0, clients.Length, i => clients[i] = administration.GetBetaVoiceAgentEndpointLiveConversations());
        Assert.Multiple(() =>
        {
            Assert.That(clients.All(c => ReferenceEquals(c, clients[0])), Is.True);
            Assert.That(clients[0].Pipeline, Is.SameAs(administration.Pipeline));
            Assert.That(typeof(BetaVoiceAgentsLiveConversations).GetCustomAttribute<ExperimentalAttribute>()?.DiagnosticId, Is.EqualTo("AAIP001"));
            Assert.That(typeof(AgentAdministrationClient).GetMethod(nameof(AgentAdministrationClient.GetBetaVoiceAgentEndpointLiveConversations)).GetCustomAttribute<ExperimentalAttribute>()?.DiagnosticId, Is.EqualTo("AAIP001"));
        });
    }

    [Test]
    public async Task HistoryPagingHonorsHasMoreAndPreservesFilters(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool raw,
        [Values(false, true)] bool items,
        [Values(false, true)] bool hasMore)
    {
        string firstPage = Page(items, "first", hasMore);
        string lastPage = Page(items, "last", false);
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync, hasMore ? [firstPage, lastPage] : [firstPage]);
        BetaVoiceAgentsLiveConversations client = administration.GetBetaVoiceAgentEndpointLiveConversations();
        List<ClientResult> pages = [];
        ContinuationToken firstToken;
        ContinuationToken lastToken;
        if (isAsync)
        {
            AsyncCollectionResult collection = items
                ? raw
                    ? client.GetLiveAgentConversationItemsAsync("agent", "conversation", 7, "asc", "initial", "before", new RequestOptions())
                    : client.GetLiveAgentConversationItemsAsync("agent", "conversation", 7, AgentListOrder.Ascending, "initial", "before")
                : raw
                    ? client.GetLiveAgentConversationsAsync("agent", 7, "asc", "initial", "before", new RequestOptions())
                    : client.GetLiveAgentConversationsAsync("agent", 7, AgentListOrder.Ascending, "initial", "before");
            await foreach (ClientResult page in collection.GetRawPagesAsync())
            {
                pages.Add(page);
            }
            firstToken = collection.GetContinuationToken(pages[0]);
            lastToken = collection.GetContinuationToken(pages[pages.Count - 1]);
        }
        else
        {
            CollectionResult collection = items
                ? raw
                    ? client.GetLiveAgentConversationItems("agent", "conversation", 7, "asc", "initial", "before", new RequestOptions())
                    : client.GetLiveAgentConversationItems("agent", "conversation", 7, AgentListOrder.Ascending, "initial", "before")
                : raw
                    ? client.GetLiveAgentConversations("agent", 7, "asc", "initial", "before", new RequestOptions())
                    : client.GetLiveAgentConversations("agent", 7, AgentListOrder.Ascending, "initial", "before");
            pages.AddRange(collection.GetRawPages());
            firstToken = collection.GetContinuationToken(pages[0]);
            lastToken = collection.GetContinuationToken(pages[pages.Count - 1]);
        }

        Assert.Multiple(() =>
        {
            Assert.That(pages, Has.Count.EqualTo(hasMore ? 2 : 1));
            Assert.That(transport.Requests, Has.Count.EqualTo(hasMore ? 2 : 1));
            Assert.That(firstToken != null, Is.EqualTo(hasMore));
            Assert.That(lastToken, Is.Null, "A terminal page's last_id is not a continuation token.");
        });
        for (int i = 0; i < transport.Requests.Count; i++)
        {
            MockPipelineRequest request = transport.Requests[i];
            Assert.Multiple(() =>
            {
                Assert.That(request.Method, Is.EqualTo("GET"));
                Assert.That(request.Uri.AbsolutePath, Does.EndWith(Route + (items ? "/conversation/items" : "")));
                Assert.That(request.Uri.Query, Does.Contain("limit=7"));
                Assert.That(request.Uri.Query, Does.Contain("order=asc"));
                Assert.That(request.Uri.Query, Does.Contain("before=before"));
                Assert.That(request.Uri.Query, Does.Contain(i == 0 ? "after=initial" : "after=first"));
                Assert.That(request.Uri.Query, Does.Contain("api-version="));
            });
        }
    }

    [Test]
    public async Task TypedHistoryEnumeratesValuesAndStopsOnNonemptyTerminalPage(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool items)
    {
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(
            isAsync, Page(items, "first", true), Page(items, "last", false));
        BetaVoiceAgentsLiveConversations client = administration.GetBetaVoiceAgentEndpointLiveConversations();
        List<string> ids = [];
        if (items)
        {
            if (isAsync)
            {
                await foreach (VoiceAgentLiveConversationItem item in client.GetLiveAgentConversationItemsAsync("agent", "conversation"))
                {
                    Assert.That(item, Is.TypeOf<VoiceAgentLiveInputConversationItem>());
                    ids.Add(item.Id);
                }
            }
            else
            {
                foreach (VoiceAgentLiveConversationItem item in client.GetLiveAgentConversationItems("agent", "conversation"))
                {
                    Assert.That(item, Is.TypeOf<VoiceAgentLiveInputConversationItem>());
                    ids.Add(item.Id);
                }
            }
        }
        else if (isAsync)
        {
            await foreach (VoiceAgentLiveConversation conversation in client.GetLiveAgentConversationsAsync("agent"))
            {
                ids.Add(conversation.Id);
            }
        }
        else
        {
            ids.AddRange(client.GetLiveAgentConversations("agent").Select(conversation => conversation.Id));
        }

        Assert.Multiple(() =>
        {
            Assert.That(ids, Is.EqualTo(new[] { "first", "last" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        });
    }

    [Test]
    public async Task EmptyTerminalPageDoesNotIssueAnotherRequest(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool raw,
        [Values(false, true)] bool items)
    {
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync,
            """{"data":[],"last_id":"terminal_cursor","has_more":false}""");
        BetaVoiceAgentsLiveConversations client = administration.GetBetaVoiceAgentEndpointLiveConversations();
        if (raw)
        {
            List<ClientResult> pages = await ReadPagesAsync(client, isAsync, true, items, new RequestOptions());
            Assert.That(pages, Has.Count.EqualTo(1));
            using JsonDocument document = JsonDocument.Parse(pages[0].GetRawResponse().Content);
            Assert.That(document.RootElement.GetProperty("data").GetArrayLength(), Is.Zero);
        }
        else if (isAsync)
        {
            if (items)
            {
                await foreach (VoiceAgentLiveConversationItem _ in client.GetLiveAgentConversationItemsAsync("agent", "conversation"))
                {
                    Assert.Fail("An empty page must not produce an item.");
                }
            }
            else
            {
                await foreach (VoiceAgentLiveConversation _ in client.GetLiveAgentConversationsAsync("agent"))
                {
                    Assert.Fail("An empty page must not produce a conversation.");
                }
            }
        }
        else if (items)
        {
            Assert.That(client.GetLiveAgentConversationItems("agent", "conversation").ToList(), Is.Empty);
        }
        else
        {
            Assert.That(client.GetLiveAgentConversations("agent").ToList(), Is.Empty);
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [Test]
    public void InvalidCursorOnNonterminalPageIsReported(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool raw,
        [Values(false, true)] bool items,
        [Values(null, "null", "\"\"")] string cursorJson)
    {
        string cursor = cursorJson == null ? "" : ",\"last_id\":" + cursorJson;
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync,
            """{"data":[],"has_more":true""" + cursor + "}");
        Assert.ThrowsAsync<JsonException>(async () => await ReadPagesAsync(
            administration.GetBetaVoiceAgentEndpointLiveConversations(), isAsync, raw, items, new RequestOptions()));
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task OpaqueCursorsAndRequestHeadersSurviveContinuation(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool raw,
        [Values(false, true)] bool items)
    {
        const string cursor = "cursor/+ ?=&#%";
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync,
            Page(items, cursor, true), Page(items, "last", false));
        RequestOptions options = new();
        options.SetHeader("x-history-test", "retained");
        List<ClientResult> pages = await ReadPagesAsync(
            administration.GetBetaVoiceAgentEndpointLiveConversations(), isAsync, raw, items, options);

        Assert.That(pages, Has.Count.EqualTo(2));
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
        Assert.That(Query(transport.Requests[1].Uri, "after"), Is.EqualTo(cursor));
        foreach (MockPipelineRequest request in transport.Requests)
        {
            Assert.Multiple(() =>
            {
                Assert.That(request.Uri.Fragment, Is.Empty);
                Assert.That(Query(request.Uri, "limit"), Is.EqualTo("7"));
                Assert.That(Query(request.Uri, "order"), Is.EqualTo("asc"));
                Assert.That(Query(request.Uri, "before"), Is.EqualTo("before"));
                Assert.That(Query(request.Uri, "api-version"), Is.EqualTo("v1"));
                Assert.That(request.Headers.TryGetValue("Foundry-Features", out string features), Is.True);
                Assert.That(features, Does.Contain("VoiceAgents=V1Preview"));
                if (raw)
                {
                    Assert.That(request.Headers.TryGetValue("x-history-test", out string header), Is.True);
                    Assert.That(header, Is.EqualTo("retained"));
                }
            });
        }
    }

    [Test]
    public void ContinuationHttpErrorsPropagate(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool raw,
        [Values(false, true)] bool items,
        [Values(404, 412)] int status)
    {
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync,
            new MockPipelineResponse(200).WithContent(Page(items, "first", true)),
            new MockPipelineResponse(status).WithContent("""{"error":{"code":"HistoryUnavailable","message":"The stored history is unavailable."}}"""));
        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(async () => await ReadPagesAsync(
            administration.GetBetaVoiceAgentEndpointLiveConversations(), isAsync, raw, items, new RequestOptions()));

        Assert.That(exception.Status, Is.EqualTo(status));
        Assert.That(exception.Message, Does.Contain("The stored history is unavailable."));
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task ProtocolNoThrowPreservesContinuationErrorResponse(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool items)
    {
        const string error = """{"error":{"code":"NotFound","message":"The stored history was deleted."}}""";
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync,
            new MockPipelineResponse(200).WithContent(Page(items, "first", true)),
            new MockPipelineResponse(404).WithContent(error));
        List<ClientResult> pages = await ReadPagesAsync(
            administration.GetBetaVoiceAgentEndpointLiveConversations(), isAsync, true, items,
            new RequestOptions { ErrorOptions = ClientErrorBehaviors.NoThrow });

        Assert.That(pages, Has.Count.EqualTo(2));
        Assert.That(pages[1].GetRawResponse().Status, Is.EqualTo(404));
        Assert.That(pages[1].GetRawResponse().Content.ToString(), Is.EqualTo(error));
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
    }

    [Test]
    public void CancellationBetweenPagesIsObserved(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool raw,
        [Values(false, true)] bool items)
    {
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync,
            Page(items, "first", true), Page(items, "last", false));
        using CancellationTokenSource cancellation = new();
        transport.OnSendingRequest = message => message.CancellationToken.ThrowIfCancellationRequested();
        int pagesReceived = 0;
        Assert.CatchAsync<OperationCanceledException>(async () => await ReadPagesAsync(
            administration.GetBetaVoiceAgentEndpointLiveConversations(), isAsync, raw, items,
            new RequestOptions { CancellationToken = cancellation.Token }, _ =>
            {
                pagesReceived++;
                cancellation.Cancel();
            }));
        Assert.That(pagesReceived, Is.EqualTo(1), "Cancellation must prevent delivery of the second page.");
    }

    [TestCase("conversation", "GET", "/conversation", false)]
    [TestCase("conversation", "GET", "/conversation", true)]
    [TestCase("delete", "DELETE", "/conversation", false)]
    [TestCase("delete", "DELETE", "/conversation", true)]
    [TestCase("item", "GET", "/conversation/items/item", false)]
    [TestCase("item", "GET", "/conversation/items/item", true)]
    [TestCase("item-audio", "GET", "/conversation/items/item/audio", false)]
    [TestCase("item-audio", "GET", "/conversation/items/item/audio", true)]
    [TestCase("item-audio-content", "GET", "/conversation/items/item/audio/content", false)]
    [TestCase("item-audio-content", "GET", "/conversation/items/item/audio/content", true)]
    [TestCase("audio", "GET", "/conversation/audio", false)]
    [TestCase("audio", "GET", "/conversation/audio", true)]
    [TestCase("audio-content", "GET", "/conversation/audio/content", false)]
    [TestCase("audio-content", "GET", "/conversation/audio/content", true)]
    public async Task LiveRestResourcesUseDedicatedRoutes(string operation, string method, string suffix, bool isAsync)
    {
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync,
            new MockPipelineResponse(operation == "delete" ? 204 : 200).WithContent("{}"));
        BetaVoiceAgentsLiveConversations client = administration.GetBetaVoiceAgentEndpointLiveConversations();
        await ReadResourceAsync(client, operation, isAsync, true, new RequestOptions());

        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        MockPipelineRequest request = transport.Requests[0];
        Assert.Multiple(() =>
        {
            Assert.That(request.Method, Is.EqualTo(method));
            Assert.That(request.Uri.AbsolutePath, Does.EndWith(Route + suffix));
            Assert.That(request.Uri.Query, Does.Contain("api-version="));
            Assert.That(request.Headers.TryGetValue("Foundry-Features", out string features), Is.True);
            Assert.That(features, Does.Contain("VoiceAgents=V1Preview"));
        });
    }

    private static IEnumerable<TestCaseData> ResourceErrorCases()
    {
        foreach (string operation in new[] { "conversation", "delete", "item", "item-audio", "item-audio-content", "audio", "audio-content" })
        {
            foreach (bool isAsync in new[] { false, true })
            {
                yield return new TestCaseData(operation, isAsync, false, false);
                yield return new TestCaseData(operation, isAsync, true, false);
                yield return new TestCaseData(operation, isAsync, true, true);
            }
        }
    }

    [TestCaseSource(nameof(ResourceErrorCases))]
    public async Task MissingResourcesThrowOrPreserveTheProtocolError(string operation, bool isAsync, bool raw, bool noThrow)
    {
        const string error = """{"error":{"code":"NotFound","message":"The stored resource does not exist."}}""";
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync,
            new MockPipelineResponse(404).WithContent(error));
        BetaVoiceAgentsLiveConversations client = administration.GetBetaVoiceAgentEndpointLiveConversations();
        RequestOptions options = new() { ErrorOptions = noThrow ? ClientErrorBehaviors.NoThrow : ClientErrorBehaviors.Default };
        if (noThrow)
        {
            ClientResult result = await ReadResourceAsync(client, operation, isAsync, raw, options);
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(404));
            Assert.That(result.GetRawResponse().Content.ToString(), Is.EqualTo(error));
        }
        else
        {
            ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(async () =>
                await ReadResourceAsync(client, operation, isAsync, raw, options));
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That(exception.Message, Does.Contain("The stored resource does not exist."));
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [Test]
    public void AudioDownloadHonorsCancellation(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool raw)
    {
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync, "{}");
        transport.OnSendingRequest = message => message.CancellationToken.ThrowIfCancellationRequested();
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();
        Assert.CatchAsync<OperationCanceledException>(async () => await ReadResourceAsync(
            administration.GetBetaVoiceAgentEndpointLiveConversations(), "audio-content", isAsync, raw,
            new RequestOptions { CancellationToken = cancellation.Token }));
        Assert.That(transport.Requests, Is.Empty);
    }

    [Test]
    public void ResourceMethodsRejectInvalidConversationIdsLocally(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool raw,
        [Values(null, "")] string conversationId)
    {
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync, "{}");
        ArgumentException exception = Assert.CatchAsync<ArgumentException>(async () => await ReadResourceAsync(
            administration.GetBetaVoiceAgentEndpointLiveConversations(), "conversation", isAsync, raw,
            new RequestOptions(), conversationId));
        Assert.That(exception, Is.TypeOf(conversationId == null ? typeof(ArgumentNullException) : typeof(ArgumentException)));
        Assert.That(exception.ParamName, Is.EqualTo("conversationId"));
        Assert.That(transport.Requests, Is.Empty);
    }

    private static async Task<ClientResult> ReadResourceAsync(
        BetaVoiceAgentsLiveConversations client, string operation, bool isAsync, bool raw, RequestOptions options, string conversationId = "conversation")
    {
        if (!raw)
        {
            return operation switch
            {
                "conversation" => isAsync ? await client.GetLiveAgentConversationAsync("agent", conversationId, options.CancellationToken) : client.GetLiveAgentConversation("agent", conversationId, options.CancellationToken),
                "delete" => isAsync ? await client.DeleteLiveAgentConversationAsync("agent", conversationId, options.CancellationToken) : client.DeleteLiveAgentConversation("agent", conversationId, options.CancellationToken),
                "item" => isAsync ? await client.GetLiveAgentConversationItemAsync("agent", conversationId, "item", options.CancellationToken) : client.GetLiveAgentConversationItem("agent", conversationId, "item", options.CancellationToken),
                "item-audio" => isAsync ? await client.GetLiveAgentConversationAudioItemAsync("agent", conversationId, "item", options.CancellationToken) : client.GetLiveAgentConversationAudioItem("agent", conversationId, "item", options.CancellationToken),
                "item-audio-content" => isAsync ? await client.GetLiveAgentConversationAudioItemContentAsync("agent", conversationId, "item", options.CancellationToken) : client.GetLiveAgentConversationAudioItemContent("agent", conversationId, "item", options.CancellationToken),
                "audio" => isAsync ? await client.GetLiveAgentConversationAudioAsync("agent", conversationId, options.CancellationToken) : client.GetLiveAgentConversationAudio("agent", conversationId, options.CancellationToken),
                "audio-content" => isAsync ? await client.GetLiveAgentConversationAudioContentAsync("agent", conversationId, options.CancellationToken) : client.GetLiveAgentConversationAudioContent("agent", conversationId, options.CancellationToken),
                _ => throw new ArgumentOutOfRangeException(nameof(operation))
            };
        }
        return isAsync
            ? await (operation switch
            {
                "conversation" => client.GetLiveAgentConversationAsync("agent", conversationId, options),
                "delete" => client.DeleteLiveAgentConversationAsync("agent", conversationId, options),
                "item" => client.GetLiveAgentConversationItemAsync("agent", conversationId, "item", options),
                "item-audio" => client.GetLiveAgentConversationAudioItemAsync("agent", conversationId, "item", options),
                "item-audio-content" => client.GetLiveAgentConversationAudioItemContentAsync("agent", conversationId, "item", options),
                "audio" => client.GetLiveAgentConversationAudioAsync("agent", conversationId, options),
                "audio-content" => client.GetLiveAgentConversationAudioContentAsync("agent", conversationId, options),
                _ => throw new ArgumentOutOfRangeException(nameof(operation))
            })
            : operation switch
            {
                "conversation" => client.GetLiveAgentConversation("agent", conversationId, options),
                "delete" => client.DeleteLiveAgentConversation("agent", conversationId, options),
                "item" => client.GetLiveAgentConversationItem("agent", conversationId, "item", options),
                "item-audio" => client.GetLiveAgentConversationAudioItem("agent", conversationId, "item", options),
                "item-audio-content" => client.GetLiveAgentConversationAudioItemContent("agent", conversationId, "item", options),
                "audio" => client.GetLiveAgentConversationAudio("agent", conversationId, options),
                "audio-content" => client.GetLiveAgentConversationAudioContent("agent", conversationId, options),
                _ => throw new ArgumentOutOfRangeException(nameof(operation))
            };
    }

    private static string Page(bool items, string id, bool hasMore)
    {
        string data = items
            ? $$"""{"id":"{{id}}","type":"input","transcription":"Hello"}"""
            : $$"""{"id":"{{id}}","object":"voice.conversation","status":"completed","created_at":1700000000}""";
        return $$"""{"data":[{{data}}],"first_id":"{{id}}","last_id":"{{id}}","has_more":{{hasMore.ToString().ToLowerInvariant()}}}""";
    }

    private static async Task<List<ClientResult>> ReadPagesAsync(
        BetaVoiceAgentsLiveConversations client, bool isAsync, bool raw, bool items, RequestOptions options, Action<ClientResult> onPage = null)
    {
        List<ClientResult> pages = [];
        if (isAsync)
        {
            AsyncCollectionResult collection = items
                ? raw
                    ? client.GetLiveAgentConversationItemsAsync("agent", "conversation", 7, "asc", "initial", "before", options)
                    : client.GetLiveAgentConversationItemsAsync("agent", "conversation", 7, AgentListOrder.Ascending, "initial", "before", options.CancellationToken)
                : raw
                    ? client.GetLiveAgentConversationsAsync("agent", 7, "asc", "initial", "before", options)
                    : client.GetLiveAgentConversationsAsync("agent", 7, AgentListOrder.Ascending, "initial", "before", options.CancellationToken);
            await foreach (ClientResult page in collection.GetRawPagesAsync())
            {
                pages.Add(page);
                onPage?.Invoke(page);
            }
        }
        else
        {
            CollectionResult collection = items
                ? raw
                    ? client.GetLiveAgentConversationItems("agent", "conversation", 7, "asc", "initial", "before", options)
                    : client.GetLiveAgentConversationItems("agent", "conversation", 7, AgentListOrder.Ascending, "initial", "before", options.CancellationToken)
                : raw
                    ? client.GetLiveAgentConversations("agent", 7, "asc", "initial", "before", options)
                    : client.GetLiveAgentConversations("agent", 7, AgentListOrder.Ascending, "initial", "before", options.CancellationToken);
            foreach (ClientResult page in collection.GetRawPages())
            {
                pages.Add(page);
                onPage?.Invoke(page);
            }
        }
        return pages;
    }

    private static string Query(Uri uri, string name)
        => uri.Query.TrimStart('?').Split('&').Select(value => value.Split(new[] { '=' }, 2))
            .Where(value => value.Length == 2 && Uri.UnescapeDataString(value[0]) == name)
            .Select(value => Uri.UnescapeDataString(value[1])).SingleOrDefault();

    private static (AgentAdministrationClient Client, MockPipelineTransport Transport) CreateClient(bool isAsync, params string[] responses)
        => CreateClient(isAsync, responses.Select(response => new MockPipelineResponse(200).WithContent(response)).ToArray());

    private static (AgentAdministrationClient Client, MockPipelineTransport Transport) CreateClient(bool isAsync, params MockPipelineResponse[] responses)
    {
        int index = 0;
        MockPipelineTransport transport = new(request =>
        {
            int responseIndex = Interlocked.Increment(ref index) - 1;
            Assert.That(responseIndex, Is.LessThan(responses.Length), "The client requested a page after has_more=false.");
            return responses[responseIndex];
        })
        {
            ExpectSyncPipeline = !isAsync
        };
        AgentAdministrationClient client = new(new Uri(Endpoint), new FakeTokenProvider(), new AgentAdministrationClientOptions { Transport = transport });
        return (client, transport);
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
