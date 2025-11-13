# Sample of using Agent with code interpreter and file attachment in Azure.AI.Projects.OpenAI.

In this example we will demonstrate how to use Code interpreter to solve the equation.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_CodeInterpreter
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Create Agent, capable to use Code Interpreter to answer questions.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_CodeInterpreter_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can help fetch data from files you know about.",
    Tools = {
        ResponseTool.CreateCodeInterpreterTool(
            new CodeInterpreterToolContainer(
                CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration(
                    fileIds: []
                )
            )
        ),
    }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_CodeInterpreter_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a personal math tutor. When asked a math question, write and run code using the python tool to answer the question.",
    Tools = {
        ResponseTool.CreateCodeInterpreterTool(
            new CodeInterpreterToolContainer(
                CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
            )
        ),
    }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Now we can ask the agent a question, which requires running python code in the container.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_CodeInterpreter_Sync
OpenAIResponseClient responseClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
responseOptions.Agent = agentVersion;

ResponseItem request = ResponseItem.CreateUserMessageItem("I need to solve the equation sin(x) + x^2 = 42");
OpenAIResponse response = responseClient.CreateResponse(
    [request],
    responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_CodeInterpreter_Async
OpenAIResponseClient responseClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
responseOptions.Agent = agentVersion;

ResponseItem request = ResponseItem.CreateUserMessageItem("I need to solve the equation sin(x) + x^2 = 42");
OpenAIResponse response = await responseClient.CreateResponseAsync(
    [request],
    responseOptions);
```

5 Wait for the response, raise the exception if the request was not successful.

Synchronous sample:
```C# Snippet:Sample_WaitForResponse_CodeInterpreter_Sync
List<ResponseItem> updateItems = [request];
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    response = responseClient.GetResponse(responseId: response.Id);
}
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_WaitForResponse_CodeInterpreter_Async
List<ResponseItem> updateItems = [request];
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    response = await responseClient.GetResponseAsync(responseId: response.Id);
}
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

6. Clean up resources by deleting conversations and the Agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_CodeInterpreter_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_CodeInterpreter_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
