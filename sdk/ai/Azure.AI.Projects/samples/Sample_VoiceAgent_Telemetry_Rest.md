# Trace Voice Agent REST operations

Trace Voice Agent REST operations with OpenTelemetry and print the traces to the console.
The example creates and reads an agent version, creates a new version with updated instructions,
and deletes the temporary agent.

## Prerequisites

- Follow the [Realtime prerequisites and authentication guidance](Sample_VoiceAgent.md#prerequisites).
- Also reference `OpenTelemetry.Exporter.Console`.

The [complete sample](../tests/Samples/VoiceAgent/Sample_VoiceAgent_Telemetry.cs) includes the
required imports and setup.

## Configure tracing

Enable tracing before creating the client. Keep message-content recording disabled to avoid
exporting instructions. If your application sets the corresponding `AppContext` switches,
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

## Create, retrieve, update, and delete a Voice Agent

Run this code in an asynchronous method. Updating instructions creates a new agent version;
the cleanup block deletes the temporary agent even if an operation fails.

```C# Snippet:Sample_VoiceAgent_Telemetry_Rest
string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
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
```

## Inspect correlation and privacy

The exported GenAI spans share one application trace:

```text
voice_agent.sample.rest
  create_agent
  create_agent
```

The two `create_agent` spans represent the initial and updated versions. They are client spans
from `Azure.AI.Projects.Agents.AgentsClient` and include the agent kind, name, ID, version, and
model when available. Reads and deletes keep their normal SDK diagnostics.

Voice Agent creation traces do not capture request/response bodies, credentials, authentication
headers, or query strings. If you enable content recording, up to 4096 characters of instructions
can be exported through `gen_ai.system_instructions`. Instructions may contain sensitive data.
Other REST calls follow their existing SDK diagnostic settings.

## Run the repository sample

Set `CLIENTMODEL_TEST_MODE=Live`, then run from the repository root:

```dotnetcli
dotnet test sdk\ai\Azure.AI.Projects\tests\Azure.AI.Projects.Tests.csproj -f net8.0 --filter "FullyQualifiedName~Sample_VoiceAgent_Telemetry&Name~VoiceAgentRestTelemetryAsync"
```

This calls the real service and may incur charges. It does not start a realtime session or
persist a conversation.
