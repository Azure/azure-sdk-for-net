# Sample for use of an agent as IChatClient in Azure.AI.Agents.Persistent.

It's possible to use Agent as `IChatClient` abstraction from Microsoft.Extensions.AI.
1. First we need to read the environment variables and create an agent client, which will be used in the next steps.

```C# Snippet:PersistentAgentsAsIChatClient_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. We will convert `PersistentAgentsClient` to `IChatClient` by using `AsIChatClient` method.

```C# Snippet:PersistentAgentsAsIChatClient_CreateAgentAsIChatClient
PersistentAgent agent = await client.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-agent",
   instructions: "You are a helpful agent.");

PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

IChatClient chatClient = client.AsIChatClient(agent.Id, thread.Id);
```

3. We will use the `IChatClient.GetResponseAsync` method to get a response from Agent.

```C# Snippet:PersistentAgentsAsIChatClient_GetResponseAsync
ChatResponse response = await chatClient.GetResponseAsync([new ChatMessage(ChatRole.User, [new TextContent("Hello, tell me a joke")])]);

Console.WriteLine(string.Join(Environment.NewLine, response.Messages.Select(c => c.Text)));
```

4. Clean up resources by deleting thread and agent.

```C# Snippet:PersistentAgentsAsIChatClient_Cleanup
await client.Threads.DeleteThreadAsync(thread.Id);
await client.Administration.DeleteAgentAsync(agent.Id);
```
