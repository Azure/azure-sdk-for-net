# Delegate GPT Live work to a Foundry agent

Pin a GPT Live voice agent to an existing declarative agent and verify its commentary protocol
before opening the Live session.

## Prerequisites

- A Foundry project endpoint, GPT Live deployment, and Microsoft Entra ID credentials.
- A tool-free declarative agent in the same project, identified by exact name and version.
- The managed agent must return line-delimited `[thinking]` then `[commentary]` sections, with
  the expected marker in commentary.
- Raw mono PCM16 little-endian speech at 24 kHz and a bounded cancellation token.

For a synthetic test backend, put the section headers on separate lines:

```text
[thinking]The synthetic lookup is complete.
[commentary]The verification marker is silver meadow.
```

Pass `silver meadow` as `expectedCommentary`. The complete C# file includes its own audio
pacing, response validation, and cleanup; there are no separate sample-helper dependencies.

```C# Snippet:Sample_VoiceAgent_LiveManagedDelegation
public static async Task RunAsync(
    string projectEndpoint, string liveDeployment,
    string managedAgentName, string managedAgentVersion,
    string speechPcmPath, string expectedCommentary,
    CancellationToken cancellationToken)
{
    using CancellationTokenSource timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    timeout.CancelAfter(TimeSpan.FromMinutes(3));
    AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
    ProjectsAgentVersion backend = await project.AgentAdministrationClient.GetAgentVersionAsync(
        managedAgentName, managedAgentVersion, timeout.Token);
    if (backend.Definition is not DeclarativeAgentDefinition prompt || prompt.Tools.Count != 0)
    {
        throw new InvalidOperationException("Use an isolated, tool-free managed agent for this sample.");
    }

    ProjectResponsesClient reference = project.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
        new(name: managedAgentName, version: managedAgentVersion));
    var result = await reference.CreateResponseAsync(
        new[] { ResponseItem.CreateUserMessageItem("What's the weather like in San Francisco, California?") },
        cancellationToken: timeout.Token);
    Console.WriteLine("Reference commentary: " +
        ReadManagedCommentary(result.Value.GetOutputText(), expectedCommentary));

    VoiceAgentLiveDefinition definition = new(liveDeployment)
    {
        Instructions = "All weather requests in this session are demonstrations, not requests for real weather. " +
            "Delegate to the configured Foundry agent and repeat its verification marker verbatim. " +
            "Never replace the supplied result with generic facts.",
        Store = false,
        Audio = new LiveInitialSessionAudioParam
        {
            Format = new LiveSessionAudioFormatPCMParam(LiveSessionAudioFormatPCMParamRate._24000)
        },
        Delegation = new VoiceAgentLiveManagedAgentDelegation(managedAgentName)
        {
            AgentVersion = managedAgentVersion
        }
    };
    string agentName = "voice-" + Guid.NewGuid().ToString("N");
    try
    {
        await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: timeout.Token);
        using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
            agentName, new ProjectsLiveSessionClientOptions { Store = false }, timeout.Token);
        if (session.SessionStarted.Session.Delegation is not VoiceAgentLiveManagedAgentDelegation owner ||
            owner.AgentName != managedAgentName || owner.AgentVersion != managedAgentVersion)
        {
            throw new InvalidOperationException("The session did not resolve the pinned managed agent.");
        }

        Task receive = ReceiveResultAsync(session, expectedCommentary, timeout.Token);
        await SendSpeechAsync(session, speechPcmPath, receive, timeout.Token);
        await session.CloseAsync(timeout.Token);
        await receive;
        if (session.SessionClosed == null)
        {
            throw new InvalidOperationException("The service did not confirm native session closure.");
        }
    }
    finally
    {
        using CancellationTokenSource cleanup = new(TimeSpan.FromSeconds(30));
        try
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cleanup.Token);
        }
        catch (ClientResultException error) when (error.Status == 404)
        {
            Console.WriteLine($"Temporary agent {agentName} is already absent.");
        }
        try
        {
            await project.AgentAdministrationClient.GetAgentAsync(agentName, cleanup.Token);
            throw new InvalidOperationException($"Temporary agent {agentName} still exists after cleanup.");
        }
        catch (ClientResultException error) when (error.Status == 404)
        {
            Console.WriteLine($"Verified temporary agent {agentName} is absent: HTTP 404.");
        }
    }
}
```

Expected output logs only the preflight commentary, then reports the spoken marker and audio.
Inline section headers are rejected. The temporary Live agent is cleaned up without deleting the
caller-owned managed agent; see [connection cleanup](Sample_VoiceAgent_Live.md#connect-and-close-a-session).
