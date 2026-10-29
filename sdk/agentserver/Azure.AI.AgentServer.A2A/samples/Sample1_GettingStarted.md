# Sample 1: Getting started

Host a native A2A agent that replies to each message with an Echo response.

## Prerequisites

Install the package in an ASP.NET Core application:

```dotnetcli
dotnet add package Azure.AI.AgentServer.A2A --prerelease
```

Use the native `A2A` namespace and `Azure.AI.AgentServer.A2A` hosting namespace.

## Describe the agent

Create a native Agent Card. The interface URL must match the address clients use
to reach the server:

```C# Snippet:A2A_AgentCard
public static AgentCard CreateCard() => new()
{
    Name = "echo",
    Description = "A native A2A echo agent",
    Version = "1.0",
    SupportedInterfaces =
    [
        new AgentInterface
        {
            Url = "http://localhost:8088/a2a",
            ProtocolBinding = "JSONRPC",
            ProtocolVersion = "1.0",
        },
    ],
    Capabilities = new AgentCapabilities(),
    DefaultInputModes = ["text/plain"],
    DefaultOutputModes = ["text/plain"],
    Skills = [new AgentSkill { Id = "echo", Name = "Echo", Description = "Echoes input", Tags = ["echo"] }],
};
```

Foundry exposes the card through its public agent endpoint when deployed. The
container's card endpoint is `/a2a/.well-known/agent-card.json`.

## Implement the handler

`IAgentHandler` receives the native request context and response event queue:

```C# Snippet:A2A_EchoAgent
public class EchoAgent : IAgentHandler
{
    public async Task ExecuteAsync(
        global::A2A.RequestContext context,
        AgentEventQueue eventQueue,
        CancellationToken cancellationToken)
    {
        await new MessageResponder(eventQueue, context.ContextId)
            .ReplyAsync($"Echo: {context.UserText}", cancellationToken: cancellationToken);
    }
}
```

The handler is a singleton. Keep request-specific state in local variables and
ensure injected services support concurrent requests.

## Start the server

```C# Snippet:A2A_Run
A2AAgentServer.Run<EchoAgent>(CreateCard());
```

The Core host listens on port 8088 by default. Set `PORT` to change it, and
update the card URL accordingly.

## Send a message

With the server running, send a native v1.0 JSON-RPC request:

```powershell
$body = @{
    jsonrpc = "2.0"
    id = "echo-1"
    method = "SendMessage"
    params = @{
        message = @{
            messageId = "message-1"
            role = "ROLE_USER"
            parts = @(@{ text = "Hello, agent!" })
        }
    }
} | ConvertTo-Json -Depth 10

$response = Invoke-RestMethod -Uri "http://localhost:8088/a2a" `
    -Method Post -ContentType "application/json" -Body $body
$response.result.message.parts[0].text
```

Expected output: `Echo: Hello, agent!`.

This handler returns a message, not a stored Task. Use
[tasks and artifacts](Sample2_TasksAndArtifacts.md) when clients need task status
or artifact retrieval.
