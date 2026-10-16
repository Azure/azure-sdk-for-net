// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Tests.Utils;
using Azure.Core.Diagnostics;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Realtime;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

#pragma warning disable AAIP001
#pragma warning disable AAIP002
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Tests.Samples;

[NonParallelizable]
[LiveOnly]
public class Sample_VoiceAgent_Telemetry : SamplesBase
{
    private const string TracingVariable = "AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING";
    private const string ContentVariable = "OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT";
    private const string TracingSwitch = "Azure.Experimental.EnableGenAITracing";
    private const string ContentSwitch = "Azure.Experimental.TraceGenAIMessageContent";
    private string _previousTracing;
    private string _previousContent;
    private bool _hadTracingSwitch;
    private bool _hadContentSwitch;
    private bool _previousTracingSwitch;
    private bool _previousContentSwitch;
    private bool _previousActivitySourceSwitch;

    public Sample_VoiceAgent_Telemetry(bool isAsync) : base(isAsync)
    {
    }

    [SetUp]
    public void ConfigureTestTracing()
    {
        _previousTracing = Environment.GetEnvironmentVariable(TracingVariable);
        _previousContent = Environment.GetEnvironmentVariable(ContentVariable);
        _hadTracingSwitch = AppContext.TryGetSwitch(TracingSwitch, out _previousTracingSwitch);
        _hadContentSwitch = AppContext.TryGetSwitch(ContentSwitch, out _previousContentSwitch);
        AppContext.TryGetSwitch("Azure.Experimental.EnableActivitySource", out _previousActivitySourceSwitch);
        Environment.SetEnvironmentVariable(TracingVariable, "true");
        Environment.SetEnvironmentVariable(ContentVariable, "false");
        if (_hadTracingSwitch)
        {
            AppContext.SetSwitch(TracingSwitch, true);
        }
        if (_hadContentSwitch)
        {
            AppContext.SetSwitch(ContentSwitch, false);
        }
        RefreshRestTracing();
    }

    [TearDown]
    public void RestoreTestTracing()
    {
        Environment.SetEnvironmentVariable(TracingVariable, _previousTracing);
        Environment.SetEnvironmentVariable(ContentVariable, _previousContent);
        if (_hadTracingSwitch)
        {
            AppContext.SetSwitch(TracingSwitch, _previousTracingSwitch);
        }
        if (_hadContentSwitch)
        {
            AppContext.SetSwitch(ContentSwitch, _previousContentSwitch);
        }
        RefreshRestTracing();
        AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", _previousActivitySourceSwitch);
    }

    [Test]
    [AsyncOnly]
    public async Task VoiceAgentRestTelemetryAsync()
    {
        MemoryTraceExporter exportedActivities = new();
        #region Snippet:Sample_VoiceAgent_Telemetry_Setup
        Environment.SetEnvironmentVariable("AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING", "true");
        Environment.SetEnvironmentVariable("OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT", "false");

        const string applicationSourceName = "VoiceAgentTelemetrySample";
        using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Projects.*")
            .AddSource(applicationSourceName)
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("VoiceAgentTelemetrySample"))
#if !SNIPPET
            .AddProcessor(new SimpleActivityExportProcessor(exportedActivities))
#endif
            .AddConsoleExporter()
            .Build();
        using ActivitySource applicationSource = new(applicationSourceName);
        #endregion

        #region Snippet:Sample_VoiceAgent_Telemetry_Rest
#if SNIPPET
        string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
#else
        string projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = $"voice-rest-tracing-{Guid.NewGuid():N}".Substring(0, 40);

        using (Activity workflow = applicationSource.StartActivity("voice_agent.sample.rest"))
        {
            VoiceAgentDefinition definition = new()
            {
                ModelType = VoiceModelType.SelfDeployed,
                Model = modelDeploymentName,
                Instructions = "Respond briefly and helpfully."
            };
            definition.OutputModalities.Add(VoiceOutputModality.Text);
            ClientResult<ProjectsAgentVersion> created = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
                agentName, new ProjectsAgentVersionCreationOptions(definition));
            Console.WriteLine($"CREATE {agentName} version {created.Value.Version}: HTTP {created.GetRawResponse().Status}");

