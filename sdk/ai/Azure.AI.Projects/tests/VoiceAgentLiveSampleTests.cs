// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Tests.Samples;
using NUnit.Framework;

#pragma warning disable AAIP001, AAIP002, OPENAI001

namespace Azure.AI.Projects.Tests;

public class VoiceAgentLiveSampleTests
{
    [Test]
    public async Task ScriptedTextCompletesMultipleTurnsWithOneReceiver()
    {
        using ScriptedSession session = new(Text("First reply."), Complete(), Text("Second reply."), Complete());
        using StringWriter output = new();

        await Sample_VoiceAgent_Live.RunResponsesConversationAsync(
            session, new[] { "First prompt", "Second prompt" }, output, false, default);

        Assert.Multiple(() =>
        {
            Assert.That(session.Receivers, Is.EqualTo(1));
            Assert.That(session.ReceiverEnded, Is.True);
            Assert.That(session.Commands.Select(EventType),
                Is.EqualTo(new[] { "response.item.create", "response.create", "response.item.create", "response.create" }));
            Assert.That(output.ToString(), Does.Contain("You: First prompt").And.Contain("First reply.")
                .And.Contain("You: Second prompt").And.Contain("Second reply."));
        });
        using JsonDocument first = JsonDocument.Parse(session.Commands[0]);
        using JsonDocument second = JsonDocument.Parse(session.Commands[2]);
        Assert.That(first.RootElement.GetProperty("item").GetProperty("content")[0].GetProperty("text").GetString(), Is.EqualTo("First prompt"));
        Assert.That(second.RootElement.GetProperty("item").GetProperty("content")[0].GetProperty("text").GetString(), Is.EqualTo("Second prompt"));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    public void EmptyScriptedPromptsAreRejectedBeforeSending(string prompt)
    {
        using ScriptedSession session = new();
        Assert.ThrowsAsync<ArgumentException>(() => Run(session, new[] { prompt }));
        Assert.That(session.Commands, Is.Empty);
    }

    [Test]
    public void NullPromptCollectionIsRejected()
    {
        using ScriptedSession session = new();
        Assert.ThrowsAsync<ArgumentNullException>(() =>
            Sample_VoiceAgent_Live.RunResponsesConversationAsync(session, null, TextWriter.Null, false, default));
    }

    [Test]
    public async Task ToolResultsWaitForBackendCompletionAndContinueOncePerBatch()
    {
        using ScriptedSession session = new(Tool("call-a"), Tool("call-b"), Complete(), Text("The result is 7."), Complete());
        session.BeforeEvent = index =>
        {
            if (index == 2)
            {
                Assert.That(session.Commands, Has.Count.EqualTo(2), "No tool output or continuation may precede backend completion.");
            }
        };
        using StringWriter output = new();

        await Sample_VoiceAgent_Live.RunResponsesConversationAsync(session, new[] { "Use the test function." }, output, true, default);

        Assert.That(session.Commands.Select(EventType),
            Is.EqualTo(new[] { "response.item.create", "response.create", "response.item.create", "response.item.create", "response.create" }));
        for (int index = 0; index < 2; index++)
        {
            using JsonDocument result = JsonDocument.Parse(session.Commands[index + 2]);
            JsonElement item = result.RootElement.GetProperty("item");
            Assert.Multiple(() =>
            {
                Assert.That(item.GetProperty("type").GetString(), Is.EqualTo("function_call_output"));
                Assert.That(item.GetProperty("call_id").GetString(), Is.EqualTo(index == 0 ? "call-a" : "call-b"));
                Assert.That(item.GetProperty("output").GetString(), Is.EqualTo("{\"value\":7}"));
            });
        }
        Assert.That(output.ToString(), Does.Contain("The result is 7."));
        Assert.That(session.ReceiverEnded, Is.True);
    }

    [Test]
    public void DuplicateToolCallIdsAreRejected()
    {
        using ScriptedSession session = new(Tool("same-call"), Tool("same-call"), Complete());
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => Run(session, tools: true));
        Assert.That(error.Message, Does.Contain("unique nonempty call_id"));
        Assert.That(session.Commands, Has.Count.EqualTo(2));
    }

    [TestCase("other_function", "{}")]
    [TestCase("get_test_value", """{"unexpected":true}""")]
    [TestCase("get_test_value", "[]")]
    public void FunctionNamesAndArgumentsAreAllowlisted(string name, string arguments)
    {
        using ScriptedSession session = new(Tool("call", name, arguments), Complete());
        Assert.ThrowsAsync<InvalidOperationException>(() => Run(session, tools: true));
        Assert.That(session.Commands, Has.Count.EqualTo(2));
    }

    [TestCase("")]
    [TestCase(" ")]
    public void EmptyToolCallIdsAreRejected(string id)
    {
        using ScriptedSession session = new(Tool(id), Complete());
        Assert.ThrowsAsync<InvalidOperationException>(() => Run(session, tools: true));
    }

