# Trace Voice Agent REST operations

This runnable sample uses the existing Foundry GenAI tracing setting and an OpenTelemetry console
exporter for Voice Agent REST operations. It creates and retrieves an agent version, creates a new
version with updated instructions, and deletes the temporary agent.

## Prerequisites

- Set `FOUNDRY_PROJECT_ENDPOINT` to your Foundry project endpoint.
- Set `FOUNDRY_REALTIME_MODEL_NAME` to a realtime-capable model deployment.
- Authenticate an identity with access to the project, such as `az login` for local development.
- Reference `Azure.AI.Projects`, `Azure.Identity`, and `OpenTelemetry.Exporter.Console`.

Use the namespaces `System`, `System.ClientModel`, `System.Diagnostics`, `Azure.AI.Projects`,
`Azure.AI.Projects.Agents`, `Azure.Identity`, `OpenTelemetry`, `OpenTelemetry.Resources`, and
`OpenTelemetry.Trace`. Suppress experimental diagnostic `AAIP001`.

## Configure tracing

Configure the existing tracing setting and provider before constructing a client. The sample
disables message-content recording; explicitly configured AppContext switches take precedence
over the environment variables shown here. The application-owned ActivitySource supplies a
common parent for the REST calls; it is not an additional SDK configuration option.

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

Run the following code in an asynchronous method. A unique temporary agent is deleted in the
cleanup block, including when an operation inside that block fails.

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

The GenAI part of the exported trace has this hierarchy:

```text
voice_agent.sample.rest
  create_agent
  create_agent
```

The first `create_agent` span represents the initial version; the second represents the new
version with updated instructions. Both use `ActivityKind.Client` and the ActivitySource
`Azure.AI.Projects.Agents.AgentsClient`. They share the application's trace ID and have the
application workflow's span ID as their parent span ID.

Voice Agent creation metadata includes the agent kind, name, ID, version, and model when available.
These service identifiers are attributes, not replacements for OpenTelemetry trace and span IDs.
Read and delete operations retain their existing diagnostics rather than gaining new GenAI
operation names.

The enriched Voice Agent creation traces do not record HTTP request/response bodies, credentials,
authentication headers, or query strings. Instruction text is excluded with the sample's existing
content-recording setting. If content recording is explicitly enabled, up to 4096 characters of
Voice Agent instructions can be exported through `gen_ai.system_instructions`, following the
existing Foundry instruction schema and attribute/event configuration.
Other REST operations retain their existing SDK diagnostic settings and scopes.

To run the repository sample, set `CLIENTMODEL_TEST_MODE=Live` and the project/model variables,
then run from the repository root:

```dotnetcli
dotnet test sdk\ai\Azure.AI.Projects\tests\Azure.AI.Projects.Tests.csproj -f net8.0 --filter "FullyQualifiedName~Sample_VoiceAgent_Telemetry&Name~VoiceAgentRestTelemetryAsync"
```

This calls the real service and may incur charges. It does not start a realtime session or
persist a conversation.
