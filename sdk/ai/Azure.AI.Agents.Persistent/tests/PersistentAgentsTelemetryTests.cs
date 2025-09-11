// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry;
using Azure.AI.Agents.Persistent.Tests.Utilities;
using System.Text.Json;
using System.Reflection;
using Azure.Identity;
using System.Diagnostics;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class PersistentAgentTelemetryTests : RecordedTestBase<AIAgentsTestEnvironment>
{
    public const string TraceContentsEnvironmentVariable = "AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED";
    public const string EnableOpenTelemetryEnvironmentVariable = "AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE";
    private MemoryTraceExporter _exporter;
    private TracerProvider _tracerProvider;
    private GenAiTraceVerifier _traceVerifier;
    private bool _contentRecordingEnabledInitialValue = false;
    private bool _tracesEnabledInitialValue = false;

    public PersistentAgentTelemetryTests(bool isAsync) : base(isAsync)
    {
        TestDiagnostics = false;
    }

    [SetUp]
    public void Setup()
    {
        _exporter = new MemoryTraceExporter();
        _traceVerifier = new GenAiTraceVerifier();

        _tracesEnabledInitialValue = string.Equals(
            Environment.GetEnvironmentVariable(TraceContentsEnvironmentVariable),
            "true",
            StringComparison.OrdinalIgnoreCase);

        _contentRecordingEnabledInitialValue = string.Equals(
            Environment.GetEnvironmentVariable(TraceContentsEnvironmentVariable),
            "true",
            StringComparison.OrdinalIgnoreCase);

        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);

        _tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingTest"))
            .AddProcessor(new SimpleActivityExportProcessor(_exporter))
            .Build();
    }

    [TearDown]
    public void Cleanup()
    {
        _tracerProvider.Dispose();
        _exporter.Clear();
        Environment.SetEnvironmentVariable(
            TraceContentsEnvironmentVariable,
            _contentRecordingEnabledInitialValue.ToString(),
            EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(
            TraceContentsEnvironmentVariable,
            _tracesEnabledInitialValue.ToString(),
            EnvironmentVariableTarget.Process);
    }

    private PersistentAgentsClient GetClient()
    {
        var connectionString = TestEnvironment.PROJECT_ENDPOINT;
        // If we are in the Playback, do not ask for authentication.
        PersistentAgentsAdministrationClient admClient = null;
        PersistentAgentsAdministrationClientOptions opts = InstrumentClientOptions(new PersistentAgentsAdministrationClientOptions());
        if (Mode == RecordedTestMode.Playback)
        {
            admClient = InstrumentClient(new PersistentAgentsAdministrationClient(connectionString, new MockCredential(), opts));
            return new PersistentAgentsClient(admClient);
        }
        // For local testing if you are using non default account
        // add USE_CLI_CREDENTIAL into the .runsettings and set it to true,
        // also provide the PATH variable.
        // This path should allow launching az command.
        var cli = System.Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL");
        if (!string.IsNullOrEmpty(cli) && string.Compare(cli, "true", StringComparison.OrdinalIgnoreCase) == 0)
        {
            admClient = InstrumentClient(new PersistentAgentsAdministrationClient(connectionString, new AzureCliCredential(), opts));
        }
        else
        {
            admClient = InstrumentClient(new PersistentAgentsAdministrationClient(connectionString, new DefaultAzureCredential(), opts));
        }
        Assert.IsNotNull(admClient);
        return new PersistentAgentsClient(admClient);
    }

    private async Task<ThreadRun> WaitForRun(PersistentAgentsClient client, ThreadRun run)
    {
        double delay = 500;
        do
        {
            if (Mode != RecordedTestMode.Playback)
                await Task.Delay(TimeSpan.FromMilliseconds(delay));
            run = await client.Runs.GetRunAsync(run.ThreadId, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress
            || run.Status == RunStatus.RequiresAction);
        Assert.AreEqual(RunStatus.Completed, run.Status, message: run.LastError?.Message?.ToString());
        return run;
    }

    private string GetModelDeploymentName()
    {
        string modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        return modelDeploymentName;
    }

    [RecordedTest]
    public async Task TestAgentChatWithTracingActivitySourceDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "my-agent",
            instructions: "You are helpful agent");

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Hello, tell me a joke");

        ThreadRun run = await client.Runs.CreateRunAsync(thread.Id, agent.Id);

        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress || run.Status == RunStatus.RequiresAction)
        {
            await Task.Delay(1000);
            run = await client.Runs.GetRunAsync(thread.Id, run.Id);
        }

        var messages = client.Messages.GetMessagesAsync(threadId: thread.Id, order: ListSortOrder.Ascending);
        await foreach (PersistentThreadMessage threadMessage in messages)
        {
            _ = threadMessage;
        }

        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent my-agent");
        Assert.IsNull(createAgentSpan);
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        Assert.IsNull(createThreadSpan);
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNull(createMessageSpan);
        var startThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "start_thread_run");
        Assert.IsNull(startThreadRunSpan);
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        Assert.IsNull(getThreadRunSpan);
        var listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        Assert.IsNull(listMessagesSpan);
    }

    [RecordedTest]
    public async Task TestAgentChatWithTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "my-agent",
            instructions: "You are helpful agent");

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Hello, tell me a joke");

        ThreadRun run = await client.Runs.CreateRunAsync(thread.Id, agent.Id);

        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress || run.Status == RunStatus.RequiresAction)
        {
            await Task.Delay(1000);
            run = await client.Runs.GetRunAsync(thread.Id, run.Id);
        }

        var messages = client.Messages.GetMessagesAsync(threadId: thread.Id, order: ListSortOrder.Ascending);
        await foreach (PersistentThreadMessage threadMessage in messages)
        {
            _ = threadMessage;
        }

        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent my-agent");
        Assert.IsNotNull(createAgentSpan);

        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", "my-agent" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", "{\"content\": \"You are helpful agent\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        Assert.IsNotNull(createThreadSpan);
        var expectedCreateThreadAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_thread" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createThreadSpan, expectedCreateThreadAttributes));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", "{\"content\": \"Hello, tell me a joke\", \"role\": \"user\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify start_thread_run span
        var startThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "start_thread_run");
        Assert.IsNotNull(startThreadRunSpan);
        var expectedStartThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "start_thread_run" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.thread.run.status", "queued" },
            { "gen_ai.response.model", modelDeploymentName }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(startThreadRunSpan, expectedStartThreadRunAttributes));

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        Assert.IsNotNull(getThreadRunSpan);
        var expectedGetThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "get_thread_run" },
            { "gen_ai.thread.run.status", "completed" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(getThreadRunSpan, expectedGetThreadRunAttributes));

        // Verify list_messages span
        var listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        Assert.IsNotNull(listMessagesSpan);
        var expectedListMessagesAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_messages" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listMessagesSpan, expectedListMessagesAttributes));

        var expectedListMessagesEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"content\": {\"text\": {\"value\": \"*\"}}, \"role\": \"assistant\"}" }
            }),
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"content\": {\"text\": {\"value\": \"Hello, tell me a joke\"}}, \"role\": \"user\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(listMessagesSpan, expectedListMessagesEvents));
    }

    [RecordedTest]
    public async Task TestAgentChatWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "my-agent",
            instructions: "You are helpful agent");

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Hello, tell me a joke");

        ThreadRun run = await client.Runs.CreateRunAsync(thread.Id, agent.Id);

        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress || run.Status == RunStatus.RequiresAction)
        {
            await Task.Delay(1000);
            run = await client.Runs.GetRunAsync(thread.Id, run.Id);
        }

        var messages = client.Messages.GetMessagesAsync(threadId: thread.Id, order: ListSortOrder.Ascending);
        await foreach (PersistentThreadMessage threadMessage in messages)
        {
            _ = threadMessage;
        }

        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent my-agent");
        Assert.IsNotNull(createAgentSpan);

        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", "my-agent" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", "\"\"" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        Assert.IsNotNull(createThreadSpan);
        var expectedCreateThreadAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_thread" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createThreadSpan, expectedCreateThreadAttributes));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", "{\"role\": \"user\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify start_thread_run span
        var startThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "start_thread_run");
        Assert.IsNotNull(startThreadRunSpan);
        var expectedStartThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "start_thread_run" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.thread.run.status", "*" },
            { "gen_ai.response.model", modelDeploymentName }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(startThreadRunSpan, expectedStartThreadRunAttributes));

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        Assert.IsNotNull(getThreadRunSpan);
        var expectedGetThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "get_thread_run" },
            { "gen_ai.thread.run.status", "completed" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(getThreadRunSpan, expectedGetThreadRunAttributes));

        // Verify list_messages span
        var listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        Assert.IsNotNull(listMessagesSpan);
        var expectedListMessagesAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_messages" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listMessagesSpan, expectedListMessagesAttributes));

        var expectedListMessagesEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"role\": \"assistant\"}" }
            }),
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"role\": \"user\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(listMessagesSpan, expectedListMessagesEvents));
    }

    [RecordedTest]
    public async Task TestAgentChatWithFunctionToolTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        // Define the function tool
        FunctionToolDefinition getCurrentWeatherAtLocationTool = new FunctionToolDefinition(
            name: "getCurrentWeatherAtLocation",
            description: "Gets the current weather at a provided location.",
            parameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Location = new
                        {
                            Type = "string",
                            Description = "The city and state, e.g. San Francisco, CA",
                        },
                    },
                    Required = new[] { "location" },
                },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));

        // Create agent with toolset
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
            instructions: "You are a weather bot. Use the provided function to help answer questions about weather.",
            tools: new[] { getCurrentWeatherAtLocationTool });

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the weather in Seattle.");

        ThreadRun run = await client.Runs.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as J. Doe. The user has a premium account.");

        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress || run.Status == RunStatus.RequiresAction)
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(1000);
            }
            run = await client.Runs.GetRunAsync(thread.Id, run.Id);

            if (run.Status == RunStatus.RequiresAction && run.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
            {
                var toolOutputs = new List<ToolOutput>();
                foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
                {
                    if (toolCall is RequiredFunctionToolCall functionToolCall)
                    {
                        var argumentsJson = JsonDocument.Parse(functionToolCall.Arguments);
                        var locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                        toolOutputs.Add(new ToolOutput(toolCall.Id, "{\"weather\": \"Sunny\"}"));
                    }
                }
                run = await client.Runs.SubmitToolOutputsToRunAsync(run, toolOutputs);
            }
        }
        Assert.AreEqual(RunStatus.Completed, run.Status, run.LastError?.Message);

        // Enumerate messages and run steps to trigger spans
        await foreach (var messageInList in client.Messages.GetMessagesAsync(thread.Id))
        {
            _ = messageInList;
        }

        await foreach (var step in client.Runs.GetRunStepsAsync(thread.Id, run.Id))
        {
            _ = step;
        }

        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent SDK Test Agent - Functions");
        Assert.IsNotNull(createAgentSpan);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", "SDK Test Agent - Functions" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", "{\"content\": \"You are a weather bot. Use the provided function to help answer questions about weather.\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", "{\"content\": \"What is the weather in Seattle.\", \"role\": \"user\"}" }
            })
        };

        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify submit_tool_outputs span explicitly
        var submitToolOutputsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "submit_tool_outputs");
        Assert.IsNotNull(submitToolOutputsSpan);
        var expectedSubmitToolOutputsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "submit_tool_outputs" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.response.model", modelDeploymentName }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(submitToolOutputsSpan, expectedSubmitToolOutputsAttributes));

        var expectedSubmitToolOutputsEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.tool.message", new Dictionary<string, object>
            {
                { "gen_ai.event.content", "{\"content\":\"{\\\"weather\\\": \\\"Sunny\\\"}\",\"id\":\"*\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(submitToolOutputsSpan, expectedSubmitToolOutputsEvents));

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        Assert.IsNotNull(getThreadRunSpan);
        var expectedGetThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "get_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.thread.run.status", "completed" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(getThreadRunSpan, expectedGetThreadRunAttributes));

        // Verify list_messages span explicitly
        var listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        Assert.IsNotNull(listMessagesSpan);

        var expectedListMessagesAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_messages" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listMessagesSpan, expectedListMessagesAttributes));

        var expectedListMessagesEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"content\":{\"text\":{\"value\":\"What is the weather in Seattle.\"}},\"role\":\"user\"}" }
            }),
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"content\":{\"text\":{\"value\":\"*\"}},\"role\":\"assistant\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(listMessagesSpan, expectedListMessagesEvents));

        // Verify list_run_steps span
        var listRunStepsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_run_steps");
        Assert.IsNotNull(listRunStepsSpan);
        var expectedListRunStepsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_run_steps" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listRunStepsSpan, expectedListRunStepsAttributes));

        var expectedListRunStepsEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.run_step.message_creation", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.run_step.status", "completed" },
                { "gen_ai.run_step.start.timestamp", "+" },
                { "gen_ai.run_step.end.timestamp", "+" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" }
            }),
            ("gen_ai.run_step.tool_calls", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.run_step.status", "completed" },
                { "gen_ai.run_step.start.timestamp", "+" },
                { "gen_ai.run_step.end.timestamp", "+" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.event.content", "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"function\",\"function\":{\"name\":\"getCurrentWeatherAtLocation\",\"arguments\":{\"location\":\"Seattle, WA\"}}}]}"}
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(listRunStepsSpan, expectedListRunStepsEvents));
    }

    [RecordedTest]
    public async Task TestBingCustomSearchTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Type type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        MethodInfo methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        PersistentAgentsClient client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        string system_prompt = "You are helpful agent.";
        string prompt = "How many medals did the USA win in the 2024 summer olympics?";
        string agentName = "SDK Test Agent - DeepResearch";
        // Create agent with toolset
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: agentName,
            instructions: system_prompt,
            tools: [
                new BingCustomSearchToolDefinition(
                    new BingCustomSearchToolParameters(
                        connectionId: TestEnvironment.BING_CUSTOM_CONNECTION_ID,
                        instanceName: TestEnvironment.BING_CONFIGURATION_NAME
                    )
                )
            ]);

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            prompt);

        ThreadRun run = await client.Runs.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as J. Doe. The user has a premium account.");
        run = await WaitForRun(client, run);

        // Enumerate messages and run steps to trigger spans
        await foreach (PersistentThreadMessage messageInList in client.Messages.GetMessagesAsync(thread.Id))
        {
            _ = messageInList;
        }

        await foreach (RunStep step in client.Runs.GetRunStepsAsync(thread.Id, run.Id))
        {
            _ = step;
        }

        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent SDK Test Agent - DeepResearch");
        Assert.IsNotNull(createAgentSpan);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", agentName },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", $"{{\"content\": \"{system_prompt}\"}}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", $"{{\"content\":\"{prompt}\",\"role\":\"user\"}}" }
            })
        };

        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        Assert.IsNotNull(getThreadRunSpan);
        var expectedGetThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "get_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.thread.run.status", "completed" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(getThreadRunSpan, expectedGetThreadRunAttributes));

        // Verify list_messages span explicitly
        var listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        Assert.IsNotNull(listMessagesSpan);

        var expectedListMessagesAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_messages" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listMessagesSpan, expectedListMessagesAttributes));

        var expectedListMessagesEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", $"{{\"content\":{{\"text\":{{\"value\":\"{prompt}\"}}}},\"role\":\"user\"}}" }
            }),
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"content\":{\"text\":{\"value\":\"*\",\"annotations\":\"*\"}},\"role\":\"assistant\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(listMessagesSpan, expectedListMessagesEvents));

        // Verify list_run_steps span
        var listRunStepsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_run_steps");
        Assert.IsNotNull(listRunStepsSpan);
        var expectedListRunStepsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_run_steps" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listRunStepsSpan, expectedListRunStepsAttributes));

        var expectedListRunStepsEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.run_step.message_creation", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.run_step.status", "completed" },
                { "gen_ai.run_step.start.timestamp", "+" },
                { "gen_ai.run_step.end.timestamp", "+" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" }
            }),
            ("gen_ai.run_step.tool_calls", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.run_step.status", "completed" },
                { "gen_ai.run_step.start.timestamp", "+" },
                { "gen_ai.run_step.end.timestamp", "+" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.event.content", "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"bing_custom_search\",\"details\":{\"requesturl\":\"*\",\"response_metadata\":\"*\"}}]}"}
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(listRunStepsSpan, expectedListRunStepsEvents));
    }

    [RecordedTest]
    public async Task TestDeepResearchToolTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        string system_prompt = "You are a helpful agent that assists in researching scientific topics.";
        string prompt = "Research the current state of studies on orca intelligence and orca language, " +
            "including what is currently known about orcas cognitive capabilities, " +
            "communication systems and problem-solving reflected in recent publications in top their scientific " +
            "journals like Science, Nature and PNAS.";
        // Create agent with toolset
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - DeepResearch",
            instructions: system_prompt,
            tools: [
                new DeepResearchToolDefinition(
                    new DeepResearchDetails(
                        model: TestEnvironment.DEEP_RESEARCH_MODEL_DEPLOYMENT_NAME,
                        bingGroundingConnections: [new DeepResearchBingGroundingConnection(TestEnvironment.BING_CONNECTION_ID)]
                    )
                )
            ]);

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            prompt);

        ThreadRun run = await client.Runs.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as J. Doe. The user has a premium account.");
        run = await WaitForRun(client, run);

        // Enumerate messages and run steps to trigger spans
        await foreach (var messageInList in client.Messages.GetMessagesAsync(thread.Id))
        {
            _ = messageInList;
        }

        await foreach (var step in client.Runs.GetRunStepsAsync(thread.Id, run.Id))
        {
            _ = step;
        }

        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent SDK Test Agent - DeepResearch");
        Assert.IsNotNull(createAgentSpan);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", "SDK Test Agent - DeepResearch" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", $"{{\"content\": \"{system_prompt}\"}}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", $"{{\"content\":\"{prompt}\",\"role\":\"user\"}}" }
            })
        };

        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        Assert.IsNotNull(getThreadRunSpan);
        var expectedGetThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "get_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.thread.run.status", "completed" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(getThreadRunSpan, expectedGetThreadRunAttributes));

        // Verify list_messages span explicitly
        //var listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        IEnumerable<Activity> spans = _exporter.GetExportedActivities().Where(s => s.DisplayName == "list_messages");
        Assert.Greater(spans.Count(), 0);

        List<ActivityEvent> events = [];
        var expectedListMessagesAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_messages" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" }
        };
        foreach (Activity listMessagesSpan in spans)
        {
            Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listMessagesSpan, expectedListMessagesAttributes));
            events.AddRange(listMessagesSpan.Events);
        }

        var expectedListMessagesEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", $"{{\"content\":{{\"text\":{{\"value\":\"{prompt}\"}}}},\"role\":\"user\"}}" }
            }),
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"content\":{\"text\":{\"value\":\"*\",\"annotations\":\"*\"}},\"role\":\"assistant\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(events, expectedListMessagesEvents, allowAdditionalEvents: true));

        // Verify list_run_steps span
        events = [];
        var expectedListRunStepsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_run_steps" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" }
        };
        spans = _exporter.GetExportedActivities().Where(s => s.DisplayName == "list_run_steps");
        Assert.Greater(spans.Count(), 0);
        List<ActivityEvent> runStepsSpanEvents = [];
        foreach (Activity listRunStepsSpan in spans)
        {
            runStepsSpanEvents.AddRange(listRunStepsSpan.Events);
            Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listRunStepsSpan, expectedListRunStepsAttributes));
        }

        Assert.Greater(runStepsSpanEvents.Count(), 5, "Deep research typically have more than 5 steps.");
        List<(string, Dictionary<string, object>)> expectedListRunStepsEvents =
        [
            ("gen_ai.run_step.message_creation", new Dictionary<string, object>
                {
                    { "gen_ai.system", "az.ai.agents" },
                    { "gen_ai.thread.id", "*" },
                    { "gen_ai.message.id", "*" },
                    { "gen_ai.agent.id", "*" },
                    { "gen_ai.thread.run.id", "*" },
                    { "gen_ai.run_step.status", "completed" },
                    { "gen_ai.run_step.start.timestamp", "*" },
                    { "gen_ai.run_step.end.timestamp", "*" },
                    { "gen_ai.usage.input_tokens", "0" },
                    { "gen_ai.usage.output_tokens", "0" }
                }
            ),
            ("gen_ai.run_step.tool_calls", new Dictionary<string, object>
                {
                    { "gen_ai.system", "az.ai.agents" },
                    { "gen_ai.thread.id", "*" },
                    { "gen_ai.agent.id", "*" },
                    { "gen_ai.thread.run.id", "*" },
                    { "gen_ai.run_step.status", "completed" },
                    { "gen_ai.run_step.start.timestamp", "*" },
                    { "gen_ai.run_step.end.timestamp", "*" },
                    { "gen_ai.usage.input_tokens", "+" },
                    { "gen_ai.usage.output_tokens", "+" },
                    { "gen_ai.event.content", "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"deep_research\",\"details\":{\"input\":\"*\"}}]}"}
                }
            )
        ];
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(runStepsSpanEvents, expectedListRunStepsEvents, allowAdditionalEvents: true));
    }

    [RecordedTest]
    public async Task TestAgentChatWithFunctionToolTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        // Define the function tool
        FunctionToolDefinition getCurrentWeatherAtLocationTool = new FunctionToolDefinition(
            name: "getCurrentWeatherAtLocation",
            description: "Gets the current weather at a provided location.",
            parameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Location = new
                        {
                            Type = "string",
                            Description = "The city and state, e.g. San Francisco, CA",
                        },
                    },
                    Required = new[] { "location" },
                },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));

        // Create agent with toolset
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
            instructions: "You are a weather bot. Use the provided function to help answer questions about weather.",
            tools: new[] { getCurrentWeatherAtLocationTool });

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the weather in Seattle.");

        ThreadRun run = await client.Runs.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as J. Doe. The user has a premium account.");

        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress || run.Status == RunStatus.RequiresAction)
        {
            await Task.Delay(1000);
            run = await client.Runs.GetRunAsync(thread.Id, run.Id);

            if (run.Status == RunStatus.RequiresAction && run.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
            {
                var toolOutputs = new List<ToolOutput>();
                foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
                {
                    if (toolCall is RequiredFunctionToolCall functionToolCall)
                    {
                        var argumentsJson = JsonDocument.Parse(functionToolCall.Arguments);
                        var locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                        toolOutputs.Add(new ToolOutput(toolCall.Id, "{\"weather\": \"Sunny\"}"));
                    }
                }
                run = await client.Runs.SubmitToolOutputsToRunAsync(run, toolOutputs);
            }
        }

        // Enumerate messages and run steps to trigger spans
        await foreach (var messageInList in client.Messages.GetMessagesAsync(thread.Id))
        {
            _ = messageInList;
        }

        await foreach (var step in client.Runs.GetRunStepsAsync(thread.Id, run.Id))
        {
            _ = step;
        }

        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent SDK Test Agent - Functions");
        Assert.IsNotNull(createAgentSpan);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", "SDK Test Agent - Functions" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", "\"\"" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", "{\"role\": \"user\"}" }
            })
        };

        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify submit_tool_outputs span explicitly
        var submitToolOutputsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "submit_tool_outputs");
        Assert.IsNotNull(submitToolOutputsSpan);
        var expectedSubmitToolOutputsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "submit_tool_outputs" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.response.model", modelDeploymentName }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(submitToolOutputsSpan, expectedSubmitToolOutputsAttributes));

        var expectedSubmitToolOutputsEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.tool.message", new Dictionary<string, object>
            {
                { "gen_ai.event.content", "{\"content\":\"\",\"id\":\"*\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(submitToolOutputsSpan, expectedSubmitToolOutputsEvents));

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        Assert.IsNotNull(getThreadRunSpan);
        var expectedGetThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "get_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.thread.run.status", "completed" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(getThreadRunSpan, expectedGetThreadRunAttributes));

        // Verify list_messages span explicitly
        var listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        Assert.IsNotNull(listMessagesSpan);

        var expectedListMessagesAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_messages" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listMessagesSpan, expectedListMessagesAttributes));

        var expectedListMessagesEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"role\": \"user\"}" }
            }),
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", "{\"role\": \"assistant\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(listMessagesSpan, expectedListMessagesEvents));

        // Verify list_run_steps span
        var listRunStepsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_run_steps");
        Assert.IsNotNull(listRunStepsSpan);
        var expectedListRunStepsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_run_steps" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listRunStepsSpan, expectedListRunStepsAttributes));

        var expectedListRunStepsEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.run_step.message_creation", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.run_step.status", "completed" },
                { "gen_ai.run_step.start.timestamp", "+" },
                { "gen_ai.run_step.end.timestamp", "+" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" }
            }),
            ("gen_ai.run_step.tool_calls", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.run_step.status", "completed" },
                { "gen_ai.run_step.start.timestamp", "+" },
                { "gen_ai.run_step.end.timestamp", "+" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.event.content", "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"function\"}]}"}
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(listRunStepsSpan, expectedListRunStepsEvents));
    }

    [RecordedTest]
    public async Task TestAgentStreamingWithTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        // Create agent
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Test Agent",
            instructions: "You are a helpful assistant.");

        // Create thread
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
        var threadId = thread.Id;

        // Create message
        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Tell me a joke.");

        // Start streaming run
        var stream = client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id);
        await foreach (StreamingUpdate streamingUpdate in stream)
        {
            _ = streamingUpdate;
        }

        // Cleanup
        await client.Threads.DeleteThreadAsync(threadId: threadId);
        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent Test Agent");
        Assert.IsNotNull(createAgentSpan);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", "Test Agent" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", "{\"content\":\"You are a helpful assistant.\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        Assert.IsNotNull(createThreadSpan);
        var expectedCreateThreadAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_thread" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createThreadSpan, expectedCreateThreadAttributes));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", "{\"content\":\"Tell me a joke.\",\"role\":\"user\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify process_thread_run span
        var processThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "process_thread_run");
        Assert.IsNotNull(processThreadRunSpan);
        var expectedProcessThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "process_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.run.status", "completed" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(processThreadRunSpan, expectedProcessThreadRunAttributes));

        var expectedProcessThreadRunEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.status", "completed" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.event.content", "{\"content\":{\"text\":{\"value\":\"*\"}},\"role\":\"assistant\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(processThreadRunSpan, expectedProcessThreadRunEvents));
    }

    [RecordedTest]
    public async Task TestAgentStreamingWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        // Create agent
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Test Agent",
            instructions: "You are a helpful assistant.");

        // Create thread
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
        var threadId = thread.Id;

        // Create message
        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Tell me a joke.");

        // Start streaming run
        var stream = client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id);
        await foreach (StreamingUpdate streamingUpdate in stream)
        {
            _ = streamingUpdate;
        }

        // Cleanup
        await client.Threads.DeleteThreadAsync(threadId: threadId);
        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent Test Agent");
        Assert.IsNotNull(createAgentSpan);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", "Test Agent" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", "\"\"" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        Assert.IsNotNull(createThreadSpan);
        var expectedCreateThreadAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_thread" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createThreadSpan, expectedCreateThreadAttributes));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", "{\"role\": \"user\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify process_thread_run span
        var processThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "process_thread_run");
        Assert.IsNotNull(processThreadRunSpan);
        var expectedProcessThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "process_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.run.status", "completed" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(processThreadRunSpan, expectedProcessThreadRunAttributes));

        var expectedProcessThreadRunEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.status", "completed" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.event.content", "{\"role\": \"assistant\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(processThreadRunSpan, expectedProcessThreadRunEvents));
    }

    [RecordedTest]
    public async Task TestAgentStreamingWithFunctionToolTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        // Define the function tool
        FunctionToolDefinition getCurrentWeatherAtLocationTool = new FunctionToolDefinition(
            name: "getCurrentWeatherAtLocation",
            description: "Gets the current weather at a provided location.",
            parameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Location = new
                        {
                            Type = "string",
                            Description = "The city and state, e.g. San Francisco, CA",
                        },
                    },
                    Required = new[] { "location" },
                },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));

        ToolOutput GetResolvedToolOutput(string functionName, string toolCallId, string functionArguments)
        {
            if (functionName == getCurrentWeatherAtLocationTool.Name)
            {
                using JsonDocument argumentsJson = JsonDocument.Parse(functionArguments);
                string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                return new ToolOutput(toolCallId, JsonSerializer.Serialize(new { temperature = "70f" }));
            }
            return null;
        }

        // Create agent with toolset
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
            instructions: "You are a weather bot. Use the provided function to help answer questions about weather.",
            tools: new[] { getCurrentWeatherAtLocationTool });

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
        var threadId = thread.Id;

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the weather in Seattle?");

        List<ToolOutput> toolOutputs = new List<ToolOutput>();
        ThreadRun streamRun = null;
        var stream = client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id);

        do
        {
            toolOutputs.Clear();
            await foreach (StreamingUpdate streamingUpdate in stream)
            {
                if (streamingUpdate is RequiredActionUpdate submitToolOutputsUpdate)
                {
                    RequiredActionUpdate newActionUpdate = submitToolOutputsUpdate;
                    toolOutputs.Add(
                        GetResolvedToolOutput(
                            newActionUpdate.FunctionName,
                            newActionUpdate.ToolCallId,
                            newActionUpdate.FunctionArguments
                    ));
                    streamRun = submitToolOutputsUpdate.Value;
                }
            }
            if (toolOutputs.Count > 0)
            {
                stream = client.Runs.SubmitToolOutputsToStreamAsync(streamRun, toolOutputs);
            }
        }
        while (toolOutputs.Count > 0);

        await client.Threads.DeleteThreadAsync(threadId: threadId);
        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent SDK Test Agent - Functions");
        Assert.IsNotNull(createAgentSpan);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", "SDK Test Agent - Functions" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", "{\"content\":\"You are a weather bot. Use the provided function to help answer questions about weather.\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        Assert.IsNotNull(createThreadSpan);
        var expectedCreateThreadAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_thread" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createThreadSpan, expectedCreateThreadAttributes));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", "{\"content\":\"What is the weather in Seattle?\",\"role\":\"user\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify process_thread_run span
        var processThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "process_thread_run");
        Assert.IsNotNull(processThreadRunSpan);
        var expectedProcessThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "process_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.run.status", "requires_action" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(processThreadRunSpan, expectedProcessThreadRunAttributes));

        // Verify submit_tool_outputs span
        var submitToolOutputsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "submit_tool_outputs");
        Assert.IsNotNull(submitToolOutputsSpan);
        var expectedSubmitToolOutputsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "submit_tool_outputs" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(submitToolOutputsSpan, expectedSubmitToolOutputsAttributes));

        var expectedSubmitToolOutputsEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.tool.message", new Dictionary<string, object>
            {
                { "gen_ai.event.content", "{\"content\":\"{\\\"temperature\\\":\\\"70f\\\"}\",\"id\":\"*\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(submitToolOutputsSpan, expectedSubmitToolOutputsEvents));

        // Verify process_thread_run span after tool submission
        var processThreadRunSpanAfterTool = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "process_thread_run");
        Assert.IsNotNull(processThreadRunSpanAfterTool);
        var expectedProcessThreadRunAttributesAfterTool = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "process_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.run.status", "completed" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(processThreadRunSpanAfterTool, expectedProcessThreadRunAttributesAfterTool));

        var expectedProcessThreadRunEventsAfterTool = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.status", "completed" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.event.content", "{\"content\":{\"text\":{\"value\":\"*\"}},\"role\":\"assistant\"}" }
            }),
            ("gen_ai.tool.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.run_step.status", "completed" },
                { "gen_ai.run_step.start.timestamp", "+" },
                { "gen_ai.run_step.end.timestamp", "+" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.event.content", "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"function\",\"function\":{\"name\":\"getCurrentWeatherAtLocation\",\"arguments\":{\"location\":\"Seattle, WA\"}}}]}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(processThreadRunSpanAfterTool, expectedProcessThreadRunEventsAfterTool));
    }

    [RecordedTest]
    public async Task TestAgentStreamingWithFunctionToolTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        var type = typeof(Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryScope);
        var methodInfo = type.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        methodInfo?.Invoke(null, null);

        var client = GetClient();
        var modelDeploymentName = GetModelDeploymentName();

        // Define the function tool
        FunctionToolDefinition getCurrentWeatherAtLocationTool = new FunctionToolDefinition(
            name: "getCurrentWeatherAtLocation",
            description: "Gets the current weather at a provided location.",
            parameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Location = new
                        {
                            Type = "string",
                            Description = "The city and state, e.g. San Francisco, CA",
                        },
                    },
                    Required = new[] { "location" },
                },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));

        ToolOutput GetResolvedToolOutput(string functionName, string toolCallId, string functionArguments)
        {
            if (functionName == getCurrentWeatherAtLocationTool.Name)
            {
                using JsonDocument argumentsJson = JsonDocument.Parse(functionArguments);
                string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                return new ToolOutput(toolCallId, JsonSerializer.Serialize(new { temperature = "70f" }));
            }
            return null;
        }

        // Create agent with toolset
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
            instructions: "You are a weather bot. Use the provided function to help answer questions about weather.",
            tools: new[] { getCurrentWeatherAtLocationTool });

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
        var threadId = thread.Id;

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the weather in Seattle?");

        List<ToolOutput> toolOutputs = new List<ToolOutput>();
        ThreadRun streamRun = null;
        var stream = client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id);

        do
        {
            toolOutputs.Clear();
            await foreach (StreamingUpdate streamingUpdate in stream)
            {
                if (streamingUpdate is RequiredActionUpdate submitToolOutputsUpdate)
                {
                    RequiredActionUpdate newActionUpdate = submitToolOutputsUpdate;
                    toolOutputs.Add(
                        GetResolvedToolOutput(
                            newActionUpdate.FunctionName,
                            newActionUpdate.ToolCallId,
                            newActionUpdate.FunctionArguments
                    ));
                    streamRun = submitToolOutputsUpdate.Value;
                }
            }
            if (toolOutputs.Count > 0)
            {
                stream = client.Runs.SubmitToolOutputsToStreamAsync(streamRun, toolOutputs);
            }
        }
        while (toolOutputs.Count > 0);

        await client.Threads.DeleteThreadAsync(threadId: threadId);
        await client.Administration.DeleteAgentAsync(agent.Id);

        // Force flush spans
        _exporter.ForceFlush();

        // Verify create_agent span
        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent SDK Test Agent - Functions");
        Assert.IsNotNull(createAgentSpan);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.agent.name", "SDK Test Agent - Functions" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));

        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", "\"\"" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        Assert.IsNotNull(createThreadSpan);
        var expectedCreateThreadAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_thread" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createThreadSpan, expectedCreateThreadAttributes));

        // Verify create_message span
        var createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        Assert.IsNotNull(createMessageSpan);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_message" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageSpan, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", "{\"role\": \"user\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageSpan, expectedCreateMessageEvents));

        // Verify process_thread_run span
        var processThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "process_thread_run");
        Assert.IsNotNull(processThreadRunSpan);
        var expectedProcessThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "process_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.run.status", "requires_action" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(processThreadRunSpan, expectedProcessThreadRunAttributes));

        // Verify submit_tool_outputs span
        var submitToolOutputsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "submit_tool_outputs");
        Assert.IsNotNull(submitToolOutputsSpan);
        var expectedSubmitToolOutputsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "submit_tool_outputs" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(submitToolOutputsSpan, expectedSubmitToolOutputsAttributes));

        var expectedSubmitToolOutputsEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.tool.message", new Dictionary<string, object>
            {
                { "gen_ai.event.content", "{\"content\":\"\",\"id\":\"*\"}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(submitToolOutputsSpan, expectedSubmitToolOutputsEvents));

        // Verify process_thread_run span after tool submission
        var processThreadRunSpanAfterTool = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "process_thread_run");
        Assert.IsNotNull(processThreadRunSpanAfterTool);
        var expectedProcessThreadRunAttributesAfterTool = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "process_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.response.model", modelDeploymentName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.run.status", "completed" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(processThreadRunSpanAfterTool, expectedProcessThreadRunAttributesAfterTool));

        var expectedProcessThreadRunEventsAfterTool = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.assistant.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.message.status", "completed" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.event.content", "{\"role\":\"assistant\"}" }
            }),
            ("gen_ai.tool.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.run_step.status", "completed" },
                { "gen_ai.run_step.start.timestamp", "+" },
                { "gen_ai.run_step.end.timestamp", "+" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.event.content", "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"function\"}]}" }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(processThreadRunSpanAfterTool, expectedProcessThreadRunEventsAfterTool));
    }
}
