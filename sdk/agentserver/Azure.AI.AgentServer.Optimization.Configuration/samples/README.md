---
page_type: sample
languages:
- csharp
products:
- azure
- ai
name: Azure.AI.AgentServer.Optimization.Configuration samples for .NET
description: TravelAgent sample showing DI / IConfiguration integration for optimization config loading.
---

# Azure.AI.AgentServer.Optimization.Configuration Samples

## What's here

| Sample | Description |
|---|---|
| [`TravelAgent/`](TravelAgent/) | The same Travel Agent as the [procedural sample](../Azure.AI.AgentServer.Optimization/samples/TravelAgent/), but wired through `AddOptimizationConfigSource()` and `GetOptimizationOptions()` — the DI integration provided by this Configuration package. |

## See also

- [Procedural sample](../../Azure.AI.AgentServer.Optimization/samples/TravelAgent/) — calls `OptimizationOptionsLoader.LoadAsync()` directly, no DI required.
- [Configuration package README](../README.md) — API reference for `AddOptimizationConfigSource` and `GetOptimizationOptions`.