    [Test]
    public void TextExampleDoesNotExecuteUnexpectedTools()
    {
        using ScriptedSession session = new(Tool("call"), Complete());
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => Run(session));
        Assert.That(error.Message, Does.Contain("does not execute function tools"));
    }

    [Test]
    public void ToolContinuationRoundsAreBounded()
    {
        List<LiveServerEvent> events = new();
        for (int index = 0; index < 9; index++)
        {
            events.Add(Tool("call-" + index));
            events.Add(Complete());
        }
        using ScriptedSession session = new(events.ToArray());
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => Run(session, tools: true));
        Assert.That(error.Message, Does.Contain("continuation limit"));
        Assert.That(session.Commands, Has.Count.EqualTo(18), "Only eight tool-result/continuation batches may be sent.");
    }

    [TestCase("response.failed")]
    [TestCase("response.incomplete")]
    public void BackendFailuresDoNotReturnPendingToolResults(string type)
    {
        using ScriptedSession session = new(Tool("call"), Backend("{\"type\":\"" + type + "\"}"));
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => Run(session, tools: true));
        Assert.That(error.Message, Does.Contain(type));
        Assert.That(session.Commands, Has.Count.EqualTo(2));
    }

    [Test]
    public void PrematureNativeCloseIsNotReportedAsCompletedConversation()
    {
        using ScriptedSession session = new(Closed());
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => Run(session));
        Assert.That(error.Message, Does.Contain("closed before the backend completed"));
    }

    [Test]
    public void TransportEofIsNotReportedAsCompletedConversation()
    {
        using ScriptedSession session = new(Text("An incomplete answer."));
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => Run(session));
        Assert.That(error.Message, Does.Contain("disconnected before the backend response completed"));
    }

    [Test]
    public void FunctionConversationRequiresAnActualToolResult()
    {
        using ScriptedSession session = new(Text("A response without calling the tool."), Complete());
        Assert.ThrowsAsync<InvalidOperationException>(() => Run(session, tools: true));
    }

    [Test]
    public void CompletionWithoutTextDoesNotHang()
    {
        using ScriptedSession session = new(Complete());
        Assert.ThrowsAsync<InvalidOperationException>(() => Run(session));
    }

    [TestCase("{}")]
    [TestCase("""{"type":null}""")]
    [TestCase("""{"type":""}""")]
    public void BackendEnvelopesRequireAnEventType(string json)
    {
        using ScriptedSession session = new(Backend(json));
        Assert.ThrowsAsync<InvalidDataException>(() => Run(session));
    }

    [TestCase(null)]
    [TestCase("content_filter")]
    public void ServiceErrorsRetainMessageAndTypeWhenCodeIsUnavailable(string code)
    {
        using ScriptedSession session = new(Error(code));
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() => Run(session));
        Assert.That(error.Message, Does.Contain("invalid_request_error").And.Contain("The service rejected the example.")
            .And.Contain(code ?? "<not supplied>"));
    }

    [Test]
    public void AudioReceiverFailureCancelsAndObservesProducer()
    {
        using ScriptedSession session = new(Error(null)) { BlockAudio = true };
        using MemoryStream output = new();
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(5));

        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() =>
            Sample_VoiceAgent_Live.RunAudioConversationAsync(session, Array.Empty<byte>(), output, TextWriter.Null, timeout.Token));

        Assert.Multiple(() =>
        {
            Assert.That(error.Message, Does.Contain("The service rejected the example."));
            Assert.That(session.AudioEnded, Is.True);
            Assert.That(session.AudioToken.IsCancellationRequested, Is.True);
            Assert.That(session.ReceiverEnded, Is.True);
            Assert.That(timeout.IsCancellationRequested, Is.False);
        });
    }

    [Test]
    public void AudioProducerFailureCancelsAndObservesReceiver()
    {
        using ScriptedSession session = new() { WaitAfterEvents = true, AudioFailure = new IOException("Audio send failed.") };
        using MemoryStream output = new();
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(5));

        IOException error = Assert.ThrowsAsync<IOException>(() =>
            Sample_VoiceAgent_Live.RunAudioConversationAsync(session, Array.Empty<byte>(), output, TextWriter.Null, timeout.Token));

        Assert.Multiple(() =>
        {
            Assert.That(error.Message, Is.EqualTo("Audio send failed."));
            Assert.That(session.ReceiverEnded, Is.True);
            Assert.That(session.ReceiveToken.IsCancellationRequested, Is.True);
            Assert.That(timeout.IsCancellationRequested, Is.False);
        });
    }

    [Test]
    public void OddPcmOutputFailsAndStopsAudioProducer()
    {
        using ScriptedSession session = new(Read("""{"type":"session.output_audio.delta","delta":"AA=="}""")) { BlockAudio = true };
        using MemoryStream output = new();
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(5));
        Assert.ThrowsAsync<InvalidDataException>(() =>
            Sample_VoiceAgent_Live.RunAudioConversationAsync(session, Array.Empty<byte>(), output, TextWriter.Null, timeout.Token));
        Assert.That(session.AudioEnded, Is.True);
        Assert.That(output.Length, Is.Zero);
    }

    [Test]
    public void PrematureAudioEofCancelsProducerAndDoesNotClaimFinalization()
    {
        using ScriptedSession session = new() { BlockAudio = true };
        using MemoryStream output = new();
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(5));
        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() =>
            Sample_VoiceAgent_Live.RunAudioConversationAsync(session, Array.Empty<byte>(), output, TextWriter.Null, timeout.Token));
        Assert.That(error.Message, Does.Contain("before native session finalization"));
        Assert.That(session.AudioEnded, Is.True);
        Assert.That(session.AudioToken.IsCancellationRequested, Is.True);
    }

    [Test]
    public async Task AudioCaptionsLabelSpeakersWithoutPrintingBackendNotes()
    {
        using ScriptedSession session = new(
            Text("Private backend notes."),
            Transcript("session.input_transcript.delta", "What is "),
            Transcript("session.input_transcript.delta", "the weather?"),
            Transcript("session.output_transcript.delta", "I cannot "),
            Transcript("session.output_transcript.delta", "look that up."),
            Closed());
        using MemoryStream output = new();
        using StringWriter transcript = new();

        await Sample_VoiceAgent_Live.ReceiveAudioAsync(session, output, transcript, default);

        Assert.That(transcript.ToString(), Is.EqualTo("You: What is the weather?" + Environment.NewLine +
            "Assistant: I cannot look that up." + Environment.NewLine));
        Assert.That(session.ReceiverEnded, Is.True);
    }

    private static Task Run(ScriptedSession session, IEnumerable<string> prompts = null, bool tools = false)
        => Sample_VoiceAgent_Live.RunResponsesConversationAsync(session, prompts ?? new[] { "Prompt" }, TextWriter.Null, tools, default);

    private static LiveServerEvent Backend(string json)
        => Read("""{"type":"response.event","event_id":"event","event":""" + json + "}");

    private static LiveServerEvent Text(string text)
        => Backend(BinaryData.FromObjectAsJson(new { type = "response.output_text.delta", delta = text }).ToString());

    private static LiveServerEvent Complete() => Backend("""{"type":"response.completed"}""");

    private static LiveServerEvent Transcript(string type, string delta)
        => Read(BinaryData.FromObjectAsJson(new { type, delta, event_id = "transcript", start_ms = 0, end_ms = 20 }).ToString());

    private static LiveServerEvent Tool(string id, string name = "get_test_value", string arguments = "{}")
        => Backend(BinaryData.FromObjectAsJson(new
        {
            type = "response.output_item.done",
            item = new { type = "function_call", call_id = id, name, arguments, status = "completed" }
        }).ToString());

    private static LiveServerEvent Closed() => Read("""
        {"type":"session.closed","event_id":"closed","reason":"expired",
         "session":{"id":"session","model":"gpt-live-1","status":"active","expires_at":2000000000},"usage":{"seconds":0}}
        """);

    private static LiveServerEvent Error(string code) => Read(BinaryData.FromObjectAsJson(new
    {
        type = "error",
        event_id = "error",
        error = new { type = "invalid_request_error", code, message = "The service rejected the example." }
    }).ToString());

    private static LiveServerEvent Read(string json) => ModelReaderWriter.Read<LiveServerEvent>(
        BinaryData.FromString(json), ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

    private static string EventType(BinaryData command)
    {
        using JsonDocument document = JsonDocument.Parse(command);
        return document.RootElement.GetProperty("type").GetString();
    }

    private sealed class ScriptedSession : ProjectsLiveSessionClient
    {
        private readonly LiveServerEvent[] _events;

        public ScriptedSession(params LiveServerEvent[] events)
        {
            _events = events;
        }

        public List<BinaryData> Commands { get; } = new();
        public int Receivers { get; private set; }
        public bool ReceiverEnded { get; private set; }
        public bool AudioEnded { get; private set; }
        public bool BlockAudio { get; set; }
        public bool WaitAfterEvents { get; set; }
        public Exception AudioFailure { get; set; }
        public CancellationToken ReceiveToken { get; private set; }
        public CancellationToken AudioToken { get; private set; }
        public Action<int> BeforeEvent { get; set; }

        public override Task SendEventAsync(LiveClientEvent clientEvent, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Commands.Add(ModelReaderWriter.Write(clientEvent, new ModelReaderWriterOptions("W"), AzureAIProjectsAgentsContext.Default));
            return Task.CompletedTask;
        }

        public override async Task SendInputAudioAsync(BinaryData audio, CancellationToken cancellationToken = default)
        {
            AudioToken = cancellationToken;
            try
            {
                if (AudioFailure != null)
                {
                    throw AudioFailure;
                }
                if (BlockAudio)
                {
                    await Task.Delay(Timeout.Infinite, cancellationToken);
                }
            }
            finally
            {
                AudioEnded = true;
            }
        }

        public override async IAsyncEnumerable<LiveServerEvent> ReceiveEventsAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            ReceiveToken = cancellationToken;
            Receivers++;
            try
            {
                for (int index = 0; index < _events.Length; index++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    BeforeEvent?.Invoke(index);
                    yield return _events[index];
                    await Task.Yield();
                }
                if (WaitAfterEvents)
                {
                    await Task.Delay(Timeout.Infinite, cancellationToken);
                }
            }
            finally
            {
                ReceiverEnded = true;
            }
        }
    }
}
