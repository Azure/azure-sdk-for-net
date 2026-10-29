---
page_type: sample
languages:
- csharp
products:
- azure
name: Azure.AI.AgentServer.A2A samples for .NET
description: Samples for hosting native A2A agents with Azure.AI.AgentServer.A2A.
---

# Azure AI Agent Server A2A samples

These samples use native A2A v1.0 handlers, messages, tasks, and artifacts.
Start with the message-only Echo agent, then choose the task or hosting scenario
your application needs.

## Protocol scenarios

1. [Getting started](Sample1_GettingStarted.md) - Native Agent Card, Echo handler, and JSON-RPC requests.
2. [Tasks and artifacts](Sample2_TasksAndArtifacts.md) - Task lifecycle, artifact output, and `GetTask`.
3. [Multi-turn](Sample3_MultiTurn.md) - Request clarification and continue the same Task.
4. [Long-running tasks](Sample4_LongRunningTasks.md) - Return immediately, process work, and poll for completion.

## Customization

5. [Customize the build](Sample5_CustomizeTheBuild.md) - Inject application dependencies, select storage, and configure native options.
6. [Existing request handler](Sample6_ExistingRequestHandler.md) - Preserve a preconstructed native handler and its storage.
7. [Native A2A hosting](Sample7_NativeA2AHosting.md) - Add Foundry hosting to an existing native ASP.NET Core application.

## Hosting tiers

8. [Tier 1 hosting customization](Sample8_Tier1HostingCustomize.md) - Configure the one-call server.
9. [Tier 2 host builder](Sample9_Tier2HostingBuilder.md) - Configure the Core builder and compose protocols.
10. [Tier 3 self-hosting](Sample10_Tier3SelfHosting.md) - Own the ASP.NET Core host and middleware pipeline.

## Storage

11. [Task persistence](Sample11_TaskPersistence.md) - Configure retention and retrieve stored snapshots after host reconstruction.

## Running the samples

Create an ASP.NET Core application and install the package:

```dotnetcli
dotnet new web -n A2ASample
cd A2ASample
dotnet add package Azure.AI.AgentServer.A2A --prerelease
```

Use the namespaces identified on each page. `CreateCard`, `EchoAgent`, and
`TaskAgent` are defined in the first two samples and reused where indicated.
Each page's C# snippets are compiled from the package's test sources, and the
sample handlers and hosting paths are exercised through HTTP tests.

The examples use the native in-memory store unless persistence is explicitly
configured. Neither a background Task nor a persisted snapshot implies recovery
of interrupted execution.
