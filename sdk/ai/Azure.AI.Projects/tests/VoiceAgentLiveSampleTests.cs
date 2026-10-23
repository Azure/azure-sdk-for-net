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
using Azure.AI.Projects.Tests.Utils;
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

    [TestCase("model_not_found")]
    [TestCase(null)]
    public void BackendErrorsRetainCodeAndMessageWithoutWaitingForCancellation(string code)
    {
        using ScriptedSession session = new(Tool("call"), Backend(BinaryData.FromObjectAsJson(new
        {
            type = "error",
            code,
            message = "The requested backend deployment does not exist."
        }).ToString())) { WaitAfterEvents = true };
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(3));

        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() =>
            Sample_VoiceAgent_Live.RunResponsesConversationAsync(session, ["Use the test function."],
                TextWriter.Null, true, timeout.Token));

        Assert.Multiple(() =>
        {
            Assert.That(error.Message, Does.Contain(code ?? "<not supplied>")
                .And.Contain("The requested backend deployment does not exist."));
            Assert.That(timeout.IsCancellationRequested, Is.False);
            Assert.That(session.Commands, Has.Count.EqualTo(2), "Backend errors must not return pending tool results.");
            Assert.That(session.ReceiverEnded, Is.True);
        });
    }

    [Test]
    public void BackendErrorWithoutCodeStillRetainsItsMessage()
    {
        using ScriptedSession session = new(Backend("""
            {"type":"error","message":"Backend request rejected."}
            """)) { WaitAfterEvents = true };
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(3));

        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() =>
            Sample_VoiceAgent_Live.RunResponsesConversationAsync(session, ["Prompt"],
                TextWriter.Null, false, timeout.Token));

        Assert.That(error.Message, Does.Contain("<not supplied>").And.Contain("Backend request rejected."));
        Assert.That(timeout.IsCancellationRequested, Is.False);
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

    [Test]
    public async Task SlowAudioSendDoesNotTruncateSpeechOrShortenSilenceTail()
    {
        using ScriptedSession session = new(Read("""{"type":"session.output_audio.delta","delta":"AQABAA=="}"""))
        {
            FirstAudioDelay = TimeSpan.FromSeconds(9),
            WaitForClose = true
        };
        byte[] speech = Enumerable.Repeat((byte)1, 1920).ToArray();
        using MemoryStream output = new();
        using StringWriter transcript = new();
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(30));
        await Sample_VoiceAgent_Live.RunAudioConversationAsync(session, speech, output, transcript, timeout.Token);

        Assert.Multiple(() =>
        {
            Assert.That(session.AudioChunks.Take(2).SelectMany(chunk => chunk.ToArray()), Is.EqualTo(speech),
                "A slow send must not consume the time reserved for sending the remaining speech.");
            Assert.That(session.AudioChunks.Skip(2).Count(), Is.EqualTo(400),
                "Eight seconds of 20 ms silence chunks must follow all input speech.");
            Assert.That(session.AudioChunks.Skip(2).All(chunk => chunk.ToArray().All(value => value == 0)), Is.True);
            Assert.That(output.Length, Is.GreaterThan(0));
            Assert.That(session.ReceiverEnded, Is.True);
            Assert.That(timeout.IsCancellationRequested, Is.False);
            Assert.That(transcript.ToString(), Does.Contain("Input audio sent: 385920 bytes")
                .And.Contain("Output audio received: 4 bytes").And.Contain("Total audio transferred: 385924 bytes"));
        });
    }

    [Test]
    public void ConnectionOptionsUseVersionStructuredInputsCustomHeadersAndRawStoreQuery()
    {
        ProjectsLiveSessionClientOptions options = Sample_VoiceAgent_Live.CreateConnectionOptions("7");

        Assert.Multiple(() =>
        {
            Assert.That(options.AgentVersion, Is.EqualTo("7"));
            Assert.That(options.Store, Is.Null, "The raw store query must not conflict with a managed Store option.");
            Assert.That(options.QueryString, Is.EqualTo("store=false"));
            Assert.That(options.StructuredInputs["language"].ToObjectFromJson<string>(), Is.EqualTo("English"));
            Assert.That(Guid.TryParse(options.Headers["x-correlation-id"], out _), Is.True);
            Assert.That(options.Headers.ContainsKey("Authorization"), Is.False);
            Assert.That(options.Headers.ContainsKey("Foundry-Features"), Is.False);
        });
    }

    [Test]
    public async Task ControlsSendTypedAndRawCommandsAndWaitForEveryAcknowledgment()
    {
        using ScriptedSession session = new(ControlAcknowledgments()) { WaitAfterEvents = true };
        using StringWriter output = new();
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(5));

        await Sample_VoiceAgent_Live.RunSessionControlsAsync(session, output, timeout.Token);

        Assert.Multiple(() =>
        {
            Assert.That(session.Commands.Select(EventType), Is.EqualTo(new[]
            {
                "session.update", "session.input_audio.mute", "session.input_audio.unmute",
                "session.thinking.append", "session.commentary.append", "session.instructions.append", "session.thinking.append"
            }));
            Assert.That(session.Receivers, Is.EqualTo(1));
            Assert.That(session.ReceiverEnded, Is.True);
            Assert.That(output.ToString().Split(new[] { "Acknowledged:" }, StringSplitOptions.None).Length - 1, Is.EqualTo(7));
            Assert.That(session.AudioToken.IsCancellationRequested, Is.False,
                "Stopping silence after acknowledgments must not cancel an active WebSocket send.");
            Assert.That(timeout.IsCancellationRequested, Is.False);
        });
        using JsonDocument update = JsonDocument.Parse(session.Commands[0]);
        Assert.That(update.RootElement.GetProperty("session").GetProperty("delegation").GetProperty("responses")
            .GetProperty("instructions").GetString(), Does.Contain("verified context"));
        using JsonDocument instructions = JsonDocument.Parse(session.Commands[5]);
        Assert.That(instructions.RootElement.GetProperty("delegation_id").ValueKind, Is.EqualTo(JsonValueKind.Null));
    }

    [Test]
    public void MissingControlAcknowledgmentsAreNotReportedAsSuccess()
    {
        using ScriptedSession session = new(ControlAcknowledgments().Take(6).ToArray());
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(5));

        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() =>
            Sample_VoiceAgent_Live.RunSessionControlsAsync(session, TextWriter.Null, timeout.Token));

        Assert.That(error.Message, Does.Contain("before acknowledging all session controls"));
        Assert.That(session.ReceiverEnded, Is.True);
    }

    [Test]
    public void ControlsRetainNativeErrorsAndStopTheirProducer()
    {
        using ScriptedSession session = new(Error(null));
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(5));

        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() =>
            Sample_VoiceAgent_Live.RunSessionControlsAsync(session, TextWriter.Null, timeout.Token));

        Assert.That(error.Message, Does.Contain("invalid_request_error").And.Contain("The service rejected the example."));
        Assert.That(session.AudioEnded, Is.True);
        Assert.That(session.ReceiverEnded, Is.True);
    }

    [Test]
    public void ControlsAudioFailureInterruptsItsReceiver()
    {
        using ScriptedSession session = new() { AudioFailure = new IOException("Control audio failed."), WaitAfterEvents = true };
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(5));

        IOException error = Assert.ThrowsAsync<IOException>(() =>
            Sample_VoiceAgent_Live.RunSessionControlsAsync(session, TextWriter.Null, timeout.Token));

        Assert.That(error.Message, Is.EqualTo("Control audio failed."));
        Assert.That(session.ReceiverEnded, Is.True);
        Assert.That(timeout.IsCancellationRequested, Is.False);
    }

    [Test]
    public async Task StreamSampleSendsAllPcmAndSilenceThroughTheStreamOverload()
    {
        using ScriptedSession session = new(Read("""{"type":"session.output_audio.delta","delta":"AQABAA=="}""")) { WaitForClose = true };
        byte[] speech = Enumerable.Repeat((byte)1, 1920).ToArray();
        using MemoryStream output = new();
        using StringWriter transcript = new();
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(20));
        await Sample_VoiceAgent_Live.RunAudioConversationAsync(
            session, speech, output, transcript, timeout.Token, streamAudio: true);

        Assert.Multiple(() =>
        {
            Assert.That(session.AudioStreamCalls, Is.EqualTo(1));
            Assert.That(session.AudioChunks.Take(2).SelectMany(chunk => chunk.ToArray()), Is.EqualTo(speech));
            Assert.That(session.AudioChunks.Skip(2).Count(), Is.EqualTo(400));
            Assert.That(session.AudioChunks.Skip(2).All(chunk => chunk.ToArray().All(value => value == 0)), Is.True);
            Assert.That(session.ReceiverEnded, Is.True);
            Assert.That(output.Length, Is.GreaterThan(0));
            Assert.That(transcript.ToString(), Does.Contain("Input audio sent: 385920 bytes")
                .And.Contain("Output audio received: 4 bytes").And.Contain("Total audio transferred: 385924 bytes"));
        });
    }

    [Test]
    public void AudioTransferTotalsIncludeSilenceAndSeparateReflectedInput()
    {
        VoiceAgentE2EDiagnostics.AudioTransfer transfer = new();
        transfer.Sent(960);
        transfer.Sent(1920);
        transfer.Received(4800);
        transfer.Reflected(960);
        using StringWriter output = new();

        transfer.Report(output);

        Assert.Multiple(() =>
        {
            Assert.That(transfer.InputBytes, Is.EqualTo(2880));
            Assert.That(transfer.OutputBytes, Is.EqualTo(4800));
            Assert.That(transfer.ReflectedBytes, Is.EqualTo(960));
            Assert.That(output.ToString(), Does.Contain("Input audio transferred: 2880 bytes")
                .And.Contain("Output audio transferred: 4800 bytes").And.Contain("Total audio transferred: 8640 bytes")
                .And.Contain("KiB").And.Contain("MiB").And.Contain("PCM16LE / 24000 Hz / mono"));
        });
    }

    [Test]
    public async Task AudioEventsReportUsageAndNoticesWithoutPlayingReflectedInput()
    {
        using ScriptedSession session = new(
            Transcript("session.output_transcript.delta", "Before."),
            Read("""{"type":"session.usage.updated","usage":{"seconds":7}}"""),
            Read("""{"type":"info","code":"notice","message":"A session notice."}"""),
            Read("""{"type":"session.input_audio.append","audio":"AQABAA=="}"""),
            Read("""{"type":"future.event","detail":"Not a transcript."}"""),
            Transcript("session.output_transcript.delta", "After."), Closed());
        using MemoryStream audio = new();
        using StringWriter output = new();

        await Sample_VoiceAgent_Live.ReceiveAudioAsync(session, audio, output, default);

        Assert.Multiple(() =>
        {
            Assert.That(output.ToString(), Does.Contain("7 seconds").And.Contain("A session notice.").And.Contain("future.event"));
            Assert.That(output.ToString(), Does.Contain("Assistant: Before." + Environment.NewLine + "Cumulative")
                .And.Contain("Assistant: After."));
            Assert.That(output.ToString(), Does.Not.Contain("Not a transcript."));
            Assert.That(audio.Length, Is.Zero);
        });
    }

    [TestCase("client", true)]
    [TestCase("responses", false)]
    [TestCase("foundry_managed_agent", false)]
    [TestCase("future_owner", false)]
    public async Task AudioReceiverRepliesOnlyToClientOwnedDelegations(string target, bool expectReply)
    {
        using ScriptedSession session = new(Read(BinaryData.FromObjectAsJson(new
        {
            type = "session.delegation.created",
            event_id = "delegated",
            offset_ms = 100,
            delegation = new { id = "delegation_1", type = "delegation", target }
        }).ToString()), Closed());
        using MemoryStream audio = new();
        using StringWriter output = new();

        await Sample_VoiceAgent_Live.ReceiveAudioAsync(session, audio, output, default);

        Assert.That(session.Commands, Has.Count.EqualTo(expectReply ? 1 : 0));
        if (expectReply)
        {
            using JsonDocument command = JsonDocument.Parse(session.Commands[0]);
            Assert.Multiple(() =>
            {
                Assert.That(command.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.commentary.append"));
                Assert.That(command.RootElement.GetProperty("delegation_id").GetString(), Is.EqualTo("delegation_1"));
            });
        }
        Assert.That(session.ReceiverEnded, Is.True);
    }

    private static LiveServerEvent[] ControlAcknowledgments() =>
    [
        Read("""{"type":"session.updated","client_event_id":"sample-update","session":{"id":"session","model":"gpt-live-1","expires_at":2000000000}}"""),
        Read("""{"type":"session.input_audio.muted","client_event_id":"sample-mute"}"""),
        Read("""{"type":"session.input_audio.unmuted","client_event_id":"sample-unmute"}"""),
        Read("""{"type":"session.thinking.appended","client_event_id":"sample-thinking","start_ms":0,"end_ms":0}"""),
        Read("""{"type":"session.commentary.appended","client_event_id":"sample-commentary","start_ms":0,"end_ms":0}"""),
        Read("""{"type":"session.instructions.appended","client_event_id":"sample-instructions","start_ms":0,"end_ms":0}"""),
        Read("""{"type":"session.thinking.appended","client_event_id":"sample-raw","start_ms":0,"end_ms":0}""")
    ];

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
        private readonly TaskCompletionSource<bool> _closed = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public ScriptedSession(params LiveServerEvent[] events)
        {
            _events = events;
        }

        public List<BinaryData> Commands { get; } = new();
        public List<BinaryData> AudioChunks { get; } = new();
        public int AudioStreamCalls { get; private set; }
        public int Receivers { get; private set; }
        public bool ReceiverEnded { get; private set; }
        public bool AudioEnded { get; private set; }
        public bool BlockAudio { get; set; }
        public bool WaitAfterEvents { get; set; }
        public bool WaitForClose { get; set; }
        public TimeSpan FirstAudioDelay { get; set; }
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

        public override Task SendCommandAsync(BinaryData command, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Commands.Add(command);
            return Task.CompletedTask;
        }

        public override async Task SendInputAudioAsync(Stream audio, CancellationToken cancellationToken = default)
        {
            AudioStreamCalls++;
            byte[] buffer = new byte[960];
            int read;
            while ((read = await audio.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) != 0)
            {
                await SendInputAudioAsync(BinaryData.FromBytes(buffer.AsMemory(0, read)), cancellationToken);
            }
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
                AudioChunks.Add(BinaryData.FromBytes(audio.ToArray()));
                if (AudioChunks.Count == 1 && FirstAudioDelay > TimeSpan.Zero)
                {
                    await Task.Delay(FirstAudioDelay, cancellationToken);
                }
            }
            finally
            {
                AudioEnded = true;
            }
        }

        public override Task CloseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _closed.TrySetResult(true);
            return Task.CompletedTask;
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
                if (WaitForClose)
                {
                    using CancellationTokenRegistration registration = cancellationToken.Register(() => _closed.TrySetCanceled());
                    await _closed.Task;
                    yield return Closed();
                }
            }
            finally
            {
                ReceiverEnded = true;
            }
        }
    }
}
