# Sample of using Agent with code interpreter for file generation in Azure.AI.Extensions.OpenAI.

In this example we will demonstrate how to use Code interpreter to run the code and save the result to a file.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CodeInterpreter_File_Generation
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Create Agent, capable of using Code Interpreter to answer questions, add the instructions to save the result into PDF file.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_CodeInterpreter_File_Generation_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a personal math tutor. When asked a math question, generate the appropriate PDF, save it and return its file ID.",
    Tools = {
        ResponseTool.CreateCodeInterpreterTool(
            new CodeInterpreterToolContainer(
                CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
            )
        ),
    }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_CodeInterpreter_File_Generation_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a personal math tutor. When asked a math question, generate the appropriate PDF, save it and return its file ID.",
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

3. Now we can ask the agent a question, which requires running code. In this scenario we ask to render the Mandelbrot set and to save it on a file. If the response was not successful, we throw an exception.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_CodeInterpreter_File_Generation_Sync
AgentReference agentReference = new(name: agentVersion.Name, version: agentVersion.Version);
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference);
ResponseResult response = responseClient.CreateResponse("Please create PDF file showing the rendering of Mandelbrot set");
if (response.Status != ResponseStatus.Completed)
{
    throw new InvalidOperationException($"The response status is not successful: {response.Status.Value}");
}
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_CodeInterpreter_File_Generation_Async
AgentReference agentReference = new(name: agentVersion.Name, version: agentVersion.Version);
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference);
ResponseResult response = await responseClient.CreateResponseAsync("Please create PDF file showing the rendering of Mandelbrot set");
if (response.Status != ResponseStatus.Completed)
{
    throw new InvalidOperationException($"The response status is not successful: {response.Status.Value}");
}
Console.WriteLine(response.GetOutputText());
```

4. The resulting Items should contain the generated file ID in the `ContainerFileCitationMessageAnnotation` object. In this example we parse response items to find it. We will throw the error if the file is not generated.

```C# Snippet:Sample_GetCitation_CodeInterpreter_File_Generation
ContainerFileCitationMessageAnnotation containerAnnotation = null;
foreach (ResponseItem item in response.OutputItems)
{
    if (item is MessageResponseItem messageItem)
    {
        foreach (ResponseContentPart content in messageItem.Content)
        {
            foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
            {
                if (annotation is ContainerFileCitationMessageAnnotation cntrAnnotation)
                {
                    containerAnnotation = cntrAnnotation;
                }
            }
        }
    }
}
if (containerAnnotation is null)
{
    throw new InvalidOperationException("The file was not generated.");
}
Console.WriteLine($"Container: {containerAnnotation.ContainerId}, fileID: {containerAnnotation.FileId}");
```

5. Download the file to the current directory and write out its path.

Synchronous sample:
```C# Snippet:Sample_Download_CodeInterpreter_File_Generation_Sync
ContainerClient containerClient = projectClient.OpenAI.GetContainerClient();
BinaryData fileData = containerClient.DownloadContainerFile(containerId: containerAnnotation.ContainerId, fileId: containerAnnotation.FileId);
File.WriteAllBytes(
    path: "./results.pdf",
    bytes: fileData.ToArray()
);
Console.WriteLine($"PDF downloaded and saved to: {Path.GetFullPath("results.pdf")}");
```

Asynchronous sample:
```C# Snippet:Sample_Download_CodeInterpreter_File_Generation_Async
ContainerClient containerClient = projectClient.OpenAI.GetContainerClient();
BinaryData fileData = await containerClient.DownloadContainerFileAsync(containerId: containerAnnotation.ContainerId, fileId: containerAnnotation.FileId);
File.WriteAllBytes(
    path: "./results.pdf",
    bytes: fileData.ToArray()
);
Console.WriteLine($"PDF downloaded and saved to: {Path.GetFullPath("results.pdf")}");
```

6. Clean up resources by deleting generated file and the Agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_CodeInterpreter_File_Generation_Sync
containerClient.DeleteContainerFile(containerId: containerAnnotation.ContainerId, fileId: containerAnnotation.FileId);
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_CodeInterpreter_File_Generation_Async
await containerClient.DeleteContainerFileAsync(containerId: containerAnnotation.ContainerId, fileId: containerAnnotation.FileId);
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
