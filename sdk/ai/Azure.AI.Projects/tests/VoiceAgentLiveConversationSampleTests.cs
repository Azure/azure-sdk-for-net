// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Tests.Samples;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests;

public class VoiceAgentLiveConversationSampleTests
{
    private const string Endpoint = "https://example.services.ai.azure.com/api/projects/project";
    private const string AgentName = "stored-live-agent";
    private const string ConversationId = "conversation-from-session-started";
    private const string SpeechId = "speech-from-history";
    private const string Route = "/api/projects/project/agents/" + AgentName + "/endpoint/protocols/voice/live/conversations";
    private const string ConversationSuffix = "/" + ConversationId;
    private const string ItemsSuffix = ConversationSuffix + "/items";
    private const string ItemSuffix = ItemsSuffix + "/" + SpeechId;
    private const string SegmentSuffix = ItemSuffix + "/audio";
    private const string RecordingSuffix = ConversationSuffix + "/audio";
    private const string PrivateBlobUri = "https://customer-storage.example/private-recordings/conversation.wav";
    private static readonly byte[] SegmentBytes = { 3, 1, 4, 1, 5 };
    private static readonly byte[] RecordingBytes = { 2, 7, 1, 8, 2, 8 };

    [Test]
    public async Task AllOverloadsReadEveryResourcePageAndDeleteOnlyAfterDownloads(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values(false, true)] bool deleteConversation,
        [Values("input", "output")] string speechType)
    {
        using SampleFixture fixture = new(sample, speechType);
        fixture.BeforeDelete = () =>
        {
            Assert.That(File.ReadAllBytes(Path.Combine(fixture.OutputDirectory, "segment.wav")), Is.EqualTo(SegmentBytes));
            Assert.That(File.ReadAllBytes(Path.Combine(fixture.OutputDirectory, "conversation.wav")), Is.EqualTo(RecordingBytes));
        };

        await RunSample(sample, fixture, deleteConversation);

        string[] expectedPaths =
        {
            Route, Route, Route + ConversationSuffix,
            Route + ItemsSuffix, Route + ItemsSuffix, Route + ItemSuffix,
            Route + SegmentSuffix, Route + SegmentSuffix + "/content",
            Route + RecordingSuffix, Route + RecordingSuffix + "/content"
        };
        if (deleteConversation)
        {
            expectedPaths = expectedPaths.Concat(new[] { Route + ConversationSuffix }).ToArray();
        }
        Assert.Multiple(() =>
        {
            Assert.That(fixture.Transport.Requests.Select(request => request.Uri.AbsolutePath).ToArray(), Is.EqualTo(expectedPaths));
            Assert.That(fixture.Transport.Requests.Select(request => request.Method).ToArray(),
                Is.EqualTo(Enumerable.Repeat("GET", 10).Concat(deleteConversation ? new[] { "DELETE" } : Array.Empty<string>()).ToArray()));
            Assert.That(File.ReadAllBytes(Path.Combine(fixture.OutputDirectory, "segment.wav")), Is.EqualTo(SegmentBytes));
            Assert.That(File.ReadAllBytes(Path.Combine(fixture.OutputDirectory, "conversation.wav")), Is.EqualTo(RecordingBytes));
            Assert.That(Directory.GetFiles(fixture.OutputDirectory).Select(Path.GetFileName).ToArray(),
                Is.EquivalentTo(new[] { "segment.wav", "conversation.wav" }));
            Assert.That(fixture.Transport.Requests.Count(request => request.Method == "DELETE"), Is.EqualTo(deleteConversation ? 1 : 0));
        });

        MockPipelineRequest[] conversationPages = fixture.Transport.Requests.Where(request => request.Uri.AbsolutePath == Route).ToArray();
        MockPipelineRequest[] itemPages = fixture.Transport.Requests.Where(request => request.Uri.AbsolutePath == Route + ItemsSuffix).ToArray();
        AssertPaging(conversationPages, ConversationId);
        AssertPaging(itemPages, "delegation");
        Assert.That(fixture.Transport.Requests.Any(request => request.Uri.AbsolutePath.Contains("/items/later-speech")), Is.False);
        Assert.That(fixture.Transport.Requests.Any(request => request.Uri.AbsolutePath.Contains("/items/delegation")), Is.False);
        foreach (MockPipelineRequest request in fixture.Transport.Requests)
        {
            Assert.Multiple(() =>
            {
                Assert.That(request.Uri.AbsoluteUri, Does.Not.Contain("realtime"));
                Assert.That(request.Uri.Query, Does.Contain("api-version=v1"));
                Assert.That(request.Headers.TryGetValue("Foundry-Features", out string features), Is.True);
                Assert.That(features, Does.Contain("VoiceAgents=V1Preview"));
                if (request.Method == "GET")
                {
                    Assert.That(request.Headers.TryGetValue("Accept", out string accept), Is.True);
                    Assert.That(accept, Is.EqualTo(request.Uri.AbsolutePath.EndsWith("/content", StringComparison.Ordinal) ? "audio/wav" : "application/json"));
                }
            });
        }
    }

    [Test]
    public async Task OmittingDeleteArgumentPreservesConversation(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample)
    {
        using SampleFixture fixture = new(sample);
        await RunSample(sample, fixture);
        Assert.That(fixture.Transport.Requests.Count, Is.EqualTo(10));
        AssertNoDelete(fixture);
    }

    [Test]
    public void MissingLiveRoutesPropagate404WithoutFallbackOrDeletion(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values("", ConversationSuffix, ItemsSuffix, ItemSuffix, SegmentSuffix, SegmentSuffix + "/content",
            RecordingSuffix, RecordingSuffix + "/content")] string failedSuffix)
    {
        using SampleFixture fixture = new(sample) { FailedSuffix = failedSuffix };
        ClientResultException error = Assert.ThrowsAsync<ClientResultException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.Multiple(() =>
        {
            Assert.That(error.Status, Is.EqualTo(404));
            Assert.That(fixture.Transport.Requests.Last().Uri.AbsolutePath, Is.EqualTo(Route + failedSuffix));
            Assert.That(fixture.Transport.Requests.All(request => request.Uri.AbsolutePath.StartsWith(Route, StringComparison.Ordinal)), Is.True);
        });
        AssertNoDelete(fixture);
    }

    [Test]
    public void NonfinalizedOrFailedPersistenceIsNotACompleteSample(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values("in_progress", "failed")] string status)
    {
        using SampleFixture fixture = new(sample) { ConversationStatus = status };
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(error.Message, Does.Contain(status).And.Contain("finalization"));
        Assert.That(fixture.Transport.Requests.Count, Is.EqualTo(3));
        AssertNoDelete(fixture);
    }

    [Test]
    public void MismatchedConversationIdFailsBeforeReadingItems(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample)
    {
        using SampleFixture fixture = new(sample) { ReturnedConversationId = "different-conversation" };
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(error.Message, Does.Contain("does not match"));
        Assert.That(fixture.Transport.Requests.Count, Is.EqualTo(3));
        AssertNoDelete(fixture);
    }

    [Test]
    public void EmptyUnknownOrDelegationOnlyHistoryDoesNotInventSpeechIds(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values(false, true)] bool nonSpeechItems)
    {
        using SampleFixture fixture = new(sample)
        {
            ItemsPageOverride = nonSpeechItems
                ? Page(NonSpeechItems, "delegation", false)
                : Page("", "", false)
        };
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(error.Message, Does.Contain("No stored input or output speech item").And.Contain("actual speech"));
        Assert.That(fixture.Transport.Requests.Count, Is.EqualTo(4));
        AssertNoDelete(fixture);
    }

    [Test]
    public void MalformedSpeechItemsFailRatherThanUsingPlaceholderIds(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values("""{"type":"input"}""", """{"type":"output","id":""}""", """{"type":"input","id":" "}""", "null")] string item)
    {
        using SampleFixture fixture = new(sample) { ItemsPageOverride = Page(item, "unused", false) };
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(error.Message, Does.Contain("nonempty id"));
        Assert.That(fixture.Transport.Requests.Count, Is.EqualTo(4));
        AssertNoDelete(fixture);
    }

    [Test]
    public void MalformedHistoryJsonPropagatesWithoutDeleting(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample)
    {
        using SampleFixture fixture = new(sample) { ItemsPageOverride = """{"data":[not-json]}""" };
        Assert.CatchAsync<JsonException>(() => RunSample(sample, fixture, deleteConversation: true));
        AssertNoDelete(fixture);
    }

    [Test]
    public void UnsupportedItemKindsAreNotInterpretedAsSpeech(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample)
    {
        using SampleFixture fixture = new(sample)
        {
            ItemsPageOverride = Page("""{"id":"unknown","type":"future_item"}""", "unknown", false)
        };
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(fixture.Transport.Requests.Count, Is.EqualTo(4));
        AssertNoDelete(fixture);
    }

    [Test]
    public void MissingDeleteRoutePropagates404AfterDownloads(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample)
    {
        using SampleFixture fixture = new(sample) { FailDelete = true };
        ClientResultException error = Assert.ThrowsAsync<ClientResultException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.Multiple(() =>
        {
            Assert.That(error.Status, Is.EqualTo(404));
            Assert.That(fixture.Transport.Requests.Last().Method, Is.EqualTo("DELETE"));
            Assert.That(fixture.Transport.Requests.Count, Is.EqualTo(11));
            Assert.That(File.ReadAllBytes(Path.Combine(fixture.OutputDirectory, "segment.wav")), Is.EqualTo(SegmentBytes));
            Assert.That(File.ReadAllBytes(Path.Combine(fixture.OutputDirectory, "conversation.wav")), Is.EqualTo(RecordingBytes));
        });
        Assert.That(fixture.Transport.Requests.Count(request => request.Method == "DELETE"), Is.EqualTo(1));
    }

    [Test]
    public void RetrievedItemMustMatchTheSelectedSpeechItem(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values(false, true)] bool delegation)
    {
        using SampleFixture fixture = new(sample)
        {
            RetrievedItemOverride = delegation
                ? $$"""{"id":"{{SpeechId}}","type":"delegation","target":"client","created_at":1700000000}"""
                : SpeechItem("different-item", "input")
        };
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(error.Message, Does.Contain("selected input or output speech item"));
        Assert.That(fixture.Transport.Requests.Count, Is.EqualTo(6));
        AssertNoDelete(fixture);
    }

    [Test]
    public void ByosMetadataRequiresOwnCredentialsAndIsNotFollowed(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values(false, true)] bool mergedRecording)
    {
        using SampleFixture fixture = new(sample) { SegmentByos = !mergedRecording, RecordingByos = mergedRecording };
        NotSupportedException error = Assert.ThrowsAsync<NotSupportedException>(() => RunSample(sample, fixture, deleteConversation: true));
        string blockedContentPath = Route + (mergedRecording ? RecordingSuffix : SegmentSuffix) + "/content";
        Assert.Multiple(() =>
        {
            Assert.That(error.Message, Does.Contain("BYOS").And.Contain("own credentials").And.Contain("without a SAS token"));
            Assert.That(error.Message, Does.Not.Contain(PrivateBlobUri));
            Assert.That(fixture.Transport.Requests.Any(request => request.Uri.AbsolutePath == blockedContentPath), Is.False);
            Assert.That(fixture.Transport.Requests.All(request => request.Uri.Host == "example.services.ai.azure.com"), Is.True);
        });
        AssertNoDelete(fixture);
    }

    [Test]
    public void MetadataMustReferToTheRequestedResources(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values(false, true)] bool mergedRecording)
    {
        using SampleFixture fixture = new(sample) { InvalidSegmentMetadata = !mergedRecording, InvalidRecordingMetadata = mergedRecording };
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(error.Message, Does.Contain("metadata must identify"));
        Assert.That(fixture.Transport.Requests.Last().Uri.AbsolutePath, Is.EqualTo(Route + (mergedRecording ? RecordingSuffix : SegmentSuffix)));
        AssertNoDelete(fixture);
    }

    [Test]
    public void EmptyDownloadsAreFailuresAndNeverTriggerDeletion(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values(false, true)] bool mergedRecording)
    {
        using SampleFixture fixture = new(sample) { EmptyContentSuffix = (mergedRecording ? RecordingSuffix : SegmentSuffix) + "/content" };
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(error.Message, Does.Contain("download was empty"));
        Assert.That(File.Exists(Path.Combine(fixture.OutputDirectory, mergedRecording ? "conversation.wav" : "segment.wav")), Is.False);
        AssertNoDelete(fixture);
    }

    [Test]
    public void PreCanceledSamplesDoNotSendRequests(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample)
    {
        using SampleFixture fixture = new(sample);
        fixture.Cancellation.Cancel();
        Assert.CatchAsync<OperationCanceledException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(fixture.Transport.Requests, Is.Empty);
        Assert.That(Directory.GetFiles(fixture.OutputDirectory), Is.Empty);
    }

    [Test]
    public void CancellationDuringPagingOrDownloadPreventsDeletion(
        [Values("Read", "ReadAsync", "ReadProtocol", "ReadProtocolAsync")] string sample,
        [Values("", SegmentSuffix + "/content", RecordingSuffix + "/content")] string cancelSuffix)
    {
        using SampleFixture fixture = new(sample);
        fixture.Transport.OnReceivedResponse = message =>
        {
            if (message.Request.Uri.AbsolutePath == Route + cancelSuffix)
            {
                fixture.Cancellation.Cancel();
            }
        };
        Assert.CatchAsync<OperationCanceledException>(() => RunSample(sample, fixture, deleteConversation: true));
        Assert.That(fixture.Transport.Requests.Last().Uri.AbsolutePath, Is.EqualTo(Route + cancelSuffix));
        AssertNoDelete(fixture);
    }

    private static void AssertPaging(MockPipelineRequest[] pages, string cursor)
    {
        Assert.That(pages.Length, Is.EqualTo(2), "The nonempty terminal page must stop pagination.");
        for (int index = 0; index < pages.Length; index++)
        {
            Assert.Multiple(() =>
            {
                Assert.That(pages[index].Uri.Query, Does.Contain("limit=2").And.Contain("order=asc"));
                Assert.That(pages[index].Uri.Query, Does.Not.Contain("before="));
                Assert.That(pages[index].Uri.Query,
                    index == 0 ? Does.Not.Contain("after=") : Does.Contain("after=" + cursor));
            });
        }
    }

    private static void AssertNoDelete(SampleFixture fixture)
        => Assert.That(fixture.Transport.Requests.Count(request => request.Method == "DELETE"), Is.Zero);

    private static async Task RunSample(string sample, SampleFixture fixture, bool? deleteConversation = null)
    {
        if (deleteConversation.HasValue)
        {
            switch (sample)
            {
                case "Read":
                    Sample_VoiceAgent_Live_Conversations.Read(fixture.Client, AgentName, ConversationId, fixture.OutputDirectory,
                        deleteConversation: deleteConversation.Value, cancellationToken: fixture.Cancellation.Token);
                    break;
                case "ReadAsync":
                    await Sample_VoiceAgent_Live_Conversations.ReadAsync(fixture.Client, AgentName, ConversationId, fixture.OutputDirectory,
                        deleteConversation: deleteConversation.Value, cancellationToken: fixture.Cancellation.Token);
                    break;
                case "ReadProtocol":
                    Sample_VoiceAgent_Live_Conversations.ReadProtocol(fixture.Client, AgentName, ConversationId, fixture.OutputDirectory,
                        deleteConversation: deleteConversation.Value, cancellationToken: fixture.Cancellation.Token);
                    break;
                case "ReadProtocolAsync":
                    await Sample_VoiceAgent_Live_Conversations.ReadProtocolAsync(fixture.Client, AgentName, ConversationId, fixture.OutputDirectory,
                        deleteConversation: deleteConversation.Value, cancellationToken: fixture.Cancellation.Token);
                    break;
                default:
                    throw new ArgumentException("Unknown sample.", nameof(sample));
            }
            return;
        }

        switch (sample)
        {
            case "Read":
                Sample_VoiceAgent_Live_Conversations.Read(fixture.Client, AgentName, ConversationId, fixture.OutputDirectory,
                    cancellationToken: fixture.Cancellation.Token);
                break;
            case "ReadAsync":
                await Sample_VoiceAgent_Live_Conversations.ReadAsync(fixture.Client, AgentName, ConversationId, fixture.OutputDirectory,
                    cancellationToken: fixture.Cancellation.Token);
                break;
            case "ReadProtocol":
                Sample_VoiceAgent_Live_Conversations.ReadProtocol(fixture.Client, AgentName, ConversationId, fixture.OutputDirectory,
                    cancellationToken: fixture.Cancellation.Token);
                break;
            case "ReadProtocolAsync":
                await Sample_VoiceAgent_Live_Conversations.ReadProtocolAsync(fixture.Client, AgentName, ConversationId, fixture.OutputDirectory,
                    cancellationToken: fixture.Cancellation.Token);
                break;
            default:
                throw new ArgumentException("Unknown sample.", nameof(sample));
        }
    }

    private const string NonSpeechItems =
        """{"id":"unknown-delegation","type":"delegation","target":"future_target","created_at":1700000000},{"id":"delegation","type":"delegation","target":"client","created_at":1700000000,"commentary":"Not a spoken transcript"}""";

    private static string Conversation(string id, string status = "completed")
        => $$"""{"id":"{{id}}","object":"voice.conversation","status":"{{status}}","created_at":1700000000,"completed_at":1700000001}""";

    private static string SpeechItem(string id, string type)
        => $$"""{"id":"{{id}}","type":"{{type}}","transcription":"Do not print stored transcripts."}""";

    private static string Page(string data, string lastId, bool hasMore)
        => $$"""{"data":[{{data}}],"last_id":"{{lastId}}","has_more":{{hasMore.ToString().ToLowerInvariant()}}}""";

    private sealed class SampleFixture : IDisposable
    {
        public SampleFixture(string sample, string speechType = "input")
        {
            OutputDirectory = Path.Combine(Path.GetTempPath(), "live-conversation-sample-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(OutputDirectory);
            SpeechType = speechType;
            Transport = new MockPipelineTransport(Respond)
            {
                ExpectSyncPipeline = !sample.EndsWith("Async", StringComparison.Ordinal),
                OnSendingRequest = message =>
                {
                    Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                    message.CancellationToken.ThrowIfCancellationRequested();
                }
            };
            AgentAdministrationClientOptions options = new() { Transport = Transport };
            options.AddPolicy(new CallerTokenPolicy(Cancellation.Token), PipelinePosition.PerCall);
            AgentAdministrationClient administration = new(new Uri(Endpoint), new FakeTokenProvider(), options);
            Client = administration.GetBetaVoiceAgentEndpointLiveConversations();
        }

        public BetaVoiceAgentsLiveConversations Client { get; }
        public MockPipelineTransport Transport { get; }
        public CancellationTokenSource Cancellation { get; } = new();
        public string OutputDirectory { get; }
        public string SpeechType { get; }
        public string FailedSuffix { get; set; }
        public bool FailDelete { get; set; }
        public string ItemsPageOverride { get; set; }
        public string RetrievedItemOverride { get; set; }
        public string ReturnedConversationId { get; set; } = ConversationId;
        public string ConversationStatus { get; set; } = "completed";
        public string EmptyContentSuffix { get; set; }
        public bool SegmentByos { get; set; }
        public bool RecordingByos { get; set; }
        public bool InvalidSegmentMetadata { get; set; }
        public bool InvalidRecordingMetadata { get; set; }
        public Action BeforeDelete { get; set; }

        public void Dispose()
        {
            Cancellation.Dispose();
            if (Directory.Exists(OutputDirectory))
            {
                Directory.Delete(OutputDirectory, recursive: true);
            }
        }

        private MockPipelineResponse Respond(MockPipelineMessage message)
        {
            MockPipelineRequest request = (MockPipelineRequest)message.Request;
            Assert.That(request.Uri.AbsolutePath, Does.StartWith(Route), "The sample must not switch to Realtime or a storage endpoint.");
            string suffix = request.Uri.AbsolutePath.Substring(Route.Length);
            if (suffix == FailedSuffix || (FailDelete && request.Method == "DELETE"))
            {
                return Json("""{"error":{"code":"NotFound","message":"The Live REST route is unavailable in this deployment."}}""", 404);
            }
            if (request.Method == "DELETE")
            {
                Assert.That(suffix, Is.EqualTo(ConversationSuffix));
                BeforeDelete?.Invoke();
                return new MockPipelineResponse(204);
            }
            Assert.That(request.Method, Is.EqualTo("GET"));
            bool after = request.Uri.Query.Contains("after=");
            switch (suffix)
            {
                case "":
                    return Json(after
                        ? Page(Conversation("terminal-conversation"), "terminal-conversation", false)
                        : Page(Conversation("earlier-conversation") + "," + Conversation(ConversationId), ConversationId, true));
                case ConversationSuffix:
                    return Json(Conversation(ReturnedConversationId, ConversationStatus));
                case ItemsSuffix:
                    return Json(ItemsPageOverride ?? (after
                        ? Page(SpeechItem(SpeechId, SpeechType) + "," + SpeechItem("later-speech", SpeechType == "input" ? "output" : "input"), "later-speech", false)
                        : Page(NonSpeechItems, "delegation", true)));
                case ItemSuffix:
                    return Json(RetrievedItemOverride ?? SpeechItem(SpeechId, SpeechType));
                case SegmentSuffix:
                    string itemId = InvalidSegmentMetadata ? "different-item" : SpeechId;
                    string segmentBlob = SegmentByos ? ",\"blob_uri\":\"" + PrivateBlobUri + "\"" : "";
                    return Json($$"""{"conversation_id":"{{ConversationId}}","item_id":"{{itemId}}","role":"{{(SpeechType == "input" ? "user" : "assistant")}}","format":"wav","codec":"pcm16","sample_rate":24000,"channels":1,"start_offset_ms":0,"duration_ms":100{{segmentBlob}}}""");
                case RecordingSuffix:
                    string id = InvalidRecordingMetadata ? "different-conversation" : ConversationId;
                    string recordingBlob = RecordingByos ? ",\"blob_uri\":\"" + PrivateBlobUri + "\"" : "";
                    return Json($$"""{"conversation_id":"{{id}}","format":"wav","sample_rate":24000,"channels":2,"channel_layout":{"left":"user","right":"assistant"},"duration_ms":100{{recordingBlob}}}""");
                case SegmentSuffix + "/content":
                    return Audio(suffix, SegmentBytes);
                case RecordingSuffix + "/content":
                    return Audio(suffix, RecordingBytes);
                default:
                    Assert.Fail("Unexpected Live REST resource: " + suffix);
                    return new MockPipelineResponse(500);
            }
        }

        private MockPipelineResponse Audio(string suffix, byte[] bytes)
            => new MockPipelineResponse(200).WithHeader("Content-Type", "audio/wav")
                .WithContent(suffix == EmptyContentSuffix ? Array.Empty<byte>() : bytes);

        private static MockPipelineResponse Json(string content, int status = 200)
            => new MockPipelineResponse(status).WithHeader("Content-Type", "application/json").WithContent(content);
    }

    private sealed class CallerTokenPolicy(CancellationToken expectedToken) : PipelinePolicy
    {
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            Assert.That(message.CancellationToken, Is.EqualTo(expectedToken), "Every page and resource must use the caller's token.");
            ProcessNext(message, pipeline, currentIndex);
        }

        public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            Assert.That(message.CancellationToken, Is.EqualTo(expectedToken), "Every page and resource must use the caller's token.");
            return ProcessNextAsync(message, pipeline, currentIndex);
        }
    }

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);

        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return new AuthenticationToken("fake-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);
        }

        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}
