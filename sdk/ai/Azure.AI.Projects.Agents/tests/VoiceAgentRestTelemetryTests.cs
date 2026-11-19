// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001, SCME0002

namespace Azure.AI.Projects.Agents.Tests;

[NonParallelizable]
public class VoiceAgentRestTelemetryTests
{
    private const string SourceName = "Azure.AI.Projects.Agents.AgentsClient";
    private const string EnableSwitch = "Azure.Experimental.EnableGenAITracing";
    private const string ContentSwitch = "Azure.Experimental.TraceGenAIMessageContent";
    private const string MessageEventsSwitch = "Azure.Experimental.UseMessageEvents";
    private const string EnableEnvironment = "AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING";
    private const string ContentEnvironment = "OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT";
    private const string MessageEventsEnvironment = "AZURE_EXPERIMENTAL_TRACING_GEN_AI_USE_MESSAGE_EVENTS";
    private const string Endpoint = "https://private-user:private-password@voice.example:8443/api/projects/private-project?key=private-query";
    private const string AgentName = "voice-agent";
    private const string PrivateContent = "private-rest-content";
    private const string PrivateError = "private-rest-error +15555550101 Bearer private-token ?key=private-query";
    private const string ResponseBody = """
        {
          "id": "job_123",
          "status": "queued",
          "provider": "twilio",
          "connection_name": "private-connection",
          "source": "+15555550102",
          "phone_number": "+15555550101",
          "destination": { "type": "phone_number", "value": "+15555550101" },
          "structured_inputs": { "secret": "private-rest-content" },
          "messages": [{ "content": "private-rest-content" }]
        }
        """;
    private const string VoiceDefinition = """
        { "kind": "voice", "model_type": "managed", "model": "gpt-realtime",
          "instructions": "private-rest-content", "store": true,
          "greeting": { "type": "template", "text": "private-rest-content" } }
        """;
    private const string AgentResponse = """
        { "id": "agent_123", "name": "voice-agent", "version": "1",
          "definition": { "kind": "voice", "model_type": "managed", "model": "gpt-realtime" },
          "versions": { "latest": { "id": "agent_123:1", "name": "voice-agent", "version": "1",
            "definition": { "kind": "voice", "model_type": "managed", "model": "gpt-realtime" } } } }
        """;

    private readonly ConcurrentQueue<Activity> _activities = new();
    private ActivityListener _listener;
    private string _originalEnableEnvironment;
    private string _originalContentEnvironment;
    private string _originalMessageEventsEnvironment;
    private bool _hadEnableSwitch;
    private bool _hadContentSwitch;
    private bool _hadMessageEventsSwitch;
    private bool _originalEnableSwitch;
    private bool _originalContentSwitch;
    private bool _originalMessageEventsSwitch;
    private bool _originalActivitySourceSwitch;

    [SetUp]
    public void SetUp()
    {
        while (_activities.TryDequeue(out _))
        {
        }
        _originalEnableEnvironment = Environment.GetEnvironmentVariable(EnableEnvironment);
        _originalContentEnvironment = Environment.GetEnvironmentVariable(ContentEnvironment);
        _originalMessageEventsEnvironment = Environment.GetEnvironmentVariable(MessageEventsEnvironment);
        _hadEnableSwitch = AppContext.TryGetSwitch(EnableSwitch, out _originalEnableSwitch);
        _hadContentSwitch = AppContext.TryGetSwitch(ContentSwitch, out _originalContentSwitch);
        _hadMessageEventsSwitch = AppContext.TryGetSwitch(MessageEventsSwitch, out _originalMessageEventsSwitch);
        AppContext.TryGetSwitch("Azure.Experimental.EnableActivitySource", out _originalActivitySourceSwitch);
        SetTracing(true);
        SetContentRecording(false);

        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name.StartsWith("Azure.AI.Projects.Agents.", StringComparison.Ordinal),
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            SampleUsingParentId = (ref ActivityCreationOptions<string> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity => _activities.Enqueue(activity)
        };
        ActivitySource.AddActivityListener(_listener);
    }

    [TearDown]
    public void TearDown()
    {
        _listener.Dispose();
        Environment.SetEnvironmentVariable(EnableEnvironment, _originalEnableEnvironment);
        Environment.SetEnvironmentVariable(ContentEnvironment, _originalContentEnvironment);
        Environment.SetEnvironmentVariable(MessageEventsEnvironment, _originalMessageEventsEnvironment);
        if (_hadEnableSwitch)
        {
            AppContext.SetSwitch(EnableSwitch, _originalEnableSwitch);
        }
        if (_hadContentSwitch)
        {
            AppContext.SetSwitch(ContentSwitch, _originalContentSwitch);
        }
        if (_hadMessageEventsSwitch)
        {
            AppContext.SetSwitch(MessageEventsSwitch, _originalMessageEventsSwitch);
        }
        ReinitializeConfiguration();
        AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", _originalActivitySourceSwitch);
    }

    private static IEnumerable<TestCaseData> MutationCases()
    {
        string[] operations =
        [
            "create_call_job", "cancel_call_job", "replace_transfer_targets", "end_call", "transfer_call",
            "create_binding", "update_binding", "delete_binding", "delete"
        ];
        foreach (string operation in operations)
        {
            foreach (bool isAsync in new[] { false, true })
            {
                foreach (bool typed in new[] { false, true })
                {
                    // Binding updates expose only the BinaryContent protocol overload.
                    if (typed && operation == "update_binding")
                    {
                        continue;
                    }
                    yield return new TestCaseData(operation, isAsync, typed)
                        .SetName($"VoiceRest_{operation}_{(isAsync ? "Async" : "Sync")}_{(typed ? "Typed" : "Protocol")}");
                }
            }
        }
    }

    private static IEnumerable<TestCaseData> ResponseOwnershipCases()
    {
        foreach (string operation in new[] { "create", "version", "update" })
        {
            foreach (bool isAsync in new[] { false, true })
            {
                foreach (bool metricsOnly in new[] { false, true })
                {
                    foreach (bool nestedFails in new[] { false, true })
                    {
                        yield return new TestCaseData(operation, isAsync, metricsOnly, nestedFails);
                    }
                }
            }
        }
    }

    [TestCaseSource(nameof(MutationCases))]
    public async Task MutationsRetainExistingSdkDiagnostics(string operation, bool isAsync, bool typed)
    {
        int status = SuccessStatus(operation);
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(status).WithContent(ResponseBody));
        using Activity parent = new Activity("caller").SetIdFormat(ActivityIdFormat.W3C).Start();

        ClientResult result = await Mutate(client, operation, isAsync, typed);

