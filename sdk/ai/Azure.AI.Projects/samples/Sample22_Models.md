# Sample of managing model weights in Azure.AI.Projects.

**Note:** Model weights is an experimental feature, to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

In this example we will demonstrate how to create, update, list and delete model weights.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_Createclient_Models
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var connectionName = Environment.GetEnvironmentVariable("STORAGE_CONNECTION_NAME");
AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
string modelName = "sample-model";
string modelVersion = "1";
```

2. Create a toy model weights and upload them to Blob store.

Synchronous sample:
```C# Snippet:Sample_UploadData_Models_Sync
DirectoryInfo dataFolder = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "sample-model"));
File.WriteAllBytes(Path.Combine(dataFolder.FullName, "weights.bin"), BinaryData.FromString("hello-foundry-model").ToArray());
File.WriteAllText(Path.Combine(dataFolder.FullName, "config.json"), "{\"sample\": true}");
Uri dataUri = projectClient.Models.UploadModel(path: dataFolder.FullName, name: modelName, version: modelVersion);
Console.WriteLine($"Created data set. Uri: {dataUri}");
Directory.Delete(dataFolder.FullName, true);
```

Asynchronous sample:
```C# Snippet:Sample_UploadData_Models_Async
DirectoryInfo dataFolder = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "sample-model"));
File.WriteAllBytes(Path.Combine(dataFolder.FullName, "weights.bin"), BinaryData.FromString("hello-foundry-model").ToArray());
File.WriteAllText(Path.Combine(dataFolder.FullName, "config.json"), "{\"sample\": true}");
Uri dataUri = await projectClient.Models.UploadModelAsync(path: dataFolder.FullName, name: modelName, version: modelVersion);
Console.WriteLine($"Created data set. Uri: {dataUri}");
Directory.Delete(dataFolder.FullName, true);
```

3. Use the uploaded BLOB URI to create new `ModelVersion` object.

Synchronous sample:
```C# Snippet:Sample_CreateModel_Models_Sync
ModelVersion modelVersionObj = new(dataUri)
{
    WeightType = FoundryModelWeightType.FullWeight,
    Description = "Sample model registered from Azure.AI.Projects",
};
modelVersionObj.Tags["source"] = "Model from sample";
CreateAsyncResponse createResponse = projectClient.Models.CreateModelVersionRequest(
    name: modelName,
    version: modelVersion,
    modelVersion: modelVersionObj);
```

Asynchronous sample:
```C# Snippet:Sample_CreateModel_Models_Async
ModelVersion modelVersionObj = new(dataUri)
{
    WeightType = FoundryModelWeightType.FullWeight,
    Description = "Sample model registered from Azure.AI.Projects",
};
modelVersionObj.Tags["source"] = "Model from sample";
CreateAsyncResponse createResponse = await projectClient.Models.CreateModelVersionRequestAsync(
    name: modelName,
    version: modelVersion,
    modelVersion: modelVersionObj);
