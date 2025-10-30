# Sample using Files in Azure.AI.Projects

This sample demonstrates how to use file operations with OpenAI Files API through the Azure AI Projects SDK. The file operations are accessed via the AgentsClient's GetOpenAIClient() method.

## Prerequisites

- Install the Azure.AI.Projects package.
- Install the Azure.AI.Agents package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

## Important Note

File upload via OpenAIClient from AgentsClient.GetOpenAIClient() is not currently supported because it doesn't set the required Content-Type header for individual multipart form parts. The sample demonstrates other file operations using pre-existing file IDs.

## Asynchronous Sample

```C# Snippet:AI_Projects_FileOperationsAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
AgentsClient agentClient = projectClient.GetAgentsClient();
OpenAIClient oaiClient = agentClient.GetOpenAIClient();
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();

string fileId = "file-abc123"; // Replace with an actual file ID from your project

// Retrieve file metadata
OpenAIFile retrievedFile = await fileClient.GetFileAsync(fileId);
Console.WriteLine($"File ID: {retrievedFile.Id}, Filename: {retrievedFile.Filename}");

// Download file content
BinaryData fileContent = await fileClient.DownloadFileAsync(fileId);
Console.WriteLine($"Content size: {fileContent.ToMemory().Length} bytes");

// List all files
ClientResult<OpenAIFileCollection> filesResult = await fileClient.GetFilesAsync();
foreach (OpenAIFile file in filesResult.Value)
{
    Console.WriteLine($"File: {file.Filename} (ID: {file.Id})");
}

// Delete file
ClientResult<FileDeletionResult> deleteResult = await fileClient.DeleteFileAsync(fileId);
Console.WriteLine($"File deleted: {deleteResult.Value.Deleted}");
```
