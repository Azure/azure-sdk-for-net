# Azure.AI.AgentServer.Optimization Samples

## Sample list

| Sample | Description |
|---|---|
| [Sample 1: Getting Started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Optimization/samples/Sample1_GettingStarted.md) | Resolve optimization config using the client or IConfiguration, and use the resolved config to build an agent. |

## End-to-end runnable samples

For complete deployable applications that demonstrate the full optimization workflow — deploy, optimize, and serve optimized candidates:

| Sample | Description |
|---|---|
| [Procedural TravelAgent](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-procedural) | Calls `AgentOptimizationClient.ResolveOptionsAsync()` directly. |
| [DI TravelAgent](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-di) | Uses `AddOptimizationConfigSource(sectionName)` with `IConfiguration`. |
