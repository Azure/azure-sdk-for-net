# Sample for Azure.AI.Projects with AzureOpenAI chat extension.

If `Azure.AI.Openai` package is installed, the project can use AzureOpenAI extension.

Synchronous sample: 
```C# Snippet:AzureOpenAISync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(connectionString);
ChatClient chatClient = client.GetAzureOpenAIChatClient(modelDeploymentName);

ChatCompletion result = chatClient.CompleteChat("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```

Asynchronous sample:
```C# Snippet:AzureOpenAIAsync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(connectionString);
ChatClient chatClient = client.GetAzureOpenAIChatClient(modelDeploymentName);

ChatCompletion result = await chatClient.CompleteChatAsync("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```