            try
            {
                ClientResult<ProjectsAgentVersion> retrieved = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(
                    agentName, created.Value.Version);
                Console.WriteLine($"GET {agentName} version {retrieved.Value.Version}: HTTP {retrieved.GetRawResponse().Status}");
                if (retrieved.Value.Id != created.Value.Id)
                {
                    throw new InvalidOperationException("The retrieved agent version did not match the created version.");
                }

                definition.Instructions = "Respond in one short sentence.";
                ClientResult<ProjectsAgentVersion> updated = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
                    agentName, new ProjectsAgentVersionCreationOptions(definition));
                Console.WriteLine($"UPDATE {agentName} via version {updated.Value.Version}: HTTP {updated.GetRawResponse().Status}");
                if (updated.Value.Version == created.Value.Version ||
                    updated.Value.Definition is not VoiceAgentDefinition saved ||
                    saved.Instructions != definition.Instructions)
                {
                    throw new InvalidOperationException("The agent version update did not persist the expected instructions.");
                }
            }
            finally
            {
                ClientResult deleted = await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentName);
                Console.WriteLine($"DELETE {agentName}: HTTP {deleted.GetRawResponse().Status}");
            }
        }
        tracerProvider.ForceFlush();
        #endregion

        Activity workflowSpan = exportedActivities.GetExportedActivities().Single(activity => activity.DisplayName == "voice_agent.sample.rest");
        Activity[] createSpans = exportedActivities.GetExportedActivities().Where(activity => activity.DisplayName == "create_agent").ToArray();
        Assert.That(createSpans, Has.Length.EqualTo(2));
        Assert.That(createSpans.All(activity => activity.TraceId == workflowSpan.TraceId &&
            activity.ParentSpanId == workflowSpan.SpanId && Equals(activity.GetTagItem("gen_ai.agent.type"), "voice")), Is.True);
    }

    [Test]
    [AsyncOnly]
    public async Task VoiceAgentRealtimeTelemetryAsync()
    {
        MemoryTraceExporter exportedActivities = new();
        Environment.SetEnvironmentVariable("AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING", "true");
        Environment.SetEnvironmentVariable("OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT", "false");
        const string applicationSourceName = "VoiceAgentTelemetrySample";
        using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Projects.*")
            .AddSource(applicationSourceName)
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("VoiceAgentTelemetrySample"))
            .AddProcessor(new SimpleActivityExportProcessor(exportedActivities))
            .AddConsoleExporter()
            .Build();
        using ActivitySource applicationSource = new(applicationSourceName);

        #region Snippet:Sample_VoiceAgent_Telemetry_Logs
        using AzureEventSourceListener sdkLogs = new((eventData, message) =>
        {
            if (eventData.EventSource.Name == "Azure-AI-Projects-Realtime")
            {
                Console.WriteLine($"[SDK] {message}");
            }
        }, EventLevel.Verbose);
        #endregion

        #region Snippet:Sample_VoiceAgent_Telemetry_Realtime
#if SNIPPET
        string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
