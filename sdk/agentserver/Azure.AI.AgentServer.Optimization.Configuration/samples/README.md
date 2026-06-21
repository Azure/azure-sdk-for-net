# Azure.AI.AgentServer.Optimization.Configuration Samples

## Sample list

| Sample | Description |
|---|---|
| [Sample 1: Getting Started](Sample1_GettingStarted.md) | Register the optimization config source with `IConfigurationBuilder`, bind options with DI, and consume them in an ASP.NET host. |

## End-to-end runnable samples

| Sample | Description |
|---|---|
| [DI TravelAgent](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-di) | Uses `AddOptimizationConfigSource()` with `IConfiguration`. |
| [Procedural TravelAgent](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-procedural) | Calls `OptimizationOptionsLoader.LoadAsync()` directly. |
