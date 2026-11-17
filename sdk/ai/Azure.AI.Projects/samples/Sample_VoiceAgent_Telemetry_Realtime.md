# Trace Voice Agent realtime sessions

This runnable sample uses the existing Foundry GenAI tracing setting and an OpenTelemetry console
exporter for a realtime text exchange. It also prints the SDK's payload-free connection and
session diagnostic logs. The same tracing setup applies to audio and tool interactions; it does
not require a Voice Agent-specific tracing option.

## Prerequisites

- Set `FOUNDRY_PROJECT_ENDPOINT` to your Foundry project endpoint.
- Set `FOUNDRY_REALTIME_MODEL_NAME` to a realtime-capable model deployment.
- Authenticate an identity with access to the project, such as `az login` for local development.
- Reference `Azure.AI.Projects`, `Azure.Identity`, and `OpenTelemetry.Exporter.Console`.

Use the namespaces `System`, `System.ClientModel`, `System.Diagnostics`,
`System.Diagnostics.Tracing`, `System.Threading`, `Azure.AI.Projects`, `Azure.AI.Projects.Agents`,
`Azure.Core.Diagnostics`, `Azure.Identity`, `OpenAI.Realtime`, `OpenTelemetry`,
`OpenTelemetry.Resources`, and `OpenTelemetry.Trace`. Suppress experimental diagnostics
`AAIP001`, `AAIP002`, and `OPENAI002`.

## Configure tracing and logging

Configure the existing tracing setting and provider before constructing a client. The sample
disables message-content recording; explicitly configured AppContext switches take precedence
over the environment variables shown here.

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

Optionally enable the existing Azure EventSource listener to print only Voice Agent realtime
milestones. These log messages include correlation identifiers, not event payloads.

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

Run the following code in an asynchronous method. It creates a unique temporary agent, requests
a text response, closes the session, reads and deletes the stored conversation, and deletes the
agent. It logs event types and REST statuses without printing the conversation text.

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

The console exporter prints the actual Activities with this hierarchy:

```text
voice_agent.sample.realtime
  create_agent
  voice_agents.realtime.session
    voice_agents.realtime.connect
    invoke_agent
  BetaVoiceAgentsConversations.DeleteAgentConversation
```

The realtime source is `Azure.AI.Projects.ProjectsRealtimeClient`. Session, connection, and
response Activities have `ActivityKind.Client` and share the application's trace ID.
`invoke_agent` includes response status, model, token usage when returned by the service, and
safe response/conversation identifiers, `gen_ai.agent.type=voice`, and time to the first nonempty
text or audio delta. Session spans include total input/output audio bytes and the audio
format/sample rate when reported by the service. Session lifecycle events use the
`voice_agents.session.created`, `voice_agents.session.updated`, and `voice_agents.session.update`
names.
The conversation deletion uses its existing SDK diagnostic scope rather than a new GenAI span.

Dispose each session before disposing its tracer provider so session and response Activities
are completed and exported. Updates are observed as the application consumes the receive loop.

Raw audio, credentials, authentication headers, query strings, exception messages, and close
reasons are not recorded by the realtime instrumentation. Message content requires the existing
content-recording opt-in; keep it disabled unless you intend to export potentially sensitive
content. With that opt-in, bounded input transcripts are associated with their audio items,
and tool-call message parts include names and arguments. Tool result message parts retain
OpenTelemetry's `response` field. Existing `AIProjectClientOptions.EnableDistributedTracing = false` disables Voice
Agent tracing, and the existing client logging options control diagnostic logging.

To run the repository sample, set `CLIENTMODEL_TEST_MODE=Live` and the project/model variables,
then run from the repository root:

```dotnetcli
dotnet test sdk\ai\Azure.AI.Projects\tests\Azure.AI.Projects.Tests.csproj -f net8.0 --filter "FullyQualifiedName~Sample_VoiceAgent_Telemetry&Name~VoiceAgentRealtimeTelemetryAsync"
```

This calls the real service and may incur charges. It temporarily persists a text conversation
and deletes it during cleanup. It does not implement WebRTC peer/media handling.
