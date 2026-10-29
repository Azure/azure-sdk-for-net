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
    public async Task EmptyTerminalPageDoesNotIssueAnotherRequest([Values(false, true)] bool isAsync)
    {
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync,
            """{"data":[],"last_id":"terminal_cursor","has_more":false}""");
        BetaVoiceAgentsLiveConversations client = administration.GetBetaVoiceAgentEndpointLiveConversations();
        if (isAsync)
        {
            await foreach (VoiceAgentLiveConversation _ in client.GetLiveAgentConversationsAsync("agent"))
            {
                Assert.Fail("An empty page must not produce a value.");
            }
        }
        else
        {
            Assert.That(client.GetLiveAgentConversations("agent").ToList(), Is.Empty);
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [Test]
    public void MissingCursorOnNonterminalPageIsReported()
    {
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(false,
            """{"data":[],"has_more":true}""");
        Assert.Throws<JsonException>(() => administration.GetBetaVoiceAgentEndpointLiveConversations()
            .GetLiveAgentConversations("agent").ToList());
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
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
        (AgentAdministrationClient administration, MockPipelineTransport transport) = CreateClient(isAsync, "{}");
        BetaVoiceAgentsLiveConversations client = administration.GetBetaVoiceAgentEndpointLiveConversations();
        RequestOptions options = new();
        if (isAsync)
        {
            await (operation switch
            {
                "conversation" => client.GetLiveAgentConversationAsync("agent", "conversation", options),
                "delete" => client.DeleteLiveAgentConversationAsync("agent", "conversation", options),
                "item" => client.GetLiveAgentConversationItemAsync("agent", "conversation", "item", options),
                "item-audio" => client.GetLiveAgentConversationAudioItemAsync("agent", "conversation", "item", options),
                "item-audio-content" => client.GetLiveAgentConversationAudioItemContentAsync("agent", "conversation", "item", options),
                "audio" => client.GetLiveAgentConversationAudioAsync("agent", "conversation", options),
                _ => client.GetLiveAgentConversationAudioContentAsync("agent", "conversation", options)
            });
        }
        else
        {
            _ = operation switch
            {
                "conversation" => client.GetLiveAgentConversation("agent", "conversation", options),
                "delete" => client.DeleteLiveAgentConversation("agent", "conversation", options),
                "item" => client.GetLiveAgentConversationItem("agent", "conversation", "item", options),
                "item-audio" => client.GetLiveAgentConversationAudioItem("agent", "conversation", "item", options),
                "item-audio-content" => client.GetLiveAgentConversationAudioItemContent("agent", "conversation", "item", options),
                "audio" => client.GetLiveAgentConversationAudio("agent", "conversation", options),
                _ => client.GetLiveAgentConversationAudioContent("agent", "conversation", options)
            };
        }

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

    private static string Page(bool items, string id, bool hasMore)
    {
        string data = items
            ? $$"""{"id":"{{id}}","type":"input","transcription":"Hello"}"""
            : $$"""{"id":"{{id}}","object":"voice.conversation","status":"completed","created_at":1700000000}""";
        return $$"""{"data":[{{data}}],"first_id":"{{id}}","last_id":"{{id}}","has_more":{{hasMore.ToString().ToLowerInvariant()}}}""";
    }

    private static (AgentAdministrationClient Client, MockPipelineTransport Transport) CreateClient(bool isAsync, params string[] responses)
    {
        int index = 0;
        MockPipelineTransport transport = new(request =>
        {
            int responseIndex = Interlocked.Increment(ref index) - 1;
            Assert.That(responseIndex, Is.LessThan(responses.Length), "The client requested a page after has_more=false.");
            return new MockPipelineResponse(request.Request.Method == "DELETE" ? 204 : 200).WithContent(responses[responseIndex]);
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
