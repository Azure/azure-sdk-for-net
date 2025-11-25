# File Operations with OpenAI Files API

This sample demonstrates how to use file operations with OpenAI Files API through the Azure AI Projects SDK.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

## Create Clients

### Async

```C# Snippet:AI_Projects_Files_CreateClientsAsync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
```

### Sync

```C# Snippet:AI_Projects_Files_CreateClients
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
```

## Upload File

### Async

```C# Snippet:AI_Projects_Files_UploadFileAsync
var testFilePath = Path.Combine(dataDirectory, "sft_training_set.jsonl");
OpenAIFile uploadedFile = await fileClient.UploadFileAsync(
    BinaryData.FromBytes(File.ReadAllBytes(testFilePath)),
    "sft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
fileId = uploadedFile.Id;
```

### Sync

```C# Snippet:AI_Projects_Files_UploadFile
var testFilePath = Path.Combine(dataDirectory, "sft_training_set.jsonl");
OpenAIFile uploadedFile = fileClient.UploadFile(
    BinaryData.FromBytes(File.ReadAllBytes(testFilePath)),
    "sft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
fileId = uploadedFile.Id;
```

## Get File Metadata

### Async

```C# Snippet:AI_Projects_Files_GetFileAsync
OpenAIFile retrievedFile = await fileClient.GetFileAsync(fileId);
Console.WriteLine($"Retrieved file: {retrievedFile.Filename} ({retrievedFile.SizeInBytes} bytes)");
```

### Sync

```C# Snippet:AI_Projects_Files_GetFile
OpenAIFile retrievedFile = fileClient.GetFile(fileId);
Console.WriteLine($"Retrieved file: {retrievedFile.Filename} ({retrievedFile.SizeInBytes} bytes)");
```

## Download File Content

### Async

```C# Snippet:AI_Projects_Files_DownloadFileAsync
BinaryData fileContent = await fileClient.DownloadFileAsync(fileId);
Console.WriteLine($"Downloaded file content: {fileContent.ToMemory().Length} bytes");
```

### Sync

```C# Snippet:AI_Projects_Files_DownloadFile
BinaryData fileContent = fileClient.DownloadFile(fileId);
Console.WriteLine($"Downloaded file content: {fileContent.ToMemory().Length} bytes");
```

## List Files

### Async

```C# Snippet:AI_Projects_Files_ListFilesAsync
ClientResult<OpenAIFileCollection> filesResult = await fileClient.GetFilesAsync();
Console.WriteLine($"Listed {filesResult.Value.Count} file(s)");
```

### Sync

```C# Snippet:AI_Projects_Files_ListFiles
ClientResult<OpenAIFileCollection> filesResult = fileClient.GetFiles();
Console.WriteLine($"Listed {filesResult.Value.Count} file(s)");
```

## Delete File

### Async

```C# Snippet:AI_Projects_Files_DeleteFileAsync
ClientResult<FileDeletionResult> deleteResult = await fileClient.DeleteFileAsync(fileId);
Console.WriteLine($"Deleted file: {deleteResult.Value.FileId}");
```

### Sync

```C# Snippet:AI_Projects_Files_DeleteFile
ClientResult<FileDeletionResult> deleteResult = fileClient.DeleteFile(fileId);
Console.WriteLine($"Deleted file: {deleteResult.Value.FileId}");
```