        Assert.That(result.GetRawResponse().Status, Is.EqualTo(status));
        Activity span = GetOnlySdkSpan(MutationScopeName(operation));
        Assert.Multiple(() =>
        {
            Assert.That(span.TraceId, Is.EqualTo(parent.TraceId));
            Assert.That(span.ParentSpanId, Is.EqualTo(parent.SpanId));
            Assert.That(Activity.Current, Is.SameAs(parent));
            Assert.That(span.Status, Is.EqualTo(ActivityStatusCode.Unset));
            Assert.That(span.GetTagItem("error.type"), Is.Null);
            Assert.That(span.GetTagItem("az.ai.voice_agents.cancelled"), Is.Null);
            Assert.That(span.TagObjects.Any(tag => tag.Key.StartsWith("gen_ai.", StringComparison.Ordinal) ||
                tag.Key.StartsWith("az.ai.voice_agents.", StringComparison.Ordinal)), Is.False);
        });
        AssertPrivateSafe(span);
    }

    [TestCase(false, true, false)]
    [TestCase(true, false, false)]
    [TestCase(false, true, true)]
    [TestCase(true, false, true)]
    [TestCase(true, true, false)]
    [TestCase(true, true, true)]
    public async Task ExistingMutationTracingFollowsClientOptions(bool genAiEnabled, bool distributedTracing, bool fromSettings)
    {
        SetTracing(genAiEnabled);
        AgentAdministrationClient client = CreateClient(true, message =>
            new MockPipelineResponse(message.Request.Uri.AbsolutePath.EndsWith("/agents", StringComparison.Ordinal) ? 200 : 202).WithContent(ResponseBody), distributedTracing, fromSettings);
        await Mutate(client, "create_call_job", true, false);

        Assert.That(_activities.Where(a => a.Source.Name == SourceName), Is.Empty);
        Assert.That(_activities.Any(a => a.OperationName == "BetaVoiceAgentsTelephony.CreateTelephonyCallJob"), Is.EqualTo(distributedTracing));
        Assert.That(_activities, Has.Count.EqualTo(distributedTracing ? 1 : 0));
    }

    [TestCase("create", false)]
    [TestCase("create", true)]
    [TestCase("version", false)]
    [TestCase("version", true)]
    [TestCase("update", false)]
    [TestCase("update", true)]
    public async Task VoiceDefinitionsUseExistingCreateScopeWithoutContent(string operation, bool isAsync)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(200).WithContent(AgentResponse));
        using Activity parent = new Activity("caller").SetIdFormat(ActivityIdFormat.W3C).Start();
        await CreateVoiceDefinition(client, operation, isAsync, VoiceDefinition);

        Activity span = GetOnlyGenAiSpan();
        AssertCommon(span, "create_agent", "create_agent", 200);
        Assert.Multiple(() =>
        {
            Assert.That(span.GetTagItem("gen_ai.agent.type"), Is.EqualTo("voice"));
            Assert.That(span.GetTagItem("gen_ai.request.model"), Is.EqualTo("gpt-realtime"));
            Assert.That(span.GetTagItem("gen_ai.agent.name"), Is.EqualTo(AgentName));
            Assert.That(span.GetTagItem("gen_ai.agent.id"), Is.EqualTo("agent_123"));
            Assert.That(span.Status, Is.EqualTo(ActivityStatusCode.Unset));
            Assert.That(span.ParentSpanId, Is.EqualTo(parent.SpanId));
        });
        AssertPrivateSafe(span);
    }

    [TestCase("create", false)]
    [TestCase("create", true)]
    [TestCase("version", false)]
    [TestCase("version", true)]
    [TestCase("update", false)]
    [TestCase("update", true)]
    public async Task VoiceInstructionsUseExistingContentSchema(string operation, bool isAsync)
    {
        SetContentRecording(true);
        const string instructions = "Voice instructions \"quoted\"\nUnicode: \u65e5\u672c\u8a9e";
        string definition = VoiceDefinition.Replace("\"instructions\": \"" + PrivateContent + "\"",
            "\"instructions\": " + JsonSerializer.Serialize(instructions));
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(200).WithContent(AgentResponse));

        await CreateVoiceDefinition(client, operation, isAsync, definition);

        Activity span = GetOnlyGenAiSpan();
        AssertCommon(span, "create_agent", "create_agent", 200);
        AssertSystemInstructions(span, false, instructions);
        Assert.That(string.Join(" ", span.TagObjects.Select(tag => tag.Value)), Does.Not.Contain(PrivateContent),
            "Opting into instructions must not also capture the greeting.");
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task VoiceInstructionsFollowExistingMessageEventMode(bool recordContent)
    {
        SetContentRecording(recordContent, useMessageEvents: true);
        AgentAdministrationClient client = CreateClient(true, _ => new MockPipelineResponse(200).WithContent(AgentResponse));

        await CreateVoiceVersion(client, true);

        Activity span = GetOnlyGenAiSpan();
        if (recordContent)
        {
            AssertSystemInstructions(span, true, PrivateContent);
        }
        else
        {
            AssertPrivateSafe(span);
        }
    }

    [TestCase(false, 4095)]
    [TestCase(false, 4096)]
    [TestCase(false, 4097)]
    [TestCase(true, 4097)]
    public async Task VoiceInstructionsAreBoundedOnlyInTelemetry(bool useMessageEvents, int instructionLength)
    {
        SetContentRecording(true, useMessageEvents);
        string instructions = new('v', instructionLength);
        VoiceAgentDefinition definition = new()
        {
            ModelType = VoiceModelType.Managed,
            Model = "gpt-realtime",
            Instructions = instructions
        };
        AgentAdministrationClient client = CreateClient(true, _ => new MockPipelineResponse(200).WithContent(AgentResponse));

        await client.CreateAgentVersionAsync(AgentName, new ProjectsAgentVersionCreationOptions(definition));

        AssertSystemInstructions(GetOnlyGenAiSpan(), useMessageEvents, instructions.Substring(0, Math.Min(4096, instructionLength)));
        Assert.That(definition.Instructions, Is.EqualTo(instructions), "Telemetry must not truncate the agent definition.");
    }

    [TestCase(false, null)]
    [TestCase(true, null)]
    [TestCase(false, "")]
    [TestCase(true, "")]
    public async Task AbsentVoiceInstructionsDoNotAddContent(bool useMessageEvents, string instructions)
    {
        SetContentRecording(true, useMessageEvents);
        AgentAdministrationClient client = CreateClient(true, _ => new MockPipelineResponse(200).WithContent(AgentResponse));
        ProjectsAgentVersionCreationOptions options = new(new VoiceAgentDefinition
        {
            ModelType = VoiceModelType.Managed,
            Model = "gpt-realtime",
            Instructions = instructions
        });

        await client.CreateAgentVersionAsync(AgentName, options);

        AssertPrivateSafe(GetOnlyGenAiSpan());
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task TypedVoiceVersionUsesTheSameCreateScope(bool isAsync)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(200).WithContent(AgentResponse));
        ProjectsAgentVersionCreationOptions options = new(new VoiceAgentDefinition
        {
            ModelType = VoiceModelType.Managed,
            Model = "gpt-realtime",
            Instructions = PrivateContent
        });

        ClientResult<ProjectsAgentVersion> result = isAsync
            ? await client.CreateAgentVersionAsync(AgentName, options)
            : client.CreateAgentVersion(AgentName, options);

        Assert.That(result.Value.Id, Is.EqualTo("agent_123"));
        Activity span = GetOnlyGenAiSpan();
        AssertCommon(span, "create_agent", "create_agent", 200);
        Assert.That(span.GetTagItem("gen_ai.agent.version"), Is.EqualTo("1"));
        AssertPrivateSafe(span);
    }

    [TestCaseSource(nameof(ResponseOwnershipCases))]
    public async Task VoiceResponsesAreRecordedOnlyByTheirOwningOperation(string operation, bool isAsync, bool metricsOnly, bool nestedFails)
    {
        if (metricsOnly)
        {
            _listener.Dispose();
        }
        ConcurrentQueue<Dictionary<string, object>> measurements = new();
        using MeterListener metrics = new()
        {
            InstrumentPublished = (instrument, listener) =>
            {
                if (instrument.Meter.Name == SourceName && instrument.Name == "gen_ai.client.operation.duration")
                {
                    listener.EnableMeasurementEvents(instrument);
                }
            }
        };
        metrics.SetMeasurementEventCallback<double>((instrument, measurement, tags, state) =>
            measurements.Enqueue(tags.ToArray().ToDictionary(tag => tag.Key, tag => tag.Value)));
        metrics.Start();

        int nestedStatus = nestedFails ? 503 : 200;
        int voiceStatus = nestedFails ? 200 : 503;
        const string unrelatedResponse = """{"id":"unrelated-id","name":"unrelated-agent","version":"99"}""";
        AgentAdministrationClient unrelatedClient = CreateClient(isAsync,
            _ => new MockPipelineResponse(nestedStatus).WithContent(unrelatedResponse));
        AgentAdministrationClient voiceClient = CreateClient(isAsync,
            _ => new MockPipelineResponse(voiceStatus).WithContent(AgentResponse));
        RequestOptions options = new() { ErrorOptions = ClientErrorBehaviors.NoThrow };
        options.AddPolicy(new NestedRequestPolicy(
            () =>
            {
                using BinaryContent content = JsonContent("""{"kind":"voice","prompt":"private-rest-content"}""");
                ClientResult nested = unrelatedClient.GenerateAgent(content, new RequestOptions { ErrorOptions = ClientErrorBehaviors.NoThrow });
                Assert.That(nested.GetRawResponse().Status, Is.EqualTo(nestedStatus));
            },
            async () =>
            {
                using BinaryContent content = JsonContent("""{"kind":"voice","prompt":"private-rest-content"}""");
                ClientResult nested = await unrelatedClient.GenerateAgentAsync(content, new RequestOptions { ErrorOptions = ClientErrorBehaviors.NoThrow });
                Assert.That(nested.GetRawResponse().Status, Is.EqualTo(nestedStatus));
            }), PipelinePosition.PerCall);

        ClientResult result = await CreateVoiceDefinition(voiceClient, operation, isAsync, VoiceDefinition, options);

        Assert.That(result.GetRawResponse().Status, Is.EqualTo(voiceStatus));
        Dictionary<string, object>[] recorded = measurements.ToArray();
        Assert.That(recorded, Has.Length.EqualTo(1));
        Assert.That(recorded[0].TryGetValue("error.type", out object errorType) ? errorType : null,
            Is.EqualTo(nestedFails ? null : "503"));
        Assert.That(recorded[0].TryGetValue("gen_ai.agent.version", out object version) ? version : null,
            Is.EqualTo(nestedFails ? "1" : null));
        if (metricsOnly)
        {
            Assert.That(_activities.Where(activity => activity.Source.Name == SourceName), Is.Empty);
        }
        else
        {
            Activity span = GetOnlyGenAiSpan();
            AssertCommon(span, "create_agent", "create_agent", voiceStatus);
            Assert.Multiple(() =>
            {
                Assert.That(span.Status, Is.EqualTo(nestedFails ? ActivityStatusCode.Unset : ActivityStatusCode.Error));
                Assert.That(span.GetTagItem("error.type"), Is.EqualTo(nestedFails ? null : "503"));
                Assert.That(span.GetTagItem("gen_ai.agent.id"), Is.EqualTo(nestedFails ? "agent_123" : null));
                Assert.That(span.GetTagItem("gen_ai.agent.name"), Is.EqualTo(AgentName));
                Assert.That(span.GetTagItem("gen_ai.agent.version"), Is.EqualTo(nestedFails ? "1" : null));
            });
            AssertPrivateSafe(span);
        }
    }

    [TestCase("create", false)]
    [TestCase("create", true)]
    [TestCase("version", false)]
    [TestCase("version", true)]
    [TestCase("update", false)]
    [TestCase("update", true)]
    public async Task UnbufferedVoiceResponsesAreNotConsumed(string operation, bool isAsync)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(200).WithContent(AgentResponse));
        RequestOptions options = new() { BufferResponse = false };

        ClientResult result = await CreateVoiceDefinition(client, operation, isAsync, VoiceDefinition, options);

        Activity span = GetOnlyGenAiSpan();
        AssertCommon(span, "create_agent", "create_agent", 200);
        Assert.That(span.GetTagItem("gen_ai.agent.id"), Is.Null);
        Assert.That(span.GetTagItem("gen_ai.agent.version"), Is.Null);
        BinaryData content = isAsync
            ? await BinaryData.FromStreamAsync(result.GetRawResponse().ContentStream)
            : BinaryData.FromStream(result.GetRawResponse().ContentStream);
        Assert.That(content.ToString(), Is.EqualTo(AgentResponse));
        AssertPrivateSafe(span);
    }

    [TestCase("create", false)]
    [TestCase("create", true)]
    [TestCase("version", false)]
    [TestCase("version", true)]
    [TestCase("update", false)]
    [TestCase("update", true)]
    public async Task MalformedVoiceResponsesDoNotChangeSuccessfulCalls(string operation, bool isAsync)
    {
        const string response = "not-json-private-rest-content";
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(200).WithContent(response));

        ClientResult result = await CreateVoiceDefinition(client, operation, isAsync, VoiceDefinition);

        Assert.That(result.GetRawResponse().Content.ToString(), Is.EqualTo(response));
        Activity span = GetOnlyGenAiSpan();
        AssertCommon(span, "create_agent", "create_agent", 200);
        Assert.That(span.Status, Is.EqualTo(ActivityStatusCode.Unset));
        Assert.That(span.GetTagItem("error.type"), Is.Null);
        Assert.That(span.GetTagItem("az.ai.voice_agents.telemetry.error.type"), Is.EqualTo(typeof(JsonException).FullName));
        AssertPrivateSafe(span);
    }

    [Test]
    public void NonVoiceCreateMetadataAndNameAreUnchanged()
    {
        SetContentRecording(true);
        AgentAdministrationClient client = CreateClient(false, _ => new MockPipelineResponse(200).WithContent(AgentResponse));
        using BinaryContent content = JsonContent("""{"definition":{"kind":"prompt","model":"text-model","instructions":"original instructions"}}""");
        client.CreateAgentVersion("prompt-agent", content);

        Activity span = GetOnlyGenAiSpan();
        Assert.Multiple(() =>
        {
            Assert.That(span.DisplayName, Is.EqualTo("create_agent prompt-agent"));
            Assert.That(span.GetTagItem("gen_ai.agent.type"), Is.EqualTo("prompt"));
            Assert.That(span.GetTagItem("gen_ai.request.model"), Is.EqualTo("text-model"));
            Assert.That(span.GetTagItem("az.ai.voice_agents.operation"), Is.Null);
            Assert.That(span.GetTagItem("gen_ai.system_instructions"), Does.Contain("original instructions"));
        });
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public void NonVoiceInstructionsKeepExistingContentAndEventBehavior(bool recordContent, bool useMessageEvents)
    {
        SetContentRecording(recordContent, useMessageEvents);
        string instructions = new string('p', 4097) + PrivateContent;
        AgentAdministrationClient client = CreateClient(false, _ => new MockPipelineResponse(200).WithContent(AgentResponse));
        using BinaryContent content = JsonContent("{\"definition\":{\"kind\":\"prompt\",\"model\":\"text-model\",\"instructions\":" +
            JsonSerializer.Serialize(instructions) + "}}");

        client.CreateAgentVersion("prompt-agent", content);

        Activity span = GetOnlyGenAiSpan();
        Assert.That(span.DisplayName, Is.EqualTo("create_agent prompt-agent"));
        AssertSystemInstructions(span, useMessageEvents, recordContent ? instructions : null);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task VoiceInstructionsAreExcludedFromMetrics(bool useMessageEvents)
    {
        SetContentRecording(true, useMessageEvents);
        ConcurrentQueue<Dictionary<string, object>> measurements = new();
        using MeterListener metrics = new()
        {
            InstrumentPublished = (instrument, listener) =>
            {
                if (instrument.Meter.Name == SourceName && instrument.Name == "gen_ai.client.operation.duration")
                {
                    listener.EnableMeasurementEvents(instrument);
                }
            }
        };
        metrics.SetMeasurementEventCallback<double>((instrument, measurement, tags, state) =>
            measurements.Enqueue(tags.ToArray().ToDictionary(tag => tag.Key, tag => tag.Value)));
        metrics.Start();
        AgentAdministrationClient client = CreateClient(true, _ => new MockPipelineResponse(200).WithContent(AgentResponse));

        await CreateVoiceVersion(client, true);

        AssertSystemInstructions(GetOnlyGenAiSpan(), useMessageEvents, PrivateContent);
        Assert.That(measurements, Has.Count.EqualTo(1));
        Dictionary<string, object> tags = measurements.Single();
        Assert.Multiple(() =>
        {
            Assert.That(tags.ContainsKey("gen_ai.system_instructions"), Is.False);
            Assert.That(tags.ContainsKey("gen_ai.event.content"), Is.False);
            Assert.That(string.Join(" ", tags.Select(tag => tag.Key + "=" + tag.Value)), Does.Not.Contain(PrivateContent));
        });
    }

    [Test]
    public void DefaultHttpsPortIsOmittedWithoutAuthentication()
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200).WithContent(AgentResponse)) { ExpectSyncPipeline = true };
        AgentAdministrationClient client = new(new Uri("https://voice.example:443/api/projects/private-project?key=private-query"),
            new AgentAdministrationClientOptions { Transport = transport, EnableDistributedTracing = true });
        using BinaryContent content = JsonContent("{\"definition\":" + VoiceDefinition + "}");
        client.CreateAgentVersion(AgentName, content);

        Activity span = GetOnlyGenAiSpan();
        Assert.That(span.GetTagItem("server.address"), Is.EqualTo("voice.example"));
        Assert.That(span.GetTagItem("server.port"), Is.Null);
        AssertPrivateSafe(span);
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public void VoiceCreationErrorsAndCancellationArePrivateSafe(bool isAsync, bool cancelled)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => cancelled
            ? throw new OperationCanceledException(PrivateError)
            : new MockPipelineResponse(503).WithContent("{\"error\":{\"message\":\"" + PrivateError + "\"}}"));
        using BinaryContent content = JsonContent("{\"name\":\"voice-agent\",\"definition\":" + VoiceDefinition + "}");
        async Task Create()
        {
            if (isAsync)
            {
                await client.CreateAgentAsync(content);
            }
            else
            {
                client.CreateAgent(content);
            }
        }

        if (cancelled)
        {
            Assert.ThrowsAsync<OperationCanceledException>(Create);
        }
        else
        {
            Assert.ThrowsAsync<ClientResultException>(Create);
        }

        Activity span = GetOnlyGenAiSpan();
        Assert.That(span.DisplayName, Is.EqualTo("create_agent"));
        Assert.That(span.GetTagItem("gen_ai.agent.type"), Is.EqualTo("voice"));
        Assert.That(span.Status, Is.EqualTo(cancelled ? ActivityStatusCode.Unset : ActivityStatusCode.Error));
        Assert.That(span.GetTagItem("error.type"), Is.EqualTo(cancelled ? null : "503"));
        Assert.That(span.GetTagItem("az.ai.voice_agents.cancelled"), Is.EqualTo(cancelled ? true : null));
        AssertPrivateSafe(span);
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public async Task MutationHttpErrorsRetainExistingSdkBehavior(bool isAsync, bool noThrow)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(503).WithContent("{\"error\":{\"message\":\"" + PrivateError + "\"}}"));
        RequestOptions options = new() { ErrorOptions = noThrow ? ClientErrorBehaviors.NoThrow : ClientErrorBehaviors.Default };

        if (noThrow)
        {
            ClientResult result = await Mutate(client, "create_call_job", isAsync, false, options);
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(503));
        }
        else
        {
            ClientResultException error = Assert.ThrowsAsync<ClientResultException>(() => Mutate(client, "create_call_job", isAsync, false, options));
            Assert.That(error.Status, Is.EqualTo(503));
            Assert.That(error.Message, Does.Contain("private-rest-error"));
        }

        Activity span = GetOnlySdkSpan("BetaVoiceAgentsTelephony.CreateTelephonyCallJob");
        Assert.That(span.Status, Is.EqualTo(noThrow ? ActivityStatusCode.Unset : ActivityStatusCode.Error));
        Assert.That(span.GetTagItem("error.type"), Is.EqualTo(noThrow ? null : "503"));
        Assert.That(span.GetTagItem("az.ai.voice_agents.operation"), Is.Null);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task VoiceCreationMetricsRetainNoThrowStatusWithoutAffectingTheNextCall(bool isAsync)
    {
        _listener.Dispose();
        ConcurrentQueue<Dictionary<string, object>> measurements = new();
        using MeterListener metrics = new()
        {
            InstrumentPublished = (instrument, listener) =>
            {
                if (instrument.Meter.Name == SourceName && instrument.Name == "gen_ai.client.operation.duration")
                {
                    listener.EnableMeasurementEvents(instrument);
                }
            }
        };
        metrics.SetMeasurementEventCallback<double>((instrument, measurement, tags, state) =>
            measurements.Enqueue(tags.ToArray().ToDictionary(tag => tag.Key, tag => tag.Value)));
        metrics.Start();
        int requests = 0;
        AgentAdministrationClient client = CreateClient(isAsync,
            _ => new MockPipelineResponse(Interlocked.Increment(ref requests) == 1 ? 503 : 200).WithContent(AgentResponse));
        RequestOptions options = new() { ErrorOptions = ClientErrorBehaviors.NoThrow };

        ClientResult failed = await CreateVoiceVersion(client, isAsync, options);
        ClientResult succeeded = await CreateVoiceVersion(client, isAsync, options);

        Dictionary<string, object>[] recorded = measurements.ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(failed.GetRawResponse().Status, Is.EqualTo(503));
            Assert.That(succeeded.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(recorded, Has.Length.EqualTo(2));
            Assert.That(_activities, Is.Empty, "Metrics-only listeners must not require SDK Activities.");
        });
        Assert.That(recorded[0]["error.type"], Is.EqualTo("503"));
        Assert.That(recorded[1].ContainsKey("error.type"), Is.False);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void TransportErrorsDoNotRecordExceptionMessages(bool isAsync)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => throw new InvalidOperationException(PrivateError));
        Assert.ThrowsAsync<InvalidOperationException>(() => CreateVoiceVersion(client, isAsync));

        Activity span = GetOnlyGenAiSpan();
        Assert.That(span.Status, Is.EqualTo(ActivityStatusCode.Error));
        Assert.That(span.GetTagItem("error.type"), Is.EqualTo(typeof(InvalidOperationException).FullName));
        Assert.That(span.GetTagItem("http.response.status_code"), Is.Null);
        AssertPrivateSafe(span);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void CancellationIsNotAnError(bool isAsync)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => throw new OperationCanceledException(PrivateError));
        Assert.ThrowsAsync<OperationCanceledException>(() => CreateVoiceVersion(client, isAsync));

        Activity span = GetOnlyGenAiSpan();
        Assert.That(span.GetTagItem("az.ai.voice_agents.cancelled"), Is.True);
        Assert.That(span.GetTagItem("error.type"), Is.Null);
        Assert.That(span.Status, Is.EqualTo(ActivityStatusCode.Unset));
        AssertPrivateSafe(span);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task ReadsAndListsDoNotAddGenAiScopes(bool isAsync)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(200).WithContent("""{"data":[],"has_more":false}"""));
        BetaVoiceAgentsTelephony telephony = client.GetBetaVoiceAgentTelephony();
        BetaVoiceAgentsConversations conversations = client.GetBetaVoiceAgentEndpointConversations();

        if (isAsync)
        {
            await telephony.GetTelephonyCallJobAsync(AgentName, "job_123", null, new RequestOptions());
            await conversations.GetAgentConversationAsync(AgentName, "conv_123", new RequestOptions());
            await foreach (VoiceConversation _ in conversations.GetAgentConversationsAsync(AgentName))
            { }
            await foreach (TelephonyBindingListItem _ in telephony.GetTelephonyBindingsAsync(AgentName))
            { }
        }
        else
        {
            telephony.GetTelephonyCallJob(AgentName, "job_123", null, new RequestOptions());
            conversations.GetAgentConversation(AgentName, "conv_123", new RequestOptions());
            Assert.That(conversations.GetAgentConversations(AgentName).ToList(), Is.Empty);
            Assert.That(telephony.GetTelephonyBindings(AgentName).ToList(), Is.Empty);
        }

        Assert.That(_activities.Where(a => a.Source.Name == SourceName), Is.Empty);
        Assert.That(_activities.Select(a => a.OperationName), Does.Contain("BetaVoiceAgentsTelephony.GetTelephonyCallJob"));
        Assert.That(_activities.Select(a => a.OperationName), Does.Contain("BetaVoiceAgentsConversations.GetAgentConversation"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task UnbufferedProtocolResponsesAreNotConsumed(bool isAsync)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(202).WithContent(ResponseBody));
        ClientResult result = await Mutate(client, "create_call_job", isAsync, false, new RequestOptions { BufferResponse = false });

        Activity span = GetOnlySdkSpan("BetaVoiceAgentsTelephony.CreateTelephonyCallJob");
        Assert.That(span.GetTagItem("az.ai.voice_agents.telephony.call_job.id"), Is.Null);
        Assert.That(span.GetTagItem("az.ai.voice_agents.call_job.status"), Is.Null);
        BinaryData responseContent = isAsync
            ? await BinaryData.FromStreamAsync(result.GetRawResponse().ContentStream)
            : BinaryData.FromStream(result.GetRawResponse().ContentStream);
        Assert.That(responseContent.ToString(), Is.EqualTo(ResponseBody));
        AssertPrivateSafe(span);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task MalformedProtocolResponsesDoNotChangeSuccessfulCalls(bool isAsync)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(202).WithContent("not-json-private-rest-content"));
        ClientResult result = await Mutate(client, "create_call_job", isAsync, false);

        Assert.That(result.GetRawResponse().Content.ToString(), Is.EqualTo("not-json-private-rest-content"));
        Activity span = GetOnlySdkSpan("BetaVoiceAgentsTelephony.CreateTelephonyCallJob");
        Assert.That(span.Status, Is.EqualTo(ActivityStatusCode.Unset));
        Assert.That(span.GetTagItem("error.type"), Is.Null);
        Assert.That(span.GetTagItem("az.ai.voice_agents.telemetry.error.type"), Is.Null);
        AssertPrivateSafe(span);
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public async Task ConnectionProviderRetainsExistingSdkAndGenAiScopes(bool isAsync, bool enabled)
    {
        MockPipelineTransport transport = new(message =>
            message.Request.Uri.AbsolutePath.EndsWith("/call_jobs", StringComparison.Ordinal)
                ? new MockPipelineResponse(202).WithContent(ResponseBody)
                : message.Request.Method == "DELETE"
                    ? new MockPipelineResponse(204)
                    : new MockPipelineResponse(200).WithContent(AgentResponse))
        { ExpectSyncPipeline = !isAsync };
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        PipelineConnectionProvider provider = new(pipeline);
        AgentAdministrationClient client = provider.GetProjectAgentsClient(options: new() { EnableDistributedTracing = enabled });
        await Mutate(client, "create_call_job", isAsync, false);
        await Mutate(client, "delete", isAsync, false);
        using BinaryContent createContent = JsonContent("{\"name\":\"voice-agent\",\"definition\":" + VoiceDefinition + "}");
        using BinaryContent versionContent = JsonContent("{\"definition\":" + VoiceDefinition + "}");
        using BinaryContent updateContent = JsonContent("{\"definition\":" + VoiceDefinition + "}");
        if (isAsync)
        {
            await client.CreateAgentAsync(createContent);
            await client.CreateAgentVersionAsync(AgentName, versionContent);
            await client.UpdateAgentAsync(AgentName, updateContent);
        }
        else
        {
            client.CreateAgent(createContent);
            client.CreateAgentVersion(AgentName, versionContent);
            client.UpdateAgent(AgentName, updateContent);
        }

        Assert.That(_activities.Count(a => a.Source.Name == SourceName), Is.EqualTo(3));
        Assert.That(_activities.Count, Is.EqualTo(enabled ? 5 : 3));
        foreach (Activity span in _activities)
        {
            AssertPrivateSafe(span);
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task PropagationOnlySamplingDoesNotLeakCurrentActivity(bool isAsync)
    {
        _listener.Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.PropagationData;
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(202).WithContent(ResponseBody));
        using Activity parent = new Activity("caller").SetIdFormat(ActivityIdFormat.W3C).Start();
        await Mutate(client, "create_call_job", isAsync, false);

        Activity span = GetOnlySdkSpan("BetaVoiceAgentsTelephony.CreateTelephonyCallJob");
        Assert.That(span.IsAllDataRequested, Is.False);
        Assert.That(span.ParentSpanId, Is.EqualTo(parent.SpanId));
        Assert.That(Activity.Current, Is.SameAs(parent));
        Assert.That(span.Duration, Is.GreaterThan(TimeSpan.Zero));
    }

    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public async Task AgentGenerationRetainsExistingSdkDiagnostics(bool isAsync, bool fromSettings)
    {
        AgentAdministrationClient client = CreateClient(isAsync, _ => new MockPipelineResponse(200).WithContent(AgentResponse),
            fromSettings: fromSettings);
        using BinaryContent content = JsonContent("""{"kind":"voice","prompt":"private-rest-content"}""");
        if (isAsync)
        {
            await client.GenerateAgentAsync(content, new RequestOptions());
        }
        else
        {
            client.GenerateAgent(content, new RequestOptions());
        }

        Activity span = GetOnlySdkSpan("AgentAdministrationClient.GenerateAgent");
        Assert.That(span.GetTagItem("gen_ai.agent.name"), Is.Null);
        Assert.That(span.GetTagItem("gen_ai.agent.id"), Is.Null);
        AssertPrivateSafe(span);
    }

    [Test]
    public async Task GenericDiagnosticsRemainAvailableWithoutGenAiListener()
    {
        _listener.Dispose();
        using ActivityListener generic = new()
        {
            ShouldListenTo = source => source.Name == "Azure.AI.Projects.Agents.BetaVoiceAgentsConversations",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity => _activities.Enqueue(activity)
        };
        ActivitySource.AddActivityListener(generic);
        AgentAdministrationClient client = CreateClient(true, _ => new MockPipelineResponse(204));

        await client.GetBetaVoiceAgentEndpointConversations().DeleteAgentConversationAsync(AgentName, "conversation");

        Assert.That(_activities, Has.Count.EqualTo(1));
        Assert.That(_activities.Single().OperationName, Is.EqualTo("BetaVoiceAgentsConversations.DeleteAgentConversation"));
    }

    private Activity GetOnlyGenAiSpan()
    {
        Activity[] activities = _activities.ToArray();
        Assert.That(activities, Has.Length.EqualTo(1), "Agent creation must not emit both a GenAI and a generic operation span.");
        Assert.That(activities[0].Source.Name, Is.EqualTo(SourceName));
        return activities[0];
    }

    private Activity GetOnlySdkSpan(string operationName)
    {
        Activity[] activities = _activities.ToArray();
        Assert.That(activities, Has.Length.EqualTo(1), "Existing REST operations must not gain duplicate GenAI spans.");
        Activity span = activities[0];
        Assert.Multiple(() =>
        {
            Assert.That(span.Source.Name, Is.EqualTo("Azure.AI.Projects.Agents." + operationName.Split('.')[0]));
            Assert.That(span.OperationName, Is.EqualTo(operationName));
            Assert.That(span.DisplayName, Is.EqualTo(operationName));
            Assert.That(span.Kind, Is.EqualTo(ActivityKind.Internal));
        });
        return span;
    }

    private static void AssertCommon(Activity span, string name, string operation, int status)
    {
        Assert.Multiple(() =>
        {
            Assert.That(span.OperationName, Is.EqualTo(name));
            Assert.That(span.DisplayName, Is.EqualTo(name));
            Assert.That(span.Kind, Is.EqualTo(ActivityKind.Client));
            Assert.That(span.GetTagItem("gen_ai.provider.name"), Is.EqualTo("microsoft.foundry"));
            Assert.That(span.GetTagItem("gen_ai.operation.name"), Is.EqualTo(name));
            Assert.That(span.GetTagItem("az.namespace"), Is.EqualTo("Microsoft.CognitiveServices"));
            Assert.That(span.GetTagItem("server.address"), Is.EqualTo("voice.example"));
            Assert.That(span.GetTagItem("server.port"), Is.EqualTo(8443));
            Assert.That(span.GetTagItem("az.ai.voice_agents.operation"), Is.EqualTo(operation));
            Assert.That(span.GetTagItem("http.response.status_code"), Is.EqualTo(status));
        });
    }

    private static void AssertPrivateSafe(Activity span)
    {
        Assert.That(span.Events, Is.Empty);
        Assert.That(span.StatusDescription, Is.Null.Or.Empty);
        string tags = string.Join(" ", span.TagObjects.Select(t => t.Key + "=" + t.Value));
        foreach (string secret in new[] { PrivateContent, "private-user", "private-password", "private-project", "private-query", "private-token", "private-connection", "private-rest-error", "private-idempotency", "+15555550101", "+15555550102" })
        {
            Assert.That(tags, Does.Not.Contain(secret));
        }
        Assert.That(span.TagObjects.Select(t => t.Key), Is.SubsetOf(new[]
        {
            "gen_ai.provider.name", "gen_ai.operation.name", "az.namespace", "server.address", "server.port",
            "az.ai.voice_agents.operation", "http.response.status_code", "error.type", "az.ai.voice_agents.cancelled",
            "az.ai.voice_agents.telephony.call_job.id", "az.ai.voice_agents.call_job.status", "az.ai.voice_agents.telemetry.error.type",
            "gen_ai.agent.type", "gen_ai.agent.name", "gen_ai.agent.id", "gen_ai.agent.version", "gen_ai.request.model"
        }));
    }

    private static void AssertSystemInstructions(Activity span, bool useMessageEvents, string expectedInstructions)
    {
        string content;
        if (useMessageEvents)
        {
            Assert.That(span.GetTagItem("gen_ai.system_instructions"), Is.Null);
            Assert.That(span.Events.Count(), Is.EqualTo(1));
            ActivityEvent message = span.Events.Single();
            Assert.That(message.Name, Is.EqualTo("gen_ai.system_instructions"));
            Dictionary<string, object> tags = message.Tags.ToDictionary(tag => tag.Key, tag => tag.Value);
            Assert.That(tags.Keys, Is.EquivalentTo(new[] { "gen_ai.provider.name", "gen_ai.event.content" }));
            Assert.That(tags["gen_ai.provider.name"], Is.EqualTo("microsoft.foundry"));
            content = tags["gen_ai.event.content"] as string;
        }
        else
        {
            Assert.That(span.Events, Is.Empty);
            content = span.GetTagItem("gen_ai.system_instructions") as string;
        }

        Assert.That(content, Is.Not.Null);
        using JsonDocument document = JsonDocument.Parse(content);
        Assert.That(document.RootElement.ValueKind, Is.EqualTo(JsonValueKind.Array));
        Assert.That(document.RootElement.GetArrayLength(), Is.EqualTo(1));
        JsonElement instruction = document.RootElement[0];
        Assert.That(instruction.GetProperty("type").GetString(), Is.EqualTo("text"));
        if (expectedInstructions == null)
        {
            Assert.That(instruction.EnumerateObject().Select(property => property.Name), Is.EqualTo(new[] { "type" }));
        }
        else
        {
            Assert.That(instruction.EnumerateObject().Select(property => property.Name), Is.EquivalentTo(new[] { "type", "content" }));
            Assert.That(instruction.GetProperty("content").GetString(), Is.EqualTo(expectedInstructions));
        }
    }

    private static AgentAdministrationClient CreateClient(bool isAsync, Func<PipelineMessage, MockPipelineResponse> response, bool tracing = true, bool fromSettings = false)
    {
        MockPipelineTransport transport = new(message => response(message)) { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClientOptions options = new() { Transport = transport, EnableDistributedTracing = tracing, RetryPolicy = new ClientRetryPolicy(0) };
        return fromSettings
            ? new AgentAdministrationClient(new AgentAdministrationClientSettings
            {
                Endpoint = new Uri(Endpoint),
                Options = options,
                Credential = new CredentialSettings(null) { CredentialSource = "ApiKey", Key = "private-token" }
            })
            : new AgentAdministrationClient(new Uri(Endpoint), new FakeTokenProvider(), options);
    }

    private void SetTracing(bool enabled)
    {
        Environment.SetEnvironmentVariable(EnableEnvironment, enabled ? "true" : "false");
        if (_hadEnableSwitch)
        {
            AppContext.SetSwitch(EnableSwitch, enabled);
        }
        ReinitializeConfiguration();
    }

    private void SetContentRecording(bool enabled, bool useMessageEvents = false)
    {
        Environment.SetEnvironmentVariable(ContentEnvironment, enabled ? "true" : "false");
        Environment.SetEnvironmentVariable(MessageEventsEnvironment, useMessageEvents ? "true" : "false");
        if (_hadContentSwitch)
        {
            AppContext.SetSwitch(ContentSwitch, enabled);
        }
        if (_hadMessageEventsSwitch)
        {
            AppContext.SetSwitch(MessageEventsSwitch, useMessageEvents);
        }
        ReinitializeConfiguration();
    }

    private static void ReinitializeConfiguration()
    {
        Type scopeType = typeof(AgentAdministrationClient).Assembly.GetType("Azure.AI.Projects.Agents.Telemetry.OpenTelemetryScope");
        Assert.That(scopeType, Is.Not.Null);
        MethodInfo method = scopeType.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        Assert.That(method, Is.Not.Null);
        method.Invoke(null, null);
    }

    private static int SuccessStatus(string operation) => operation switch
    {
        "create_call_job" => 202,
        "create_binding" => 201,
        "delete" or "delete_binding" => 204,
        _ => 200
    };

    private static string MutationScopeName(string operation) => operation switch
    {
        "create_call_job" => "BetaVoiceAgentsTelephony.CreateTelephonyCallJob",
        "cancel_call_job" => "BetaVoiceAgentsTelephony.CancelTelephonyCallJob",
        "replace_transfer_targets" => "BetaVoiceAgentsTelephony.ReplaceTelephonyTransferTargets",
        "end_call" => "BetaVoiceAgentsTelephony.EndTelephonyCall",
        "transfer_call" => "BetaVoiceAgentsTelephony.TransferTelephonyCall",
        "create_binding" => "BetaVoiceAgentsTelephony.CreateTelephonyBinding",
        "update_binding" => "BetaVoiceAgentsTelephony.UpdateTelephonyBinding",
        "delete_binding" => "BetaVoiceAgentsTelephony.DeleteTelephonyBinding",
        "delete" => "BetaVoiceAgentsConversations.DeleteAgentConversation",
        _ => throw new ArgumentOutOfRangeException(nameof(operation))
    };

    private static BinaryContent JsonContent(string json) => BinaryContent.Create(BinaryData.FromString(json));

    private static async Task<ClientResult> CreateVoiceDefinition(AgentAdministrationClient client, string operation, bool isAsync, string definition, RequestOptions options = null)
    {
        string request = operation == "create"
            ? "{\"name\":\"voice-agent\",\"definition\":" + definition + "}"
            : "{\"definition\":" + definition + "}";
        using BinaryContent content = JsonContent(request);
        return operation switch
        {
            "create" => isAsync ? await client.CreateAgentAsync(content, options: options) : client.CreateAgent(content, options: options),
            "version" => isAsync ? await client.CreateAgentVersionAsync(AgentName, content, options: options) : client.CreateAgentVersion(AgentName, content, options: options),
            "update" => isAsync ? await client.UpdateAgentAsync(AgentName, content, options: options) : client.UpdateAgent(AgentName, content, options: options),
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };
    }

    private static async Task<ClientResult> CreateVoiceVersion(AgentAdministrationClient client, bool isAsync, RequestOptions options = null)
    {
        using BinaryContent content = JsonContent("{\"definition\":" + VoiceDefinition + "}");
        return isAsync
            ? await client.CreateAgentVersionAsync(AgentName, content, options: options)
            : client.CreateAgentVersion(AgentName, content, options: options);
    }

    private static async Task<ClientResult> Mutate(AgentAdministrationClient client, string operation, bool isAsync, bool typed, RequestOptions options = null)
    {
        BetaVoiceAgentsConversations conversations = client.GetBetaVoiceAgentEndpointConversations();
        BetaVoiceAgentsTelephony telephony = client.GetBetaVoiceAgentTelephony();
        if (typed)
        {
            return operation switch
            {
                "delete" => isAsync ? await conversations.DeleteAgentConversationAsync(AgentName, "conv_123") : conversations.DeleteAgentConversation(AgentName, "conv_123"),
                "create_binding" => isAsync ? await telephony.CreateTelephonyBindingAsync(AgentName, new CreateTwilioTelephonyBindingContent("private-connection", "+15555550101"), CancellationToken.None) : telephony.CreateTelephonyBinding(AgentName, new CreateTwilioTelephonyBindingContent("private-connection", "+15555550101"), CancellationToken.None),
                "delete_binding" => isAsync ? await telephony.DeleteTelephonyBindingAsync(AgentName, "binding_123", "*", CancellationToken.None) : telephony.DeleteTelephonyBinding(AgentName, "binding_123", "*", CancellationToken.None),
                "create_call_job" => isAsync ? await telephony.CreateTelephonyCallJobAsync(AgentName, "private-idempotency", CallJobContent(), CancellationToken.None) : telephony.CreateTelephonyCallJob(AgentName, "private-idempotency", CallJobContent(), CancellationToken.None),
                "cancel_call_job" => isAsync ? await telephony.CancelTelephonyCallJobAsync(AgentName, "job_123", "*", CancellationToken.None) : telephony.CancelTelephonyCallJob(AgentName, "job_123", "*", CancellationToken.None),
                "replace_transfer_targets" => isAsync ? await telephony.ReplaceTelephonyTransferTargetsAsync(AgentName, "*", Array.Empty<TelephonyTransferTarget>(), CancellationToken.None) : telephony.ReplaceTelephonyTransferTargets(AgentName, "*", Array.Empty<TelephonyTransferTarget>(), CancellationToken.None),
                "end_call" => isAsync ? await telephony.EndTelephonyCallAsync(AgentName, "call_123", CancellationToken.None) : telephony.EndTelephonyCall(AgentName, "call_123", CancellationToken.None),
                "transfer_call" => isAsync ? await telephony.TransferTelephonyCallAsync(AgentName, "call_123", PrivateContent, CancellationToken.None) : telephony.TransferTelephonyCall(AgentName, "call_123", PrivateContent, CancellationToken.None),
                _ => throw new ArgumentOutOfRangeException(nameof(operation))
            };
        }

        options ??= new RequestOptions();
        using BinaryContent content = JsonContent("""{"source":"+15555550102","destination":{"type":"phone_number","value":"+15555550101"},"messages":[{"content":"private-rest-content"}]}""");
        return operation switch
        {
            "delete" => isAsync ? await conversations.DeleteAgentConversationAsync(AgentName, "conv_123", options) : conversations.DeleteAgentConversation(AgentName, "conv_123", options),
            "create_binding" => isAsync ? await telephony.CreateTelephonyBindingAsync(AgentName, content, null, options) : telephony.CreateTelephonyBinding(AgentName, content, null, options),
            "update_binding" => isAsync ? await telephony.UpdateTelephonyBindingAsync(AgentName, "binding_123", "*", content, options) : telephony.UpdateTelephonyBinding(AgentName, "binding_123", "*", content, options),
            "delete_binding" => isAsync ? await telephony.DeleteTelephonyBindingAsync(AgentName, "binding_123", "*", null, options) : telephony.DeleteTelephonyBinding(AgentName, "binding_123", "*", null, options),
            "create_call_job" => isAsync ? await telephony.CreateTelephonyCallJobAsync(AgentName, "private-idempotency", content, null, options) : telephony.CreateTelephonyCallJob(AgentName, "private-idempotency", content, null, options),
            "cancel_call_job" => isAsync ? await telephony.CancelTelephonyCallJobAsync(AgentName, "job_123", "*", null, options) : telephony.CancelTelephonyCallJob(AgentName, "job_123", "*", null, options),
            "replace_transfer_targets" => isAsync ? await telephony.ReplaceTelephonyTransferTargetsAsync(AgentName, "*", content, null, options) : telephony.ReplaceTelephonyTransferTargets(AgentName, "*", content, null, options),
            "end_call" => isAsync ? await telephony.EndTelephonyCallAsync(AgentName, "call_123", null, options) : telephony.EndTelephonyCall(AgentName, "call_123", null, options),
            "transfer_call" => isAsync ? await telephony.TransferTelephonyCallAsync(AgentName, "call_123", content, null, options) : telephony.TransferTelephonyCall(AgentName, "call_123", content, null, options),
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };
    }

    private static CreateTelephonyCallJobContent CallJobContent()
    {
        CreateTelephonyCallJobContent content = new(new TelephonyOutboundDestination(TelephonyOutboundDestinationType.PhoneNumber, "+15555550101"), "private-connection", "+15555550102") { Purpose = PrivateContent };
        content.StructuredInputs["secret"] = BinaryData.FromString("\"private-rest-content\"");
        return content;
    }

    private sealed class NestedRequestPolicy(Action send, Func<Task> sendAsync) : PipelinePolicy
    {
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            ProcessNext(message, pipeline, currentIndex);
            send();
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
            await sendAsync().ConfigureAwait(false);
        }
    }

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);

        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("private-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);

        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }

    private sealed class PipelineConnectionProvider(ClientPipeline pipeline) : ClientConnectionProvider(1)
    {
        public override ClientConnection GetConnection(string connectionId)
            => new(connectionId, Endpoint, pipeline, CredentialKind.None);

        public override IEnumerable<ClientConnection> GetAllConnections() => [GetConnection("Internal.AgentsPipelinePassthrough")];
    }
}
