# Agent Framework Minimal Console Sample
This is a minimal console application that demonstrates how to use the Agent Framework library to create and run an agent with a simple task.

## Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later
- Access to github packages for nightly builds, see [FAQs](../../README.md#faqs) below.

## Getting Started
```csharp
// Create AIAgent
var agent = new AzureOpenAIClient(
        new Uri(endpoint),
        new DefaultAzureCredential())
    .GetChatClient(deploymentName)
    .CreateAIAgent();

// Run container agent adapter
await agent.RunAIAgentAsync();
```
