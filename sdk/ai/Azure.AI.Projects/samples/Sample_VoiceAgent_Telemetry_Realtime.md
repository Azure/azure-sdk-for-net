# Trace Voice Agent realtime sessions

Trace a Voice Agent text conversation with OpenTelemetry and print connection logs without
message payloads. The same setup works for audio and function calls.

## Prerequisites

- Follow the [Realtime prerequisites and authentication guidance](Sample_VoiceAgent.md#prerequisites).
- Also reference `OpenTelemetry.Exporter.Console`.

The [complete sample](../tests/Samples/VoiceAgent/Sample_VoiceAgent_Telemetry.cs) includes the
required imports and setup.

## Configure tracing and logging

Enable tracing before creating the client. Keep message-content recording disabled to avoid
exporting conversation text. If your application sets the corresponding `AppContext` switches,
those values take precedence over these environment variables.

```C# Snippet:Sample_VoiceAgent_Telemetry_Setup
Environment.SetEnvironmentVariable("AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING", "true");
Environment.SetEnvironmentVariable("OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT", "false");

const string applicationSourceName = "VoiceAgentTelemetrySample";
using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Azure.AI.Projects.*")
    .AddSource(applicationSourceName)
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("VoiceAgentTelemetrySample"))
    .AddConsoleExporter()
    .Build();
using ActivitySource applicationSource = new(applicationSourceName);
```

To print Voice Agent connection and session logs, add this listener. It logs correlation IDs,
not message payloads.

```C# Snippet:Sample_VoiceAgent_Telemetry_Logs
using AzureEventSourceListener sdkLogs = new((eventData, message) =>
{
    if (eventData.EventSource.Name == "Azure-AI-Projects-Realtime")
    {
        Console.WriteLine($"[SDK] {message}");
    }
}, EventLevel.Verbose);
```

## Run a stored realtime text exchange

Run this code in an asynchronous method. It saves a text conversation, reads it back, and deletes
the conversation and temporary agent. It prints event types and HTTP statuses, not conversation text.

```C# Snippet:Sample_VoiceAgent_Telemetry_Realtime
string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
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
```

## Inspect correlation and privacy

The console exporter shows the session, connection, and response spans in one application trace:

```text
voice_agent.sample.realtime
  create_agent
  voice_agents.realtime.session
    voice_agents.realtime.connect
    invoke_agent
  BetaVoiceAgentsConversations.DeleteAgentConversation
```

The client spans come from `Azure.AI.Projects.ProjectsRealtimeClient`. `invoke_agent` records
response status, model, response/conversation IDs, token usage, and time to first output when
available. Session spans include audio byte counts, formats, and sample rates. Realtime spans
use `gen_ai.agent.type=voice`. Lifecycle events are named `voice_agents.session.created`,
`voice_agents.session.updated`, and `voice_agents.session.update`.
Conversation deletion keeps its normal SDK diagnostic scope.

Keep reading updates to observe events. Dispose the session before the tracer provider so all
spans can finish and be exported.

Realtime instrumentation does not record raw audio, credentials, authentication headers, query
strings, exception messages, or close reasons. Enable content recording only if you intend to
export potentially sensitive transcripts and tool arguments/results. Captured content is bounded.
Use `AIProjectClientOptions.EnableDistributedTracing = false` to disable tracing, and the client's
logging options to control diagnostic logs.

## Run the repository sample

Set `CLIENTMODEL_TEST_MODE=Live`, then run from the repository root:

```dotnetcli
dotnet test sdk\ai\Azure.AI.Projects\tests\Azure.AI.Projects.Tests.csproj -f net8.0 --filter "FullyQualifiedName~Sample_VoiceAgent_Telemetry&Name~VoiceAgentRealtimeTelemetryAsync"
```

This calls the real service and may incur charges. It temporarily persists a text conversation
and deletes it during cleanup. It does not implement WebRTC peer/media handling.
