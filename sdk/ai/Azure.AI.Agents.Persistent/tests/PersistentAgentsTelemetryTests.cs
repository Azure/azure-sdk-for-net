// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Agents.Persistent.Tests.Utilities;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

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
        do
        {
            await WaitMayBe(500);
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
            await WaitMayBe();
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

        run = await WaitForRun(client, run);

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
        CheckCreateAgentEvent(
            createAgentSpan: createAgentSpan,
            modelName: modelDeploymentName,
            agentName: "my-agent",
            content: "{\"content\": \"You are helpful agent\"}");

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        CheckCreateThreadSpan(
            createThreadSpan: createThreadSpan,
            modelName: modelDeploymentName
        );

        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: "{\"content\": \"Hello, tell me a joke\", \"role\": \"user\"}"
        );

        // Verify start_thread_run span
        var startThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "start_thread_run");
        CheckThreadRunAttribute(threadRunActivity: startThreadRunSpan, modelName: modelDeploymentName, operation: "start_thread_run", status: "queued");

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        CheckThreadRunAttribute(threadRunActivity: getThreadRunSpan, modelName: modelDeploymentName);

        // Verify list_messages span
        Activity listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        CheckListMessages(
            listActivity: listMessagesSpan,
            contents: ["{\"content\": {\"text\": {\"value\": \"*\"}}, \"role\": \"assistant\"}", "{\"content\": {\"text\": {\"value\": \"Hello, tell me a joke\"}}, \"role\": \"user\"}"],
            roles: ["gen_ai.assistant.message", "gen_ai.user.message"]
        );
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
        run = await WaitForRun(client, run);

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
        CheckCreateAgentEvent(
            createAgentSpan: createAgentSpan,
            modelName: modelDeploymentName,
            agentName: "my-agent",
            content: "\"\""
        );

        // Verify create_thread span
        Activity createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        CheckCreateThreadSpan(
            createThreadSpan: createThreadSpan,
            modelName: modelDeploymentName
        );
        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: "{\"role\": \"user\"}"
        );

        // Verify start_thread_run span
        var startThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "start_thread_run");
        CheckThreadRunAttribute(threadRunActivity: startThreadRunSpan, modelName: modelDeploymentName, operation: "start_thread_run");

        // Verify get_thread_run span
        Activity getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        CheckThreadRunAttribute(threadRunActivity: getThreadRunSpan, modelName: modelDeploymentName);

        // Verify list_messages span
        Activity listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        CheckListMessages(
            listActivity: listMessagesSpan,
            contents: ["{\"role\": \"assistant\"}", "{\"role\": \"user\"}"],
            roles: ["gen_ai.assistant.message", "gen_ai.user.message"]
        );
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
            await WaitMayBe();
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
                run = await client.Runs.SubmitToolOutputsToRunAsync(run, toolOutputs, toolApprovals: null);
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
        Activity createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent SDK Test Agent - Functions");

        CheckCreateAgentEvent(
            createAgentSpan: createAgentSpan,
            modelName: modelDeploymentName,
            agentName: "SDK Test Agent - Functions",
            content: "{\"content\": \"You are a weather bot. Use the provided function to help answer questions about weather.\"}"
        );

        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: "{\"content\": \"What is the weather in Seattle.\", \"role\": \"user\"}"
        );

        // Verify submit_tool_outputs span explicitly
        Activity submitToolOutputsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "submit_tool_outputs");
        CheckSubmitToolOutputSpan(
            submitActivity: submitToolOutputsSpan,
            content: "{\"content\":\"{\\\"weather\\\": \\\"Sunny\\\"}\",\"id\":\"*\"}"
        );

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        CheckThreadRunAttribute(threadRunActivity: getThreadRunSpan, modelName: modelDeploymentName);

        // Verify list_messages span explicitly
        Activity listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        CheckListMessages(
            listActivity: listMessagesSpan,
            contents: ["{\"content\":{\"text\":{\"value\":\"What is the weather in Seattle.\"}},\"role\":\"user\"}", "{\"content\":{\"text\":{\"value\":\"*\"}},\"role\":\"assistant\"}"],
            roles: ["gen_ai.user.message", "gen_ai.assistant.message"]
        );

        // Verify list_run_steps span
        var listRunStepsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_run_steps");
        CheckRunSteps(
            runStepActivity: listRunStepsSpan,
            contents: [null, "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"function\",\"function\":{\"name\":\"getCurrentWeatherAtLocation\",\"arguments\":{\"location\":\"Seattle, WA\"}}}]}"],
            events: ["gen_ai.run_step.message_creation", "gen_ai.run_step.tool_calls"]);
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
        Activity createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent SDK Test Agent - DeepResearch");
        CheckCreateAgentEvent(
            createAgentSpan: createAgentSpan,
            modelName: modelDeploymentName,
            agentName: agentName,
            content: $"{{\"content\": \"{system_prompt}\"}}"
        );

        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: $"{{\"content\":\"{prompt}\",\"role\":\"user\"}}"
        );

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        CheckThreadRunAttribute(threadRunActivity: getThreadRunSpan, modelName: modelDeploymentName);

        // Verify list_messages span explicitly
        Activity listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        CheckListMessages(
            listActivity: listMessagesSpan,
            contents: [$"{{\"content\":{{\"text\":{{\"value\":\"{prompt}\"}}}},\"role\":\"user\"}}", "{\"content\":{\"text\":{\"value\":\"*\",\"annotations\":\"*\"}},\"role\":\"assistant\"}"],
            roles: ["gen_ai.user.message", "gen_ai.assistant.message"]
        );

        // Verify list_run_steps span
        var listRunStepsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_run_steps");
        CheckRunSteps(
            runStepActivity: listRunStepsSpan,
            contents: [null, "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"bing_custom_search\",\"details\":{\"requesturl\":\"*\",\"response_metadata\":\"*\"}}]}"],
            events: ["gen_ai.run_step.message_creation", "gen_ai.run_step.tool_calls"]);
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
        CheckCreateAgentEvent(
            createAgentSpan: createAgentSpan,
            modelName: modelDeploymentName,
            agentName: "SDK Test Agent - DeepResearch",
            content: $"{{\"content\": \"{system_prompt}\"}}"
        );

        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: $"{{\"content\":\"{prompt}\",\"role\":\"user\"}}"
        );

        // Verify get_thread_run span
        var getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        CheckThreadRunAttribute(threadRunActivity: getThreadRunSpan, modelName: modelDeploymentName);

        // Verify list_messages span explicitly
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
            await WaitMayBe();
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
                run = await client.Runs.SubmitToolOutputsToRunAsync(run, toolOutputs, toolApprovals: null);
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
        CheckCreateAgentEvent(
            createAgentSpan: createAgentSpan,
            modelName: modelDeploymentName,
            agentName: "SDK Test Agent - Functions",
            content: "\"\""
        );

        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: "{\"role\": \"user\"}"
        );

        // Verify submit_tool_outputs span explicitly
        Activity submitToolOutputsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "submit_tool_outputs");
        CheckSubmitToolOutputSpan(
            submitActivity: submitToolOutputsSpan,
            content: "{\"content\":\"\",\"id\":\"*\"}"
        );

        // Verify get_thread_run span
        Activity getThreadRunSpan = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "get_thread_run");
        CheckThreadRunAttribute(threadRunActivity: getThreadRunSpan, modelName: modelDeploymentName);

        // Verify list_messages span explicitly
        Activity listMessagesSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "list_messages");
        CheckListMessages(
            listActivity: listMessagesSpan,
            contents: ["{\"role\": \"user\"}", "{\"role\": \"assistant\"}"],
            roles: ["gen_ai.user.message", "gen_ai.assistant.message"]
        );
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
        CheckCreateAgentEvent(
            createAgentSpan: createAgentSpan,
            modelName: modelDeploymentName,
            agentName: "Test Agent",
            content: "{\"content\":\"You are a helpful assistant.\"}"
        );

        // Verify create_thread span
        Activity createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        CheckCreateThreadSpan(
            createThreadSpan: createThreadSpan,
            modelName: modelDeploymentName
        );

        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: "{\"content\":\"Tell me a joke.\",\"role\":\"user\"}"
        );

        // Verify process_thread_run span
        Activity processThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "process_thread_run");
        CheckProcessThreadRun(
            threadRun: processThreadRunSpan,
            modelName: modelDeploymentName,
            contents: ["{\"content\":{\"text\":{\"value\":\"*\"}},\"role\":\"assistant\"}"],
            roles: ["gen_ai.assistant.message"]
        );
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
        CheckCreateAgentEvent(
            createAgentSpan: createAgentSpan,
            modelName: modelDeploymentName,
            agentName: "Test Agent",
            content: "\"\""
        );

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        CheckCreateThreadSpan(
            createThreadSpan: createThreadSpan,
            modelName: modelDeploymentName
        );
        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: "{\"role\": \"user\"}"
        );

        // Verify process_thread_run span
        Activity processThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "process_thread_run");
        CheckProcessThreadRun(
            threadRun: processThreadRunSpan,
            modelName: modelDeploymentName,
            contents: ["{\"role\": \"assistant\"}"],
            roles: ["gen_ai.assistant.message"]
        );
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
        CheckCreateAgentEvent(
            createAgentSpan: createAgentSpan,
            modelName: modelDeploymentName,
            agentName: "SDK Test Agent - Functions",
            content: "{\"content\":\"You are a weather bot. Use the provided function to help answer questions about weather.\"}"
        );

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        //Assert.IsNotNull(createThreadSpan);
        CheckCreateThreadSpan(
            createThreadSpan: createThreadSpan,
            modelName: modelDeploymentName,
            status: RunStatus.RequiresAction
        );

        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: "{\"content\":\"What is the weather in Seattle?\",\"role\":\"user\"}"
        );

        // Verify process_thread_run span
        Activity processThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "process_thread_run");
        CheckCreateThreadSpan(
            createThreadSpan: processThreadRunSpan,
            modelName: modelDeploymentName,
            status: RunStatus.RequiresAction,
            operation: "process_thread_run"
        );

        // Verify submit_tool_outputs span
        Activity submitToolOutputsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "submit_tool_outputs");
        CheckSubmitToolOutputSpan(
            submitActivity: submitToolOutputsSpan,
            content: "{\"content\":\"{\\\"temperature\\\":\\\"70f\\\"}\",\"id\":\"*\"}"
        );

        // Verify process_thread_run span after tool submission
        Activity processThreadRunSpanAfterTool = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "process_thread_run");
        CheckProcessThreadRun(
            threadRun: processThreadRunSpanAfterTool,
            modelName: modelDeploymentName,
            contents: [
                "{\"content\":{\"text\":{\"value\":\"*\"}},\"role\":\"assistant\"}",
                "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"function\",\"function\":{\"name\":\"getCurrentWeatherAtLocation\",\"arguments\":{\"location\":\"Seattle, WA\"}}}]}"],
            roles: ["gen_ai.assistant.message", "gen_ai.tool.message"]
        );
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
            tools: [ getCurrentWeatherAtLocationTool ]);

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
        var threadId = thread.Id;

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the weather in Seattle?");

        List<ToolOutput> toolOutputs = [];
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
        Activity createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_agent SDK Test Agent - Functions");
        CheckCreateAgentEvent(createAgentSpan, modelDeploymentName, "SDK Test Agent - Functions", "\"\"");

        // Verify create_thread span
        var createThreadSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_thread");
        CheckCreateThreadSpan(
            createThreadSpan:createThreadSpan,
            modelName:modelDeploymentName
        );

        // Verify create_message span
        Activity createMessageSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "create_message");
        CheckCreateMessageSpan(
            createMessageActivity: createMessageSpan,
            content: "{\"role\": \"user\"}"
        );

        // Verify process_thread_run span
        var processThreadRunSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "process_thread_run");
        CheckCreateThreadSpan(
            createThreadSpan: processThreadRunSpan,
            modelName: modelDeploymentName,
            status: RunStatus.RequiresAction,
            operation: "process_thread_run"
        );

        // Verify submit_tool_outputs span
        Activity submitToolOutputsSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "submit_tool_outputs");
        CheckSubmitToolOutputSpan(
            submitActivity: submitToolOutputsSpan,
            content: "{\"content\":\"\",\"id\":\"*\"}"
        );

        // Verify process_thread_run span after tool submission
        Activity processThreadRunSpanAfterTool = _exporter.GetExportedActivities().LastOrDefault(s => s.DisplayName == "process_thread_run");
        CheckProcessThreadRun(
            threadRun: processThreadRunSpanAfterTool,
            modelName: modelDeploymentName,
            contents: ["{\"role\":\"assistant\"}", "{\"tool_calls\":[{\"id\":\"*\",\"type\":\"function\"}]}"],
            roles: ["gen_ai.assistant.message", "gen_ai.tool.message"]
        );
    }

    #region Helpers
    private void CheckCreateAgentEvent(Activity createAgentSpan, string modelName, string agentName, string content)
    {
        Assert.IsNotNull(createAgentSpan);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelName },
            { "gen_ai.agent.name", agentName },
            { "gen_ai.agent.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes));
        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", content }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents));
    }

    private void CheckCreateThreadSpan(Activity createThreadSpan, string modelName, RunStatus? status = null, string operation="create_thread")
    {
        Assert.IsNotNull(createThreadSpan);
        var expectedProcessThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", operation },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
        };
        if (operation == "process_thread_run")
        {
            expectedProcessThreadRunAttributes["gen_ai.agent.id"] = "*";
            expectedProcessThreadRunAttributes["gen_ai.response.model"] = modelName;
            expectedProcessThreadRunAttributes["gen_ai.thread.run.id"] = "*";
            expectedProcessThreadRunAttributes["gen_ai.thread.run.status"] = status.Value.ToString();
        }
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createThreadSpan, expectedProcessThreadRunAttributes));
    }

    private void CheckCreateMessageSpan(Activity createMessageActivity, string content)
    {
        Assert.IsNotNull(createMessageActivity);
        var expectedCreateMessageAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "server.address", "*" },
            { "gen_ai.operation.name", "create_message" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(createMessageActivity, expectedCreateMessageAttributes));

        var expectedCreateMessageEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.user.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.event.content", content }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(createMessageActivity, expectedCreateMessageEvents));
    }

    private void CheckSubmitToolOutputSpan(Activity submitActivity, string content)
    {
        Assert.IsNotNull(submitActivity);
        var expectedSubmitToolOutputsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "submit_tool_outputs" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(submitActivity, expectedSubmitToolOutputsAttributes));

        var expectedSubmitToolOutputsEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.tool.message", new Dictionary<string, object>
            {
                { "gen_ai.event.content", content }
            })
        };
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(submitActivity, expectedSubmitToolOutputsEvents));
    }

    private void CheckListMessages(Activity listActivity, string[] contents, string[] roles)
    {
        Assert.That(contents.Length == roles.Length, "The list of contents must have the same length as the list of roles." );
        Assert.IsNotNull(listActivity);
        var expectedListMessagesAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_messages" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(listActivity, expectedListMessagesAttributes));

        List<(string, Dictionary<string, object>)> expectedListMessagesEvents = [];
        for (int i = 0; i < contents.Length; i++)
        {
            var newData = new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.message.id", "*" },
                { "gen_ai.event.content", contents[i] }
            };
            if (string.Equals(roles[i], "gen_ai.assistant.message"))
            {
                newData["gen_ai.agent.id"] = "*";
                newData["gen_ai.thread.run.id"] = "*";
            }
            expectedListMessagesEvents.Add((roles[i], newData));
        }
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(listActivity, expectedListMessagesEvents));
    }

    private void CheckProcessThreadRun(Activity threadRun, string modelName, string[] contents, string[] roles)
    {
        Assert.That(contents.Length == roles.Length, "The list of contents must have the same length as the list of roles.");
        Assert.IsNotNull(threadRun);
        var expectedProcessThreadRunAttributesAfterTool = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "process_thread_run" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.response.model", modelName },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.run.status", "completed" },
            { "gen_ai.message.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(threadRun, expectedProcessThreadRunAttributesAfterTool));
        List<(string, Dictionary<string, object>)> expectedProcessThreadRunEventsAfterTool = [];
        for (int i=0; i<contents.Length; i++)
        {
            var newData = new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.event.content", contents[i] },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
            };
            if (string.Equals(roles[i], "gen_ai.tool.message"))
            {
                newData["gen_ai.run_step.status"] = "completed";
                newData["gen_ai.run_step.start.timestamp"] = "+";
                newData["gen_ai.run_step.end.timestamp"] = "+";
            }
            else
            {
                newData["gen_ai.message.id"] = "*";
                newData["gen_ai.message.status"] = "completed";
            }
            expectedProcessThreadRunEventsAfterTool.Add((roles[i], newData));
        }
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(threadRun, expectedProcessThreadRunEventsAfterTool));
    }

    private void CheckRunSteps(Activity runStepActivity, string[] contents, string[] events)
    {
        Assert.That(contents.Length == events.Length, "The list of contents must have the same length as the list of events.");
        Assert.IsNotNull(runStepActivity);
        var expectedListRunStepsAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "list_run_steps" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.thread.run.id", "*" }
        };
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(runStepActivity, expectedListRunStepsAttributes));

        List<(string, Dictionary<string, object>)> expectedListRunStepsEvents = [];
        for (int i=0; i<contents.Length; i++)
        {
            Dictionary<string, object> data = new()
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.thread.id", "*" },
                { "gen_ai.agent.id", "*" },
                { "gen_ai.thread.run.id", "*" },
                { "gen_ai.run_step.status", "completed" },
                { "gen_ai.run_step.start.timestamp", "+" },
                { "gen_ai.run_step.end.timestamp", "+" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" }
            };
            if (contents[i] is not null)
            {
                data["gen_ai.event.content"] = contents[i];
            }
            if (string.Equals(events[i], "gen_ai.run_step.message_creation"))
            {
                data["gen_ai.message.id"] = "*";
            }
            expectedListRunStepsEvents.Add((events[i], data));
        }
        Assert.IsTrue(_traceVerifier.CheckSpanEvents(runStepActivity, expectedListRunStepsEvents));
    }

    public void CheckThreadRunAttribute(Activity threadRunActivity, string modelName, string operation= "get_thread_run", string status=default)
    {
        Assert.IsNotNull(threadRunActivity);
        var expectedGetThreadRunAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", operation },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.thread.run.id", "*" },
            { "gen_ai.thread.id", "*" },
            { "gen_ai.response.model", modelName },
            { "gen_ai.agent.id", "*" },
        };
        if (operation == "get_thread_run")
        {
            expectedGetThreadRunAttributes["gen_ai.usage.input_tokens"] = "+";
            expectedGetThreadRunAttributes["gen_ai.usage.output_tokens"] = "+";
            expectedGetThreadRunAttributes["gen_ai.thread.run.status"] = "completed";
        }
        if (status is not null)
        {
            expectedGetThreadRunAttributes["gen_ai.thread.run.status"] = status;
        }
        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(threadRunActivity, expectedGetThreadRunAttributes));
    }
    private async Task WaitMayBe(int timeout = 1000)
    {
        if (Mode != RecordedTestMode.Playback)
            await Task.Delay(timeout);
    }
    #endregion
}
