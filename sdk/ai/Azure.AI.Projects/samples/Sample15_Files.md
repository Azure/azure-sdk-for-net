# File Operations with OpenAI Files API

This sample demonstrates how to use file operations with OpenAI Files API through the Azure AI Projects SDK. The file operations are accessed via the ProjectOpenAIClient GetOpenAIClient method.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `TRAINING_FILE_PATH` : the file with training data.


## Create Clients

### Async

```C# Snippet:AI_Projects_Files_CreateClientsAsync
string trainFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
```

### Sync

```C# Snippet:AI_Projects_Files_CreateClients
string trainFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
```

## Upload File

The `UploadFile` method uploads a file to the OpenAI Files API. This method returns an `OpenAIFile` object containing the file ID and `Status`, which indicates whether the file was successfully uploaded to the cloud. The `FileUploadPurpose` parameter specifies how the file will be used (e.g., `FineTune` for training data).

### Async

```C# Snippet:AI_Projects_Files_UploadFileAsync
using FileStream fileStream = File.OpenRead(trainFilePath);
OpenAIFile uploadedFile = await fileClient.UploadFileAsync(
    fileStream,
    "sft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
```

### Sync

```C# Snippet:AI_Projects_Files_UploadFile
using FileStream fileStream = File.OpenRead(trainFilePath);
OpenAIFile uploadedFile = fileClient.UploadFile(
    fileStream,
    "sft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
```

## Get File Metadata

The `GetFile` method retrieves metadata about an uploaded file, including its filename, size, status, and creation timestamp. This is useful for checking the processing status of uploaded files before using them in fine-tuning jobs.

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

The `DownloadFile` method downloads the content of an uploaded file as `BinaryData`. This can be used to retrieve and verify the contents of files stored in the OpenAI Files API.

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

The `GetFiles` method returns a collection of all files that have been uploaded to the OpenAI Files API. This is useful for managing and auditing your uploaded files.

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

The `DeleteFile` method removes an uploaded file from the OpenAI Files API. It's good practice to clean up files after fine-tuning jobs complete to manage storage and costs.

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