#else
        string projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = $"voice-live-tracing-{Guid.NewGuid():N}".Substring(0, 40);

        using (Activity workflow = applicationSource.StartActivity("voice_agent.sample.realtime"))
        {
            VoiceAgentDefinition definition = new()
            {
                ModelType = VoiceModelType.SelfDeployed,
                Model = modelDeploymentName,
                Instructions = "Respond briefly and helpfully."
            };
            definition.OutputModalities.Add(VoiceOutputModality.Text);
            ClientResult<ProjectsAgentVersion> created = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
                agentName, new ProjectsAgentVersionCreationOptions(definition));
            Console.WriteLine($"CREATE {agentName}: HTTP {created.GetRawResponse().Status}");

            try
            {
                using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
                string conversationId = null;
                using (RealtimeSessionClient session = await projectClient.ProjectsRealtimeClient.StartSessionAsync(
                    agentName, intent: null, options: new ProjectsRealtimeSessionClientOptions
                    {
                        Transport = VoiceAgentTransport.Websocket,
                        QueryString = "store=true"
                    }, cancellationToken: timeout.Token))
                {
                    await session.ConfigureConversationSessionAsync(new RealtimeConversationSessionOptions
                    {
                        Instructions = "Greet the user in one short sentence."
                    }, timeout.Token);
                    await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello."), timeout.Token);
                    await session.StartResponseAsync(timeout.Token);

                    string text = null;
                    bool completed = false;
                    await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
                    {
                        Console.WriteLine($"Received event: {update.Kind}");
                        if (update is RealtimeServerUpdateResponseOutputTextDone textDone)
                        {
                            text = textDone.Text;
                        }
                        else if (update is RealtimeServerUpdateResponseDone done)
                        {
                            completed = done.Response.Status == RealtimeResponseStatus.Completed;
                            conversationId = done.Response.ConversationId;
                            Console.WriteLine($"Response {done.Response.Id} status: {done.Response.Status}");
                            break;
                        }
                    }
                    if (!completed || string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(conversationId))
                    {
                        throw new InvalidOperationException("The voice agent did not complete a stored text response.");
                    }
                }

                BetaVoiceAgentsConversations conversations = projectClient.AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations();
                ClientResult<VoiceConversation> conversation = await conversations.GetAgentConversationAsync(
                    agentName, conversationId, timeout.Token);
                Console.WriteLine($"GET stored conversation: HTTP {conversation.GetRawResponse().Status}");
                if (conversation.Value.Id != conversationId)
                {
                    throw new InvalidOperationException("The stored conversation did not match the realtime session.");
                }
                ClientResult deleted = await conversations.DeleteAgentConversationAsync(agentName, conversationId, timeout.Token);
                Console.WriteLine($"DELETE stored conversation: HTTP {deleted.GetRawResponse().Status}");
            }
            finally
            {
                ClientResult deleted = await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentName);
                Console.WriteLine($"DELETE {agentName}: HTTP {deleted.GetRawResponse().Status}");
            }
        }
        tracerProvider.ForceFlush();
        #endregion

        var spans = exportedActivities.GetExportedActivities();
        Activity workflowSpan = spans.Single(activity => activity.DisplayName == "voice_agent.sample.realtime");
        Activity sessionSpan = spans.Single(activity => activity.DisplayName == "voice_agents.realtime.session");
        Activity connectSpan = spans.Single(activity => activity.DisplayName == "voice_agents.realtime.connect");
        Activity responseSpan = spans.Single(activity => activity.DisplayName == "invoke_agent");
        Assert.Multiple(() =>
        {
            Assert.That(sessionSpan.TraceId, Is.EqualTo(workflowSpan.TraceId));
            Assert.That(sessionSpan.ParentSpanId, Is.EqualTo(workflowSpan.SpanId));
            Assert.That(connectSpan.ParentSpanId, Is.EqualTo(sessionSpan.SpanId));
            Assert.That(responseSpan.ParentSpanId, Is.EqualTo(sessionSpan.SpanId));
            Assert.That(responseSpan.Status, Is.EqualTo(ActivityStatusCode.Ok));
            Assert.That(sessionSpan.Events.Select(activityEvent => activityEvent.Name), Does.Contain("voice_agents.session.updated"));
            Assert.That(spans.Count(activity => activity.DisplayName == "BetaVoiceAgentsConversations.DeleteAgentConversation"), Is.EqualTo(1));
        });
    }

    private static void RefreshRestTracing()
    {
        Type type = typeof(AgentAdministrationClient).Assembly.GetType("Azure.AI.Projects.Agents.Telemetry.OpenTelemetryScope");
        Assert.That(type, Is.Not.Null);
        MethodInfo method = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        Assert.That(method, Is.Not.Null);
        method.Invoke(null, null);
    }
}
