// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests.LiveTests;

[LiveOnly]
[NonParallelizable]
public class ProjectsLiveTests : ProjectsClientTestBase
{
    private const string PcmFormat = """{"format":{"type":"audio/pcm","rate":24000}}""";

    public ProjectsLiveTests(bool isAsync) : base(isAsync)
    {
        TestTimeoutInSeconds = 180;
    }

    [Test]
    [AsyncOnly]
    public async Task ConnectAndGracefullyFinalize()
    {
        AIProjectClient project = CreateLiveProject();
        string name = NewAgentName();
        try
        {
            await CreateLiveAgentAsync(project, name);
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                name, new ProjectsLiveSessionClientOptions { Store = false }, timeout.Token);

            Assert.That(session.SessionStarted.Session.Id, Is.Not.Null.And.Not.Empty);
            Console.WriteLine("[service] session.started: native session id=<redacted>, model=" + session.SessionStarted.Session.Model);
            await session.CloseAsync(timeout.Token);
            AssertFinalization(session);
        }
        finally
        {
            await DeleteLiveAgentAsync(project, name);
        }
    }

    [Test]
    [AsyncOnly]
    public async Task TextGuidanceUsesNativeAppendAcknowledgments()
    {
        AIProjectClient project = CreateLiveProject();
        string name = NewAgentName();
        try
        {
            await CreateLiveAgentAsync(project, name);
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                name, new ProjectsLiveSessionClientOptions { Store = false }, timeout.Token);
            await session.SendCommandAsync(BinaryData.FromString("""
                {"type":"session.thinking.append","event_id":"sdk-context","delegation_id":null,"content":"The harmless test lookup completed. Its verified value is seven."}
                """), timeout.Token);
            await session.SendCommandAsync(BinaryData.FromString("""
                {"type":"session.commentary.append","event_id":"sdk-commentary","delegation_id":null,"content":"The verified test value is seven."}
                """), timeout.Token);
            Task audio = SendPacedAudioAsync(session, Array.Empty<byte>(), TimeSpan.FromSeconds(8), timeout.Token);
            HashSet<string> acknowledgments = new(StringComparer.Ordinal);
            await foreach (LiveServerEvent serverEvent in session.ReceiveEventsAsync(timeout.Token))
            {
                using JsonDocument document = EventDocument(serverEvent);
                JsonElement root = document.RootElement;
                string type = LogEvent(root);
                ThrowIfServiceError(root);
                if (type is "session.thinking.appended" or "session.commentary.appended")
                {
                    acknowledgments.Add(root.GetProperty("client_event_id").GetString());
                    if (acknowledgments.Contains("sdk-context") && acknowledgments.Contains("sdk-commentary"))
                    {
                        break;
                    }
                }
            }
            await audio;
            Assert.That(acknowledgments, Is.SupersetOf(new[] { "sdk-context", "sdk-commentary" }));
            await session.CloseAsync(timeout.Token);
            AssertFinalization(session);
        }
        finally
        {
            await DeleteLiveAgentAsync(project, name);
        }
    }

    [Test]
    [AsyncOnly]
    public async Task ActualSpeechProducesAudioAndStoredHistory()
    {
        AIProjectClient project = CreateLiveProject();
        string name = NewAgentName();
        string conversationId = null;
        try
        {
            await CreateLiveAgentAsync(project, name);
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                name, new ProjectsLiveSessionClientOptions { Store = true }, timeout.Token);
            conversationId = session.SessionStarted.ConversationId;
            byte[] speech = ReadSpeechPcm();
            Task audio = SendPacedAudioAsync(session, speech, TimeSpan.FromSeconds(14), timeout.Token);
            long outputBytes = 0;
            int inputTranscriptCharacters = 0;
            int outputTranscriptCharacters = 0;
            Task closing = FinalizeAfterAudioAsync(session, audio, timeout.Token);
            await foreach (LiveServerEvent serverEvent in session.ReceiveEventsAsync(timeout.Token))
            {
                using JsonDocument document = EventDocument(serverEvent);
                JsonElement root = document.RootElement;
                string type = LogEvent(root);
                ThrowIfServiceError(root);
                if (type == "session.output_audio.delta")
                {
                    outputBytes += Convert.FromBase64String(root.GetProperty("delta").GetString()).Length;
                }
                else if (type == "session.input_transcript.delta")
                {
                    inputTranscriptCharacters += root.GetProperty("delta").GetString().Length;
                }
                else if (type == "session.output_transcript.delta")
                {
                    outputTranscriptCharacters += root.GetProperty("delta").GetString().Length;
                }
                else if (type == "session.delegation.created")
                {
                    string delegationId = root.GetProperty("delegation").GetProperty("id").GetString();
                    await session.SendCommandAsync(BinaryData.FromObjectAsJson(new
                    {
                        type = "session.commentary.append",
                        event_id = "sdk-weather-result",
                        delegation_id = delegationId,
                        content = "The verified weather in the test location is sunny and seven degrees Celsius."
                    }), timeout.Token);
                }
                if (type == "session.closed")
                {
                    break;
                }
            }
            await audio;
            await closing;
            Assert.Multiple(() =>
            {
                Assert.That(speech.Length, Is.GreaterThan(0));
                Assert.That(outputBytes, Is.GreaterThan(0));
                Assert.That(inputTranscriptCharacters, Is.GreaterThan(0));
                Assert.That(outputTranscriptCharacters, Is.GreaterThan(0));
                Assert.That(conversationId, Is.Not.Null.And.Not.Empty);
            });
            Console.WriteLine($"[audio] PCM16LE/24000Hz input speech={speech.Length} bytes, output={outputBytes} bytes; " +
                $"input transcript characters={inputTranscriptCharacters}; output transcript characters={outputTranscriptCharacters}");
            AssertFinalization(session);
            BetaVoiceAgentsLiveConversations history = project.AgentAdministrationClient.GetBetaVoiceAgentEndpointLiveConversations();
            ClientResult<VoiceAgentLiveConversation> conversation = await history.GetLiveAgentConversationAsync(name, conversationId, timeout.Token);
            Assert.That(conversation.Value.Id, Is.EqualTo(conversationId));
            List<VoiceAgentLiveConversationItem> items = await history.GetLiveAgentConversationItemsAsync(name, conversationId).ToListAsync(timeout.Token);
            Assert.That(items, Is.Not.Empty);
            Console.WriteLine($"[history] GET HTTP {conversation.GetRawResponse().Status}; persisted items={items.Count}");
        }
        finally
        {
            try
            {
                if (conversationId != null)
                {
                    await project.AgentAdministrationClient.GetBetaVoiceAgentEndpointLiveConversations()
                        .DeleteLiveAgentConversationAsync(name, conversationId);
                }
            }
            catch (ClientResultException exception) when (exception.Status == 404)
            {
                Console.WriteLine("[cleanup] no persisted Live conversation was found (HTTP 404)");
            }
            finally
            {
                await DeleteLiveAgentAsync(project, name);
            }
        }
    }

    [Test]
    [AsyncOnly]
    public async Task ResponsesFunctionCallReturnsMatchingToolOutput()
    {
        AIProjectClient project = CreateLiveProject();
        string name = NewAgentName();
        string backendModel = Environment.GetEnvironmentVariable("FOUNDRY_LIVE_BACKEND_MODEL_NAME")
            ?? throw new InvalidOperationException("Set FOUNDRY_LIVE_BACKEND_MODEL_NAME to a Responses deployment.");
        BinaryData delegation = BinaryData.FromObjectAsJson(new
        {
            type = "responses",
            responses = new
            {
                model = backendModel,
                instructions = "Call get_test_value exactly once when requested, then report only the verified numeric result.",
                tools = new[]
                {
                    new
                    {
                        type = "function",
                        name = "get_test_value",
                        parameters = new { type = "object", properties = new { }, required = Array.Empty<string>(), additionalProperties = false },
                        strict = true
                    }
                },
                tool_choice = "auto",
                parallel_tool_calls = false
            }
        });
        try
        {
            await CreateLiveAgentAsync(project, name, delegation);
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                name, new ProjectsLiveSessionClientOptions { Store = false }, timeout.Token);
            await session.SendCommandAsync(BinaryData.FromString("""
                {"type":"response.item.create","event_id":"sdk-ask","item":{"type":"message","role":"user","content":[{"type":"input_text","text":"Call get_test_value exactly once and report its verified numeric result."}]}}
                """), timeout.Token);
            await session.SendCommandAsync(BinaryData.FromString("""{"type":"response.create","event_id":"sdk-create"}"""), timeout.Token);
            string callId = null;
            StringBuilder output = new();
            await foreach (LiveServerEvent serverEvent in session.ReceiveEventsAsync(timeout.Token))
            {
                using JsonDocument document = EventDocument(serverEvent);
                JsonElement root = document.RootElement;
                string type = LogEvent(root);
                ThrowIfServiceError(root);
                if (type != "response.event")
                {
                    continue;
                }
                JsonElement backend = root.GetProperty("event");
                string backendType = backend.GetProperty("type").GetString();
                Console.WriteLine("[backend] " + backendType);
                if (backendType == "response.output_item.done" &&
                    backend.GetProperty("item").GetProperty("type").GetString() == "function_call")
                {
                    Assert.That(callId, Is.Null, "The backend must not execute a duplicate function call.");
                    JsonElement item = backend.GetProperty("item");
                    Assert.That(item.GetProperty("name").GetString(), Is.EqualTo("get_test_value"));
                    using JsonDocument arguments = JsonDocument.Parse(item.GetProperty("arguments").GetString());
                    Assert.That(arguments.RootElement.EnumerateObject(), Is.Empty);
                    callId = item.GetProperty("call_id").GetString();
                    await session.SendCommandAsync(BinaryData.FromObjectAsJson(new
                    {
                        type = "response.item.create",
                        event_id = "sdk-tool-result",
                        item = new { type = "function_call_output", call_id = callId, output = "{\"value\":7}" }
                    }), timeout.Token);
                    await session.SendCommandAsync(BinaryData.FromString("""{"type":"response.create","event_id":"sdk-continue"}"""), timeout.Token);
                    Console.WriteLine("[tool] completed get_test_value; matching call_id=<redacted>; result={\"value\":7}");
                }
                else if (backendType == "response.output_text.delta")
                {
                    output.Append(backend.GetProperty("delta").GetString());
                }
                else if (backendType == "response.completed" && callId != null && output.Length > 0)
                {
                    break;
                }
                else if (backendType is "response.failed" or "response.incomplete")
                {
                    Assert.Fail("The delegated backend did not complete: " + backendType);
                }
            }
            Assert.That(callId, Is.Not.Null.And.Not.Empty);
            Assert.That(output.ToString(), Does.Contain("7"));
            Console.WriteLine("[backend] completed verified tool result; output=" + output);
            await session.CloseAsync(timeout.Token);
            AssertFinalization(session);
        }
        finally
        {
            await DeleteLiveAgentAsync(project, name);
        }
    }

    [Test]
    [AsyncOnly]
    public async Task ServiceErrorsRemainTypedAndSessionRemainsUsable()
    {
        AIProjectClient project = CreateLiveProject();
        string name = NewAgentName();
        try
        {
            await CreateLiveAgentAsync(project, name);
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                name, new ProjectsLiveSessionClientOptions { Store = false }, timeout.Token);
            await session.SendEventAsync(new LiveClientEventLiveResponseCreateParam { EventId = "sdk-invalid" }, timeout.Token);
            bool sawError = false;
            await foreach (LiveServerEvent serverEvent in session.ReceiveEventsAsync(timeout.Token))
            {
                using JsonDocument document = EventDocument(serverEvent);
                JsonElement root = document.RootElement;
                string type = LogEvent(root);
                if (type == "error")
                {
                    Assert.That(serverEvent, Is.TypeOf<LiveServerEventLiveErrorEvent>());
                    JsonElement error = root.GetProperty("error");
                    Assert.That(error.GetProperty("type").GetString(), Is.Not.Null.And.Not.Empty);
                    Assert.That(error.GetProperty("message").GetString(), Is.Not.Null.And.Not.Empty);
                    string code = error.TryGetProperty("code", out JsonElement errorCode) && errorCode.ValueKind == JsonValueKind.String
                        ? errorCode.GetString() : "<not supplied>";
                    Console.WriteLine($"[service error] type={error.GetProperty("type").GetString()}; code={code}; message={error.GetProperty("message").GetString()}");
                    sawError = true;
                    break;
                }
            }
            Assert.That(sawError, Is.True);
            await session.CloseAsync(timeout.Token);
            AssertFinalization(session);
        }
        finally
        {
            await DeleteLiveAgentAsync(project, name);
        }
    }

    [Test]
    [AsyncOnly]
    public async Task ConcurrentSessionsAndMissingAgentHandshake()
    {
        AIProjectClient project = CreateLiveProject();
        string name = NewAgentName();
        try
        {
            await CreateLiveAgentAsync(project, name);
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));
            ProjectsLiveSessionClient[] sessions = new ProjectsLiveSessionClient[2];
            try
            {
                await Task.WhenAll(Enumerable.Range(0, sessions.Length).Select(async index =>
                    sessions[index] = await project.ProjectsLiveClient.StartSessionAsync(
                        name, new ProjectsLiveSessionClientOptions { Store = false }, timeout.Token)));
                Assert.That(sessions.Select(session => session.SessionStarted.Session.Id).Distinct().Count(), Is.EqualTo(2));
                await Task.WhenAll(sessions.Select(session => session.CloseAsync(timeout.Token)));
                foreach (ProjectsLiveSessionClient session in sessions)
                {
                    AssertFinalization(session);
                }
            }
            finally
            {
                foreach (ProjectsLiveSessionClient session in sessions)
                {
                    session?.Dispose();
                }
            }
            Assert.ThrowsAsync<System.Net.WebSockets.WebSocketException>(() => project.ProjectsLiveClient.StartSessionAsync(
                NewAgentName(), cancellationToken: timeout.Token));
            Console.WriteLine("[lifecycle] two independent sessions finalized; nonexistent-agent handshake failed as expected");
        }
        finally
        {
            await DeleteLiveAgentAsync(project, name);
        }
    }

    [Test]
    [AsyncOnly]
    public async Task CancellationAndDisposalInterruptPendingReceive()
    {
        AIProjectClient project = CreateLiveProject();
        string name = NewAgentName();
        try
        {
            await CreateLiveAgentAsync(project, name);
            foreach (bool dispose in new[] { false, true })
            {
                using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));
                using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                    name, new ProjectsLiveSessionClientOptions { Store = false }, timeout.Token);
                using CancellationTokenSource receiving = CancellationTokenSource.CreateLinkedTokenSource(timeout.Token);
                await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(receiving.Token).GetAsyncEnumerator();
                Assert.That(await events.MoveNextAsync(), Is.True);
                Task<bool> pending = events.MoveNextAsync().AsTask();
                for (int index = 0; index < 10 && pending.IsCompleted && pending.Status == TaskStatus.RanToCompletion && pending.Result; index++)
                {
                    pending = events.MoveNextAsync().AsTask();
                }
                if (dispose)
                {
                    session.Dispose();
                }
                else
                {
                    receiving.Cancel();
                }
                Assert.CatchAsync<OperationCanceledException>(async () => await pending);
                Assert.That(session.SessionClosed, Is.Null, "An interrupted receive must not manufacture native finalization.");
                Console.WriteLine(dispose
                    ? "[lifecycle] disposal interrupted a real pending receive; native finalization unconfirmed"
                    : "[lifecycle] cancellation interrupted a real pending receive; native finalization unconfirmed");
            }
        }
        finally
        {
            await DeleteLiveAgentAsync(project, name);
        }
    }

    private AIProjectClient CreateLiveProject() => new(new Uri(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT), GetTestTokenProvider());

    private static string NewAgentName() => ("dotnet-live-" + Guid.NewGuid().ToString("N")).Substring(0, 40);

    private static async Task DeleteLiveAgentAsync(AIProjectClient project, string name)
    {
        try
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(name);
            Console.WriteLine("[cleanup] deleted the temporary Live agent");
        }
        catch (ClientResultException exception) when (exception.Status == 404)
        {
            Console.WriteLine("[cleanup] temporary Live agent is already absent");
        }
    }

    private static async Task CreateLiveAgentAsync(AIProjectClient project, string name, BinaryData delegation = null)
    {
        string deployment = Environment.GetEnvironmentVariable("FOUNDRY_LIVE_MODEL_NAME")
            ?? throw new InvalidOperationException("Set FOUNDRY_LIVE_MODEL_NAME to a native GPT Live deployment.");
        VoiceAgentLiveDefinition definition = new(deployment)
        {
            Instructions = "Respond briefly in English. Use verified context to answer the user's question.",
            Audio = ModelReaderWriter.Read<LiveInitialSessionAudioParam>(BinaryData.FromString(PcmFormat),
                ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default),
            Delegation = delegation
        };
        ClientResult<ProjectsAgentVersion> result = await project.AgentAdministrationClient.CreateAgentVersionAsync(
            name, new ProjectsAgentVersionCreationOptions(definition));
        Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
        Console.WriteLine($"[REST] created temporary Live agent {name}, version HTTP {result.GetRawResponse().Status}");
    }

    private static JsonDocument EventDocument(LiveServerEvent serverEvent)
        => JsonDocument.Parse(ModelReaderWriter.Write(serverEvent, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));

    private static string LogEvent(JsonElement root)
    {
        string type = root.GetProperty("type").GetString();
        if (type != "session.output_audio.delta")
        {
            Console.WriteLine("[service] " + type);
        }
        return type;
    }

    private static void ThrowIfServiceError(JsonElement root)
    {
        if (root.GetProperty("type").GetString() == "error")
        {
            Assert.Fail("The Live service reported " + root.GetProperty("error").GetProperty("code").GetString());
        }
    }

    private static void AssertFinalization(ProjectsLiveSessionClient session)
    {
        Assert.That(session.SessionClosed, Is.Not.Null, "A normal transport close is not native finalization.");
        using JsonDocument document = EventDocument(session.SessionClosed);
        JsonElement root = document.RootElement;
        Assert.Multiple(() =>
        {
            Assert.That(root.GetProperty("type").GetString(), Is.EqualTo("session.closed"));
            Assert.That(root.GetProperty("reason").GetString(), Is.EqualTo("close_requested"));
            Assert.That(root.GetProperty("usage").GetProperty("seconds").GetDouble(), Is.GreaterThanOrEqualTo(0));
            Assert.That(session.State, Is.EqualTo(System.Net.WebSockets.WebSocketState.Closed));
        });
        Console.WriteLine("[service] session.closed: reason=close_requested, native status=" +
            root.GetProperty("session").GetProperty("status").GetString() + ", seconds=" +
            root.GetProperty("usage").GetProperty("seconds").GetDouble());
    }

    private static async Task FinalizeAfterAudioAsync(ProjectsLiveSessionClient session, Task audio, CancellationToken cancellationToken)
    {
        await audio;
        await session.CloseAsync(cancellationToken);
    }

    private static async Task SendPacedAudioAsync(ProjectsLiveSessionClient session, byte[] speech, TimeSpan duration, CancellationToken cancellationToken)
    {
        const int chunkBytes = 960;
        byte[] silence = new byte[chunkBytes];
        Stopwatch clock = Stopwatch.StartNew();
        int offset = 0;
        int chunks = 0;
        while (clock.Elapsed < duration)
        {
            byte[] audio;
            if (offset < speech.Length)
            {
                int count = Math.Min(chunkBytes, speech.Length - offset);
                audio = new byte[count];
                Buffer.BlockCopy(speech, offset, audio, 0, count);
                offset += count;
            }
            else
            {
                audio = silence;
            }
            await session.SendCommandAsync(BinaryData.FromObjectAsJson(new
            {
                type = "session.input_audio.append",
                audio = Convert.ToBase64String(audio)
            }), cancellationToken);
            chunks++;
            TimeSpan delay = TimeSpan.FromMilliseconds(chunks * 20) - clock.Elapsed;
            if (delay > TimeSpan.Zero)
            {
                await Task.Delay(delay, cancellationToken);
            }
        }
        Console.WriteLine($"[audio] sent {offset} real speech bytes and {Math.Max(0, chunks * chunkBytes - offset)} silence bytes");
    }

    private static byte[] ReadSpeechPcm()
    {
        string path = Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory,
            "..", "..", "..", "..", "..", "sdk", "openai", "Azure.AI.OpenAI", "tests", "Assets",
            "whats_the_weather_pcm16_24khz_mono.wav"));
        using BinaryReader reader = new(File.OpenRead(path), Encoding.ASCII);
        Assert.That(new string(reader.ReadChars(4)), Is.EqualTo("RIFF"));
        reader.ReadUInt32();
        Assert.That(new string(reader.ReadChars(4)), Is.EqualTo("WAVE"));
        bool formatVerified = false;
        while (reader.BaseStream.Position + 8 <= reader.BaseStream.Length)
        {
            string chunk = new(reader.ReadChars(4));
            int length = reader.ReadInt32();
            long end = reader.BaseStream.Position + length;
            if (chunk == "fmt ")
            {
                Assert.That(reader.ReadUInt16(), Is.EqualTo(1));
                Assert.That(reader.ReadUInt16(), Is.EqualTo(1));
                Assert.That(reader.ReadUInt32(), Is.EqualTo(24000));
                reader.ReadUInt32();
                reader.ReadUInt16();
                Assert.That(reader.ReadUInt16(), Is.EqualTo(16));
                formatVerified = true;
            }
            else if (chunk == "data")
            {
                Assert.That(formatVerified, Is.True);
                byte[] data = reader.ReadBytes(length);
                Assert.That(data, Has.Length.EqualTo(length));
                return data;
            }
            reader.BaseStream.Position = end + (length & 1);
        }
        throw new InvalidDataException("The existing speech fixture has no PCM data chunk.");
    }
}
