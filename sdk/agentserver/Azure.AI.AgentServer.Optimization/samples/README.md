# Azure.AI.AgentServer.Optimization Samples

## Sample list

| Sample | Description |
|---|---|
| [Sample 1: Getting Started](Sample1_GettingStarted.md) | Load optimization options using the priority waterfall, configure authentication, and use the loaded options to build an agent. |

## End-to-end runnable samples

For complete deployable applications that demonstrate the full optimization workflow — deploy, optimize, and serve optimized candidates:

| Sample | Description |
|---|---|
| [Procedural TravelAgent](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-procedural) | Calls `OptimizationOptionsLoader.LoadAsync()` directly. |
| [DI TravelAgent](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-di) | Uses `AddOptimizationConfigSource()` with `IConfiguration`. |
