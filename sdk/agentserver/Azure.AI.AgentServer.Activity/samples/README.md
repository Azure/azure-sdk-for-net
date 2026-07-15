---
page_type: sample
languages:
- csharp
products:
- azure
name: Azure.AI.AgentServer.Activity samples for .NET
description: Samples for the Azure.AI.AgentServer.Activity client library.
---

# Azure.AI.AgentServer.Activity Samples

- [Getting Started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample1_GettingStarted.md) — Echo agent (the simplest handler)
- [Welcome & Commands](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample2_WelcomeAndCommands.md) — Greet new members and handle keyword commands
- [Digital Worker](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample3_DigitalWorker.md) — The blueprint + FMI outbound-auth model
- [Customize the Build](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample4_CustomizeTheBuild.md) — Override storage, connections, and services
- [Custom Request Handler](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample5_CustomRequestHandler.md) — Own the request pipeline (M365 SDK not initialized)
- [Injected Application](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample6_InjectedApplication.md) — Host a pre-built `AgentApplication`
- [M365-Native Hosting](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample7_M365NativeHosting.md) — Convert an existing M365 agent with a two-line change (`AddFoundryActivity` / `MapFoundryActivity`)

## Hosting tiers

- [Tier 1 — Customize the One-Liner](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample8_Tier1HostingCustomize.md) — `ActivityServer.Run()` with options and builder customization
- [Tier 2 — Builder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample9_Tier2HostingBuilder.md) — `AgentHost.CreateBuilder()` + `builder.AddActivity<TAgent>()`
- [Tier 3 — Self-Hosted](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample10_Tier3SelfHosting.md) — Add Activity endpoints to your own ASP.NET Core app (`AddActivityServer` / `MapActivityServer`)

## Activity scenarios

- [Adaptive Cards](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample11_AdaptiveCards.md) — Send cards and handle `Action.Submit` responses
- [Invoke Activities](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Activity/samples/Sample12_InvokeActivities.md) — Synchronous request/response (task modules, message extensions)