```

4. Wait for model deployment by trying to get it for a period of time. After the model is deployed, display its name, version and SAS URI.

Synchronous sample:
```C# Snippet:Sample_GetModel_Models_Sync
DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: 5, seconds: 0);
ModelVersion retrievedModel = null;
while (DateTime.UtcNow < deadline)
{
    Thread.Sleep(500);
    try
    {
        retrievedModel = projectClient.Models.GetModelVersion(modelName, modelVersion);
        break;
    }
    catch (ClientResultException e)
    {
        if (e.Status != 404)
        {
            throw;
        }
    }
    Console.WriteLine("Waiting for model to register...");
}
if (retrievedModel is null)
{
    throw new InvalidOperationException($"The model {modelName} v. {modelVersion} did not registered successfully.");
}
Console.WriteLine($"Model {retrievedModel.Name}, v. {retrievedModel.Version}.");
ModelCredentialRequest credentialRequest = new(dataUri);
DatasetCredential modelCredential = projectClient.Models.GetModelCredentials(name: retrievedModel.Name, version: retrievedModel.Version, credentialRequest: credentialRequest);
Console.WriteLine($"Model SAS URI: {modelCredential.BlobReference.Credential.SasUri}.");
```

Asynchronous sample:
```C# Snippet:Sample_GetModel_Models_Async
DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: 5, seconds: 0);
ModelVersion retrievedModel = null;
while (DateTime.UtcNow < deadline)
{
    await Task.Delay(500);
    try
    {
        retrievedModel = await projectClient.Models.GetModelVersionAsync(modelName, modelVersion);
        break;
    }
    catch (ClientResultException e)
    {
        if (e.Status != 404)
        {
            throw;
        }
    }
    Console.WriteLine("Waiting for model to register...");
}
if (retrievedModel is null)
{
    throw new InvalidOperationException($"The model {modelName} v. {modelVersion} did not registered successfully.");
}
Console.WriteLine($"Model {retrievedModel.Name}, v. {retrievedModel.Version}.");
ModelCredentialRequest credentialRequest = new(dataUri);
DatasetCredential modelCredential = await projectClient.Models.GetModelCredentialsAsync(name: retrievedModel.Name, version: retrievedModel.Version, credentialRequest: credentialRequest);
Console.WriteLine($"Model SAS URI: {modelCredential.BlobReference.Credential.SasUri}.");
```

5. Update the model with new tags and description.

Synchronous sample:
```C# Snippet:Sample_UpdateModel_Models_Sync
UpdateModelVersionOptions updateOptions = new()
{
    Description = "Updated model description."
};
updateOptions.Tags["new_tag"] = "The tag from update";
ModelVersion updatedModel = projectClient.Models.UpdateModelVersion(
    name: retrievedModel.Name,
    version: retrievedModel.Version,
    updateOptions: updateOptions
);
Console.WriteLine($"The model was updated. New description is: {updatedModel.Description}. Tags:");
foreach (KeyValuePair<string, string> keyValyePair in updatedModel.Tags)
{
    Console.WriteLine($"    Key: {keyValyePair.Key} Value: {keyValyePair.Value}");
}
```

Asynchronous sample:
```C# Snippet:Sample_UpdateModel_Models_Async
UpdateModelVersionOptions updateOptions = new()
{
    Description = "Updated model description."
};
updateOptions.Tags["new_tag"] = "The tag from update";
ModelVersion updatedModel = await projectClient.Models.UpdateModelVersionAsync(
    name: retrievedModel.Name,
    version: retrievedModel.Version,
    updateOptions: updateOptions
);
Console.WriteLine($"The model was updated. New description is: {updatedModel.Description}. Tags:");
foreach (KeyValuePair<string, string> keyValyePair in updatedModel.Tags)
{
    Console.WriteLine($"    Key: {keyValyePair.Key} Value: {keyValyePair.Value}");
}
```

6. List all versions of the model, we have created.

Synchronous sample:
```C# Snippet:Sample_ListModelVersions_Models_Sync
CollectionResult<ModelVersion> modelVersions = projectClient.Models.GetModelVersions(name: updatedModel.Name);
List<ModelVersion> versions = [.. modelVersions];
Console.WriteLine($"For model {updatedModel.Name} there are next versions available:");
foreach (ModelVersion oneModelVersion in modelVersions)
{
    Console.WriteLine($"    {oneModelVersion.Version}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListModelVersions_Models_Async
AsyncCollectionResult<ModelVersion> modelVersions = projectClient.Models.GetModelVersionsAsync(name: updatedModel.Name);
Console.WriteLine($"For model {updatedModel.Name} there are next versions available:");
await foreach (ModelVersion oneModelVersion in modelVersions)
{
    Console.WriteLine($"    {oneModelVersion.Version}");
}
```

7. List all models in Microsoft Foundry along with their latest versions.

Synchronous sample:
```C# Snippet:Sample_ListLatestVersions_Models_Sync
CollectionResult<ModelVersion> models = projectClient.Models.GetLatestModelVersions();
foreach (ModelVersion oneModel in models)
{
    Console.WriteLine($"    {oneModel.Name}, latest version: {oneModel.Version}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListLatestVersions_Models_Async
AsyncCollectionResult<ModelVersion> models = projectClient.Models.GetLatestModelVersionsAsync();
Console.WriteLine("The next models are available in the project:");
await foreach (ModelVersion oneModel in models)
{
    Console.WriteLine($"    {oneModel.Name}, latest version: {oneModel.Version}");
}
```

8. Finally, delete `ModelVersion` we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_Models_Sync
projectClient.Models.DeleteModelVersion(name: updatedModel.Name, version: updatedModel.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_Models_Async
await projectClient.Models.DeleteModelVersionAsync(name: updatedModel.Name, version: updatedModel.Version);
```

